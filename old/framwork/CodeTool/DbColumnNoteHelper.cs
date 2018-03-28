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
using Qx.Tools.CommonExtendMethods;

namespace xyj.tool
{
    public partial class DbColumnNoteHelper : BaseDbForm
    {
        public DbColumnNoteHelper()
        {
            InitializeComponent();
        }

        private void DbColumnNoteHelper_Load(object sender, EventArgs e)
        {
            var head = new List<string>()
            {
                "编号",
                "名称",
                "表达式",
                "输入提示",
                "错误提示",
                "功能说明"
            };   
            ListViewBinding(lv_regex, head,SQL_Regex().ExecuteReader2(ConnectionString("sys.core")));
        }

        private void tb_error_tip_TextChanged(object sender, EventArgs e)
        {
            rtb_output.Text = tb_note.Text+"{#C1:"+ tb_regex.Text+":"+ tb_error_tip.Text+"#}";
              
       
        }

        private void lv_regex_DoubleClick(object sender, EventArgs e)
        {
            if (lv_regex.SelectedItems.Count > 0)
            {
                var selectedItem = lv_regex.SelectedItems[0].SubItems;

                tb_regex.Text = selectedItem[2].Text;
                tb_error_tip.Text = selectedItem[4].Text;
                tb_error_tip_TextChanged(sender, e);
            }
        }
    }
}
