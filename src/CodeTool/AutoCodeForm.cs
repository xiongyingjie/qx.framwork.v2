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

namespace CodeTool
{
    public partial class AutoCodeForm : Form
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
        private string _database = "";
        private string _tables = "";
        private string _colums = "";
        private string _columsNote = "";

        public AutoCodeForm(string database, string tables, string colums, string columsNote)
        {
            _database = database;
            _tables = tables;
            _colums = colums;
            _columsNote = columsNote;

            InitializeComponent();
        }

        #region 页面参数
            
        private string _service
        {
            get { return tb_service.Text; }
        }
        private string _apiName
        {
            get { return tb_apiName.Text; }
        }
        private string _apiNote
        {
            get { return tb_apiNote.Text; }
        }
        
        private string _apiInModelNote
        {
            get { return tb_apiInModelNote.Text; }
        }
        private string _apiModel
        {
            get { return tb_apiModel.Text; }
        }
        private string _apiReturnModel
        {
            get { return tb_apiReturnModel.Text; }
        }
        private string _apiReturnModelNote
        {
            get { return tb_apiReturnModelNote.Text; }
        }
        
        private string _area
        {
            get { return tb_area.Text; }
        }

        private string _interface
        {
            get { return tb_interface.Text; }
        }
        private string _controller
        {
            get { return tb_controller.Text; }
        }
        private string _action
        {
            get { return tb_action.Text; }
        }
        private string _actionNote
        {
            get { return tb_actionNote.Text; }
        }
        private string _columsTip
        {
            get { return tb_columsTip.Text; }
        }
        private string _viewModel
        {
            get { return tb_viewModel.Text; }
        }
        #endregion

        #region 代码模板
        string interfaceTemplate
        {
            get
            {
                return string.Format(@"
public interface {0}
    #left
        /// <summary>
        /// {1}
        /// </summary>
        /// <param name=#quotemodel#quote>{2}</param>
        /// <returns>{3}</returns>
       {4} {5}({6} model);
    #right",_interface, _apiNote, _apiInModelNote,_apiReturnModelNote,_apiReturnModel, _apiName, _apiModel);
            }
        }
        string serviceTemplate
        {
            get
            {
                return string.Format(@"
public class {0} : BaseRepository, {1}
    #left
        public {2} {3}({4} model)
        #left
            Db.{5}.AddOrUpdate(model.ToEntity());
            var saveOk= Db.SaveChanges() > 0;
            return saveOk;
        #right
    #right", _service, _interface, _apiReturnModel, _apiName, _apiModel, _tables);
            }
        }
        string assignTemplate(string from, string to)
        {
            return string.Format(@"
 {0} = {1} ,
", to, from); ;
        }
        string getSetTemplate(string type,string name)
        {
            return string.Format(@"
public {0} {1} #left get; set; #right
", type, name);;
        }
        string getSetPlusTemplate(string type, string name,string display)
        {
            return string.Format(@"
[Display(Name = #quote{0}#quote)]
{1}
", display, getSetTemplate(type, name) );
        }
        string serviceModelTemplate
        {
            get
            {
                //assignTemplate
                var columCode = "";
                var apiModelAssignCode = "";
                var toEntityModelAssignCode = "";
                var columList = _colums.UnPackString(';');
                foreach (var col in columList)
                {
                    columCode += getSetTemplate("string", col);
                    apiModelAssignCode += assignTemplate(col, col);
                    toEntityModelAssignCode += assignTemplate("model." + col, col);
                }    
                return string.Format(@"
public class {0}
    #left

    public {1} ToEntity()
        #left
            return new {1}()
            #left
              {3}
            #right;
        #right

        public static {0} ToModel({1} model)
        #left
            return new {0}()
            #left
            {4}
            #right;
        #right
   
       {2}

    #right", _apiModel,_tables, columCode, apiModelAssignCode, toEntityModelAssignCode);
            }
        }
        string controllerTemplate
        {
            get {
                var assignInterfaceInConstruct = _interface[0].ToString().ToLower() + _interface.Substring(1, _interface.Length - 1);
                var assignInterface = "_" + assignInterfaceInConstruct;
                return string.Format(@"
using System.Web.Mvc;
using Web.Controllers.Base;
using Qx.Tools.CommonExtendMethods;
using Web.Areas.{2}.ViewModels;
public class {3}Controller : BaseController
#left
private {4} {5};

public {3}Controller(
{4} {6})
        #left
            {5} = {6};
        #right








 // GET: {2}/{3}/{0}
public ActionResult {0}()
        #left
            InitForm(#quote{1}#quote);
            return View(new {0}_M());
        #right

 // Post:  {2}/{3}/{0}
[HttpPost]
public ActionResult {0}({0}_M m)
        #left
            if (ModelState.IsValid)
            #left
                var success={5}.{7}(m.ToModel());
                if(success)
                #left
                    return Alert(#quote提交成功#quote);
                #right
                 else
                #left
                    return Alert(#quote提交失败#quote);
                #right
            #right
            else
            #left
                InitForm(#quote{1}#quote);
                return View(m);
            #right
        #right
#right", _action, _actionNote,_area,_controller,_interface, assignInterface, assignInterfaceInConstruct,_apiName ); }
        }

        string viewControlTemplate(string name,string tip,string viewControlType)
        {
            return string.Format(@"
@Html.{0}For(o => o.{1},#quote{2}#quote)", viewControlType.HasValue()? viewControlType: "Hidden", name, tip);
        }
       
        string viewTemplate
        {
            get
            {
                var viewControlCode = "";
                var columList = _colums.UnPackString(';');
                var columsTipList = _columsTip.UnPackString(';');
                for (var i = 0; i < columList.Count; i++)
                {
                    viewControlCode += viewControlTemplate(columList[i], (columsTipList.Count <= i)?"":columsTipList[i], "Input");
                }
                return string.Format(@" 
@using Qx.Tools.Web.Mvc.Html
@model Web.Areas.{0}.ViewModels.{1}
@#left
    Layout = ViewData[#quoteLayout#quote].ToString();
#right
{2}",
_area, _viewModel, viewControlCode); }
        }

        string viewModelTemplate
        {
            get
            {
                //assignTemplate
                var viewModelColumCode = "";
                var viewModelAssignCode = "";
                var toViewModelAssignCode = "";
                var columList = _colums.UnPackString(';');
                var columsNoteList = _columsNote.UnPackString(';');
                for (var i = 0; i < columList.Count; i++)
                {
                    viewModelColumCode += getSetPlusTemplate("string",columList[i], (columsNoteList.Count <= i) ?  columList[i] : columsNoteList[i]);
                    viewModelAssignCode += assignTemplate(columList[i], columList[i]);
                    toViewModelAssignCode += assignTemplate("model." + columList[i], columList[i]);
                }
                return string.Format(@"
public class {0}
    #left

        public {2} ToModel()
        #left
            return new  {2}()
            #left
              {1}
            #right;
        #right

        public static  {0} ToViewModel({2} model)
        #left
            return new  {0}() 
            #left 
                {3}
            #right;
        #right

       {4}
    #right", _viewModel, viewModelAssignCode,_apiModel, toViewModelAssignCode, viewModelColumCode);
            }
        }
        #endregion



        private void AutoCodeForm_Load(object sender, EventArgs e)
        {
         
            tb_database.Text = _database;
            tb_columsNote.Text = _columsNote;
            tb_tableName.Text = _tables;
            tb_colums.Text = _colums;

            #region apiModel自动赋值
            var apiModel = "";
            for (var index = 0; index < _tables.Length; index++)
            {
                var elem = _tables[index];
                var nextElem = index< _tables.Length-1?_tables[index+1]:' ';
                var nextNextElem = index < _tables.Length - 2 ? _tables[index + 2] : ' ';
                if (nextElem == '_')
                {
                    apiModel += elem+ nextNextElem.ToString().ToUpper();
                    index += 2;
                }else if (index == 0)
                {
                    apiModel += elem.ToString().ToUpper();
                }
                else
                {
                    apiModel += elem;
                }
            }
            #endregion
            tb_apiModel.Text = apiModel;
            tb_viewModel.Text = tb_action.Text + "_M";
            tb_apiInModelNote.Text = apiModel;
            tb_apiName.Text =
                tb_apiNote.Text =
                tb_action.Text =
                tb_actionNote.Text ="Update" + apiModel;


        }

        private void bt_generate_Click(object sender, EventArgs e)
        {
            rtb_interface.Text = Decode(interfaceTemplate);
            rtb_service.Text = Decode(serviceTemplate);
            rtb_serviceModel.Text = Decode(serviceModelTemplate);
            rtb_controller.Text = Decode(controllerTemplate);
            rtb_view.Text = Decode(viewTemplate);
            rtb_viewModel.Text = Decode(viewModelTemplate);
        }

        private void tb_viewModel_TextChanged(object sender, EventArgs e)
        {
            tb_action.Text = tb_viewModel.Text.Replace("_M", "");
            bt_generate_Click(sender, e);
        }

        private void tb_action_TextChanged(object sender, EventArgs e)
        {
            tb_viewModel.Text = tb_action.Text+"_M";
            bt_generate_Click(sender, e);
        }
    }
}
