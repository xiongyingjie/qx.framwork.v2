using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyj.tool.Entity;
using xyj.tool.Extension;
using xyj.tool.Helper;
using xyj.tool.Models;

using Qx.Tools.CommonExtendMethods;
using xyj.tool.Properties;

namespace xyj.tool
{
    public partial class FormTool : BaseDbForm
    {
        public FormTool()
        {
            InitializeComponent();
        }

        private void FormTool_Load(object sender, EventArgs e)
        {
          
            //创建根节点
            tv_dataBase.Nodes.Add(NewNodeWithEmptyChild("数据源"));
           // tv_dataBase.Nodes[0].Expand();
            //加载报表
           // ListViewBinding(lv_reports, REPORT_HEADER, SQL_REPORTS(tb_queryReportId.Text,tb_queryReportName.Text).ExecuteQuery());
            //加载连接字符串
           // ComBoxBinding(cb_connString,ConnectionStrings.Select(a=>a.Name));
            // tv_dataBase.ExpandAll();
        }
        private List<TreeNode> TreeNodes
        {
            get
            {
                return AllTreeNodes(tv_dataBase.Nodes[0]);
            }
        }

        #region 控制勾选状态
        private void tv_dataBase_AfterChecked(object sender, TreeViewEventArgs e)
        {
            ////通知上级
            //var parent = e.Node.Parent;
            //if (parent != null)
            //{
            //    parent.Checked = true;
            //}
            //通知下级
            var children = e.Node.Nodes;
            foreach (TreeNode child in children)
            {
                child.Checked = true;
            }
        }
        private void tv_dataBase_AfterUnChecked(object sender, TreeViewEventArgs e)
        {
            var children = e.Node.Nodes;
            foreach (TreeNode child in children)
            {
                child.Checked = false;
            }
        }
        #endregion
        //勾选状态发生更改
        private void tv_dataBase_AfterCheck(object sender, TreeViewEventArgs e)
        {
            #region 自动展开节点
            if (e.Node.Level == 2&&!e.Node.IsExpanded)
            {
                e.Node.Expand();
            }
            #endregion
            if (e.Node.Checked)
            {
                tv_dataBase_AfterChecked(sender, e);
            }
            else
            {
                tv_dataBase_AfterUnChecked(sender, e);
            }
            Step1();
            Step2();
        }

        void Step1()
        {
            var dbName = "";
            var sequence = 1;
            var lvBody = new List<List<string>>();
            TreeNodes.ForEach(node =>
            {
                if (node.Checked && node.Level == 3)
                {
                    #region 跨库检测
                    if (!dbName.HasValue())
                    {
                        dbName = node.Parent.Parent.Text;
                        #region 填写tb_database.Text
                        tb_database.Text = dbName;
                        #endregion
                    }
                    else
                    {
                        if (dbName != node.Parent.Parent.Text)
                        {
                            TipError(Resources.Error001);
                            return;

                        }
                    }
                    #endregion

                    var nodeTag = node.Tag.ToString().UnPackString(';'); 
                    var row = new List<string> {
                        nodeTag[0],
                        nodeTag[1],
                        nodeTag[2],
                        nodeTag[3],
                        nodeTag[4],
                        (sequence++).ToString()
                    };
                    lvBody.Add(row);
                }
            });
            ListViewBinding(lv_colums, new List<string>()
            {
                "GUID",
                "列名",
                "说明",
                "表",
                "不显示",
                "排序",
            }, lvBody);
        }
        void Step2()
        {
            //读取listView生成配置
            var rows = lv_colums.Items;
            if (rows.Count <= 0)
            {
                return;
            }

            var form_tables = "";
            var form_colums = "";
            var form_columsNote = "";
            var tables = new List<string>();
            foreach (ListViewItem row in rows)
            {
                var id = row.SubItems[0].Text;
                var columName = row.SubItems[1].Text;
                var columNote = row.SubItems[2].Text;
                var tableName = row.SubItems[3].Text;
                //var isHidden = bool.Parse(row.SubItems[4].Text);
                //加入tables
                if (!tables.Contains(tableName))
                {
                    tables.Add(tableName);
                    //拼接tables
                    form_tables += tableName + ";";
                }
                //拼接columsNote
                form_columsNote += columNote + ";";
                //拼接colums
                form_colums +=  columName + ";";
             
            }
            //删除tableName最后一个;
            form_tables = form_tables.Substring(0, form_tables.Length-1);
            //删除columsNote最后一个;
            form_columsNote = form_columsNote.Substring(0, form_columsNote.Length - 1);
            //删除拼接columsNote最后一个;
            form_colums = form_colums.Substring(0, form_colums.Length - 1);

            //赋值
            //tb_database.Text = DateTime.Now.Random();
            tb_tables.Text = form_tables;
            rtb_colums.Text = form_colums;
            rtb_columsNote.Text = form_columsNote; 
        }
      
      
        private void lv_colums_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = GetSelectedRow(lv_colums);
            if (item.Any())
            {
                var obj = new ColumSetting();
                obj.GUID = item[0];
                obj.ColumName = item[1];
                obj.ColumNote = item[2];
                obj.TableName = item[3];
                obj.IsHidden = bool.Parse(item[4]);
                obj.Sequence = int.Parse(item[5]);
                pg_colum.SelectedObject = obj;
            }       
        }
        //字段属性状态发生更改
        private void pg_colum_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var oldValue = e.OldValue.ToString();
            var newValue = e.ChangedItem.Value.ToString();
            var grid= (PropertyGrid) s;
            var obj = (ColumSetting) grid.SelectedObject;
            var key = obj.GUID;
            //查找
            foreach (ListViewItem item in lv_colums.Items)
            {
                if (item.Text.ToLower()==key.ToLower())//匹配
                {
                    foreach (ListViewItem.ListViewSubItem sub in item.SubItems)
                    {
                        if (sub.Text.ToLower() == oldValue.ToLower())//修改
                        {
                            sub.Text = newValue;
                        }
                    }
                }
            }
            FreshListView(lv_colums);
            Step2();
        } 
        private void lv_colums_Leave(object sender, EventArgs e)
        {
            FreshListView(lv_colums);
        }

        private void tv_dataBase_AfterExpand(object sender, TreeViewEventArgs e)
        {
            
            //清空孩子
            e.Node.Nodes.Clear();
            //判断层级
            if (e.Node.Level == 0)
            {
                
                e.Node.Nodes.AddRange(
                    NewNodesWithEmptyChild(SQL_DATABASE.ExecuteQuery().
                    Select(row
                    => row[0]).ToArray()));
                //MessageBox.Show("正在获取数据库"+e.Node.Text + e.Action.ToString());
            }
            if (e.Node.Level == 1)
            {
                e.Node.Nodes.AddRange(
                   NewNodesWithEmptyChild(SQL_TABLE().ExecuteQuery(e.Node.Text).
                   Select(row
                   => row[0]).ToArray()));
                // MessageBox.Show("正在获取数据表" + e.Node.Text + e.Action.ToString());
            }
            if (e.Node.Level == 2)
            {
                var connStr = ConnectionString(e.Node.Parent.Text);
                if (connStr.HasValue())
                {
                    e.Node.Nodes.AddRange(
                 NewNodes(SQL_TABLECOLUMN(e.Node.Text).ExecuteReader2(connStr).
                 Select(row
                 => new string[] { row[1],
                      string.Format("{0};{1};{2};{3};{4};", DateTime.Now.Random(), row[1], row[2], row[3], row[4]) }).ToArray()));
                }
               
                // MessageBox.Show("正在获字段列表" + e.Node.Text + e.Action.ToString());
            }
        }
      
        private void bt_confirm_Click(object sender, EventArgs e)
        {
            var f = new AutoCodeForm(tb_database.Text,tb_tables.Text,rtb_colums.Text,rtb_columsNote.Text);
            f.Show();
        }

       
    }
}
