using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Tools.CommonExtendMethods;
using System.Configuration;
using System.Data.SqlClient;
using CodeTool.Models;
using Qx.Tools.Annotations;
using Qx.Tools.Models;

namespace CodeTool.Extension
{
   public static class ModelExtension
    {

       
       public static bool Contains(this List<TableModel> list,string tableName)
       {
           return list.Any(a=>a.TableName== tableName);
       }
        public static List<TableModel> Add(this List<TableModel> list, string tableName, string pkName)
        {
            list.Add(new TableModel() {TableName = tableName, PkName = pkName });
            return list;
        }
        public static List<TableModel> AddIfNotExsit(this List<TableModel> list, string tableName, string pkName)
        {
            if (!list.Contains(tableName))
            {
                list.Add(tableName, pkName);
            }
            return list;
        }

        public static bool Contains(this List<TableRelationModel> list, string tableName,string columName, 
            string foreginTableName, string foreginColumName)
        {
            return list.Any(a => a.TableName == tableName&&a.ColumName==columName&&
            a.ForeginTableName==foreginTableName&&a.ForeginColumName==foreginColumName);
        }
        public static List<TableRelationModel> Add(this List<TableRelationModel> list, string tableName, string columName, string columNote,
            string foreginTableName, string foreginColumName)
        {
            list.Add(new TableRelationModel() { TableName = tableName ,ColumName = columName,
                ColumNote = columNote,
                ForeginTableName = foreginTableName,ForeginColumName = foreginColumName
            });
            return list;
        }
        public static List<TableRelationModel> AddIfNotExsit(this List<TableRelationModel> list, string tableName, 
            string columName, string columNote,
            string foreginTableName, string foreginColumName)
        {
            if (!list.Contains(tableName, columName,foreginTableName, foreginColumName))
            {
                list.Add(tableName, columName, columNote, foreginTableName, foreginColumName);
            }
            return list;
        }
        public static List<TableModel> GetTables(this List<TableRelationModel> list)
        {
            var tables= list.Select(a => new TableModel() {TableName = a.TableName});
            var foreginables = list.Select(a => new TableModel() { TableName = a.ForeginTableName });
            return  tables.Union(foreginables,
                Qx.Tools.Equality<TableModel>.
                CreateComparer(x => x.TableName)).
                ToList();
        }

       public static List<FormControlType> GetAllControlType(this FormControlType src)
       {
           return Enum.GetNames(typeof (FormControlType)).Select(a=>a.ToControlType()).ToList();
       }

        public static FormControlType ToControlType(this string src)
        {
            FormControlType type;
            FormControlType.TryParse(src, out type);
            return type;
        }

        public static List<string> GetAllQueryType(this QueryTypeEnum src)
        {
            return Enum.GetNames(typeof(QueryTypeEnum)).ToList();
        }

        public static QueryTypeEnum ToQueryType(this string src)
        {
            QueryTypeEnum type;
            QueryTypeEnum.TryParse(src, out type);
            return type;
        }
    }
}
