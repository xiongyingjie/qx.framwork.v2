using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeTool.Extension;
using CodeTool.Helper;
using CodeTool.Models;
using CodeTool.Properties;
using Microsoft.VisualBasic;
using Qx.Tools.CommonExtendMethods;

namespace CodeTool
{
    public partial class FormTool2 : BaseDbForm
    {
        public FormTool2()
        {
            InitializeComponent();
        }

        private string dbName = "";
        private List<string> cbItems;

        private void FormTool2_Load(object sender, EventArgs e)
        {
            // 初始化状态
            tb_form_Id.Visible = false;
            //可用数据库列表
            cbItems = ConnectionStrings.Select(a => a.Name).ToList();
            //创建根节点
            tv_dataBase.Nodes.Add(NewNodeWithEmptyChild("数据源"));
            // tv_dataBase.Nodes[0].Expand();
            //加载报表
            // ListViewBinding(lv_reports, REPORT_HEADER, SQL_REPORTS(tb_queryReportId.Text,tb_queryReportName.Text).ExecuteQuery());
            //加载连接字符串
            ComBoxBinding(cb_connString, cbItems);
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
                        Where(a => cbItems.Contains(a[0])).
                        Select(row
                            => row[0]).ToArray()));
                //MessageBox.Show("正在获取数据库"+e.Node.Text + e.Action.ToString());
            }
            if (e.Node.Level == 1)
            {
                e.Node.Nodes.AddRange(
                    NewNodesWithEmptyChild(SQL_TABLE(e.Node.Text).ExecuteQuery().
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
                                => new string[]
                                {
                                    row[1],
                                    string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}",
                                        DateTime.Now.Random(),
                                        row[1], row[2], row[3],
                                        row[4], row[5], row[6],
                                        row[7], row[8], row[9],
                                        row[10], row[11])
                                }).ToArray()));

                }


            }
        }

        #region 控制勾选状态

        private void tv_dataBase_AfterChecked(object sender, TreeViewEventArgs e)
        {
            var children = e.Node.Nodes;
            foreach (TreeNode child in children)
            {
                child.Checked = true;
            }
        }

        private void tv_dataBase_AfterUnChecked(object sender, TreeViewEventArgs e)
        {
            var children = e.Node.Nodes;
            if (children.Count == 0)
            {

            }
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

            if (e.Node.Level == 2 && !e.Node.IsExpanded)
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

            #region 自动选择数据源

            cb_connString.SelectedIndex = cb_connString.Items.IndexOf(dbName);

            #endregion
        }

        private List<TreeNode> TreeNodes
        {
            get { return AllTreeNodes(tv_dataBase.Nodes[0]); }
        }

        private void Step1()
        {

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
                    var row = new string[]
                    {
                        nodeTag[0],
                        (sequence++).ToString(),
                        nodeTag[1],
                        nodeTag[2],
                        nodeTag[3],
                        nodeTag[4],
                        nodeTag[5],
                        nodeTag[6],
                        nodeTag[7],
                        nodeTag[8],
                        nodeTag[9],
                        nodeTag[10],
                        nodeTag[11],
                        ControlTypeEnum.Input.ToString(),
                        ""
                    }.ToList();
                    lvBody.Add(row);
                }
            });
            ListViewBinding(lv_colums, new List<string>()
            {
                "GUID",
                "排序",
                "列名",
                "说明",
                "表",
                "不显示",
                "主键",
                "字段类型",
                "长度",
                "允许空",
                "默认值",
                "外键列",
                "外键表",
                "控件类型",
                "正则式"
            }, lvBody);
        }

        public void Step2()
        {
            //读取listView生成配置
            var rows = lv_colums.Items;
            if (rows.Count <= 0)
            {
                return;
            }
            var split_flag = ";";
            var tableList = new List<TableModel>();
            var tableRelationList = new List<TableRelationModel>();
            var colum_to_show = "";
            var key_info = "";
            var colum = "";
            var display = "";
            var control_type = "";
            var regex = "";

            var columnIndex = 0;
            foreach (ListViewItem row in rows)
            {
                if (columnIndex == rows.Count - 1)
                {
                    split_flag = "";
                }
                #region 赋值转换
                var item = row.SubItems;
                var obj = new FormColumSetting();
                obj.GUID = item[0].Text.TrimString();
                obj.Sequence = item[1].Text.TrimString();
                obj.ColumName = item[2].Text.TrimString();
                obj.ColumNote = item[3].Text.TrimString() + //防止列明重复
                                (rows.Cast<ListViewItem>().Count(a => a.SubItems[2].Text == row.SubItems[2].Text) > 1
                                    ? ""
                                    : "");
                obj.TableName = item[4].Text.TrimString();
                obj.IsHidden = bool.Parse(item[5].Text.TrimString());
                obj.IsPrimaryKey = bool.Parse(item[6].Text.TrimString());
                obj.Type = item[7].Text.TrimString(); ;
                obj.Length = item[8].Text.TrimString(); ;
                obj.CanNull = bool.Parse(item[9].Text.TrimString());
                obj.DefaultValue = item[10].Text.TrimString();
                obj.ForeignKey = item[11].Text.TrimString(); 
                obj.ForeignTable = item[12].Text.TrimString();
                obj.ControlType = item[13].Text.TrimString().ToControlType();
                obj.Regex = item[14].Text.TrimString();
                //加入tables
                tableList.AddIfNotExsit(obj.TableName);
                //加入relation
                if (obj.ForeignTable.HasValue())
                {
                    tableRelationList.AddIfNotExsit(obj.TableName, obj.ColumName, obj.ColumNote,
                        obj.ForeignTable, obj.ForeignKey);
                }
                #endregion

                #region  拼接
                //拼接key_info
                if (obj.IsPrimaryKey)
                {
                    key_info += string.Format("{0}.{1}{2}", obj.TableName, obj.ColumName, split_flag);
                }
                //拼接colum_to_show
                if (!obj.IsHidden)
                {
                    colum_to_show += columnIndex + split_flag;
                }
                //拼接colum
                colum += obj.ColumName + split_flag;
                //拼接display
                if (display.UnPackString(';').FindAll(a => a == obj.ColumNote).Count > 1)
                {  //处理重复columNote
                    obj.ColumNote += obj.ColumNote + "_1";
                }
                display += obj.ColumNote + split_flag;   
                //拼接control_type
                control_type += obj.ControlType + split_flag;
                //拼接regex
                regex += obj.Regex + split_flag + split_flag;
                #endregion
                //计数累加
                columnIndex++;
            }

            //赋值
            tb_form_name.Text = DateTime.Now.Random();
            tb_key_info.Text = key_info;
            tb_columToShow.Text = colum_to_show;
            tb_key_info.Text = key_info;
            rtb_colum.Text = colum;
            rtb_display.Text = display;
            rtb_control_type.Text = control_type;
            rtb_regex.Text = regex;
            tb_form_Id.Text = string.Format("{0}.{1}.{2}", dbName, DateTime.Now.Random().Substring(0, 3),
                tb_form_name.Text);
            rtb_output.Text = "";
        }


        private void lv_colums_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = GetSelectedRow(lv_colums);
            if (item.Any())
            {
                /*

GUID	列名	说明	表	 不显示 	主键	字段类型	长度
0	      1	      2	     3	    4	     5	        6	     7	 
允许空	默认值	外键列明	外键表名
8       9        10          11

*/
                {
                    #region 赋值
                    var obj = new FormColumSetting();
                    obj.GUID = item[0];
                    obj.Sequence = item[1];
                    obj.ColumName = item[2];
                    obj.ColumNote = item[3];
                    obj.TableName = item[4];
                    obj.IsHidden = bool.Parse(item[5]);
                    obj.IsPrimaryKey = bool.Parse(item[6]);
                    obj.Type = item[7];
                    obj.Length = item[8];
                    obj.CanNull = bool.Parse(item[9]);
                    obj.DefaultValue = item[10];
                    obj.ForeignKey = item[11];
                    obj.ForeignTable = item[12];
                    obj.ControlType = item[13].ToControlType();
                    obj.Regex = item[14];
                    pg_colum.SelectedObject = obj;
                    #endregion
                }
            }
        }

        //字段属性状态发生更改
        private void pg_colum_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var oldValue = e.OldValue.ToString();
            var newValue = e.ChangedItem.Value.ToString();
            var grid = (PropertyGrid)s;
            var obj = (ColumSetting)grid.SelectedObject;
            var key = obj.GUID;
            //查找
            foreach (ListViewItem item in lv_colums.Items)
            {
                if (item.Text.ToLower() == key.ToLower())//匹配
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
        private void lv_colums_KeyDown(object sender, KeyEventArgs e)
        {
            //按键过滤
            var key = e.KeyCode.ToString().ToLower();
            if (!(key == "w" || key == "s" || key == "a" || 
                key == "d" || key == "e" || key == "t"))
                return;
            //按键判断
            var moveUp = false;
            var moveDown = false;
            var showThis = false;
            var hideThis = false;
            var editThis = false;
            var changeType = false;
            switch (key)
            {
                case "w":
                    moveUp = true;
                    break;
                case "s":
                    moveDown = true;
                    break;
                case "a":
                    showThis = true;
                    break;
                case "d":
                    hideThis = true;
                    break;
                case "e":
                    editThis = true;
                    break;
                case "t":
                    changeType = true;
                    break;
                default:
                    break;
            }


            var items = (ListView)sender;
            if (items.SelectedItems.Count > 0)
            {
                //定位
                var selectItem = items.SelectedItems[0];
                for (var index = 0; index < lv_colums.Items.Count; index++)
                {
                    var item = lv_colums.Items[index];
                    if (item.Text.ToLower() == selectItem.Text.ToLower())//匹配
                    {
                        //改类型
                        if (changeType)
                        {
                           var type = item.SubItems[13].Text.ToControlType();
                           var all = type.GetAll();
                           var cur = 0;
                           var tip = "";
                            all.ForEach(t =>
                            {
                                tip+=(cur++)+":"+t+",";
                            });
                            var old = all.IndexOf(item.SubItems[13].Text).ToString();
                            Rectangle rect = Screen.GetWorkingArea(this);
                            var input = int.Parse(Interaction.InputBox("请输入控件编号" + tip,
                                "输入控件编号", old, rect.Width/3, rect.Height/3)
                                .CheckValue(old));
                            item.SubItems[13].Text = input>=0&&input< all.Count? all[input]:all[0];
                        }

                        //编辑
                        if (editThis)
                        {
                            Rectangle rect = Screen.GetWorkingArea(this);
                            item.SubItems[3].Text = Interaction.InputBox("请输入修改后的字段说明",
                                "修改字段说明", item.SubItems[3].Text, rect.Width / 3, rect.Height / 3).CheckValue(item.SubItems[3].Text);
                        }
                        //显示/不显示
                        if (showThis)
                        {
                            item.SubItems[5].Text = true.ToString();
                        }
                       if (hideThis)
                        {
                            item.SubItems[5].Text = false.ToString();
                        }
                        //上移/下移
                       
                        var current = item.SubItems[1];
                        if (moveUp)
                        {
                            if (index > 0)
                            {
                                //目标
                                var target = lv_colums.Items[index - 1].SubItems[1];
                                //修改前缓存
                                var temp = target.Text;
                                target.Text = current.Text;
                                current.Text = temp;
                            }
                            else
                            {
                                TipInfo("已经移到最上面了！");
                            }
                        }

                         if (moveDown)
                        {
                            if (index < lv_colums.Items.Count - 1)
                            {
                                //目标
                                var target = lv_colums.Items[index + 1].SubItems[1];
                                //修改前缓存
                                var temp = target.Text;
                                target.Text = current.Text;
                                current.Text = temp;
                            }
                            else
                            {
                                TipInfo("已经移到最下面了！");
                            }
                        }


                    }
                }
                //刷新
                FreshListView(lv_colums);
                Step2();
            }

        }

    }
}