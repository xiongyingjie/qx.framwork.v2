using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeTool.Extension;
using CodeTool.Helper;
using CodeTool.Models;
using CodeTool.Properties;
using Microsoft.VisualBasic;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Models;

namespace CodeTool
{
    public partial class FormTool2 : BaseDbForm
    {
        public FormTool2()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private string _lastDir;
        protected string LastDir
        {
            get
            {
                return _lastDir;
            }
            set
            {
              
                _lastDir = value;
                if (LastDir.HasValue())
                {
                    tssl_State.Text = "项目所在目录:" + _lastDir;
                    ck_rechoose.Enabled = true;
                    ck_rechoose.Checked = false;
                }
               
            }
        }
       
        private List<string> cbItems;

        private void FormTool2_Load(object sender, EventArgs e)
        {
          
            //可用数据库列表
            cbItems = ConnectionStrings.Select(a => a.Name).ToList();
            //创建根节点
            tv_dataBase.Nodes.Add(NewNodeWithEmptyChild("数据源"));
            tv_dataBase.Nodes[0].Expand();
            //加载报表
            // ListViewBinding(lv_reports, REPORT_HEADER, SQL_REPORTS(tb_queryReportId.Text,tb_queryReportName.Text).ExecuteQuery());
       
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
                       // TipInfo("已更换数据库"+ dbName);
                    }
                }
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


        //勾选状态发生更改
        private void tv_dataBase_AfterCheck(object sender, TreeViewEventArgs e)
        {

            #region 自动展开节点

            if (e.Node.Level == 2 && !e.Node.IsExpanded)
            {
                e.Node.Expand();
            }

            #endregion

            if (e.Node.Level == 2)
            {
                var children = e.Node.Nodes;
                foreach (TreeNode child in children)
                {
                    child.Checked = e.Node.Checked;
                }
                var lastChild = children[children.Count - 1];
                Step1(lastChild, e.Node.Checked);
            }
        }

        private void Step1(TreeNode lastChild,bool checkOrUnChek)
        {//塞入listView
         //改变鼠标状态
          
            new Thread(() =>
            {
                Cursor = Cursors.WaitCursor;
                while (true)
                {
                    if (lastChild.Checked== checkOrUnChek)
                    {//检测是否完成
                        break;
                    }
                    Thread.Sleep(100);
                }//恢复鼠标
                Cursor = Cursors.Default;

                var sequence = 1;
                var lvBody = new List<List<string>>();
                AllTreeNodes(tv_dataBase.Nodes[0]).ForEach(node =>
                {
                    if (node.Checked && node.Level == 3)
                    {
                        var nodeTag = node.Tag.ToString().UnPackString(';');
                        var dataType = nodeTag[6].ToLower();
                        var length = int.Parse(nodeTag[7]);
                        var controlType = FormControlType.Input.ToString();
                        var showControlType = FormControlType.ShowInput.ToString();
                        var regex = "";
                        switch (dataType)
                        {
                            case "varchar":
                                {
                                    if (length == 18)
                                    {//身份证
                                        regex = "{idno:true}";
                                    }
                                    else if (length == 11)
                                    {//手机号
                                        regex = "{mobile:true}";
                                    }
                                    else if (length == 800 || length == 500 || length == 600)
                                    {
                                        controlType = FormControlType.File.ToString();
                                        showControlType = FormControlType.Showfile.ToString();
                                    }
                                    else if (length < 100)
                                    {
                                        regex = "{min:1,max:" + length + "}";
                                    }
                                    else if (length > 200)
                                    {
                                        controlType = FormControlType.Area.ToString();
                                        showControlType = FormControlType.ShowArea.ToString();
                                    }
                                }
                                break;
                            case "text":
                                {
                                    controlType = FormControlType.Editor.ToString();
                                    showControlType = FormControlType.ShowEditor.ToString();
                                }
                                break;
                            case "datetime2":
                                {
                                    controlType = FormControlType.Time.ToString();
                                    showControlType = FormControlType.ShowTime.ToString();
                                }
                                break;
                            case "int":
                                {
                                    regex = "{int:true}";
                                }
                                break;
                            case "float":
                                {
                                    regex = "{float:true}";
                                }
                                break;
                        }
                        var row = new string[]
                        {
                        nodeTag[0],
                        (sequence++).ToString(),
                        nodeTag[1],
                        nodeTag[2],
                        nodeTag[3],
                        nodeTag[4],
                        nodeTag[5],
                        nodeTag[6],//数据类型
                        nodeTag[7],
                        nodeTag[8],
                        nodeTag[9],
                        nodeTag[10],
                        nodeTag[11],
                        controlType,
                        regex,
                        showControlType,
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
                "详情控件类型",
            }, lvBody);
            //执行第二步
           
            Step2();
            }).Start();

           
        }

        #region 辅助类
      public class FormModel
        {
            public FormModel(List<FormColumSetting> columSettings,string dataBase)
            {
                ColumSettings = columSettings;
                DataBase = dataBase;
            }

          public string DataBase { get; }
          public List<string> Tables
          {
              get
              {
                    return ColumSettings.Distinct(Qx.Tools.Equality<FormColumSetting>.CreateComparer(d=>d.TableName)).Select(t=>t.TableName).ToList();
                }
          }
           
            public List<FormColumSetting> ColumSettings { get; set; }

            public string[] JavaScript
            {
                get
                {
                    var split_flag = ";";
                    var tableList = new List<TableModel>();
                    var tableRelationList = new List<TableRelationModel>();
                    var display = "";
                    var html = "";//render: function (htmlArray, submiturl, dataUrl, overWrite)
                    var detailHtml = "";
                    var columnIndex = 0;
                    foreach (var obj in ColumSettings)
                    {
                        var isLast = columnIndex == ColumSettings.Count - 1;
                        html += ToJavaScript(obj, isLast);
                        detailHtml += ToDetailJavaScript(obj, isLast);
                        if (isLast)
                        {
                            split_flag = "";
                        }
                        //加入tables
                        tableList.AddIfNotExsit(obj.TableName);
                        //加入relation
                        if (obj.ForeignTable.HasValue())
                        {
                            tableRelationList.AddIfNotExsit(obj.TableName, obj.ColumName, obj.ColumNote,
                                obj.ForeignTable, obj.ForeignKey);
                        }
                       
                        #region  拼接
                        //拼接key_info
                        if (obj.IsPrimaryKey)
                        {
                        }
                        //拼接colum_to_show
                        if (!obj.IsHidden)
                        {
                        }
                        //拼接colum
                        //拼接display
                        if (display.UnPackString(';').FindAll(a => a == obj.ColumNote).Count > 1)
                        {  //处理重复columNote
                            obj.ColumNote += obj.ColumNote + "_1";
                        }
                        display += obj.ColumNote + split_flag;
                        //拼接control_type
                        //拼接regex

                        #endregion
                        //计数累加
                        columnIndex++;
                    }
                    return new []{ html , detailHtml };
                }
            }

          private string DbApi(string type)
          {
              var dest = DataBase + "." ;
              for (var i = 0; i < Tables.Count; i++)
              {
                  var table = Tables[i];
                  dest += table + "@" + type+(i==Tables.Count-1?"":"|");
              }
              return dest;
          }
            public string FinalUpdateJavaScript
            {
                get
                {
                   
                    var  js=
@"render(function(){
var cfg=[];
cfg.push(
    group([
";
                    js += JavaScript[0]+
@"],'标题'));
return cfg;
},'" + DbApi("update") + "&id='+q.id" + ",'" +  DbApi("find") + "&id='+q.id" + ",'编辑');";
                    return js;
                }
            }
            public string FinalAddJavaScript
            {
                get
                {

                    var js =
@"render([
    group([
";
                    js += JavaScript[0] +
@"],'标题')],'" + DbApi("add") + "','','添加');";
                    return js;
                }
            }
            public string FinalDetailJavaScript
            {
                get
                {

                    var js =
@"render([
    group([
";
                    js += JavaScript[1] +
@"],'标题')],'','" + DbApi("find") + "&id='+q.id" + ",'','详情');";
                    return js;
                }
            }
            public string FinalDeleteApi
            {
                get
                {
                    return DbApi("delete");
                }
            }
            public string FinalItemsJavaScript
            {
                get
                {
                    var js =
string.Format(@"render([
    group([
        pre(""select('下拉', 'test_dropdown', '{0}&name=<span id='item_name'></span>', '<span id='item_deafultValue'></span>', '4')"", 1),
         select(""选字段"", ""choose_column"", ""{1}"", """", ""4""),
         select(""<span id='item_lable'>下拉</span>"", ""test_dropdown"", ""{0}&name="", """", ""4"")
    ], ""下拉代码生成"")], """", """", ""下拉测试"");
                    function formReady() {{
    $.bindSelect(""choose_column"", ""test_dropdown"", '{0}', true, function(src, target) {{
        $(""#item_name"").html(src.val());
        $(""#item_lable"").html(src.find(""option:selected"").text());
                            target.change(function() {{
            $(""#item_deafultValue"").html($(this).val());
                            }});
                        }});
                    }}
                    ", DbApi("items"), DbApi("info"));
                    return js;
                }
            }
            public string FinalListScript
            {
                get
                {
                    var js = string.Format(@"List();
function List() {{
    render(function () {{
        var cfg = [
            table(model),
            button(""刷新"", ""1:5"", Color.blue, function () {{
                List();
                }}),
            button(""关闭"", ""6:0"", Color.blue, function () {{
                    subClose();
                }})
        ];
        return cfg;
            }}, """", ""{0}"", ""列表"", true);
}}", DbApi("list"));
                    return js;
                }
            }
        }

      public static FormModel ToForm(List<FormColumSetting> rows, string dataBase)
      {
        return new FormModel(rows,dataBase);

            //赋值
            //tb_form_name.Text = DateTime.Now.Random();
            //tb_key_info.Text = key_info;
            //tb_columToShow.Text = colum_to_show;
            //tb_key_info.Text = key_info;
            //rtb_colum.Text = colum;
            //rtb_display.Text = display;
            //rtb_control_type.Text = control_type;
            //rtb_regex.Text = regex;
            //tb_form_Id.Text = string.Format("{0}.{1}.{2}", dbName, DateTime.Now.Random().Substring(0, 3),
            //    tb_form_name.Text);
         
           
        }
      public static string ToJavaScript(FormColumSetting obj, bool isLast)
        {
            var html = "";
            //判断控件类型
            switch (obj.ControlType)
            {
                case FormControlType.Input:
                    {// input: function (label, name, value, num,reg, tip)
                        if (!obj.Regex.HasValue()&&int.Parse(obj.Length) > 10)
                        {
                            obj.Regex = "{min:1,max:"+ obj.Length + "}";
                        }
                        html += string.Format("input('{0}', '{1}', '{2}', '{3}'{4})",
                           obj.ColumNote, obj.ColumName, obj.DefaultValue, 4, obj.Regex.HasValue()? ", " + obj.Regex: "" );
                    }
                    break;
                case FormControlType.Time:
                    {
                        // time: function (label, name, value, num, tip)
                        html += string.Format("time('{0}', '{1}', '{2}', '{3}', '{4}')",
                           obj.ColumNote, obj.ColumName, obj.DefaultValue, 4, "请选择" + obj.ColumNote);

                    }
                    break;
                case FormControlType.Date:
                    {
                        // date: function (label, name, value, num, tip)
                        html += string.Format("date('{0}', '{1}', '{2}', '{3}', '{4}')",
                           obj.ColumNote, obj.ColumName, obj.DefaultValue, 4, "请选择" + obj.ColumNote);

                    }
                    break;
                case FormControlType.Select:
                    {
                        // select: function (label, name, option, value, num, tip)
                        html += string.Format("select('{0}', '{1}', '[]')",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                case FormControlType.Radio:
                    {
                        // radio: function (label, name, items, num, value)
                        html += string.Format("radio('{0}', '{1}', [])",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                case FormControlType.Editor:
                    {
                        // editor: function (label, name)
                        html += string.Format("editor('{0}', '{1}')",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                case FormControlType.Checkbox:
                    {
                        // checkbox: function (label, name, items, num, valueArray)
                        html += string.Format("checkbox('{0}', '{1}',[])",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                case FormControlType.Switch:
                    {
                        // _switch: function (label,name, num, value, onText, offText)
                        html += string.Format("_switch('{0}', '{1}')",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                case FormControlType.Area:
                    {
                        // area: function (label, name, value, num, tip, height)
                        html += string.Format("area('{0}', '{1}')",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                case FormControlType.File:
                    {
                        // area: function (label, name, value, num, tip, height)
                        html += string.Format("file('{0}', '{1}')",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                    defaut:
                    {
                        html += string.Format("//暂不支持该类型控件的生成" + obj.ControlType.ToString() + "\n");
                    }
                    break;
            }
            html += (isLast ? "" : ",") + "\n";
            return html;
        }
      public static string ToDetailJavaScript(FormColumSetting obj, bool isLast)
        {
            var html = "";
            //判断控件类型
            switch (obj.ShowControlType)
            {
                case FormControlType.ShowInput:
                    {// input: function (label, name, value, num,reg, tip)
                        html += string.Format("showInput('{0}', '{1}', '{2}', '{3}')",
                           obj.ColumNote, obj.ColumName, obj.DefaultValue, 4);
                    }
                    break;
                case FormControlType.ShowTime:
                    {
                        // time: function (label, name, value, num, tip)
                        html += string.Format("showTime('{0}', '{1}', '{2}', '{3}')",
                           obj.ColumNote, obj.ColumName, obj.DefaultValue, 4);

                    }
                    break;
                case FormControlType.ShowDate:
                    {
                        // date: function (label, name, value, num, tip)
                        html += string.Format("showDate('{0}', '{1}', '{2}', '{3}')",
                           obj.ColumNote, obj.ColumName, obj.DefaultValue, 4);

                    }
                    break;
                case FormControlType.ShowSelect:
                    {
                        // select: function (label, name, option, value, num, tip)
                        html += string.Format("showSelect('{0}', '{1}', '[]')",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                case FormControlType.ShowRadio:
                    {
                        // showRadio: (label, name, items, num, vertical, value)
                        html += string.Format("showRadio('{0}', '{1}', [])",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                case FormControlType.ShowEditor:
                    {
                        // showEditor(label, name, value, num, height)
                        html += string.Format("showEditor('{0}', '{1}')",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                case FormControlType.ShowCheckbox:
                    {
                        // checkbox(label, name, items, num, vertical,valueArra)
                        html += string.Format("showCheckbox('{0}', '{1}',[])",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                case FormControlType.ShowSwitch:
                    {
                        // showSwitch(label, name, num, value, onText, offText)
                        html += string.Format("showSwitch('{0}', '{1}')",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                case FormControlType.ShowArea:
                    {
                        // showArea(label, name, value, num, height, validators, tip)
                        html += string.Format("showArea('{0}', '{1}')",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                case FormControlType.Showfile:
                    {
                        //function showFile(label, name, files, num)
                        html += string.Format("showFile('{0}', '{1}')",
                            obj.ColumNote, obj.ColumName);
                    }
                    break;
                    defaut:
                    {
                        html += string.Format("//暂不支持该类型控件的生成" + obj.ControlType.ToString() + "\n");
                    }
                    break;
            }
            html += (isLast ? "" : ",") + "\n";
            return html;
        }

      List<FormColumSetting> ParseListView(ListView.ListViewItemCollection rows,bool hasPre)
        {
            var result = new List<FormColumSetting>();
          
            foreach (ListViewItem row in rows)
            {

                var item = row.SubItems;
                var obj = new FormColumSetting();
                obj.GUID = item[0].Text.TrimString();
                obj.Sequence = int.Parse(item[1].Text.TrimString());
                obj.TableName = item[4].Text.TrimString(); obj.AddTable(obj.TableName); obj.HasPre = hasPre;
                obj.ColumName = item[2].Text.TrimString();
                obj.ColumName = hasPre ? obj.TableName+"-" + obj.ColumName : obj.ColumName;//加前缀
                obj.ColumNote = item[3].Text.TrimString() + //防止列明重复
                                (rows.Cast<ListViewItem>().Count(a => a.SubItems[2].Text == row.SubItems[2].Text) > 1
                                    ? ""
                                    : "");
                obj.IsHidden = bool.Parse(item[5].Text.TrimString());
                obj.IsPrimaryKey = bool.Parse(item[6].Text.TrimString());
                obj.Type = item[7].Text.TrimString();
                obj.Length = item[8].Text.TrimString();
                obj.CanNull = bool.Parse(item[9].Text.TrimString());
                obj.DefaultValue = item[10].Text.TrimString();
                obj.ForeignKey = item[11].Text.TrimString();
                obj.ForeignTable = item[12].Text.TrimString();
                obj.ControlType = item[13].Text.TrimString().ToControlType();
                obj.Regex = item[14].Text.TrimString();
                obj.ShowControlType = item[15].Text.TrimString().ToControlType();

                result.Add(obj);

            }

            return result;
        }
      #endregion

        public void Step2(bool hasPre=true)
        {//读取listView生成配置
            var rows = ParseListView(lv_colums.Items, hasPre);
            var cfg = ToForm(rows, DbName);
            rtb_output_add.Text =cfg.FinalAddJavaScript;
            rtb_output_update.Text = cfg.FinalUpdateJavaScript;
            rtb_output_detail.Text = cfg.FinalDetailJavaScript;
            rtb_output_delete.Text = cfg.FinalDeleteApi;
            rtb_output_items.Text = cfg.FinalItemsJavaScript;
            rtb_output_list.Text = cfg.FinalListScript;
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
                key == "d" || key == "e" || key == "t" || key == "r" || key == "c"))
                return;
            //按键判断
            var moveUp = false;
            var moveDown = false;
            var showThis = false;
            var hideThis = false;
            var editThis = false;
            var changeType = false;
            var changeShowType = false;
            var editRegix = false;
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
                case "r":
                    editRegix = true;
                    break;
                case "c":
                    changeShowType = true;
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
                            var all = type.GetAllControlType().Where(t=>!t.ToString().ToLower().Contains("show")).ToList();
                            var tip = "";
                            all.ForEach(t =>
                            {
                                tip += (int)t + ":" + t.ToString() + ",";
                            });
                            var old = ((int)all[all.IndexOf(type)]).ToString();
                            Rectangle rect = Screen.GetWorkingArea(this);
                            var input = int.Parse(Interaction.InputBox("请输入控件编号" + tip,
                                "输入控件编号", old, rect.Width / 3, rect.Height / 3)
                                .CheckValue(old));
                            item.SubItems[13].Text = ((FormControlType)input).ToString();
                        }
                        //改类型
                        if (changeShowType)
                        {
                            var type = item.SubItems[15].Text.ToControlType();
                            var all = type.GetAllControlType().Where(t => t.ToString().ToLower().Contains("show")).ToList();
                            var tip = "";
                            all.ForEach(t =>
                            {
                                tip += (int)t + ":" + t.ToString() + ",";
                            });
                            var old = ((int)all[all.IndexOf(type)]).ToString();
                            Rectangle rect = Screen.GetWorkingArea(this);
                            var input = int.Parse(Interaction.InputBox("请输入控件编号" + tip,
                                "输入控件编号", old, rect.Width / 3, rect.Height / 3)
                                .CheckValue(old));
                            item.SubItems[15].Text = ((FormControlType)input).ToString();
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
                        //编辑
                        if (editRegix)
                        {
                            Rectangle rect = Screen.GetWorkingArea(this);
                            var value = Interaction.InputBox("请输入修改后的正则表达式(清除验证输入0,默认验证输入1，非空验证输入空白)",
                                "修改正则验证", item.SubItems[14].Text, rect.Width/3, rect.Height/3);

                            item.SubItems[14].Text = value=="0"?"null" : value == "1"?"{max:50,min:2}": value;
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
            if (!rtb_output_add.Text.HasValue())
            {
                TipError("请选择数据源并配置好相应参数后再点击生成按钮");
                return;
            }
            if (ck_test.Checked)
            {

                if (ck_rechoose.Checked)
                {
                    OpenFolderBrowserDialog();
                }
                else
                {
                    WriteDebugFiles();
                }
            }
            else
            {
                if (!ck_add.Checked && !ck_update.Checked && !ck_detail.Checked)
                {
                    TipError("至少勾选一个要生成的界面");
                    return;    
                }
                if (ck_rechoose.Checked)
                {
                    OpenSaveFileDialog();
                }
                else
                {
                    WriteJsFiles();
                }
            }
          
        }
        #region 保存对话框

        private void WriteJsFiles()
        {
            var addJs = GetPath(LastDir, "Add");
            var updateJs = GetPath(LastDir, "Update");
            var detailJs = GetPath(LastDir, "Detail");
            if (ck_add.Checked)
            {
                rtb_output_add.Text.WriteFile(addJs);
            }
            if (ck_update.Checked)
            {
                rtb_output_update.Text.WriteFile(updateJs);
            }
            if (ck_detail.Checked)
            {
                rtb_output_detail.Text.WriteFile(detailJs);
            }
            TipInfo("写入成功");
        }
        private void WriteDebugFiles()
        {
            var id = DbName.Replace(".", "-") + "-" + DateTime.Now.FormatTime(false);
            var visitDir = "debug\\" + DbName.Replace(".", "-") + "\\" + DateTime.Now.FormatTime(false) + "\\";
            var debugDir = LastDir + "\\web\\debug\\";
            var destDir = LastDir + "\\web\\" + visitDir;
            var testJs = LastDir + "\\web\\core\\test\\" + "all.js";
            var testJsBak = LastDir + "\\web\\core\\test\\" + "all-bak.js";
            var addJs = destDir + "add.js";
            var editJs = destDir + "update.js";
            var detailJs = destDir + "detail.js";
            var deleteJs = destDir + "delete.js";
            var itemsJs = destDir + "items.js";
            var listJs = destDir + "list.js";
            var content = (ck_clean.Checked ? testJsBak : testJs).ReadFile().Replace("cfg = [];", "cfg=[];").Replace("cfg=[];", string.Format(
@"cfg=[];
    cfg.push(input('', '{0}', '', 6));
    cfg.push(dropdown('{0}',
              [
                  {{ text: '添加', value: '*f/{1}add', id: '{0}-add' }},
                  {{ text: '编辑', value: '*f/{1}update', id: '{0}-update' }},
                  {{ text: '详情', value: '*f/{1}detail', id: '{0}-detail' }},      
                  {{ text: '删除', value: '{2}', id: '{0}-delete' }},
                  {{ text: '下拉', value: '*f/{1}items', id: '{0}-items' }},
                  {{ text: '列表', value: '*f/{1}list', id: '{0}-list' }}
              ]));", id, visitDir.Replace("\\", "/"), rtb_output_delete.Text)).
          Replace("testIdArray = [", "testIdArray=[").Replace("testIdArray=[", "testIdArray=['" + id + "',");
            if (ck_clean.Checked)
            {//清理调试目录
                Directory.Delete(debugDir, true);
                Directory.CreateDirectory(debugDir);
            }

            content.WriteFile(testJs, true);
            rtb_output_add.Text.WriteFile(addJs);
            rtb_output_update.Text.WriteFile(editJs);
            rtb_output_detail.Text.WriteFile(detailJs);
            rtb_output_delete.Text.WriteFile(deleteJs);
            rtb_output_items.Text.WriteFile(itemsJs);
            rtb_output_list.Text.WriteFile(listJs);
            TipInfo("写入成功");
           
        }
        private void OpenSaveFileDialog()
        {
              var sfd = new SaveFileDialog();
            sfd.InitialDirectory = "E:\\svn\\jwxt\\html\\web\\";
            //设置文件类型 
            sfd.Filter = "javascript文件（*.js）|";

            //设置默认文件类型显示顺序 
            sfd.FilterIndex = 1;

            //保存对话框是否记忆上次打开的目录 
            sfd.RestoreDirectory = true;

            //点了保存按钮进入 
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                LastDir = sfd.FileName;
                WriteJsFiles();
            }
        }
        private void OpenFolderBrowserDialog()
        {
            var fbd = new FolderBrowserDialog();
           
            fbd.Description = "请选择前端项目所在目录，推荐路径为E:/svn/jwxt/html";

            //点了保存按钮进入 
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                
                if (!Directory.Exists(fbd.SelectedPath + "\\web\\debug\\"))
                {
                    TipError("目录选择错误，请确保选择了正确的前端项目目录");
                    return;
                }
                LastDir = fbd.SelectedPath;
                WriteDebugFiles();
            }
        }

        #endregion




        private void bt_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ck_test_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_test.Checked)
            {
                ck_add.Checked = true;
                ck_detail.Checked = true;
                ck_update.Checked = true;
                ck_delete.Checked = true;
                ck_items.Checked = true;
                ck_list.Checked = true;

                ck_add.Enabled = false;
                ck_detail.Enabled = false;
                ck_update.Enabled = false;
                ck_delete.Enabled = false;
                ck_items.Enabled = false;
                ck_list.Enabled = false;
            }
            else
            {
                ck_rechoose.Checked = true;
                ck_rechoose.Enabled = false;

                ck_clean.Checked = false;
                ck_delete.Checked = false;
                ck_items.Checked = false;
                ck_list.Checked = false;

                ck_add.Enabled = true;
                ck_detail.Enabled = true;
                ck_update.Enabled = true;
              
            }
           
        }
        private void ck_clean_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_clean.Checked)
            {
                ck_test.Checked = true;
                ck_test.Enabled = false;
            }
            else
            {
                ck_test.Enabled = true;
            }
           
        }

        private void ck_pre_CheckedChanged(object sender, EventArgs e)
        {
            Step2(ck_pre.Checked);
        }

      
    }
}