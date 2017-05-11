using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeTool.Entity;
using Qx.Report.Interfaces;
using Qx.Report.Services;
using Qx.Tools.CommonExtendMethods;

namespace CodeTool.Helper
{
    public partial class BaseDbForm : Form
    {

        #region  ReportServices 
        private IReportServices reportServices;

        protected IReportServices _reportServices
        {
            get
            {
                if (reportServices == null)
                {
                    reportServices = new ReportServices();
                }
                return reportServices;
            }
        }

        public BaseDbForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Db
        private MyDbContext db;

        protected MyDbContext Db
        {
            get
            {
                if (db == null)
                {
                    db = new MyDbContext();
                }
                return db;
            }
        }
        #endregion

        #region ConnectionString
        protected string ConnectionString(string key)
        {
            var connStr = "";
            try
            {
                connStr = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            catch (Exception)
            {
                TipError("连接字符串[" + key + "]未找到,请检查App.config中的字符串配置");
            }
            return connStr;
        }
        protected List<ConnectionStringSettings> ConnectionStrings
        {
            get
            {
                return ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>().ToList();
            }
        }

        #endregion

        #region Sql Script
        protected string SQL_REPORTS(string reportId = "", string reportName = "")
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
        protected List<string> REPORT_HEADER
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
        protected string SQL_DATABASE
        {
            get { return "Select Name FROM Master.dbo.SysDatabases orDER BY Name"; }
        }
        protected string SQL_TABLE(string dataBaseName)
        {
            return @"SELECT Name FROM [" + dataBaseName + "]..SysObjects Where XType='U' ORDER BY Name";
        }
        protected string SQL_TABLECOLUMN(string tableName)
        {
            return string.Format(@"
declare @table_name varchar(100) --声明变量
set @table_name='{0}'   ---赋值
 SELECT 
'GUID' as GUID,--0
列名 = Rtrim(b.name),--1
说明 = Isnull(c.VALUE,'_'+b.name),@table_name as 表,'false'as 不显示,--2
主键 = CASE WHEN h.id IS NOT NULL THEN 'PK'ELSE ''END,--3
字段类型 = Type_name(b.xusertype)--4
                + CASE 
                    WHEN b.colstat & 1 = 1 THEN '[ID('
                                                 + CONVERT(VARCHAR,Ident_seed(a.name))
                                                 + ','
                                                 + CONVERT(VARCHAR,Ident_incr(a.name))
                                                 + ')]'
                    ELSE ''
                  END,
长度 = b.length,--5
允许空 = CASE b.isnullable --6
                WHEN 0 THEN 'N'
                ELSE 'Y'
              END,
默认值 = Isnull(e.TEXT,''),--7
外键列明 = (SELECT top 1 RC.name 被引用列名--8
					      FROM sys.foreign_key_columns 
						  JOIN sys.objects PT ON sys.foreign_key_columns.parent_object_id=PT.object_id
						  JOIN sys.objects RT ON sys.foreign_key_columns.referenced_object_id=RT.object_id
						  JOIN sys.columns PC ON sys.foreign_key_columns.parent_object_id=PC.object_id 
						       AND sys.foreign_key_columns.parent_column_id=PC.column_id
						  JOIN sys.columns RC ON sys.foreign_key_columns.referenced_object_id=RC.object_id 
							   AND sys.foreign_key_columns.referenced_column_id=RC.column_id
						  JOIN sys.foreign_keys FK ON sys.foreign_key_columns.constraint_object_id=FK.object_id where PT.name=@table_name and RC.name=Rtrim(b.name)),
外键表名 =(SELECT top 1 RT.name 被引用表名--9
					      FROM sys.foreign_key_columns 
						  JOIN sys.objects PT ON sys.foreign_key_columns.parent_object_id=PT.object_id
						  JOIN sys.objects RT ON sys.foreign_key_columns.referenced_object_id=RT.object_id
						  JOIN sys.columns PC ON sys.foreign_key_columns.parent_object_id=PC.object_id 
						       AND sys.foreign_key_columns.parent_column_id=PC.column_id
						  JOIN sys.columns RC ON sys.foreign_key_columns.referenced_object_id=RC.object_id 
							   AND sys.foreign_key_columns.referenced_column_id=RC.column_id
						  JOIN sys.foreign_keys FK ON sys.foreign_key_columns.constraint_object_id=FK.object_id where PT.name=@table_name and RC.name=Rtrim(b.name))
      
FROM     sysobjects a
         INNER JOIN  sys.all_objects aa ON a.id=aa.object_id 
              AND  schema_name(schema_id)='dbo' ,syscolumns b
         LEFT OUTER JOIN sys.extended_properties c ON b.id = c.major_id
              AND b.colid = c.minor_id
         LEFT OUTER JOIN syscomments e ON b.cdefault = e.id
         LEFT OUTER JOIN (SELECT g.id
                                 ,g.colid
                          FROM   sysindexes f
                                 ,sysindexkeys g
                          WHERE  (f.id = g.id)
                                 AND (f.indid = g.indid)
                                 AND (f.indid > 0)
                                 AND (f.indid < 255)
                                 AND (f.status & 2048) <> 0) h ON (b.id = h.id)
              AND (b.colid = h.colid)
WHERE    (a.id = b.id)
         AND (a.id = Object_id(@table_name))  --要查询的表改成你要查询表的名称
ORDER BY b.colid",
 tableName);
        }
        #endregion

        #region Tip MessageBox
        protected void TipError(string content)
        {
            MessageBox.Show(content, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        protected void TipInfo(string content)
        {
            MessageBox.Show(content, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected void ComBoxBinding(ComboBox cb, IEnumerable<string> itemList)
        {
            cb.Items.Clear();
            foreach (var item in itemList)
            {
                cb.Items.Add(item);
            }
            //cb.Tag = itemList;
        }
        #endregion

        #region ListView 相关
        protected List<string> GetSelectedRow(ListView lv)
        {
            var itemsList = new List<string>();
            var items = lv.SelectedItems;
            if (items.Count > 0)
            {
                var subItems = items[0].SubItems;
                foreach (ListViewItem.ListViewSubItem sub in subItems)
                {
                    itemsList.Add(sub.Text);
                }
            }
            return itemsList;
        }
        protected void ListViewBinding(ListView lv, List<string> head, List<List<string>> body)//  为ListView绑定数据源//static
        {
            if (head != null)
            {
                lv.View = View.Details;
                lv.GridLines = true;//显示网格线
                lv.MultiSelect = false;//多选
                lv.FullRowSelect = true;//选中整行
                lv.Items.Clear();//所有的项
                lv.Columns.Clear();//标题
                for (int i = 0; i < head.Count; i++)
                {
                    lv.Columns.Add(head[i]);//增加标题
                }
                for (int i = 0; i < body.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem(body[i][0].ToString());
                    for (int j = 1; j < body[i].Count; j++)
                    {
                        // lvi.ImageIndex = 0;
                        lvi.SubItems.Add(body[i][j]);
                    }
                    lv.Items.Add(lvi);
                }
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);//调整列的宽度

            }
        }

        protected void FreshListView(ListView lv)
        {
            lv.ListViewItemSorter = new ListViewSort();
            lv.Sort();
        }
        #endregion

        #region 创建新节点
        protected TreeNode NewNodeWithEmptyChild(string nodeText)
        {
            TreeNode deafultTreeNode = new TreeNode("empty");
            deafultTreeNode.Checked = false;
            return new TreeNode(nodeText, new TreeNode[]
            {
                deafultTreeNode
            });
        }
        protected TreeNode[] NewNodesWithEmptyChild(string[] nodeTexts)
        {
            var rreeNodes = new TreeNode[nodeTexts.Count()];
            for (var i = 0; i < nodeTexts.Count(); i++)
            {
                rreeNodes[i] = NewNodeWithEmptyChild(nodeTexts[i]);
            }
            return rreeNodes;
        }
        protected TreeNode[] NewNodes(string[][] nodesInfo)
        {
            var rreeNodes = new TreeNode[nodesInfo.Count()];
            for (var i = 0; i < nodesInfo.Count(); i++)
            {
                var nodeText = nodesInfo[i][0];
                var nodeTag = nodesInfo[i][1];
                rreeNodes[i] = new TreeNode(nodeText);
                rreeNodes[i].Tag = nodeTag;//附加数据
            }
            return rreeNodes;
        }
        #endregion

        #region 递归获取所有节点
        protected void GetAllSubNodes(TreeNode cuurentNode, List<TreeNode> treeNodeContainer)
        {
            treeNodeContainer.Add(cuurentNode);
            if (cuurentNode.Nodes.Count > 0)
            {
                foreach (TreeNode item in cuurentNode.Nodes)
                {
                    GetAllSubNodes(item, treeNodeContainer);
                }
            }
        }

        protected List<TreeNode> AllTreeNodes(TreeNode node)
        {
            var container = new List<TreeNode>();
            GetAllSubNodes(node, container);
            return container;
        }
        #endregion
    }
}
