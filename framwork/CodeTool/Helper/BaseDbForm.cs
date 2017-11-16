using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeTool.Entity;
using qx.permmision.v2.Interfaces;
using qx.permmision.v2.Services;
using Qx.Report.Interfaces;
using Qx.Report.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Scripts;

namespace CodeTool.Helper
{
    public  class BaseDbForm : Form
    {

        protected IPermissionProvider _permissionProvider;

        protected string DbName = "";
        protected string GetPath(string path,  string fileName)
        {
            return path + fileName + (path.Substring(path.Length - 3).ToLower() == ".js" ? "" : (".js"));//加扩展名

        }
        protected bool WriteFile(SaveFileDialog sfd, string content, string fileName)
        {
            try
            {
                var path= sfd.FileName + fileName + (sfd.FileName.Substring(sfd.FileName.Length - 3).ToLower() == ".js" ? "" : (".js"));//加扩展名
                byte[] myByte = System.Text.Encoding.UTF8.GetBytes(content);
                using (var fs = new FileStream(path,FileMode.Create))//输出文件
                {
                    fs.Write(myByte, 0, myByte.Length);
                    fs.Close();
                    fs.Dispose();
                    return true;

                };
            }
            catch (Exception)
            {
                return false;
            }
        }

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

       
        #endregion

        #region Db
        private MyDbContext db;

        public BaseDbForm()
        {
            _permissionProvider = new PermissionProvider(new PermissionServices());
        }

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
            return Sql.SQL_REPORTS(reportId, reportName);
        }
        protected List<string> REPORT_HEADER
        {
            get
            {
                return Sql.REPORT_HEADER;
            }
        }
        protected string SQL_DATABASE
        {
            get { return Sql.SQL_DATABASE; }
        }
        protected string SQL_TABLE()
        {
            return Sql.SQL_TABLE();
        }
        protected string SQL_TABLECOLUMN(string tableName)
        {            /*
             
GUID	列名	说明	表	 不显示 	主键	字段类型	长度	允许空	默认值	外键列明	外键表名
  0	      1	      2	     3	    4	     5	        6	     7	      8       9        10          11

             */
            return Sql.SQL_TABLECOLUMN(tableName);
        }
        protected string SQL_Regex()
        {
            return Sql.SQL_Regex();
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
                    var listBody = new List<ListViewItem>();
                    for (int i = 0; i < body.Count; i++)
                    {
                        ListViewItem lvi = new ListViewItem(body[i][0].ToString());
                        for (int j = 1; j < body[i].Count; j++)
                        {
                            // lvi.ImageIndex = 0;
                            lvi.SubItems.Add(body[i][j]);
                        }
                        listBody.Add(lvi);
                    }
                    lv.Items.AddRange(listBody.ToArray());
                    lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);//调整列的宽度
                }
            }
        

        

        }

        protected virtual void FreshListView(ListView lv)
        {
           
            lv.ListViewItemSorter = new ListViewSort();
            lv.Sort();
        }
        #endregion

        #region 创建新节点
        protected TreeNode NewNodeWithEmptyChild(string nodeText)
        {
           
            var deafultTreeNode = new TreeNode("empty");
            deafultTreeNode.Checked = false;

            var node = new TreeNode(nodeText, new TreeNode[]
            {
                deafultTreeNode
            });
            if (nodeText.Contains("#"))
            { 
                node.Text = nodeText.Replace("#", "");
                 node.ToolTipText = "请为该表设置表说明";
                node.ForeColor = Color.Red;    
            }
            return node;
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

                var node = new TreeNode(nodeText);
                if (nodeText.Contains("#"))
                {
                    node.Text = nodeText.Replace("#", "");
                    node.ToolTipText = "请为该字段设置字段说明";
                    node.ForeColor = Color.Red;
                }
                rreeNodes[i] = node;
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
