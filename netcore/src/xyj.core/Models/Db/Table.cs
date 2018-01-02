using System;
using System.Collections.Generic;
using System.Linq;
using xyj.core.Extensions;
using xyj.core.Scripts;

namespace xyj.core.Models.Db
{
    public class Table
    {
        public Table(string tableName, string connString)
        {
            Columns = Sql.SQL_TABLECOLUMN(tableName).ExecuteReader2(connString).
                Select(a => new TableColumn(a)).ToList();
            ColumnNames = Columns.Select(a => a.ColumName).ToList();
            ColumnNamesWithTableName = Columns.Select(a => tableName+"."+ a.ColumName).ToList();
            var pk = Columns.FirstOrDefault(a => a.IsPrimaryKey);
            if (pk == null)
            {
                throw new Exception("没有给" + tableName + "设置主键");
            }
            PrimaryKey = pk.ColumName;
            Name = tableName;
            ConnString = connString;
        }
        public readonly string ConnString;
        public readonly string Name;
        public readonly string PrimaryKey;
        // public readonly string ForeignKey;
        public string ColumnItems
        {
            get { return Columns.Select(a => new {Text = a.ColumNote, Value = a.ColumName}).Serialize(); }
        }
        public readonly List<TableColumn> Columns;
        public readonly List<string> ColumnNames;
        public readonly List<string> ColumnNamesWithTableName;
        public string GetJson(List<string> data)
        {
            var json = "{";
            for (var i = 0; i < data.Count; i++)
            {
                json +="\""+ ColumnNames[i] + "\":\"" + data[i]+ "\""+ 
                    ",\"" + Name+"-"+ColumnNames[i] + "\":\"" + data[i] + "\""//兼容表前缀
                    + (i==data.Count-1?"":",");
            }
            json += "}";
            return json;
        }
        public string GetJson(List<string> data,List<string> diyHeaders)
        {
            var json = "{";
            for (var i = 0; i < data.Count; i++)
            {
                json += "\"" + diyHeaders[i].Replace(".","-") + "\":\"" + data[i] + "\"" +
                    (i == data.Count - 1 ? "" : ",");
            }
            json += "}";
            return json;
        }
    }
}