using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeTool.Entity;
using CodeTool.Extension;
using CodeTool.Helper;
using CodeTool.Models;
using CodeTool.Properties;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Models.Report;
using Microsoft.VisualBasic;
namespace CodeTool
{
    public partial class ReportTool : BaseDbForm
    {
        public ReportTool()
        {
            InitializeComponent();
        }
        string dbName = "";
        private List<string> cbItems;
        private void ReportTool_Load(object sender, EventArgs e)
        {
            // 初始化状态
            tb_reportId.Visible = false;
            ChangeStateTo(CheckStateEnum.NeverCheck);
            ChangeStateTo(FormStateEnum.AddReport);
            //可用数据库列表
            cbItems = ConnectionStrings.Select(a => a.Name).ToList();
            //创建根节点
            tv_dataBase.Nodes.Add(NewNodeWithEmptyChild("数据源"));
           // tv_dataBase.Nodes[0].Expand();
            //加载报表
           // ListViewBinding(lv_reports, REPORT_HEADER, SQL_REPORTS(tb_queryReportId.Text,tb_queryReportName.Text).ExecuteQuery());
            //加载连接字符串
            ComBoxBinding(cb_connString, cbItems);
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
            #region 自动选择数据源
            cb_connString.SelectedIndex = cb_connString.Items.IndexOf(dbName);
            #endregion
        }

        void Step1()
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
                    var row = new List<string> {
                        nodeTag[0],
                        nodeTag[1],
                        nodeTag[2],
                        nodeTag[3],
                        nodeTag[4],
                        (sequence++).ToString(),
                         nodeTag[5],
                         nodeTag[6],
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
                 "外键列名",
                  "外键表名"
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
            var tableList = new List<TableModel>();
            var tableRelationList = new List<TableRelationModel>();
            var reportTableName = "";
            var reportDataBase = dbName;
            var reportHeadears = "";
            var reportColumToShow = "";
            var reportSql_select = "Select ";
            var reportSql_from = "From ";
            var reportSql_where = " ";
            //var reportSql_where_relation = " ";
            var columnIndex = 0;
            foreach (ListViewItem row in rows)
            {
                var id = row.SubItems[0].Text.TrimString();
                var columName = row.SubItems[1].Text.TrimString();
                var columNote = row.SubItems[2].Text.TrimString() + //防止列明重复
                    (rows.Cast<ListViewItem>().Count(a=>a.SubItems[2].Text == row.SubItems[2].Text)>1 ?"":"");
                var tableName = row.SubItems[3].Text.TrimString();
                var foreginColumName = row.SubItems[6].Text.TrimString();
                var foreginTableName = row.SubItems[7].Text.TrimString();
                var isHidden = bool.Parse(row.SubItems[4].Text.TrimString());

                //加入tables
                tableList.AddIfNotExsit(tableName);
                //加入relation
                if (foreginTableName.HasValue())
                {
                    tableRelationList.AddIfNotExsit(tableName, columName, columNote,
                    foreginTableName, foreginColumName);
                }
                //拼接Headears
                reportHeadears += columNote + ";";
                //处理重复columNote
                if (reportHeadears.UnPackString(';').FindAll(a => a == columNote).Count > 1)
                {
                    columNote += columNote + "_1";
                }
                reportSql_select += string.Format("\n  {0}.{1} as '{2}' ,", tableName, columName, columNote);
                if (!isHidden)
                {
                    //拼接ColumToShow
                    reportColumToShow += columnIndex + ";";
                }
                //计数累加
                columnIndex++;
            }
            //拼接relation
            tableRelationList.ForEach(r =>
            {
                //关系的主表 和 引用表 都存在于 已勾选的表 中时才生成连接语句
                if (tableList.Contains(r.TableName)&& tableList.Contains(r.ForeginTableName))
                {
                    reportSql_where += string.Format("\n {0}.{1}={2}.{3} and", r.TableName,
                        r.ColumName, r.ForeginTableName, r.ForeginColumName);
                }
            });

            //清除select中sql最后一个,
            reportSql_select = reportSql_select.Substring(0, reportSql_select.Length - 2);
            //拼接from和where子句
            foreach (var table in tableList)
            {
                reportSql_from += "\n" + table.TableName + ",";
                reportTableName += table.TableName + "|";
            }
             //清除Headears中最后一个;
             reportHeadears = reportHeadears.Substring(0, reportHeadears.Length - 1);
            //清除from中sql最后一个,
            reportSql_from = reportSql_from.Substring(0, reportSql_from.Length - 1); 
            //清除where中sql最后一个and
            reportSql_where = reportSql_where.HasValue() ? "\n Where "+reportSql_where.Substring(0, reportSql_where.Length - 4):"";
            //清除reportTableName中最后一个-
            reportTableName = reportTableName.Substring(0, reportTableName.Length - 1);
      
            //赋值
            tb_reportName.Text = DateTime.Now.Random();
            tb_reportId.Text = string.Format("{0}.{1}.{2}", reportDataBase, DateTime.Now.Random().Substring(0,3), tb_reportName.Text);
            rtb_headears.Text = reportHeadears;
            tb_columToShow.Text = reportColumToShow;
            #region 不更新CheckError和CheckPass状态的where子句
           /* if (_checkState == CheckStateEnum.CheckError|| _checkState == CheckStateEnum.CheckPass)
            {
                var oldSql = rtb_sql.Text;
                var indexOfWhere = oldSql.ToLower().IndexOf("where", StringComparison.Ordinal);
                if (indexOfWhere > -1)
                {
                    var oldSqlOfWhere = oldSql.Substring(indexOfWhere, oldSql.Length - indexOfWhere);
                    reportSql_where = oldSqlOfWhere;
                }
            }*/
            #endregion
            rtb_sql.Text = string.Format("{0} {1} {2}", reportSql_select, reportSql_from, reportSql_where);
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            
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
                obj.Sequence = item[5];
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
                    Where(a=> cbItems.Contains(a[0])).
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
                 => new string[] { row[1],
                      string.Format("{0};{1};{2};{3};{4};{5};{6}", DateTime.Now.Random(), row[1], row[2], row[3], row[4], row[10], row[11]) }).ToArray()));
                }
               
                // MessageBox.Show("正在获字段列表" + e.Node.Text + e.Action.ToString());
            }
        }

        private void bt_query_Click(object sender, EventArgs e)
        {
            ListViewBinding(lv_reports, REPORT_HEADER, SQL_REPORTS(tb_queryReportId.Text, tb_queryReportName.Text).ExecuteQuery());
        }

        private void tb_reportName_TextChanged(object sender, EventArgs e)
        {
            #region 不更新EditReport状态的reportId
            if (_formState == FormStateEnum.EditReport)
            {
                return;
            }
            #endregion
            var reportId = tb_reportId.Text;
            reportId = reportId.Substring(0, reportId.LastIndexOf('.')+1);
            tb_reportId.Text = reportId + tb_reportName.Text;
            ReFreshState();
        }

        private void bt_check_Click(object sender, EventArgs e)
        {
            #region 前置条件检测

            if (cb_connString.SelectedIndex < 0)
            {
                TipError("请选择测试数据源");
                cb_connString.Focus();
                return;
            }

            if (rtb_sql.Text.HasValue())
            {
                if (rtb_sql.Text.Contains("XXX.XXX"))
                {
                    TipError("请先修改sql语句的where条件");
                    rtb_sql.Focus();
                    return;
                }
            }
            else
            {
                TipError("请先选择字段");
                tv_dataBase.Focus();
                return;

            }
            #endregion
            try
            {
                var data=_reportServices.Test(FormReport, tb_deafultParam.Text, cb_connString.Text);
                var header = data[0];
                data.RemoveAt(0);
                var body = data;
                ListViewBinding(lv_preview, header,body);
                //改变成已检查状态
                ChangeStateTo(CheckStateEnum.CheckPass);
            }
            catch (Exception ex)
            {
                ChangeStateTo(CheckStateEnum.CheckError);
                TipError("检查失败！错误信息：" + ex.Message);
            }
        }
        #region 报表配置状态
        private CheckStateEnum _checkState=CheckStateEnum.NeverCheck;
        protected void ChangeStateTo(CheckStateEnum targetState)
        {
            _checkState = targetState;
            if (targetState == CheckStateEnum.CheckPass)
            {
                bt_submit.Enabled = true;
                bt_submit.ForeColor = Color.Green;
                bt_submit.Text = "7.提交";
            }
            else
            {
                bt_submit.Enabled = false;
                bt_submit.ForeColor = Color.Red;
                bt_submit.Text = "请先[检查]";
            }
            ReFreshState();
        }
        private FormStateEnum _formState = FormStateEnum.AddReport;
        protected void ChangeStateTo(FormStateEnum targetState)
        {
            _formState = targetState;
            if (_formState == FormStateEnum.AddReport)
            {
                p_addReport.Enabled = true;
                gp_manageReport.Enabled = false;
            }
            else if(_formState == FormStateEnum.EditReport)
            {
                p_addReport.Enabled = false;
                gp_manageReport.Enabled = false;
            }
            else
            {
                p_addReport.Enabled = false;
                gp_manageReport.Enabled = true;
            }
            ReFreshState();
        }
        #region 刷新状态条
        void ReFreshState()
        {
            tssl_State.Text =string.Format("当前时间:{0} | FormState:{1} | CheckState:{2} | CurrentReport:{3}",
                DateTime.Now, _formState.ToString(), _checkState.ToString(),tb_reportId.Text);
        }
        #endregion
        #endregion
        #region 更新报表
        bool UpdateReport(report_data report)
        {
            var saveOk = false;
            try
            {
                Db.report_data.AddOrUpdate(report);
                saveOk = Db.SaveChanges()>0;
            }
            catch (Exception ex)
            {
                TipInfo("报表提交发生异常，异常信息:"+ex.Message);
            }
            TipInfo(saveOk ? "报表提交成功！" : "报表提交失败！");
            return saveOk;
        }
        bool UpdateReport(ReportModel form)
        {
            var report = new report_data()
            {
                ReportID = form.ReportID,
                ReportName = form.ReportName,
                HeadFields = form.HeadFields,
                ColunmToShow = form.ColunmToShow,
                OperateColum = form.OperateColum,
                ParaNames = form.ParaNames,
                RecordsPerPage = form.RecordsPerPage,
                ReportLog = form.RecordsPerPage + ";" + DateTime.Now.ToTimeStr() + "从winform中添加",
                SqlStr = form.SqlStr
            };
            return UpdateReport(report);
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            if (_checkState == CheckStateEnum.CheckPass)
            {
                ChangeStateTo(CheckStateEnum.NeverCheck);
                if (UpdateReport(FormReport))
                {
                    var f = new AutoCode(tb_reportId.Text,tb_reportName.Text,tb_deafultParam.Text,tb_perCount.Text,cb_connString.Text);
                    f.Show();
                }
            }
            else
            {
                TipError("提交失败，提交前请先点击[检查]！");
                bt_check.Focus();
            }
        }

        private void bt_dubeg_Click(object sender, EventArgs e)
        {
            try
            {
                var item = GetSelectedRow(lv_reports);
                var reportId = item[0];
                var reportName = item[1];
                var sql = item[2];
                var headears = item[3];
                var perCount = int.Parse(item[4]);
                var deafultParam = item[5];
                var columToShow = item[6];
                var operateColum = item[7];
                var data = _reportServices.Test(new ReportModel()
                {
                    ReportID = reportId,
                    ReportName = reportName,
                    HeadFields = headears,
                    SqlStr = sql,
                    RecordsPerPage = perCount,
                    ColunmToShow = columToShow,
                    OperateColum = operateColum,
                    ParaNames = deafultParam
                }, tb_deafultParam.Text, cb_connString.Text);
                var header = data[0];
                data.RemoveAt(0);
                var body = data;
                ListViewBinding(lv_preview, header, body);   
            }
            catch (Exception ex)
            {
                TipError("调试失败！错误信息：" + ex.Message);
            }
        }

        #region 界面控件赋值
        ReportModel FormReport
        {
            get
            {
                return new ReportModel()
                {
                    ReportID = tb_reportId.Text,
                    ReportName = tb_reportName.Text,
                    HeadFields = rtb_headears.Text,
                    SqlStr = rtb_sql.Text,
                    RecordsPerPage = int.Parse(tb_perCount.Text),
                    ColunmToShow = tb_columToShow.Text,
                    OperateColum = rtb_oprate.Text,
                    ParaNames = tb_deafultParam.Text
                };
            }
        }

        void SetFormReport(string reportId, string reportName, string headears,
            string columToShow, string sql, string oprate,
            string deafultParam, string perCount)
        {
            tb_reportName.Text = reportName;
            tb_reportId.Text = reportId;
            rtb_headears.Text = headears;
            tb_perCount.Text = perCount;
            tb_columToShow.Text = columToShow;
            rtb_sql.Text = sql;
            rtb_oprate.Text= oprate;
            tb_deafultParam.Text = deafultParam;
            //改变状态
            ChangeStateTo(CheckStateEnum.NeverCheck);
            ChangeStateTo(FormStateEnum.EditReport);
        }
        private void bt_edit_Click(object sender, EventArgs e)
        {
            var item = GetSelectedRow(lv_reports);
            if (!item.Any())
            {
                TipInfo("请先在[" + lv_reports.Text + "]列表中选中要操作的行！");
                return;
            }
            //tb_reportId.Text = item[0];
            //tb_reportName.Text = item[1];
            //rtb_sql.Text = item[2];
            //rtb_headears.Text = item[3];
            //tb_perCount.Text = item[4];
            //tb_deafultParam.Text = item[5];
            //tb_columToShow.Text = item[6];
            //rtb_oprate.Text = item[7];
            SetFormReport(item[0], item[1], item[3],
                            item[6], item[2], item[7], 
                            item[5], item[4] );
          
        }
        #endregion

        private void bt_delete_Click(object sender, EventArgs e)
        {
           // TipInfo("此功能已被管理员禁用！");
            //return;
            try
            {
                var item = GetSelectedRow(lv_reports);
                if (!item.Any())
                {
                    TipInfo("请先在[" + lv_reports.Text + "]列表中选中要操作的行！");
                    return;
                }
                var reportId = item[0];
                Db.report_data.Remove(Db.report_data.Find(reportId));
                Db.SaveChanges();
                TipInfo("[" + reportId + "]已删除,请手动刷新列表！");

            }
            catch (Exception ex)
            {
                TipError("删除失败！异常信息:"+ex.Message);
            }
            
          
        }

        private void bt_copy_Click(object sender, EventArgs e)
        {
            try
            {
                var item = GetSelectedRow(lv_reports);
                if (!item.Any())
                {
                    TipInfo("请先在[" + lv_reports.Text + "]列表中选中要操作的行！");
                    return;
                }
                var reportId = item[0];
                var report = Db.report_data.Find(reportId);
                report.ReportID += ".copy";
                UpdateReport(report);
                Db.report_data.AddOrUpdate(report);
            }
            catch (Exception)
            {
                TipError("复制出错！");
            }   
        }

        private void p_addReport_Click(object sender, EventArgs e)
        {
            if (_formState == FormStateEnum.ManageReport)
            {
                TipInfo("请点击[添加]按钮切换至报表编辑页面");
                bt_add.Focus();
            }
            ChangeStateTo(FormStateEnum.AddReport);
        }

        private void p_manageReport_Click(object sender, EventArgs e)
        {
            if (_formState== FormStateEnum.EditReport)
            {
                DialogResult choose = MessageBox.Show("现在离开编辑区可能会丢失对当前报表的更改,确认要不保存离开编辑区吗?", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (choose == DialogResult.No)
                {
                    return;
                }
            }
            ChangeStateTo(FormStateEnum.ManageReport);
        }

        private void bt_add_Click(object sender, EventArgs e)
        {
            ChangeStateTo(FormStateEnum.AddReport);
        }

        private void lv_colums_KeyDown(object sender, KeyEventArgs e)
        {
            //按键过滤
            var key = e.KeyCode.ToString().ToLower();
            if (!(key == "w" || key == "s" || key == "a" || key == "d" || key == "e"))
                return;
            //按键判断
            int moveUp=0;
            int showThis=0;
            int editThis=0;
            switch (key)
            {
                case "w":
                    moveUp = 1;
                    break;
                case "s":
                    moveUp = 2;
                    break;
                case "a":
                    showThis = 1;
                    break;
                case "d":
                    showThis = 2;
                    break;
                case "e":
                    editThis = 1;
                    break;
                default:
                    moveUp = 0;
                    showThis = 0;
                    editThis = 0;
                    break;
            }
           
           
            var items = (ListView)sender;
            if (items.SelectedItems.Count > 0)
            {
                //定位
                var selectItem = items.SelectedItems[0];
                for (var index=0 ;index< lv_colums.Items.Count;index++)
                {
                    var item = lv_colums.Items[index];
                    if (item.Text.ToLower() == selectItem.Text.ToLower())//匹配
                    {
                        //编辑
                        if (editThis == 1)
                        {
                            Rectangle rect = Screen.GetWorkingArea(this);
                            item.SubItems[2].Text = Interaction.InputBox("请输入修改后的字段说明",
                                "修改字段说明", item.SubItems[2].Text, rect.Width/3, rect.Height/3).CheckValue(item.SubItems[2].Text);
                        }
                        //显示/不显示
                        if (showThis == 1)
                        {
                            item.SubItems[4].Text = true.ToString();
                        }else if (showThis == 2)
                        {
                            item.SubItems[4].Text = false.ToString();
                        }
                        //上移/下移
                        var currSeq = item.SubItems[5].Text;
                        if (moveUp==1)
                        {
                            if (index > 0)
                            {
                                var preSeq = lv_colums.Items[index - 1].SubItems[5].Text;
                                item.SubItems[5].Text = preSeq;
                                lv_colums.Items[index - 1].SubItems[5].Text = currSeq;
                            }
                            else
                            {
                                TipInfo("已经移到最上面了！");
                            }
                        }
                        else if (moveUp == 2)
                        {
                            if (index < lv_colums.Items.Count-1)
                            {
                                var afterSeq = lv_colums.Items[index + 1].SubItems[5].Text;
                                item.SubItems[5].Text = afterSeq;
                                lv_colums.Items[index + 1].SubItems[5].Text = currSeq;
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
        protected override void FreshListView(ListView lv)
        {
            if (lv.Items.Count == 0)
            {
                dbName = "";
            }
            base.FreshListView(lv);
        }
    }
}
