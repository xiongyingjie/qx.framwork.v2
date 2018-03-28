using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyj.tool.Extension;
using xyj.tool.Helper;
using Qx.Tools.CommonExtendMethods;

namespace xyj.tool
{
    public partial class OperateConfig : BaseDbForm
    {
        public OperateConfig()
        {
            InitializeComponent();
        }



        string dest = "";

        int _param
        {
            get
            {
                return Convert.ToInt32(nud_param.Value);
            }  
        }
        int _condition
        {
            get
            {
                return Convert.ToInt32(nud_condition.Value);
            }
        }
        string _operate
        {
            get
            {
                var t = "";
                switch (cb_can_click.SelectedIndex)
                {
                    case 0:
                        //是表单
                        tb_url.Enabled = true;
                        switch (_param)
                        {
                            case 0:
                                t = "<a href='*f" + tb_url.Text + "'>" + tb_operate.Text + "</a>";
                                break;
                            case 1:
                                t = "<a href='*f" + tb_url.Text + "?id={0}'>" + tb_operate.Text + "</a>";
                                break;
                            case 2:
                                t = "<a href='*f" + tb_url.Text + "?id1={0}&?id2={1}'>" + tb_operate.Text + "</a>";
                                break;
                        }
                        break;
                    case 1:
                        //是报表
                        tb_url.Enabled = true;
                        switch (_param)
                        {
                            case 0:
                                t = "<a href='*r" + tb_url.Text + "'>" + tb_operate.Text + "</a>";
                                break;
                            case 1:
                                t = "<a href='*r" + tb_url.Text + "?id={0}'>" + tb_operate.Text + "</a>";
                                break;
                            case 2:
                                t = "<a href='*r" + tb_url.Text + "?id1={0}&?id2={1}'>" + tb_operate.Text + "</a>";
                                break;
                        }
                        break;
                    case 2:
                        //是删除
                        tb_url.Enabled = true;
                        switch (_param)
                        {
                            case 0:
                                TipError("删除操作至少设置一个参数");
                                   break;
                            case 1:
                                if (!cb_db.Text.HasValue() || !cb_table.Text.HasValue())
                                {
                                    TipError("删除操作必须选择目标库和表");
                                    cb_db.Focus();
                                }
                                else
                                {
                                    t = "<a href='" + cb_db.Text + "." + cb_table.Text + "@delete-{0}'>" + tb_operate.Text + "</a>";
                                }
                                break;
                            case 2:
                                TipError("删除操作只能设置一个参数");
                                break;
                        }
                        break;
                    case 3:
                        //可点击
                        tb_url.Enabled = true;
                        switch (_param)
                        {
                            case 0:
                                t = "<a href='" + tb_url.Text + "'>" + tb_operate.Text + "</a>";
                                break;
                            case 1:
                                t = "<a href='" + tb_url.Text + "?id={0}'>" + tb_operate.Text + "</a>";
                                break;
                            case 2:
                                t = "<a href='" + tb_url.Text + "?id1={0}&?id2={1}'>" + tb_operate.Text + "</a>";
                                break;
                        }
                        break;
                    case 4:
                        //不可点击
                        tb_url.Enabled = false;
                        t = tb_operate.Text;
                        break;
                  
                }
                return t;
            }
        }


        void UpdateOutPut(object sender, EventArgs e)
        {
          
            p_condition_1.Enabled = false;
            p_param_1.Enabled = false;
            p_param_2.Enabled = false;
            tb_url.Enabled = false;
            var type = "";
            switch (_condition)
            {
                case 0://无条件
                    {
                        type = "N" + _param;
                        switch (_param)
                        {
                            case 0:
                                dest = string.Format("{0}:{1};", type, _operate);
                                break;
                            case 1:
                                p_param_1.Enabled = true;
                                dest = string.Format("{0}:{1}:{2};", type, _operate ,nud_param_1.Value);
                                break;
                            case 2:
                                p_param_1.Enabled = true;
                                p_param_2.Enabled = true;
                                dest = string.Format("{0}:{1}:{2}:{3};", type,  _operate, nud_param_1.Value, nud_param_2.Value);
                                break;
                        }
                    }


                    break;
                case 1://一个条件
                    {
                        p_condition_1.Enabled = true;
                        type = "YC" + _param;
                        switch (_param)
                        {
                            case 0:
                                dest = string.Format("{0}:{1}:{2}:{3}:{4};", type, nud_conditon_1.Value,cb_condition_oprator.Text,tb_conditon_value_1.Text, _operate);
                                break;
                            case 1:
                                p_param_1.Enabled = true;
                                dest = string.Format("{0}:{1}:{2}:{3}:{4}:{5};", type, nud_conditon_1.Value, cb_condition_oprator.Text, tb_conditon_value_1.Text, _operate, nud_param_1.Value);
                                break;
                            case 2:
                                p_param_1.Enabled = true;
                                p_param_2.Enabled = true;
                                dest = string.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6};", type, nud_conditon_1.Value, cb_condition_oprator.Text, tb_conditon_value_1.Text, _operate, nud_param_1.Value, nud_param_2.Value);
                                break;
                        }
                    }

                    break;

            }
            tb_output.Text = dest;
        }
        private void bt_submit_Click(object sender, EventArgs e)
        {
            UpdateOutPut(sender, e);
            FormApplication.ReportTool.AddOperateConfig(dest);
        }
        private void OperateConfig_Load(object sender, EventArgs e)
        {
            nud_condition.Value = 0; 
            nud_condition.Value = 0;
            cb_can_click.SelectedIndex = 0;
            panel3.Visible =false;
            cb_condition_oprator.SelectedIndex = 0;
            ComBoxBinding(cb_db, SQL_DATABASE.ExecuteQuery().
                    Select(row => row[0]));
            UpdateOutPut(sender, e);
        }

        private void cb_can_click_SelectedIndexChanged(object sender, EventArgs e)
        {
            tb_operate.Text = cb_can_click.SelectedIndex == 2 ? "删除" : "添加，编辑，详情";
            panel1.Visible = cb_can_click.SelectedIndex != 2;
            panel3.Visible = !panel1.Visible;
        }

        private void cb_db_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComBoxBinding(cb_table, SQL_TABLE().ExecuteQuery(cb_db.Text).
                  Select(row => row[0]));
        }

        private void tb_op2_TextChanged(object sender, EventArgs e)
        {
            tb_operate.Text = tb_op2.Text;
        }
    }
}
