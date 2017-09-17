using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeTool.Helper;

namespace CodeTool
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
                if (cb_can_click.SelectedIndex == 0)
                {
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
                  
                }
                else
                {
                    tb_url.Enabled = false;
                    t = tb_operate.Text;
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
            cb_condition_oprator.SelectedIndex = 0;
            UpdateOutPut(sender, e);
        }
    }
}
