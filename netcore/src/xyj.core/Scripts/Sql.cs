using System.Collections.Generic;
using xyj.core.Extensions;

namespace xyj.core.Scripts
{
  public static  class Sql
    {
        public static string SQL_REPORTS(string reportId = "", string reportName = "")
        {
            return string.Format(@"SELECT [ReportID]
      ,[ReportName]
      ,[SqlStr]
      ,[HeadFields]
      ,[RecordsPerPage]
      ,[ParaNames]
      ,[ColunmToShow]
      ,[OperateColum]
      ,[ReportLog]
         FROM [report_data]
        WHERE [ReportID] LIKE '{0}' OR [ReportName] LIKE '{1}'", reportId.HasValue() ? "%" + reportId + "%" : "", reportName.HasValue() ? "%" + reportName + "%" : "");
        }
        public static List<string> REPORT_HEADER
        {
            get
            {
                return new List<string>()
            {
                "编号",
                 "名称",
                  "sql脚本",
                   "标题头",
                   "每页条数",
                    "参数说明",
                     "要显示的列索引",
                     "操作列",
                     "日志",
            };
            }
        }
        public static string SQL_DATABASE
        {
            get { return "Select Name FROM Master.dbo.SysDatabases orDER BY Name"; }
        }
        public static string SQL_TABLE()
        {
            return @"SELECT  表名 = CASE WHEN a.colorder=1 THEN d.name
                  ELSE ''
             END,
			 表说明 = CASE WHEN a.colorder=1 THEN ISNULL(f.value,'#')
                            ELSE ''
                       END  
FROM    syscolumns a
LEFT   JOIN systypes b
        ON a.xusertype=b.xusertype
INNER   JOIN sysobjects d
        ON a.id=d.id
           AND d.xtype='U'
           AND d.name<>'dtproperties'
LEFT   JOIN syscomments e
        ON a.cdefault=e.id
LEFT   JOIN sys.extended_properties g
        ON a.id=g.major_id
           AND a.colid=g.minor_id
LEFT   JOIN sys.extended_properties f
        ON d.id=f.major_id
           AND f.minor_id=0 --where   d.name='V_test'         --如果只查询指定表,加上此条件
WHERE a.colorder=1	 	  
ORDER   BY a.id,a.colorder;";
        }
        public static string SQL_TABLECOLUMN(string tableName)
        {            /*
             
GUID	列名	说明	表	 不显示 	主键	字段类型	长度	允许空	默认值	外键列明	外键表名
  0	      1	      2	     3	    4	     5	        6	     7	      8       9        10          11

             */
            return tableName.SqlTableInfo();
        }
        public static string SQL_Regex()
        {
            return @"
SELECT 
regex_id
,name
,regex_string
,input_tip
,false_tip
,note
  FROM regex_data";
        }
    }
}
