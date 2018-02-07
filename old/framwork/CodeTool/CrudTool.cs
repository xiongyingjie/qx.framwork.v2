using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeTool.Extension;
using CodeTool.Helper;
using CodeTool.Models;
using CodeTool.Template;

using Microsoft.VisualBasic;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Models;
using Qx.Tools.Models.Report;
using xyj.tool.Properties;

namespace CodeTool
{
    public partial class CrudTool : BaseDbForm
    {



        #region 所需变量
        public class Config
        {
             public string app_namespace { get; set; }
            public string db_name { get; set; }
            public string repository_name
            {//表名toUpper   user_role=>UserRole
                get { return table_name.ToBigCamelCase(); }
            }

            public string table_name { get; set; }
            public string table_note { get; set; }

            public string controller_area
            {
                get
                {//数据库名后缀 qx.permission=>permission
                    var temp = app_namespace.UnPackString('.');
                    return temp.Count > 1 ? temp[temp.Count - 1] : app_namespace;
                }
            }

          

            public string controller_name
            { //同repository_name   
                get { return repository_name; }
            }
            public string js {
                get
                {//同form
                    return form.JavaScript[0];
                }
            }
            public string table_column_pk_note { get; set; }
            public string report_title
            { //同table_note
                get { return table_note+"列表"; }
            }

            public string reportId
            {
                get
                {//同数据库名+表名  
                    return app_namespace+"."+table_name;
                }
            }

            public string Params { get; set; }
            public string pageIndex
            {
                get
                {
                    return "1";
                }
            }
            public string perCount {
                get
                {
                    return "10";
                }
            }
            public string table_column_pk { get; set; }
            public string table_column_name { get; set; }

            private List<ControllerModel.Header> headers
            {
                get
                {
                    return form.ColumSettings.Select(a=>new ControllerModel.Header() {name = a.ColumName,note = a.ColumNote}).ToList();
                }
            }

            public ReportModel report{ get; set; }
            public ReportModel finalReport
            {
                get
                {
                    var temp = report;
                    temp.OperateColum = 
                        "N1:<a href=\"*f"+ controller_area+ "/" + controller_name + "/Add?id={0}\">添加</a>:1;"+
                        "N1:<a href=\"*f" + controller_area + "/" + controller_name + "/Update?id={0}\">编辑</a>:1;"+
                        "N1:<a href=\"*d" + controller_area + "/" + controller_name + "/Delete?id={0}\">删除</a>:1;";
                    return temp;
                }
                }
            public FormTool2.FormModel form { get; set; }

        }

        private Config _cfg;
        #endregion
        public CrudTool()
        {
            InitializeComponent();
        }

        //private string _cfg.db_name = "";
        private void CrudTool_Load(object sender, EventArgs e)
        {

            // 初始化状态
            tb_form_Id.Visible = false;
             //创建根节点
            tv_dataBase.Nodes.Add(NewNodeWithEmptyChild("数据源"));
            tv_dataBase.Nodes[0].Expand();

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
                       // Where(a => cbItems.Contains(a[0])).
                        Select(row
                            => row[0]).ToArray()));
            }
            if (e.Node.Level == 1)
            {
                //防止垮裤
                var brothers = e.Node.Parent.Nodes;
                foreach (TreeNode item in brothers)
                {
                    if (item.FullPath != e.Node.FullPath)
                    {
                        //折叠节点
                        item.Collapse(false);
                        //清空listView
                        lv_colums.Clear();
                    }
                    else
                    {
                        DbName = e.Node.Text;
                       // TipInfo("已更换数据库" + DbName);
                    }
                }
                var temp = SQL_TABLE().ExecuteQuery(e.Node.Text).
                        Select(row
                            => new {name= row[0] ,note= row[1] }).ToList();
                if (temp.Any())
                {
                    _cfg = new Config();
                    var _t = temp.FirstOrDefault();
                    _cfg.table_name = _t.name;
                    _cfg.table_note = _t.note;
                    e.Node.Nodes.AddRange(
                        NewNodesWithEmptyChild(temp.Select(a=> a.note.HasValue()?a.name: a.name+"#").ToArray()));
                }
               
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
                                    row[2].HasValue()?row[1]:row[1]+"#",
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

           // cb_connString.SelectedIndex = cb_connString.Items.IndexOf(_cfg.db_name);

            #endregion
        }

        private void Step1()
        {

            var sequence = 1;
            var lvBody = new List<List<string>>();
            AllTreeNodes(tv_dataBase.Nodes[0]).ForEach(node =>
            {
                if (node.Checked && node.Level == 3)
                {
                    #region 跨库检测

                    if (!_cfg.db_name.HasValue())
                    {
                       _cfg.app_namespace= _cfg.db_name = node.Parent.Parent.Text;
                    }
                    else
                    {
                        if (_cfg.db_name != node.Parent.Parent.Text)
                        {
                            TipInfo(Resources.Error001);
                            //return;
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
                        FormControlType.Input.ToString(),
                        "",
                        QueryTypeEnum.None.ToString(),
                        false.ToString()
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
                "正则式",
                "查询类型",
                "是下拉项"
            }, lvBody);
        }

        List<FormReportColumSetting> ParseListView(ListView.ListViewItemCollection rows)
        {
            var result = new List<FormReportColumSetting>();
            foreach (ListViewItem row in rows)
            {
                var item = row.SubItems;
                var obj = new FormReportColumSetting();
                obj.GUID = item[0].Text.TrimString();
                obj.Sequence = int.Parse(item[1].Text.TrimString());
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
                obj.QuerType = item[15].Text.TrimString().ToQueryType();
                obj.IsSelectItem = bool.Parse(item[16].Text.TrimString());
                result.Add(obj);
            }
            return result;
        }
        public void Step2()
        {
            //读取listView生成配置
            var rows = ParseListView(lv_colums.Items);
            if (rows.Count <= 0)
            {
                return;
            }
            //查询生成器
            rtb_jsQuery.Text = ToJsQuery(rows, _cfg.db_name);
            //报表
         //   _cfg.report =ReportTool.ToReport(rows.Select(a => a.CopyToAll<ReportColumSetting>()).ToList(), _cfg.db_name);
            //表单
       //     _cfg.form = FormTool2.ToForm(rows.Select(a=>a.CopyToAll<FormColumSetting>()).ToList(),DbName);
            var tableList = new List<TableModel>();
            var columnIndex = 0;
            foreach (var obj in rows)
            {       
                 #region  拼接
                //拼接selectListItem
                if (obj.IsSelectItem)
                {
                    _cfg.table_column_name = obj.ColumName;
                }
                //拼接key_info
                if (obj.IsPrimaryKey)
                {
                     _cfg.table_column_pk = obj.ColumName;
                    _cfg.table_column_pk_note = obj.ColumNote;
                   
                     if (!_cfg.table_column_name.HasValue())
                    {
                        _cfg.table_column_name = obj.ColumName;
                    }
                }
                #endregion
                //计数累加
                columnIndex++;
            }  
          
          

        }

        private string ToJsQuery(List<FormReportColumSetting> rows, string db_name)
        {

                var tableList = new List<TableModel>();
            var tableNotAutoJoinList = new List<TableModel>();
            var queryConditionList = new List<QueryCondition>();

                var tableRelationList = new List<TableRelationModel>();
              
                var reportDataBase = db_name;
                var jsQeury = new List<string>();
             
                var columnIndex = 0;
            var tableIndex = 0;
            var gp = rows.GroupBy(a => a.TableName).OrderByDescending(b => b.AsEnumerable().Count(bb => bb.ForeignKey.HasValue()));
            gp.ToList().ForEach(g =>
            {
                var currntTableName = g.Key;//表名称
                var currntTableColumns = g.AsEnumerable();//当前表的列集合
                if (tableIndex == 0)
                {//主表
                    jsQeury.Add(string.Format("'{0}.{1}@list'", reportDataBase, currntTableName));
                }
                else
                {
                   
                    var pk = rows.FirstOrDefault(t => t.TableName == g.Key && t.IsPrimaryKey);
                    var pkName = pk == null ? "请勾选" + currntTableName + "的主键" : pk.ColumName;
                    string fkName;
                    string fkTableName;
                    //找该表引用的表
                    var currentTableQuote = currntTableColumns.Where(c => c.ForeignKey.HasValue()).ToList();
                    if (currentTableQuote.Any())
                    {//找到有引用的表-寻找引用表
               
                        var quotedTable = currentTableQuote.FirstOrDefault(t => gp.Select(gg=>gg.Key).Contains(t.ColumName));
                         if (quotedTable == null)
                        {//在勾选的表中没有匹配到
                            fkTableName = "目标表";
                            fkName = "目标列";
                        }
                        else
                        {
                            fkName = quotedTable.ColumName;
                            fkTableName = quotedTable.TableName;
                        }
                    }
                    else
                    {//未找到有引用的表
                        fkTableName = "目标表";
                        fkName = "目标列";
                    }
                    jsQeury.Add(string.Format(".jn('{0}.{1}','{2}.{3}')",
                        currntTableName, pkName, fkTableName, fkName
                        ));
                }
                tableIndex++;
            });
            //查询条件
                rows.Where(o => o.QuerType != QueryTypeEnum.None).ToList().ForEach(oo =>
                {
                    var tp = new QueryCondition()
                    {
                        ColumName = oo.ColumName,
                        TableName = oo.TableName,
                        QueryType = oo.QuerType
                    };
                    jsQeury.Add(tp.ToJsString(0));

                }
                );

            return jsQeury.PackString("");
//                foreach (var obj in rows)
//                {


            //                //加入tables
            //                    var hasPk = rows.FirstOrDefault(a => a.IsPrimaryKey);
            //                    if (hasPk != null)
            //                    {
            //                        var columName = hasPk.ColumName;
            //                        if (columName != null)
            //                        {
            //                            tableList.AddIfNotExsit(obj.TableName, columName);

            //                            //加入relation
            //                            if (obj.ForeignTable.HasValue())
            //                            {
            //                                tableRelationList.AddIfNotExsit(obj.TableName, obj.ColumName, obj.ColumNote,
            //                                    obj.ForeignTable, obj.ForeignKey);
            //                            }
            //                            else
            //                            {
            //                                tableNotAutoJoinList.AddIfNotExsit(obj.TableName, columName);


            //                            }
            //                        }
            //                    }

            //                    //计数累加
            //                columnIndex++;
            //                }

            //                //生成jn
            //                tableRelationList.ForEach(r =>
            //                {
            //                    jsQeury.Add(r.ToJsString()); //连表

            //                });
            //            //生成jn
            //            tableNotAutoJoinList.ForEach(r =>
            //            {
            //                if(tableRelationList.All(g => g.ColumName != r.TableName))
            //                jsQeury.Add(string.Format(".jn('{0}.{1}','目标表.目标列')", r.TableName,r.PkName));

            //            });
            //            //生成查询条件
            //            for (var i = 0; i < queryConditionList.Count; i++)
            //                {
            //                    var t = queryConditionList[i];
            //                    if (t.CanQuery)
            //                    {
            //                    jsQeury.Add(t.ToJsString(i));//加条件

            //                   }
            //                }
            //            //final
            //            var allTable = tableRelationList;;
            //            tableNotAutoJoinList.ForEach(a =>
            //            {
            //                if (allTable.All(item => item.TableName != a.TableName))
            //                {
            //                    allTable.Add(new TableRelationModel() { TableName = a.TableName, PkName = a.PkName,ForeginTableName = "目标表",ForeginColumName = "目标列"});
            //                }
            //            });


            //            if (!allTable.Any())
            //            {
            //                return "请在左侧勾选数据表";
            //            }
            //            else if (allTable.Count() == 1)
            //            {
            ////单表
            //                return string.Format("'{0}.{1}@list'", reportDataBase, (tableNotAutoJoinList.Any()
            //                    ? tableNotAutoJoinList[0].TableName
            //                    : tableRelationList[0].TableName));
            //            }
            //            else
            //            {//多表
            //                if (tableNotAutoJoinList.Any() || tableRelationList.Any())
            //                {
            //                    if (tableRelationList.Any())
            //                    {//有关系

            //                        return string.Format("'{0}.{1}@list'{2}", reportDataBase,
            //                        tableRelationList[0].TableName, jsQeury.Where(a => !a.Contains(tableRelationList[0].ToJsString())).
            //                        //Where(a => !a.Contains(string.Format(".jn('{0}.{1}','目标表.目标列')", tableRelationList[0].TableName, tableRelationList[0].ColumName))).
            //                                ToList().PackString(""));

            //                        //if (tableRelationList.Count() == allTable.Count)
            //                        //{


            //                        //}
            //                        //else
            //                        //{
            //                        //    ////部分有关系-把有关系的放前面且过滤掉第一个
            //                        //    //return string.Format("'{0}.{1}@list'{2}", reportDataBase,
            //                        //    //    tableRelationList[0].TableName, jsQeury.
            //                        //    //         Where(a => !a.Contains(tableRelationList[0].ToJsString())).
            //                        //    //    ToList().PackString(""));
            //                        //}


            //                    }
            //                    else
            //                    {//均无关系
            //                        return string.Format("'{0}.{1}@list'{2}", reportDataBase,
            //                           tableNotAutoJoinList[0].TableName, jsQeury.
            //                           Where(a => !a.Contains(string.Format(".jn('{0}.{1}','目标表.目标列')", tableNotAutoJoinList[0].TableName, tableNotAutoJoinList[0].PkName))).
            //                           ToList().PackString(""));
            //                    }
            //                }
            //            }




        //    return "请在左侧勾选数据表";




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
                    var obj = new FormReportColumSetting();
                    obj.GUID = item[0];
                    obj.Sequence = int.Parse(item[1]);
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
                    obj.QuerType = QueryTypeEnum.None;
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
                key == "d" || key == "e" || key == "t" || key == "q" || key == "f"))
                return;
            //按键判断
            var moveUp = false;
            var moveDown = false;
            var showThis = false;
            var hideThis = false;
            var editThis = false;
            var changeType = false;
            var queryThis = false;
            var selectThis = false;
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
                case "q":
                    queryThis = true;
                    break;
                case "f":
                    selectThis = true;
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
                            var all = type.GetAllControlType();
                            var tip = "";
                            all.ForEach(t =>
                            {
                                tip += (int)t + ":" + t.ToString() + ",";
                            });
                            var old = all.IndexOf(type).ToString();
                            Rectangle rect = Screen.GetWorkingArea(this);
                            var input = int.Parse(Interaction.InputBox("请输入控件编号" + tip,
                                "输入控件编号", old, rect.Width / 3, rect.Height / 3)
                                .CheckValue(old));
                            item.SubItems[13].Text = ((FormControlType)input).ToString();
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
                        //查询条件
                        if (queryThis)
                        {
                            var type = item.SubItems[16].Text.ToQueryType();
                            var all = type.GetAllQueryType();
                            var cur = 0;
                            var tip = "";
                            all.ForEach(t =>
                            {
                                tip += (cur++) + ":" + t + ",";
                            });
                            var old = all.IndexOf(item.SubItems[15].Text).ToString();
                            Rectangle rect = Screen.GetWorkingArea(this);
                            var input = int.Parse(Interaction.InputBox("请输入查询类型编号" + tip,
                                "输入查询类型编号", old, rect.Width / 3, rect.Height / 3)
                                .CheckValue(old));
                            item.SubItems[15].Text = input >= 0 && input < all.Count ? all[input] : all[0];
                        }

                        //显示/不显示
                        if (selectThis)
                        {
                            for (var j = 0; j < lv_colums.Items.Count; j++)
                            {//重置所有
                                lv_colums.Items[j].SubItems[16].Text = false.ToString();
                            }//重新赋值
                            item.SubItems[16].Text = true.ToString();
                        }
                    }
                }
                //刷新
                FreshListView(lv_colums);
                Step2();
            }

        }

        private void bt_check_Click(object sender, EventArgs e)
        {
            rtb_output.Text = _cfg.Serialize();
            var controller = _cfg.Render(@"E:\svn\jwxt\src\CodeTool\Template\Controller.tpl").WriteFile(@"e:\Controller.cs");
            var repository = _cfg.Render(@"E:\svn\jwxt\src\CodeTool\Template\Repository.tpl").WriteFile(@"e:\Repository.cs");
            var add = _cfg.Render(@"E:\svn\jwxt\src\CodeTool\Template\Add.tpl").WriteFile(@"e:\Add.js");
            var update = _cfg.Render(@"E:\svn\jwxt\src\CodeTool\Template\Update.tpl").WriteFile(@"e:\Update.js");

        }
    }
}
