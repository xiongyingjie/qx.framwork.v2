using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Web.Mvc;
using Qx.Report.Interfaces;
using Qx.Report.Services;
using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Web.Controller;
using Qx.Tools.Models.Report;
using System.Web;
using System.Web.Mvc.Async;
using System.Web.Profile;
using System.Web.Routing;
using RestSharp;
using HtmlAgilityPack;

namespace Web.Controllers.Base
{
    public class BaseController : Controller
    {
        #region restApi

        #endregion

        protected const string _FIXED_FLAG= "!fixed";
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
      
        private List<FormControlConfig> _formSearch;

        public List<FormControlConfig> Search
        {
            get
            {
                if (_formSearch == null)
                {
                    _formSearch = new List<FormControlConfig>();
                    
                }
                return _formSearch;
            }
        }
        private DataContext _dataContext;
        public DataContext DataContext
        {
            get
            {
                #region IS_DEBUG
                if (IsUnitTest)
                {
                    _dataContext = new DataContext();
                    return _dataContext;
                }
                #endregion

                var hsaValue = Session["DataContext"] as DataContext;
                if (hsaValue == null && _dataContext == null)
                {
                    _dataContext = new DataContext();
                    Session["DataContext"] = _dataContext;
                }
                else
                {
                    _dataContext = hsaValue;
                }
                return _dataContext;
            }
            set
            {
                #region IS_DEBUG
                if (IsUnitTest)
                {
                    _dataContext = value;
                }
                #endregion
                else
                {
                    _dataContext = value;
                    Session["DataContext"] = _dataContext;
                }

            }
        }

        #region ReportView
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
            V("UserID", DataContext.UserID);
            V("Url", CurrentUrl());
            V("Title", title);
            V("CurrentFullUrl", Request.RawUrl);
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
            _BaseInitLayout("菜单列表", "_SbLayout");
        }

        public void InitFormView(string Title, bool ShowSaveButton = true)
        {
            V("UserID", DataContext.UserID);
            V("Title", Title); V("ShowSaveButton", ShowSaveButton);
            _BaseInitLayout(Title, "_Sb2FormViewLayout");
        }
        public void InitForm(string Title,bool ShowSaveButton=true)
        {
            V("UserID", DataContext.UserID);
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
        protected void InitReport(List<CrossDbParam> paramList, string Title, string AddLink
            , string ExtraParam, bool showDeafultButton, string dbConnStringKey)
        {
            if (!dbConnStringKey.HasValue())
            {
                throw new Exception("报表数据库配置错误！");
            }
            var pageIndex = Q_Int("pageIndex"); var perCount = Q_Int("perCount");
            var ReportID = Q("ReportID"); var Params = V("Params");
            var dataSource = _reportServices.GetDbDataSource(ReportID, Params, dbConnStringKey);
            //垮裤
            dataSource = _reportServices.CrossDb(ReportID, Params, dataSource, paramList, pageIndex, perCount);
            _InitReport(ReportID, Params, dataSource,
                Title, AddLink,
                ExtraParam, showDeafultButton,
                pageIndex, perCount
                );
        }

        //Service专用
        protected void InitReport(List<List<string>> dataSource,
                                 string Title, string AddLink, string ExtraParam = "", bool showDeafultButton = true)
        {
            var pageIndex = Q_Int("pageIndex"); var perCount = Q_Int("perCount");
            var ReportID = Q("ReportID"); var Params = Q("Params");
            dataSource = _reportServices.ToHtml(ReportID, Params, dataSource, pageIndex, perCount);
            _InitReport(ReportID, Params, dataSource,
                Title, AddLink,
                ExtraParam, showDeafultButton,
                pageIndex, perCount
                );
        }
      
        protected void InitReport_old(string Title, string AddLink, string ExtraParam, bool showDeafultButton, string dbConnStringKey)
        {
            if (!dbConnStringKey.HasValue())
            {
                throw new Exception("报表数据库配置错误！"); 
            }
            if (!IsUnitTest)
            {
                var pageIndex = Q_Int("pageIndex"); var perCount = Q_Int("perCount");
                var ReportID = Q("ReportID"); var Params = V("Params").HasValue()? V("Params"):Q("Params");
                var dataSource = _reportServices.ToHtml(ReportID, Params, dbConnStringKey,pageIndex,perCount);
                _InitReport(ReportID, Params, dataSource,
                    Title, AddLink,
                    ExtraParam, showDeafultButton,
                    pageIndex, perCount
                    );
            }
        }
        //2.0专用
        protected void InitReport(string Title, string AddLink, string ExtraParam, bool showDeafultButton, string dbConnStringKey,string deleteLink="")
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
                V("formControlConfig", Search.Serialize());
                _InitReport(ReportID, Params, new List<List<string>>(), 
                    Title, AddLink,
                    ExtraParam, showDeafultButton,
                    pageIndex, perCount
                    );
            }
        }

        private void _InitReport(string ReportID, string Params, List<List<string>> dataSource,
            string Title, string AddLink,
            string ExtraParam, bool showDeafultButton,
            int pageIndex, int perCount)
        {
            V("ReportID", ReportID); V("Params", Params);
            V("AddLink", AddLink); V("dataSource", dataSource);
            V("ExtraParam", ExtraParam); V("showDeafultButton", showDeafultButton);
            V("pageIndex", pageIndex ); V("perCount", perCount);//分页参数
            V("Url", CurrentUrl()); V("UserID", DataContext.UserID);
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
        protected string F(string key)
        {
            return Request.Form[key];
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
            OverWriteParam(fixedParam + _FIXED_FLAG + dynamicParam);
        }
        /// <summary>
        /// 设置固定参数(限制数据域为当前登录用户)
        /// </summary>
        /// <param name="dynamicParam">动态参数(多个用;间隔)</param>
        protected void SetFixedParam(string dynamicParam)
        {
            SetFixedParam(DataContext.UserID,dynamicParam);
        }

        protected string GetProjectDir(string FileName)
        {
            return System.Web.HttpContext.Current.Request.PhysicalApplicationPath + FileName;
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
        private Qx.Wechat.Models.Msg _message;

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

        protected Qx.Wechat.Models.Msg Message
        {
            get
            {
                if (_message == null)
                {
                    _message = XmlToObj<Qx.Wechat.Models.Msg>(XmlRequstBody);
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
        protected ActionResult Refresh()
        {
            return Content("<script>window.location.href=document.referrer</script>");
        }
        protected ActionResult Alert(string content)
        {
            return Content(PageHelper.Tip(content));
        }
        protected ActionResult Alert(string content, int returnIndex)
        {
            return Content(PageHelper.Tip(content, returnIndex));
        }
        protected ActionResult Alert(string content, string returnUrl)
        {
            return Content(PageHelper.Tip(content, returnUrl));
        }
     
  
       
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (DateTime.Now > new DateTime(2017, 1, 10))
            //{
            //    throw new HttpException("检测到新版本，请联系软件提供商进行升级！");
            //}
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            base.OnActionExecuting(filterContext);
        }

    }
}
