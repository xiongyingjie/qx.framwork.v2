using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Report.Scripts;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
namespace Qx.Report.Services
{
    public class TableColumn
    {
        public TableColumn(List<string> item)
        {
            GUID = item[0];
            ColumName = item[1];
            ColumNote = item[2];
            TableName = item[3];
            IsPrimaryKey = bool.Parse(item[5]);
            Type = item[6]; ;
            Length = item[7]; ;
            CanNull = bool.Parse(item[8]);

        }
        public string GUID { get; set; }
        public string TableName { get; set; }
        public string Type { get; set; }
        public string Length { get; set; }
        public bool CanNull { get; set; }
        public string DefaultValue { get; set; }
        public string ForeignKey { get; set; }
        public string ForeignTable { get; set; }
        public string ColumName { get; set; }
        public bool IsPrimaryKey { get; set; }

        public string ColumNote { get; set; }
    }
    public class Table
    {
        public Table(string tableName, string connString)
        {
            Columns = Sql.SQL_TABLECOLUMN(tableName).ExecuteReader2(connString).
                Select(a => new TableColumn(a)).ToList();
            ColumnNames = Columns.Select(a => a.ColumName).ToList();
            var pk = Columns.FirstOrDefault(a => a.IsPrimaryKey);
            if (pk == null)
            {
                throw new Exception("没有给" + tableName + "设置主键");
            }
            PrimaryKey = pk.ColumName;     
        }

        public readonly string PrimaryKey;
       // public readonly string ForeignKey;
        public readonly List<TableColumn> Columns;
        public readonly List<string> ColumnNames;
        public string GetJson(List<string> data)
        {
            var json = "{";
            for (var i = 0; i < data.Count; i++)
            {
                json +="\""+ ColumnNames[i] + "\":\"" + data[i]+ "\""+(i==data.Count-1?"":",");
            }
            json += "}";
            return json;
        }
    }
    public class Repository
    {
        private readonly string _connString;
        private readonly string _insertSql;
        private readonly string _updateSql;
        private readonly string _deleteSql;
        private readonly string _querySql;
        private readonly string _findSql;
        private readonly Table _table;
        public Repository(string tableName, string connString
            )
        {
            //获取连接
            if (!(connString.Contains("database") || connString.Contains("Source=")))
            { connString = ConfigurationManager.ConnectionStrings[connString].ConnectionString;}
            _connString = connString;
          
            _table = new Table(tableName, connString);
            //所有列
            var insertValueList = _table.ColumnNames.Select(a => "'#" + a + "'").ToList();
            var updateNameList = _table.ColumnNames.Select(a => a + "=#" + a).ToList();
            _insertSql = "insert into " + tableName + " (" + _table.ColumnNames.PackString(',') + ") VALUES (" + insertValueList.PackString(',') + ")";
            _deleteSql = "delete from " + tableName + " where " + _table.PrimaryKey + " = '#" + _table.PrimaryKey + "'";
             _updateSql = "UPDATE " + tableName + " SET " + updateNameList.PackString(',') + " WHERE " + _table.PrimaryKey + " = '#" + _table.PrimaryKey + "'";
            _querySql = "select " + _table.ColumnNames.PackString(',') + " from " + tableName;
            _findSql = _querySql + " where " + _table.PrimaryKey + " = '#" + _table.PrimaryKey + "'";
            
        }

        public string Insert(object paramObject)
        {
            var paramDictionary = ReflectionUtility.GetObjDic(paramObject);
            var old = Find(paramDictionary[_table.PrimaryKey]);
            if (old != null)
                return "";
           return Excute(_insertSql, paramObject) > 0? paramDictionary[_table.PrimaryKey]:"";
        }

        private int Excute(string sql, object paramObject,out Dictionary<string, string>  paramDictionary)
        {
            var script = sql + "";
            paramDictionary = ReflectionUtility.GetObjDic(paramObject);
            foreach (var name in _table.ColumnNames)
            {
                var value = paramDictionary.ContainsKey(name) ? paramDictionary[name] : "";
                script = script.Replace("#" + name, value);
            }
            return script.ExecuteNonQuery(_connString);

         
        }
        private int Excute(string sql, object paramObject)
        {
            Dictionary<string, string> paramDictionary;
            return Excute(sql, paramObject, out paramDictionary);
        }
        private int Excute(string sql, string id)
        {
            var script = sql + "";
            //只需要替换PrimaryKey
            script = script.Replace("#" + _table.PrimaryKey, id);
            return script.ExecuteNonQuery(_connString);
        }
        private string Query(string sql, string id)
        {
            var script = sql + "";
            //只需要替换PrimaryKey
            script = script.Replace("#" + _table.PrimaryKey, id);
            return Query(script);
        }
        private string Query(string sql)
        {
            var result = sql.ExecuteReader2(_connString);
            //格式转换
            var json = "[";
            for (var i = 0; i < result.Count; i++)
            {
                json += _table.GetJson(result[i]) + (i == result.Count - 1 ? "" : ",");
            }
            json += "]";
            return json;
        }
        public bool Update(object paramObject)
        {
            return Excute(_updateSql, paramObject) > 0;
        }
        public bool Delete(string id)
        {
            return Excute(_deleteSql, id) > 0;
        }
        public string Query()
        {  
            var result = Query(_querySql);
            return result;
        }
        public string Find(string id)
        {
            var result = Query(_findSql,id);
            return result;
        }
        public Table TableInfo
        {
            get
            {
                return _table;
            }
        }

    

    }
   public class RepositoryService
    {
    
}
}
