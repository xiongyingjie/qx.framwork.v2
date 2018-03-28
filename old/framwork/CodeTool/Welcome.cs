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
using System.IO;
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

            #region 读取配置文件
           
             if (!File.Exists(configFilePath))
             {
                 "|".WriteFile(configFilePath,true);
             }
             var configFile = configFilePath.ReadFile();
             if (!configFile.Contains('|') || configFile.Split('|').Length != 2)
             {
                 configFile= "|";
                 configFile.WriteFile(configFilePath, true);
                 TipError("配置文件格式错误，已自动恢复默认配置");

             }
             tb_html_dir.Text = configFile.Split('|')[0];
             tb_csharp_dir.Text = configFile.Split('|')[1];
            #endregion


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
                if(!Directory.Exists(tb_csharp_dir.Text + "\\Controllers"))
                {
                    TipError("检测到配置文件错误，请确保配置了正确的后端项目目录");
                    lb_csharp_dir_Click(sender, e);
                    return;
                }
                if (!Directory.Exists(tb_html_dir.Text + "\\addons\\sys\\template\\views\\form\\debug"))
                {
                    TipError("检测到配置文件错误，请确保配置了正确的前端项目目录");
                    lb_html_dir_Click(sender, e);
                    return;
                }
                csharp_dir = tb_csharp_dir.Text;
                html_dir = tb_html_dir .Text;
                //写配置文件
                (html_dir + "|" + csharp_dir).WriteFile(configFilePath, true);
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
                    new ReportTool(html_dir,csharp_dir).Show();

                }
                else if (cb_function.SelectedIndex == 1)
                {
                    //TipInfo("环境配置正确，正在启动表单生成器...");
                    new FormTool2(html_dir, csharp_dir).Show();
                
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

        private void lb_html_dir_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.Description = "请选择前端项目所在目录，推荐路径为E:/svn/jwxt/html";

            //点了保存按钮进入 
            if (fbd.ShowDialog() == DialogResult.OK)
            {

                if (!Directory.Exists(fbd.SelectedPath + "\\addons\\sys\\template\\views\\form\\debug"))
                {
                    TipError("检测到配置文件错误，请确保选择了正确的前端项目目录");
                    return;
                }
                tb_html_dir.Text = fbd.SelectedPath;
            }

        }
     
        private void lb_csharp_dir_Click(object sender, EventArgs e)
        {

            var fbd = new FolderBrowserDialog();
            fbd.Description = "请选择后端项目所在目录，推荐路径为E:/svn/jwxt/src/web";
            //点了保存按钮进入 
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (!Directory.Exists(fbd.SelectedPath + "\\Controllers"))
                {
                    TipError("检测到配置文件错误，请确保选择了正确的后端项目目录");
                    return;
                }
                tb_csharp_dir.Text = fbd.SelectedPath;
            }
        }
    }
}
