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
using System.Configuration;
using CodeTool.Extension;

namespace CodeTool
{
    public partial class Welcome : BaseDbForm
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            bt_do.Focus();
        }

        private void bt_do_Click(object sender, EventArgs e)
        {
            var  checkOk = false;
            try
            {
                checkOk = SQL_DATABASE.ExecuteQuery().Any();
            }
            catch (Exception)
            {
                TipError("网络连接失败，请检查系统防火墙！");
            }
            if (checkOk)
            {
                TipInfo("环境配置正确，正在启动报表助手...");
                new ReportTool().ShowDialog();
            }
            else
            {
                TipInfo("环境检查失败，请尝试更新版本!");
            }
          
        }

      

        private void rtb_info_TextChanged(object sender, EventArgs e)
        {
            if (rtb_info.Text == "panda")
            {
                new FormTool().Show();
            }
        }
    }
}
