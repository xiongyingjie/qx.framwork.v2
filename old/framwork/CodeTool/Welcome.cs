using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyj.tool.Helper;
using System.Configuration;
using System.Threading;
using xyj.tool.Extension;
using Qx.Report.Services;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Qx.Tools.Services;

namespace xyj.tool
{
    public partial class Welcome : BaseDbForm
    {
        public Welcome()
        {
             InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

         private void Test_Load(object sender, EventArgs e)
        {
            //new {orgnization_id = "teadf", father_id = "1165", name = "dddddd"}
            //var all = _repository.Query();
            //var insert = _repository.Insert(new { ToDoId = "RPYJR7CBNTW", NodeRelationID = "1165", WhoShouldDo = "dddddd" });
            //var find = _repository.Find("RPYJR7CBNTW");
            //var delete = _repository.Delete("RPYJR7CBNTW");
            //var  count = _repository.Query().ToObject();

            /*  
             Web.Controllers
             Web.Areas.*.Controllers
             */
            //var path = "E:\\AutoReportController.cs";
            //var code = path.ReadFile();
            //var tempCode = code.TrimString().TrimString("\r\n");
            //var area= tempCode.PickUp("Web.Areas.", ".Controllers", "namespace", "{");
            //var controller = tempCode.PickUp("class", "Controller", "public", ":");
            //TipInfo("area:" + area+ "\ncontroller:" + controller);
            //          code.Substring(code.IndexOf("namespace",code.))
            //            code = code.ReplaceLastAt(2, "}",
            //@"//自动生成开始

            ////自动生成结束
            //}
            //");
            // TipInfo(code);
            cb_function.SelectedIndex = 1;
            bt_do.Focus();
            new Thread(() =>
            {
                try
                {
                     _permissionProvider.Login(tb_uid.Text, tb_psw.Text);
                }
                catch (Exception)
                {
                   // TipError("网络连接失败，请检查系统防火墙！");
                }
            }).Start();

        }

        private void bt_do_Click(object sender, EventArgs e)
        {
            
            var  checkOk = false;
            try
            {
                checkOk =_permissionProvider.Login(tb_uid.Text,tb_psw.Text);
            }
            catch (Exception)
            {
                TipError("网络连接失败，请检查系统防火墙！");
            }
            if (checkOk)
            {
                if (cb_function.SelectedIndex == 0)
                {
                    //TipInfo("环境配置正确，正在启动报表生成器...");
                    new ReportTool().Show();

                }
                else if (cb_function.SelectedIndex == 1)
                {
                    //TipInfo("环境配置正确，正在启动表单生成器...");
                    new FormTool2().Show();
                
                }
                else if (cb_function.SelectedIndex == 2)
                {
                    //TipInfo("开发中...");
                    //TipInfo("环境配置正确，正在启动一键增删改...");
                    new CrudTool().Show();
                }
                else if (cb_function.SelectedIndex == 3)
                {
                    //TipInfo("环境配置正确，正在启动验证配置助手...");
                    new DbColumnNoteHelper().Show();
                }
                else
                {
                    TipInfo("环境检查失败，请尝试更新版本!");
                }

            }
            else
            {
                TipInfo("账号或密码错误!");
            }
          
        }

      

        private void rtb_info_TextChanged(object sender, EventArgs e)
        {
            if (rtb_info.Text == "panda")
            {
                new FormTool().Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
