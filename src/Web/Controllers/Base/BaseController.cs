using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using Qx.Report.Interfaces;
using Qx.Report.Services;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Web.Controller;
using Qx.Tools.Models.Report;
using System.Web;
using RestSharp;
using HtmlAgilityPack;
using qx.permmision.v2.Entity;
using qx.permmision.v2.Exceptions;
using qx.permmision.v2.Interfaces;
using qx.permmision.v2.Services;
using qx.wechat.Models;
using Qx.Tools.Exceptions.Form;
using Qx.Tools.Interfaces;
using Qx.Tools.Models.Db;
using Qx.WorkFlow.Interfaces;
using Qx.WorkFlow.Models;
using Qx.WorkFlow.Services;


namespace Web.Controllers.Base
{
    public class BaseController : Controller
    {
        #region restApi

        #endregion

        protected FormValitationException FormValitation;

        protected  string _FIXED_FLAG= QxConfigs.FixedParamFlag;
        protected  bool IsUnitTest
        {
            get
            {
                return false;//Qx.Tools.QxConfigs.IsUnitTest;
            }

        }
            //测试改为true，运行改为false，不上传该控制器！！！
        protected const string PLATE_ALIPAY_ACCOUNT = "plate-alipay";
      
        private readonly IReportServices _reportServices;
        public BaseController()
        {
            this._reportServices = new ReportServices();
        }
      
        private List<ReportControlConfig> _formSearch;

        public List<ReportControlConfig> Search
        {
            get
            {
                if (_formSearch == null)
                {
                    _formSearch = new List<ReportControlConfig>();
                    
                }
                return _formSearch;
            }
        }
        private DataContext _dataContext;
        public DataContext DataContext
        {
            get
            {
                if (_dataContext == null)
                {
                    _dataContext= new DataContext();
                }
                return _dataContext;
                //#region IsUnitTest?
                //if (IsUnitTest)
                //{
                //    _dataContext = new DataContext();
                //    return _dataContext;
                //}
                //#endregion

                //var hsaCoockie = Session["DataContext"] as DataContext;
                //if (hsaCoockie == null && _dataContext == null)
                //{//若没有Coockie则重新new
                //    _dataContext = new DataContext();
                //    Session["DataContext"] = _dataContext;
                //}
                //else
                //{
                //    if (!hsaCoockie.KeepState)
                //    {//若存在Coockie但不需要保存状态则重新new
                //        _dataContext = new DataContext();
                //    }
                //    else
                //    {
                //        _dataContext = hsaCoockie;
                //    } 
                //}
                //return _dataContext;
            }
            set
            {
                _dataContext = value;
                #region IsUnitTest ?
                if (!IsUnitTest)
                {
                    Session["DataContext"] = _dataContext;
                }
                #endregion
            }
        }


        private dynamic _model;
        public dynamic model
        {
            get
            {
                if (_model==null)
                {
                    string json = Request["json"];
                    _model= json.Deserialize<dynamic>();
                    
                }
                return _model;
            }
        }

        public T Model<T>()
        {
            if (_model == null)
            {
                string json = Request["json"];
                _model = json.Deserialize<T>();

            }
            return _model;
        }
        #region ReportView
        public class ReportUI
        {
            public string DataSource { get; set; }
            public string AddLink { get; set; }
            public string Title { get; set; }
            public string ExtraParam { get; set; }
            public string ReportId { get; set; }
            public string Params { get; set; }
            public string PerCount { get; set; }
            public string PageIndex { get; set; }
            public string ShowDeafultButton { get; set; }
            public string DbConnStringKey { get; set; }
            public string DataSourceUrl { get; set; }
            public string FormControlConfig { get; set; }
            public string DeleteLink { get; set; }
            public string CurrentUrl { get; set; }
            public string FixedParams { get; set; }
            public string ImportLink { get; set; }
            public object BackUrl { get; set; }
        }
 
        public class FormUI
        {
            public FormUI(int code, string msg, string url, string jsonData)
            {
                this.code = code;
                this.msg = msg;
                this.url = url;
                this.jsonData = jsonData;
            }

            public FormUI()
            {
              
            }
            public int code;
            public string msg;
            public string url;
            public string jsonData;
           
        }
      public enum State 
      {

            Success = 1,
            Fail = 2,
            Confirm = 3,
            SuccessConfirm = 6,
            FailConfirm = 5,
            SuccessConfirmClose = 7,
            FailConfirmClose = 8,
            File = 9,
            SuccessAutoClose = 10,
            BalanceNotEnough = 11,
            UserInfoNotComplete = 12,
            Error = -1,
        }
        //针对下拉框api
        /// <summary>
        /// 返回下拉框json数据
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="repository">仓库类</param>
        /// <param name="valueExpression">下拉框的值（value属性）表达式</param>
        /// <param name="textExpression">下拉框的显示（text属性）表达式</param>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        public ActionResult Json<TModel>(IRepository<TModel> repository, 
            Expression<Func<TModel, string>> valueExpression,
            Expression<Func<TModel, string>> textExpression,
            Func<TModel, bool> filter)
        {
            var id = Request["id"];
            var dest = id.HasValue()
                ? repository.All(filter).
                    AsQueryable().ToItems(valueExpression, textExpression)
                : repository.ToSelectItems();
            return Json(State.Success, dest.ToDropDownListItem(), false);
        }

        protected ActionResult Json()
        {
            //wx.sports.user-add|user_info-add
            var operates = DataContext.Commit();
            switch (operates.MainOperate.MainOperate.OperateType)
            {
                case Operate.Add:
                    {
                        return operates.Successful ? Json(State.SuccessConfirmClose, "添加成功，是否返回列表") : Json(State.Fail, "添加失败");
                    };
                case Operate.Update:
                    {
                        return operates.Successful ? Json(State.SuccessConfirmClose, "保存成功，是否返回列表") : Json(State.Fail, "保存失败");
                    };
                case Operate.Delete:
                    {
                        return operates.Successful ? Json(State.Success, "删除成功") : Json(State.Fail, "删除失败");
                    };
                case Operate.Info:
                case Operate.Find:
                case Operate.List:
                case Operate.Items:
                    {//查询类
                        return Json(State.Success, operates.MainOperate.Result);
                    }
                case Operate.Download:
                    {
                        return Json(State.File, operates.MainOperate.Result, false); ;
                    }
            }
            return Json(State.Fail, "参数错误");
        }
      //针对写入
        protected ActionResult Json(State state, string msg,string url="")
        {
            if (!url.HasValue())
            {
                url = CurrentFullUrl();
            }
            AllowOrigin();
            if (msg.Contains("{") && msg.Contains("}") || msg.Contains("[") && msg.Contains("]"))
            {//msg为json串？
                return Json(new FormUI((int)state, "", url, msg), JsonRequestBehavior.AllowGet);
            }
            return Json(new FormUI((int)state, msg, url, "{}"), JsonRequestBehavior.AllowGet);
        }
        //针对查询
        protected ActionResult Json(State state,  object data,bool isEntity=true)
        {
            if (data == null)
            {
                data = new { };
            }

            AllowOrigin();
            Response.StatusCode = 200;
            return Json(new FormUI((int)state, "", CurrentFullUrl(), data.Serialize(isEntity)), JsonRequestBehavior.AllowGet);
        }
        protected ActionResult ReportJson()
        {

            //固定参数
            var Params = V("Params");
            var fixedParams = "";
            if (Params != null)
            {
                var fixedIndex = Params.IndexOf("!fixed", StringComparison.Ordinal);
                fixedParams = fixedIndex > -1 ? Params.Substring(0, fixedIndex) : "";
            }
            //跨域
            AllowOrigin();
            return Json(State.Success,new ReportUI()
            {
                DataSource = V("dataSourceUrl"),
                AddLink = V("AddLink"),
                Title = V("Title"),
                ExtraParam = V("ExtraParam"),
                ReportId = V("ReportID"),
                Params = Params,
                PerCount = V("perCount"),
                PageIndex = V("pageIndex"),
                ShowDeafultButton = V("showDeafultButton"),
                DbConnStringKey = V("dbConnStringKey"),
                DataSourceUrl = V("dataSourceUrl"),
                FormControlConfig = Search.Serialize(),
                DeleteLink = V("deleteLink"),
                ImportLink = V("importLink"),
                CurrentUrl = V("Url"),
                FixedParams = fixedParams,
                BackUrl= V("backUrl")
              
            }, false);
        }

        protected ActionResult ReportView()
        {
            return View("_empty");
        }
        protected ActionResult ReportView(string viewName, object model)
        {
            return View(viewName, model);
        }
        protected ActionResult ReportView(object model)
        {
            return View(model);
        }
        #endregion
        protected string ToPhysicPath(string FilePath)
        {
            return new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).FullName + FilePath;//System.Web.HttpContext.Current.Server.MapPath(SavePath) + fileBase.FileName;
        }
        protected string ReadFile(string FilePath)
        {
            var filePath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).FullName + FilePath;
            var temp = new List<char>();
            if (System.IO.File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    var br = new BinaryReader(fs, Encoding.UTF8);
                    //判断是否已经读到文件末尾
                    while (br.PeekChar() != -1)//使用while(temp=br.ReadString())!=null 会报异常System.IO.EndOfStreamExceptionl 
                    {
                        temp.Add(br.ReadChar());
                    }
                    br.Close();
                    fs.Close();
                }
            }
            return new string(temp.ToArray());
        }

        protected string GetConnStr()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        protected string GetHost(bool withPort=false)
        {
            var host ="http://"+ System.Web.HttpContext.Current.Request.Url.Host;
            return withPort? host + ":" + GetPort(): host;
        }
        protected int GetPort()
        {
            return System.Web.HttpContext.Current.Request.Url.Port;
        }
      
        protected string GeRootUrl(string absoluteUrl)
        {
            return "http://"+GetHost()+":" + GetPort()+"/"+ absoluteUrl;
        }
        protected string CurrentUrl()
        {
            return System.Web.HttpContext.Current.Request.Url.AbsolutePath;
        }
        protected string CurrentFullUrl()
        {
            return System.Web.HttpContext.Current.Request.RawUrl;
        }
      
        protected string ReturnUrl
        {
            get
            {
                return Session["ReturnUrl"] != null ? Session["ReturnUrl"].ToString() : "/";
            }
            set
            {
                Session["ReturnUrl"] = value;
            }
        }
        #region Layout相关
        private void _BaseInitLayout(string title,string layoutName)
        {
            var layout = "~/Views/Shared/"+ layoutName+".cshtml";
            V("UserID", DataContext.UserId);
            V("Url", CurrentUrl());
            V("Title", title);
            V("CurrentFullUrl", Request.RawUrl);
            V("CurrentHost", GetHost());
           
            V("Layout", layout);
            HttpContext.Items.Add("Layout", layout);
            if (Request.Url != null) V("CurrentUrl", Request.Url.AbsolutePath);
            foreach (var item in Request.QueryString)
            {
                if (item == null) continue;
                var key = item.ToString() ?? "";
                if (key != "Params")
                {
                    ViewData[key] = Request.QueryString[key];
                }
            }
           
        }
        protected void InitLayout(string Title)
        {
            _BaseInitLayout(Title, "_Sb2Layout");
        }
        protected void InitFrLayout(string Title,bool showBackButton=false)
        {
            V("showBackButton", showBackButton);
            _BaseInitLayout(Title, "_FrLayout");
        }
        protected void InitAdminLayout(string Title)
        {
            _BaseInitLayout(Title, "_Sb2AdminLayout");
       }
        
       protected void InitEJLayout(string Title)
       {
            _BaseInitLayout(Title, "_EJLayout");
        }
        protected void InitWxLayout(string Title)
        {
            _BaseInitLayout(Title, "_WxLayout");
        }
        protected void InitMenu(Dictionary<string, string> Menus)
        {
            ViewBag.Menus = Menus;
            _BaseInitLayout("菜单列表", "_Sb2Layout");
        }

        public void InitFormView(string Title, bool ShowSaveButton = true)
        {
            V("UserID", DataContext.UserId);
            V("Title", Title); V("ShowSaveButton", ShowSaveButton);
            _BaseInitLayout(Title, "_Sb2FormViewLayout");
        }
        public void InitForm(string Title,bool ShowSaveButton=true)
        {
            V("FormValitation", FormValitation ?? new FormValitationException(new List<DbValidationError>()));
            V("UserID", DataContext.UserId);
            //V("Url", CurrentUrl());
            V("Title", Title); V("ShowSaveButton", ShowSaveButton);
            if (IsUnitTest)
            {
                HttpContext.Items["Layout"] = "~/Views/Shared/_Sb2FormLayout.cshtml"; V("Layout", "~/Views/Shared/_Sb2FormLayout.cshtml");
            }
            else
            {
                _BaseInitLayout(Title, "_Sb2FormLayout");
            }
            
          }
        #endregion

        #region 废弃
        //[Obsolete(@"使用InitReport(List<List<string>> dataSource, string Title,string AddLink,string ExtraParam = "",bool showDeafultButton = true) 代替")]
        //protected void InitReport(List<List<string>> dataSource, string Title, string AddLink,
        //   int pageIndex, int perCount, string ExtraParam = "", bool showDeafultButton = true)
        //{
        //    throw new Exception("已过时的方法\r\n"+ @"使用InitReport(List<List<string>> dataSource, string Title,string AddLink,string ExtraParam = "",bool showDeafultButton = true) 代替");
        //    var ReportID = Q("ReportID"); var Params = Q("Params");
        //    _InitReport(ReportID, Params, dataSource,
        //        Title, AddLink,
        //        ExtraParam, showDeafultButton,
        //        pageIndex.ToString(), perCount.ToString()
        //        );
        //}
        //[Obsolete(@"使用InitReport(string Title, string AddLink, string ExtraParam, bool showDeafultButton, string dbConnStringKey) 代替")]
        //protected void InitReport(string Title, string AddLink, int pageIndex, int perCount, string ExtraParam, bool showDeafultButton, string dbConnStringKey)
        //{
        //    throw new Exception("已过时的方法\r\n"+ @"使用InitReport(string Title, string AddLink, string ExtraParam, bool showDeafultButton, string dbConnStringKey) 代替");
        //    if (!dbConnStringKey.HasValue())
        //    {
        //        throw new Exception("报表数据库配置错误！");
        //    }
        //    var ReportID = Q("ReportID"); var Params = V("Params");
        //    var dataSource = _reportServices.GetDbDataSource(ReportID, Params, dbConnStringKey);
        //    _InitReport(ReportID, Params, dataSource,
        //        Title, AddLink,
        //        ExtraParam, showDeafultButton,
        //        pageIndex.ToString(), perCount.ToString()
        //        );
        //}
        #endregion

        #region Report相关
        //垮裤专用
        //protected void InitReport(List<CrossDbParam> paramList, string Title, string AddLink
        //    , string ExtraParam, bool showDeafultButton, string dbConnStringKey)
        //{
        //    if (!dbConnStringKey.HasValue())
        //    {
        //        throw new Exception("报表数据库配置错误！");
        //    }
        //    var pageIndex = Q_Int("pageIndex"); var perCount = Q_Int("perCount");
        //    var ReportID = Q("ReportID"); var Params = V("Params");
        //    var dataSource = _reportServices.GetDbDataSource(ReportID, Params, dbConnStringKey);
        //    //垮裤
        //    dataSource = _reportServices.CrossDb(ReportID, Params, dataSource, paramList, pageIndex, perCount);
        //    _InitReport(ReportID, Params, dataSource,
        //        Title, AddLink,
        //        ExtraParam, showDeafultButton,
        //        pageIndex, perCount
        //        );
        //}

        //Service专用
        protected void InitReport(string dataSourceUrl,
                                 string Title, string AddLink, string ExtraParam = "", bool showDeafultButton = true, string deleteLink = "", string importLink = "")
        {
            var pageIndex = Q_Int("pageIndex"); var perCount = Q_Int("perCount");
            var ReportID = Q("ReportID"); var Params = Q("Params");
            V("deleteLink", deleteLink);
            V("importLink", importLink);
            _InitReport(ReportID, Params, dataSourceUrl,
                Title, AddLink,
                ExtraParam, showDeafultButton,
                pageIndex, perCount
                );
        }
      
        //protected void InitReport_old(string Title, string AddLink, string ExtraParam, bool showDeafultButton, string dbConnStringKey)
        //{
        //    if (!dbConnStringKey.HasValue())
        //    {
        //        throw new Exception("报表数据库配置错误！"); 
        //    }
        //    if (!IsUnitTest)
        //    {
        //        var pageIndex = Q_Int("pageIndex"); var perCount = Q_Int("perCount");
        //        var ReportID = Q("ReportID"); var Params = V("Params").HasValue()? V("Params"):Q("Params");
        //        var dataSource = _reportServices.ToHtml(ReportID, Params, dbConnStringKey,pageIndex,perCount);
        //        _InitReport(ReportID, Params, dataSource,
        //            Title, AddLink,
        //            ExtraParam, showDeafultButton,
        //            pageIndex, perCount
        //            );
        //    }
        //}
        //2.0专用
        protected void InitReport(string Title, string AddLink,
            string ExtraParam, bool showDeafultButton,
            string dbConnStringKey, 
            string deleteLink = "", string importLink = "")
        {
            if (!dbConnStringKey.HasValue())
            {
                throw new Exception("报表数据库配置错误！");
            }
            if (!IsUnitTest)
            {
                var pageIndex = Q_Int("pageIndex"); var perCount = Q_Int("perCount");
                var ReportID = Q("ReportID"); var Params = V("Params").HasValue() ? V("Params") : Q("Params");
               // var dataSource = _reportServices.ToHtml(ReportID, Params, dbConnStringKey, pageIndex, perCount);
                V("dbConnStringKey", dbConnStringKey);
                V("deleteLink", deleteLink);
                V("importLink", importLink);
                _InitReport(ReportID, Params, "", 
                    Title, AddLink,
                    ExtraParam, showDeafultButton,
                    pageIndex, perCount
                    );
            }
        }

        private void _InitReport(string ReportID, string Params,string dataSourceUrl,
            string Title, string AddLink,
            string ExtraParam, bool showDeafultButton,
            int pageIndex, int perCount)
        {
            V("ReportID", ReportID); V("Params", Params);
            V("AddLink", AddLink); V("dataSourceUrl", dataSourceUrl);
            V("ExtraParam", ExtraParam); V("showDeafultButton", showDeafultButton);
            V("pageIndex", pageIndex ); V("perCount", perCount);//分页参数
            V("Url", CurrentUrl()); V("UserID", DataContext.UserId);
            V("ReportControlConfig", Search.Serialize());
            _BaseInitLayout(Title, "_Sb2ReportLayout");
        }


        protected List<T> InitCutPage<T>(IEnumerable<T> data, int pageIndex, int perCount)
        {
            int maxIndex=10;
            var model = new List<T>();// data.GetPage(pageIndex, perCount, out maxIndex);
            V("currentUrl", CurrentUrl());
            V("maxIndex", maxIndex); V("pageIndex", pageIndex); V("perCount", perCount);
            return model.ToList();
        }
        #endregion

     
        protected string Q(string key)
        {
            return Request.QueryString[key];
        }
        /// <summary>
        /// 所有从带固定参数的报表跳转过来的参数获取必须使用此方法
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string RQ(string key)
        {
            return Q(key).Replace(_FIXED_FLAG, "");
        }
        protected int Q_Int(string key)
        {
            string value = Request.QueryString[key];
            if (!value.HasValue())
            {
                if(key== "pageIndex")
                return 1;
                else if (key == "perCount")
                    return 10;
                else
                {
                    throw new Exception("未处理的异常！");
                }
            }
            return int.Parse(value);
        }
        protected int F_Int(string key)
        {
            string value = F(key);
            if (!value.HasValue())
            {
                if (key == "pageIndex")
                    return 1;
                else if (key == "perCount")
                    return 10;
                else
                {
                    throw new Exception("未处理的异常！");
                }
            }
            return int.Parse(value);
        }
        protected string F(string key)
        {
            return Request[key].HasValue()? Request[key]:"";
        }
        protected object V(string key,object value)
        {
            ViewData[key] = value;
            return value;

        }
        protected string V(string key)
        {
            return ViewData[key] == null ? "" : ViewData[key] as string;
        }
        protected void AddParam(string Param)
        {
            var Params = V("Params");
            if (Params.Length > 2 && Param[Param.Length - 1] != ';')
            {
                Params += ';';
            }
            var newParams= Params + Param + ";";
            OverWriteParam(newParams) ;
        }
        protected void OverWriteParam(string Param)
        {
            V("Params", Param);
        }
        /// <summary>
        /// 设置固定参数
        /// </summary>
        /// <param name="fixedParam">固定参数部分(多个用;间隔)</param>
        /// <param name="dynamicParam">动态参数(多个用;间隔)</param>
        protected void SetFixedParam(string fixedParam,string dynamicParam)
        {
            if(!fixedParam.HasValue())
            { throw new Exception("固定参数为空，请检查SetFixedParam的传入参数");}
            //清除从报表带过来的标志位
            fixedParam = fixedParam.Replace(_FIXED_FLAG, "");
                  //容错处理(删除fixedParam最后一个;)
                  fixedParam = fixedParam[fixedParam.Length - 1] == ';' ? fixedParam.Substring(0, fixedParam.Length - 1) : fixedParam;
            OverWriteParam(fixedParam.IsFixedParam() + dynamicParam);
        }
        /// <summary>
        /// 设置固定参数(限制数据域为当前登录用户)
        /// </summary>
        /// <param name="dynamicParam">动态参数(多个用;间隔)</param>
        protected void SetFixedParam(string dynamicParam)
        {
            SetFixedParam(DataContext.UserId,dynamicParam);
        }
        protected void SetBackUrl(string backUrl)
        {
            V("backUrl", backUrl);
        }
        protected string GetProjectDir(string FileName)
        {
            var path = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + FileName;
          
            return path;
        }
        protected void WriteFile(string FilePath, string content, bool isBinaryWriter = true)
        {
            var filePath = GetProjectDir(FilePath);
            var fs = System.IO.File.Exists(filePath) ?
                new FileStream(filePath, FileMode.Append) :
                System.IO.File.Create(filePath);
            using (fs)
            {
                if (isBinaryWriter)
                {
                    var br = new BinaryWriter(fs, Encoding.UTF8);
                    br.Write(true);
                    br.Flush();
                    br.Close();
                }
                else
                {
                    var sw = new StreamWriter(fs);
                    sw.Write(content);
                    sw.Flush();
                    sw.Close();
                }
                fs.Close();
            }
        }


        #region 文件上传 public
        static string TempPath = null;
        [HttpPost]
        public JsonResult UploadHandle(string saveDirectory)
        {
            var fileBase = System.Web.HttpContext.Current.Request.Files[0];
            var SavePath = saveDirectory;// "/UserFiles/Test/";
            var TargetPath =   System.Web.HttpContext.Current.Server.MapPath(SavePath) + fileBase.FileName;
            var ContentRange = Request.Headers["Content-Range"];
            TempPath = TargetPath;
            FileUploadUtility.UploadBigFile(fileBase, TargetPath, ContentRange);
            var result = new { name = "提示:上传成功！", filePath = saveDirectory + fileBase.FileName };
            return Json(result);
        }

        public ActionResult RedoHandle()
        {
            //处理Redo按钮的请求
            int command = Convert.ToInt32(Request["DeleteCommand"]);
            if (command == 1 && TempPath != null)
            {
                if (System.IO.File.Exists(TempPath))//判断文件是否存在
                {
                    System.IO.File.Delete(TempPath);//执行IO文件删除,需引入命名空间System.IO;    
                } //删除物理文件
                TempPath = null;
                return Content("删除成功!");
            }
            else
            {
                return Content("删除异常!");
            }
        }

        public ActionResult ContinueHandle()
        {
            //用于处理续传功能
            //var FileByte = System.IO.File.ReadAllBytes(TempPath);
            //var resp = new HttpResponseMessage(HttpStatusCode.OK)
            //{
            //    Content = new ByteArrayContent(FileByte)
            //};
            //var fileStream = new FileStream(TempPath, FileMode.Open);
            string CurrentFileName = Request["file"];
            FileInfo info = new FileInfo(TempPath);
            long InfoSize = info.Length;
            var result = new { FileSize = InfoSize };
            return Json(result);
        }

        protected ActionResult FreshHandle()
        {
            TempPath = null;
            return View();
        }
        #endregion

        #region 微信开发工具类
        private Msg _message;

        private Dictionary<string, string> _param;
        private string _requstLog;
        private Dictionary<string, string> _requstParam;
        private string _xmlRequstBody;

        protected Dictionary<string, string> Param
        {
            get
            {
                if (_param == null)
                {
                    _param = new Dictionary<string, string>();
                }
                return _param;
            }
        }

        protected Msg Message
        {
            get
            {
                if (_message == null)
                {
                    _message = XmlToObj<Msg>(XmlRequstBody);
                }
                return _message;
            }
        }

        public string XmlRequstBody
        {
            get
            {
                if (_xmlRequstBody == null)
                {
                    var s = System.Web.HttpContext.Current.Request.InputStream;
                    var b = new byte[s.Length];
                    s.Read(b, 0, (int)s.Length);
                    var content = Encoding.UTF8.GetString(b);
                    _xmlRequstBody = content;
                }
                return _xmlRequstBody;
            }
        }



        protected Dictionary<string, string> RequstParam
        {
            get
            {
                if (_requstParam == null)
                {
                    _requstParam = new Dictionary<string, string>();
                    var keyValues = XmlToKeyValues(XmlRequstBody);
                    keyValues.ForEach(a => { _requstParam.Add(a.Key, a.Value); });
                }
                return _requstParam;
            }
        }
        public string RequstLog
        {
            get
            {
                if (_requstLog == null)
                {
                    var content = "";
                    content = "----------------------" + DateTime.Now + "----------------------" + "\r\n";

                    content += "--------RequstLog" + "\r\n";

                    if (Request.Params.HasKeys())
                    {
                        foreach (var item in Request.Params)
                        {
                            content += item + ":" + Request[item.ToString()] + "\r\n";
                        }
                    }
                    else
                    {
                        content += "none" + "\r\n";
                    }

                    content += "--------XmlBody[Source]" + "\r\n";
                    content += XmlRequstBody + "\r\n";

                    content += "--------XmlBody[Json]" + "\r\n";
                    content += Message.Serialize() + "\r\n";

                    content += "--------XmlBody[Formated]" + "\r\n";

                    foreach (var item in RequstParam)
                    {
                        content += item.Key + "=>" + item.Value + "\r\n";
                    }

                    content += "\r\n";
                    _requstLog = content;
                }
                return _requstLog;
            }
        }

        protected string ApiUrl(string action, string extraParam)
        {
            var url = ("/cgi-bin/" + action).ToLower();
            return extraParam.HasValue() ? url + "?" + extraParam : url;
        }

        public string ApiHttpGet(string host, string url, Dictionary<string, string> param, string logFileName)
        {
            var content = HttpGet(host, ApiUrl(url, null), param);
            WriteFile(string.Format("UserFiles\\Test\\{0}.txt", logFileName + DateTime.Now.ToString("-yyyy.MMMM.dd")),
                content, false);
            return content;
        }

        protected string ApiHttpPost(string host, string url, Dictionary<string, string> param, string logFileName)
        {
            var content = HttpPost(host, ApiUrl(url, null), param);
            WriteFile(string.Format("UserFiles\\Test\\{0}.txt", logFileName + DateTime.Now.ToString("-yyyy.MMMM.dd")),
                content, false);
            return content;
        }

        protected string ApiJsonHttpPost(string host, string url, object param, string logFileName, string extraParam = null)
        {
            var content = JsonHttp(host, ApiUrl(url, extraParam), param, Method.POST);
            WriteFile(string.Format("UserFiles\\Test\\{0}.txt", logFileName + DateTime.Now.ToString("-yyyy.MMMM.dd")),
                content, false);
            return content;
        }

        protected string HttpGet(string host, string url, Dictionary<string, string> param)
        {
            return NormalHttp(host, url, param, Method.GET);
        }
        protected T HttpGet<T>(string url)
        {
            var client = new RestClient(new Uri(url));
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            var content = response.Content.Deserialize<T>();
            return content;
        }

        protected string HttpPost(string host, string url, Dictionary<string, string> param)
        {
            return NormalHttp( host, url, param, Method.POST);
        }

        protected string NormalHttp(string host, string url, Dictionary<string, string> param, Method method)
        {
            var request = new RestRequest(url, method);
            foreach (var key in param.Keys)
            {
                request.AddParameter(key, param[key]);
            }
            return BaseHttp(request, host);
        }

        protected string JsonHttp(string host,string url, object objParam, Method method)
        {
            var request = new RestRequest(url, method);
            request.AddJsonBody(objParam);
            request.DateFormat = "application/json";
            return BaseHttp(request, host);
        }

        protected string BaseHttp(RestRequest request,string host)
        {
            var client = new RestClient(new Uri(host));
            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }
        protected string BaseHttp(string host, string url, Dictionary<string, string> param, Method method, out RestClient client)
        {
            client = new RestClient(new Uri(host));
            var request = new RestRequest(url, method);
            foreach (var key in param.Keys)
            {
                request.AddParameter(key, param[key]);
            }
            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }
        protected T XmlToObj<T>(string xmlBody) where T : new()
        {
            if (!xmlBody.HasValue())
                return new T();

            var dic = XmlToKeyValues(xmlBody);

            #region dic to jsonString

            var jsonString = new StringBuilder();
            jsonString.Append("{");

            for (var i = 0; i < dic.Count(); i++)
            {
                jsonString.Append("\"");
                jsonString.Append(dic[i].Key);
                jsonString.Append("\"");
                jsonString.Append(":");
                jsonString.Append("\"");
                jsonString.Append(dic[i].Value);
                jsonString.Append("\"");
                if (i < dic.Count() - 1)
                {
                    jsonString.Append(",");
                }
            }
            jsonString.Append("}");

            #endregion

            #region jsonString to obj

            var obj = jsonString.ToString().Deserialize<T>();

            #endregion

            return obj;
        }

        protected List<KeyValuePair<string, string>> XmlToKeyValues(string xmlBody)
        {
            if (!xmlBody.HasValue())
                return new List<KeyValuePair<string, string>>();

            var doc = new HtmlDocument();
            doc.LoadHtml(xmlBody);
            var nodes = doc.DocumentNode.ChildNodes.FirstOrDefault().
                ChildNodes.Where(a => !(a.InnerText == "\r\n" || a.Name == "#text" || a.InnerText == "")).
                Select(b => new KeyValuePair<string, string>(b.Name,
                    b.InnerText.Replace("<![CDATA[", "").Replace("]]>", ""))
                ).ToList();
            return nodes;
        }


        protected string ParseException(Exception ex)
        {
            var error = new StringBuilder();
            error.Append("----------------------" + DateTime.Now + "----------------------------");
            error.Append("\r\n");
            error.Append(ex.Message);
            error.Append("\r\n");
            error.Append("--------------------------StackTrace");
            error.Append("\r\n");
            error.Append(ex.StackTrace);
            error.Append("\r\n");
            foreach (var item in ex.Data)
            {
                error.Append(item);
                error.Append("\r\n");
            }

            if (ex.InnerException != null)
            {
                ex = ex.InnerException;//重新赋值
                error.Append("--------------------------InnerException");
                error.Append("\r\n");
                error.Append(ex.Message);
                error.Append("\r\n");
                error.Append("--------------------------InnerException.StackTrace");
                error.Append("\r\n");
                error.Append(ex.StackTrace);
                error.Append("\r\n");
            }


            return error.ToString();
        }


        #endregion

        #region 工作流

        private IWorkFlowService _workFlow;
        protected IWorkFlowService WorkFlowService
        {
            get
            {
                if (_workFlow == null)
                {
                    _workFlow = new WorkFlowService();
                }
                return _workFlow;
            }
        }
        private IPermmisionService _permmisionService;
        private IPermmisionService Permmision
        {
            get
            {
                if (_permmisionService == null)
                {
                    _permmisionService = new PermissionServices();
                }
                return _permmisionService;
            }
        }

        private List<orgnization> _workFlowDoman;
        protected List<string>  WorkFlowDoman
        {
         get
            {
                var uid = Request["uid"];
                if (uid==null)
                {
                    throw  new Exception("未登录");
                }
                if (_workFlowDoman == null)
                {
                    _workFlowDoman = Permmision.GetOrgIdByUserId(DataContext.UserId);
                }
                return _workFlowDoman.Select(a=>a.orgnization_id).ToList();
            }   
        }

       
        protected ActionResult CreateAndMoveNext(string workFlowId, string successTip, string failTip,
            object moveParam, Func<string, bool> doIfSuccessful, string reason = "未填写", RelationMoveParam relation = null
            )
        {
            //var uid = Request["uid"];
            var param = new WorkFlowParams(workFlowId, DataContext.UserId, DataContext.UnitId, moveParam, doIfSuccessful, DataContext.UserId, reason, relation);
            return WorkFlowService.CreateAndMoveNext(param) ?
                Json(State.SuccessAutoClose, successTip) : Json(State.Fail, failTip);
        }
        protected ActionResult MoveNext(string successTip, string failTip, 
            object moveParam, Func<string, bool> doIfSuccessful, string reason="未填写", RelationMoveParam relation = null)
        {
            var workFlowInstanceId = Request["id"]; //var uid = Request["uid"]; 
            var param=new WorkFlowParams(workFlowInstanceId,DataContext.UserId, moveParam, doIfSuccessful,DataContext.UserId,reason, relation);
            return WorkFlowService.MoveNext(param) ?
                Json(State.SuccessAutoClose, successTip) : Json(State.Fail, failTip); ;
        }
        #endregion
        protected ActionResult Refresh()
        {
            return Content("<script>window.location.href=document.referrer</script>");
        }
        protected ActionResult Alert(string content)
        {
            return Content(PageHelper.Tip(content,-1));
        }
        protected ActionResult Alert(string content, int returnIndex)
        {
            return Content(PageHelper.Tip(content, returnIndex));
        }
        protected ActionResult Alert(string content, string returnUrl)
        {
            return Content(PageHelper.Tip(content, returnUrl));
        }


        protected void AllowOrigin(HttpResponseBase r=null)
        {
            //if (r == null)
            //{
            //    r=Response;
            //}
            //if (Response.Headers.GetValues("Access-Control-Allow-Origin") == null)
            //{
            //    Dictionary<string, string> headers = new Dictionary<string, string>();

            //    headers.Add("Access-Control-Allow-Origin", "*");
            //    headers.Add("Access-Control-Allow-Methods", "*");
            //    foreach (var item in headers.Keys)
            //    {
            //        r.Headers.Add(item, headers[item]);
            //    }
            //}
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            AllowOrigin(filterContext.RequestContext.HttpContext.Response);
            //var uid = Request["uid"];
            //if (uid.HasValue())
            //{//以请求的uid为准
            //    DataContext.UserId = uid;
            //}
            //DataContext=new DataContext();
            base.OnActionExecuting(filterContext);
        }
        //把一组数据转成SQL语句中In参数     
        public string ToSQLInParam(List<string> orgIdList)
        {
            var Params = "";
            //orgItem获取所有能管理的社团
            foreach (var item in orgIdList)
            {
                Params += item.Trim() + "','";
            }
            if (Params.EndsWith(","))
            {
                Params = Params.Substring(0, Params.Length - 3);//构造我管理的社团（固定参数）
            }
            return Params;
        }
    }
}
