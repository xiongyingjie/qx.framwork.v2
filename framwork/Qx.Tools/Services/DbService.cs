using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Qx.Tools.Models.Db;

namespace Qx.Tools.Services
{
    public class DbService<T> : IDbService<T>
    {
        private readonly string _connString;

        private readonly string _insertSql;
        private readonly string _updateSql;
        private readonly string _deleteSql;

        private readonly string _insertRollBackSql;
        private readonly string _updateRollBackSql;
        private readonly string _deleteRollBackSql;

        private readonly string _querySql;
        private readonly string _findSql;

        private readonly Table _table;
        //private readonly ExcuteResult _result;
        public IDbService<T> Init(Enum table,string connString)
        {
            return new DbService<T>(table.ToString(), connString);
        }
        public IDbService<T> Get(Enum table)
        {
            return new DbService<T>(table.ToString(), typeof(T).Name.Replace("_","."));//处理特殊符号
        }
        public DbService()
        {
        }
        public DbService(string tableName, string connString)
        {//构造函数只生成脚本模板
            //获取连接
            if (!(connString.Contains("database") || connString.Contains("Source=")))
            { connString = ConfigurationManager.ConnectionStrings[connString.TrimString()].ConnectionString; }
            _connString = connString;
         
            _table = new Table(tableName, connString);
            //所有列
            var insertValueList = _table.ColumnNames.Select(a => "'#" + a + "'").ToList();
            var updateNameList = _table.ColumnNames.Select(a => a + "='#" + a+"'").ToList();
            _deleteRollBackSql=
            _insertSql = string.Format("insert into {0} ({1}) VALUES ({2})", tableName, _table.ColumnNames.PackString(','), insertValueList.PackString(','));
            _insertRollBackSql = 
            _deleteSql = string.Format("delete from {0} where {1} = '#{1}'", tableName, _table.PrimaryKey);
            _updateSql =
            _updateRollBackSql=string.Format("UPDATE {0} SET {1} WHERE {2} = '#{2}'", tableName, updateNameList.PackString(','), _table.PrimaryKey);
            _querySql = string.Format("select {0} from {1}", _table.ColumnNamesWithTableName.PackString(','), tableName);
            _findSql = string.Format("{0} where {1} = '#{1}'", _querySql, _table.PrimaryKey);
            
        }

        #region 写入
        public ExcuteResult Add(Dictionary<string, object> paramDictionary)
        {//失败时返回""
            var result = new ExcuteResult(Operate.Add, _connString,_table.Name);
            var primaryKeyValue = paramDictionary[_table.PrimaryKey]+"";
            var old = Find(primaryKeyValue);
            if (old.HasData)
            {//存在旧记录
                result.AddMessage("添加失败(已存在ID=" + primaryKeyValue + "的记录)");
                result.Successful = false;
            }
            else
            {
                result.RollBackScript = ToFinalSql(_insertRollBackSql, primaryKeyValue);
                var ex = Excute(_insertSql, paramDictionary);
                if (!ex.HasValue())
                {
                    result.AddMessage("添加成功");
                    result.Successful = true;
                    result.Value = paramDictionary[_table.PrimaryKey];
                }
                else
                {
                    result.AddMessage("添加失败=>"+ ex);
                    result.RollBackScript = "";//添加失败不需要回滚
                    result.Successful = false;
                }
            }
            return result;
        }
        public ExcuteResult Update(Dictionary<string, object> paramDictionary)
        {
            var result = new ExcuteResult(Operate.Update, _connString,_table.Name);
            var old = Find(paramDictionary[_table.PrimaryKey]+"");
            if (old.HasData)
            {
                result.RollBackScript = ToFinalSql(_updateRollBackSql, paramDictionary);
                var ex = Excute(_updateSql, paramDictionary);
                if (!ex.HasValue())
                {
                    result.AddMessage("更新成功");
                    result.Successful = true;
                }
                else
                {
                    result.AddMessage("更新失败=>" + ex);
                    result.RollBackScript = "";//更新失败不需要回滚
                    result.Successful = false;
                }
            }
            else
            {//无旧记录-执行全新添加
                var temp = Add(paramDictionary);
                if (temp.Successful)
                {
                    result.AddMessage("更新成功(全新添加)");
                    result.Successful = true;
                    result.RollBackScript = temp.RollBackScript;
                }
                else
                {
                    result.AddMessage("更新失败(全新添加)");
                    result.AddMessages(temp.Messages);
                    //此种情况无需回滚-更新时不存在旧记录且尝试添加旧记录失败
                    result.RollBackScript = "";//清空回滚脚本
                    result.Successful = false;
                }
            }
            return result;
        }
        public ExcuteResult Delete(string id)
        {
            var result = new ExcuteResult(Operate.Delete, _connString,_table.Name);
            var old = Find(id);
            if (old.HasData)
            {
                var paramDictionary = ReflectionUtility.GetObjDic(((string)old.Value).ToObject());
                result.RollBackScript = ToFinalSql(_deleteRollBackSql, paramDictionary);
                if (Excute(_deleteSql, id) > 0)
                {
                    result.AddMessage("删除成功(id=" + id + ")");
                    result.Successful = true;
                }
                else
                {
                    result.AddMessage("删除失败(id=" + id + ")");
                    result.RollBackScript = ""; //删除失败时不需要回滚
                    result.Successful = false;
                }
            }
            else
            {//无旧记录
                result.AddMessage("删除成功(未找到id=" + id + "的旧记录)");
                result.Successful = true;
            }
            return result;
        }
        #endregion

        #region 读取
        public ExcuteResult ToSelectItems(string name = "", string value = "")
        {
            var result = new ExcuteResult(Operate.Items, _connString,_table.Name);
            var items = new List<SelectListItem>();
            if (!name.HasValue() || !_table.ColumnNames.Contains(name))
            {//智能匹配
                name = _table.ColumnNames.FirstOrDefault(a => a.ToLower().Contains("name"));
                if (!name.HasValue())
                {
                    name = _table.PrimaryKey;
                }
            }
            var sql = string.Format("select {0},{1} from {2}", _table.PrimaryKey, name, _table.Name);
            var temp =
                sql.ExecuteReader2(_connString)
                    .Select(a => new SelectListItem() {Value = a[0], Text = a[1], Selected = value == a[0]})
                    .ToList();
            if (temp.Any())
            {
                result.Value = temp.Serialize();
                result.HasData = true;
            }
            return result;
      
        }
        public ExcuteResult Info()
        {
            var result = new ExcuteResult(Operate.Info, _connString,_table.Name);
            var temp = _table.ColumnItems;
            if (temp.Any())
            {
                result.Value = temp.Serialize();
                result.HasData = true;
            }
            return result;
        }
        public ExcuteResult All()
        {
            var result = new ExcuteResult(Operate.List, _connString,_table.Name);
            var temp=_querySql.ExecuteReader2(_connString);
            var json = ToJson(temp);
            if (temp.Any())
            {
                result.Value = json;
                result.HasData = true;
            }
           return result;
        }

    

        public ExcuteResult All(Dictionary<string, string> searchCondition)
        {
            var result = new ExcuteResult(Operate.List, _connString,_table.Name);
            var sql = _querySql;
            var sqlFrom = "";
            var sqlWhere = "";
           var anotherTables=new List<Table>();
            if (searchCondition != null)
            {
                foreach (string key in searchCondition.Keys)
                {
                    //取出运算符
                    var cmd = key.Split(':');  
                    var value = searchCondition[key];
                    switch (cmd[0].ToLower())
                    {
                        case "join":
                        case "jn":
                            {//join[0]: //team_mem[0].team_mem_id[1]=team_mem_id
                                var param = cmd[1].Split('.');
                                var anotherTable = new Table(param[0],_connString);
                                anotherTables.Add(anotherTable);
                                if (!value.Contains("."))
                                {//自动加前缀
                                    value =_table.Name + "." + value;
                                }
                                sqlFrom += string.Format(" join {0} on {1} = {2} ", anotherTable.Name, cmd[1], value);
                                sql = sql.Replace("select",
                                    "select " + anotherTable.ColumnNamesWithTableName.PackString(',') + ",");
                                  }
                            break;
                        case "in":
                            {//equal[0]:user_id[1]=999[2] 
                                var op = " in ";
                                if (!cmd[1].Contains("."))
                                {
                                    cmd[1] = _table.Name + "." + cmd[1];
                                }
                                sqlWhere +=cmd[1] + op + "'" + value + "' and ";// sqlWhere += (_table.ColumnNames.Contains(cmd[1]) ? (cmd[1] + op + "(" + value + ") and ") : "");
                            }
                            break;
                        case "equal":
                        case "eq":
                            {//equal:user_id=_uid 
                                if (!cmd[1].Contains("."))
                                {
                                    cmd[1] = _table.Name + "." + cmd[1];
                                }
                                var op = " = ";
                                sqlWhere +=  cmd[1] + op + "'" + value + "' and ";
                            }
                            break;
                        case "notequal":
                        case "neq":
                            {//equal:user_id=_uid 
                                if (!cmd[1].Contains("."))
                                {
                                    cmd[1] = _table.Name + "." + cmd[1];
                                }
                                var op = " != ";
                                sqlWhere += cmd[1] + op + "'" + value + "' and ";
                            }
                            break;
                        case "biger": case "bg":
                            {//equal:user_id=_uid 
                                if (!cmd[1].Contains("."))
                                {
                                    cmd[1] = _table.Name + "." + cmd[1];
                                }
                                var op = " > ";
                                sqlWhere +=  cmd[1] + op + "'" + value + "' and ";// sqlWhere += (_table.ColumnNames.Contains(cmd[1]) ? (cmd[1] + op + "(" + value + ") and ") : "");
                            }
                            break;
                        case "less": case "ls":
                            {//equal:user_id=_uid 
                                if (!cmd[1].Contains("."))
                                {
                                    cmd[1] = _table.Name + "." + cmd[1];
                                }
                                var op = " < ";
                                sqlWhere += cmd[1] + op + "'" + value + "' and ";// sqlWhere += (_table.ColumnNames.Contains(cmd[1]) ? (cmd[1] + op + "(" + value + ") and ") : "");

                            }
                            break; 
                    }
                }
                if (sqlWhere.Any())
                {
                    sqlWhere = " where " + sqlWhere.Substring(0, sqlWhere.Length - 4);
                }
            }
           
            sql += sqlFrom + sqlWhere;
            var temp = sql.ExecuteReader2(_connString);
            result.HasData = temp.Any();
            result.Value = ToJson(temp, anotherTables);
            return result;
        }
        public ExcuteResult Find(string id)
        {//返回的value是json字符串
            var result = new ExcuteResult(Operate.Find, _connString,_table.Name);
            var script = ToFinalSql(_findSql, id);
            var temp = script.ExecuteReader2(_connString);
            if (temp.Any())
            {
                var json = ToJson(temp);
                result.Value = json.Substring(1, json.Length - 2);//清除最外层的[]
                result.HasData = true;
            }         
            return result;
        }
        public ExcuteResult Download(string id,string fileColumnName)
        {
            var result = new ExcuteResult(Operate.Download, _connString,_table.Name);
            var old = Find(id).Value.ToObject();
            old.name = fileColumnName;
            result.Value = old;
            return result;
        }
        #endregion
        public Table TableInfo
        {
            get
            {
                return _table;
            }
        }

        #region private
        private string Excute(string sql, Dictionary<string, object> paramDictionary)
        {//执行成功返回空字符串，否则为错误信息
            try
            {
                return ToFinalSql(sql, paramDictionary).ExecuteNonQuery(_connString)>0?"":"受影响的行数为0";
            }
            catch (Exception ex)
            {
              
                return ex.Message;
                //result.AddMessage("捕获删除异常:" + ex.Message);
                //result.Successful = false;
            }
        }
        /// <summary>
        /// 转换脚本
        /// </summary>
        /// <param name="sql">sql模板</param>
        /// <param name="paramDictionary">参数字典</param>
        /// <returns>最终脚本</returns>
        private string ToFinalSql(string sql, Dictionary<string, object> paramDictionary)
        {//针对insert,update  
            var script = sql + "";
            foreach (var name in _table.ColumnNames)
            {
                var value = paramDictionary.ContainsKey(name) ? paramDictionary[name]+"" : "";
                script = script.Replace("#" + name, value);
            }
            return script;
        }
        /// <summary>
        /// 转换脚本
        /// </summary>
        /// <param name="sql">sql模板</param>
        /// <param name="id">参数：id</param>
        /// <returns>最终脚本</returns>
        private string ToFinalSql(string sql, string id)
        {//针对delete
            var script = sql + "";
            //只需要替换PrimaryKey
            script = script.Replace("#" + _table.PrimaryKey, id);
            return script;
        }
        private int Excute(string sql, string id)
        {
            try
            {
                return ToFinalSql(sql, id).ExecuteNonQuery(_connString);
            }
            catch (Exception ex)
            {
                return -1;
                //result.AddMessage("捕获删除异常:" + ex.Message);
                //result.Successful = false;
            }
       
        }
        //private string Query(string sql, string id)
        //{//单条
        //    var script = ToFinalSql(sql, id);
        //    var jsonData = ToJson(sql.ExecuteReader2(_connString));
        //    return jsonData=="[]"?"{}":jsonData.Substring(1, jsonData.Length-2);
        //}
        private string ToJson(List<List<string>> dataList)
        {
            //格式转换
            var json = "[";
            for (var i = 0; i < dataList.Count; i++)
            {
                json += _table.GetJson(dataList[i]) + (i == dataList.Count - 1 ? "" : ",");
            }
            json += "]";
            return json;
        }
        private string ToJson(List<List<string>> dataList, Table anotherTable)
        {
            if (anotherTable == null) return ToJson(dataList);
            var count = anotherTable.Columns.Count;
            //格式转换
            var json = "[";
            for (var i = 0; i < dataList.Count; i++)
            {
                var json1 = _table.GetJson(dataList[i].Grap(count, dataList[i].Count));
                var json2 = anotherTable.GetJson(dataList[i].Grap(0, count-1));
                json += json1.Substring(0, json1.Length - 1) +","+ json2.Substring(1, json2.Length - 1) + (i == dataList.Count - 1 ? "" : ",");
            }
            json += "]";
            return json;
        }
        private string ToJson(List<List<string>> dataList, List<Table> anotherTables)
        {
          
            var json = "[";
            for (var i = 0; i < dataList.Count; i++)
            {
                var jsons = new List<string>();
                var startIndex = 0;
                for (var j = anotherTables.Count-1; j >=0 ; j--)
                {
                    var anotherTable = anotherTables[j];
                    jsons.Add(anotherTable.GetJson(dataList[i].Grap(startIndex, startIndex+ anotherTable.Columns.Count-1)));
                    startIndex += anotherTable.Columns.Count;
                }
                jsons.Add(_table.GetJson(dataList[i].Grap(startIndex, dataList[i].Count - 1)));
                #region 拼接单行json
                if (jsons.Count == 1)
                {
                    json += jsons[0];
                }
                else
                {
                    for (var j = 0; j < jsons.Count; j++)
                    {
                        var current = jsons[j];
                        if (j == 0)
                        {//第一个
                            json += current.Substring(0, current.Length - 1) + ",";
                        }
                        else if (j == jsons.Count - 1)
                        {//最后一个
                            json += current.Substring(1, current.Length - 1);
                        }
                        else
                        {
                            var t = current.Substring(1, current.Length - 2);
                            if (t.Any())
                            {
                                json += t + ",";
                            }
                        }

                    }
                }
                #endregion
                //最后的最后一个
                json += (i == dataList.Count - 1) ? "" : ",";
            }
            json += "]";
            return json;
        }
        #endregion
    }

}
