using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qx.Tools.CommonExtendMethods;

namespace xyj.tool
{
    public partial class AutoCode : Form
    {
        #region 编码和解码
        private const string _LEFT_BRACKET= "#left";
        private const string _RIGHT_BRACKET = "#right";
        private const string _QUOUTE = "#quote";
        string Decode(string str)
        {
            return str.Replace(_LEFT_BRACKET, "{").Replace(_RIGHT_BRACKET, "}").Replace(_QUOUTE, "\"");
        }
        #endregion
        private string _filePath;
        private string _reportId;
        private string _reportName;
        private string _params;
        private string _pageIndex;
        private string _perCount;
        private string _dbKey;
        private string __area;
        private string __controller;
        private string __action;
        
        #region 页面参数
        private string _action
        {
            get { return tb_action.Text; }
        }
        private string _controller
        {
            get { return tb_controller.Text; }
        }
        private string _area
        {
            get { return tb_area.Text; }
        }
        private string _addLink
        {
            get { return tb_addLink.Text; }
        }
        private string _paramNote
        {
            get { return tb_paramNote.Text; }
        }
        #endregion

        #region 代码模板

        string seachCfgTemplate(string name)
        {
            return string.Format(@"
Search.Add(#quote{0}#quote);", name);
        }
        string controllerTemplate
        {
            get {
                var searchCfg = "";
                var paramList = _paramNote.UnPackString(';');
                if (paramList.Any())
                {
                    paramList.ForEach(name =>
                    {
                        searchCfg += seachCfgTemplate(name);
                       
                    });
                }


                return string.Format(@"
//{0}/{1}/{2}
public IActionResult {2}(string reportId, string Params)
#left
if (!reportId.HasValue())
  #left
    return RedirectToAction(#quote{2}#quote, 
        new #left 
           reportId = #quote{3}#quote,Params = #quote{4}#quote, pageIndex = {5}, perCount = {6} 
            #right);
  #right
  {10}
  InitReport(#quote{7}#quote, #quote{8}#quote, #quote#quote, true,#quote{9}#quote);
  return ReportJson();
#right", _area, _controller, _action, _reportId, _params, _pageIndex,
                  _perCount, _reportName, _addLink, _dbKey, searchCfg);
            }
        }




        string viewQueryTemplate(string name)
        {
            return string.Format(@"
            <label>
            {0}:&nbsp;
            @Html.TextBox(#quote{0}#quote, #quote#quote, new #left 
                                                                @class = #quoteform-control input-sm#quote, PlaceHolder = #quote请输入要查询的{0}#quote 
                                                             #right)
            </label>",name);
        }
        string viewSearchTemplate(string name)
        {
            return string.Format(@" v(#quote{0}#quote)+",name);
        }
        string viewTemplate
        {
            get
            {
                var viewQuery = "";
                var viewSearch = "";
                var paramList= _paramNote.UnPackString(';');
                if (paramList.Any())
                {
                    paramList.ForEach(name =>
                    {
                        viewQuery += viewQueryTemplate(name);
                        viewSearch += viewSearchTemplate(name);
                    });
                    //清除viewSearch最后一个+
                    viewSearch= viewSearch.Substring(0, viewSearch.Length - 1);
                }
                else
                {
                    viewQuery = "#quote#quote";
                    viewSearch = "#quote#quote";
                }
                return string.Format(@" 
                                    {0}
                                    <script>
                                        function Search() 
                                           #left
                                             var Params = {1};
                                             return Params;
                                           #right
                                    </script>",
                                    viewQuery, viewSearch); }
        }
        #endregion

        #region 文件对话框
        public void Open()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "控制器文件(*.cs)|*.cs;|所有文件|*.*";
            ofd.ValidateNames = true;
            ofd.CheckPathExists = true;
            ofd.CheckFileExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _filePath = ofd.FileName;
                if (_filePath.HasValue())
                {
                    var code = _filePath.ReadFile();
                    var tempCode = code.TrimString().TrimString("\r\n");
                    var area = tempCode.PickUp("Web.Areas.", ".Controllers", "namespace", "{");
                    var controller = tempCode.PickUp("class", "Controller", "public", ":");
                    tb_area.Text = area;
                    tb_controller.Text = controller;
                }
            }
            else
            {
                if (
                    MessageBox.Show("必须选择一个控制器(放弃代码生成请点击No)", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) ==
                    DialogResult.No)
                {
                    Open();
                }
                else
                {
                    this.Close();
                }
            }
        }

#endregion
        public AutoCode(string reportId,string reportName,
            string param,string perCount,string dbKey, string area, string controller, string action, string filePath)
        {
            _reportId = reportId;
            _reportName = reportName;
            _params = param;
            _pageIndex ="1";
            _perCount = perCount;
            _dbKey = dbKey;
            __area = area;
            __controller = controller;
            __action = action;
            _filePath = filePath;
            InitializeComponent();
        }

        private void AutoCode_Load(object sender, EventArgs e)
        {    
            tb_reportId.Text = _reportId;
            tb_reportName.Text = _reportName;
            tb_params.Text = _params;
            tb_pageIndex.Text = _pageIndex;
            tb_perCount.Text = _perCount;
            tb_paramNote.Text = _params;
            tb_dbKey.Text = _dbKey;
            tb_addLink.Text = "/"+ __area + "/"+ __controller + "/"+ __action.Replace("_list","_add");         
            tb_action.Text ="R"+DateTime.Now.Random();
            tb_area.Text = __area;
            tb_controller.Text = __controller;
            tb_action.Text = __action;
            
            // Open();
        }

        private void bt_generate_Click(object sender, EventArgs e)
        {
            rtb_controllerCode.Text = Decode(controllerTemplate);
            rtb_viewCode.Text = _filePath.ReadFile().ReplaceLastAt(2, "}", Decode(controllerTemplate));
        }

        private void bt_submit_Click(object sender, EventArgs e)
        {
            if (_filePath.ReadFile().ReplaceLastAt(2, "}", Decode(controllerTemplate)+"}").WriteFile(_filePath,true))
            {
                MessageBox.Show("写入成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("写入失败，请重试!");
            }
        }

        private void bt_reopen_Click(object sender, EventArgs e)
        {
            AutoCode_Load(sender,e);
        }
    }
}
