using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using xyj.acs.Interfaces;
using xyj.acs.Services;
using xyj.core;
using xyj.core.Config;
using xyj.core.Exceptions.Form;
using xyj.core.Exceptions.Upgrate;
using xyj.core.Extensions;
using xyj.core.Interfaces;
using xyj.core.Models.Db;
using xyj.core.Models.Form;
using xyj.core.Models.Http;
using xyj.core.Models.Report;
using xyj.core.Services;


namespace Web.Controllers.Base
{
    public  class BaseController : Controller
    {
      

        protected FormValitationException FormValitation;

        protected  string _FIXED_FLAG= Setting.FixedParamFlag;
      
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
                    _dataContext= new DataContext(HttpContext);
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
            }
        }


        private dynamic _model;
        public dynamic model
        {
            get
            {
                if (_model==null)
                {
                    string json = F("json");
                    _model= json.Deserialize<dynamic>();
                    
                }
                return _model;
            }
        }

        public T Model<T>()
        {
            if (_model == null)
            {
                string json =F("json");
                _model = json.Deserialize<T>();

            }
            return _model;
        }
        #region ReportView

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
        public IActionResult Json<TModel>(IRepository<TModel> repository, 
            Expression<Func<TModel, string>> valueExpression,
            Expression<Func<TModel, string>> textExpression,
            Func<TModel, bool> filter)
        {
            var id = F("id");
            var dest = id.HasValue()
                ? repository.All(filter).
                    AsQueryable().ToItems(valueExpression, textExpression)
                : repository.ToSelectItems();
            return Json(State.Success, dest.ToDropDownListItem(), false);
        }

        protected IActionResult Json()
        {
            //wx.sports.user-add|user_info-add
            var operates = DataContext.Commit();
            switch (operates.MainOperate.MainOperate.OperateType)
            {
                case Operate.Add:
                    {
                        return operates.Successful ? Json(State.SuccessConfirmClose, "添加成功，是否关闭页面") : Json(State.Fail, "添加失败");
                    };
                case Operate.Update:
                    {
                        return operates.Successful ? Json(State.SuccessConfirmClose, "保存成功，是否关闭页面") : Json(State.Fail, "保存失败");
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
        protected IActionResult Json(State state, string msg,string url="")
        {
            if (!url.HasValue())
            {
                url = CurrentFullUrl();
            }
         
            if (msg.Contains("{") && msg.Contains("}") || msg.Contains("[") && msg.Contains("]"))
            {//msg为json串？
                return Json(new FormUI((int)state, "", url, msg));
            }
            return Json(new FormUI((int)state, msg, url, "{}"));
        }
        //针对查询
        protected IActionResult Json(State state,  object data,bool isEntity=false)
        {
            if (data == null)
            {
                data = new { };
            }

         
            Response.StatusCode = 200;
            return Json(new FormUI((int)state, "", CurrentFullUrl(), data.Serialize(isEntity)));
        }
        protected IActionResult ReportJson()
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
          
            var jsonData = new ReportUI()
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
                BackUrl = V("backUrl")

            };
            return Json(State.Success, jsonData, false);
        }

        #endregion


        public string Session(string key, string value = null)
        {
            return DataContext.S(HttpContext, key, value);
        }
        protected string ReturnUrl
        {
            get
            {
                // Qx.Tools.Web.HttpContext.Current.Session
                return Session("ReturnUrl") != null ? Session("ReturnUrl").ToString() : "/";
            }
            set
            {
                Session("ReturnUrl", value);
            }
        }


        #region Layout相关
        private void _BaseInitLayout(string title,string layoutName)
        {
           // var layout = "~/Views/Shared/"+ layoutName+".cshtml";
            V("UserID", DataContext.UserId);
            V("Url", CurrentUrl());
            V("Title", title);
            V("CurrentFullUrl", Request.GetUri().AbsoluteUri);
            V("CurrentHost", GetHost());
           
           // V("Layout", layout);
          //  HttpContext.Items.Add("Layout", layout);
            if (Request.GetType() != null) V("CurrentUrl", Request.GetUri().AbsolutePath);
            HandleRequestParam();

        }

        protected void HandleRequestParam()
        {
            if (Request != null)
            {
                foreach (var item in Request.Query)
                {
                    if (item.Key == null) continue;
                    var key = item.Key;
                    if (key != "Params")
                    {
                        ViewData[key] = item.Value;
                        DataContext.SetFiled(key, item.Value.FirstOrDefault());
                    }
                }
            }
           

        }

        public void InitForm(string Title,bool ShowSaveButton=true)
        {
            V("FormValitation",  new FormValitationException(new List<DbValidationError>()).Serialize());
            V("UserID", DataContext.UserId);
            //V("Url", CurrentUrl());
            V("Title", Title); V("ShowSaveButton", ShowSaveButton.ToString());
            _BaseInitLayout(Title, "_Sb2FormLayout");

        }
        #endregion
        protected string GetProjectDir(IHostingEnvironment env, string FileName)
        {
           
            var path = env.WebRootPath+"\\" + FileName;
            //var path = env.ContentRootPath + FileName;
            return path;
        }
        protected string GetHost(bool withPort = false)
        {

            var host = Request.Scheme+"://" + Request.Host.Host;
            if (Request.IsHttps)
            {//https时不加端口
                withPort = false;
            }
            return withPort ? host + ":" + GetPort() : host;
        }
        protected int GetPort()
        {
            return Request.GetUri().Port;
        }

        protected string GeRootUrl(string absoluteUrl)
        {
            return GetHost() + ":" + GetPort() + "/" + absoluteUrl;
        }
        protected string CurrentFullUrl()
        {
            return Request.GetUri().AbsoluteUri;
        }
        protected string CurrentUrl()
        {
            return Request.GetUri().AbsolutePath;
        }
        #region Report相关

        protected void InitReport(string dataSourceUrl,
                                 string Title, string AddLink, string ExtraParam = "", bool showDeafultButton = true, string deleteLink = "", string importLink = "")
        {
            var pageIndex = Q_Int("pageIndex");
            var perCount = Q_Int("perCount");
            var ReportID = Q("ReportID");
            var Params = Q("Params");
            V("deleteLink", deleteLink);
            V("importLink", importLink);
            _InitReport(ReportID, Params, dataSourceUrl,
                Title, AddLink,
                ExtraParam, showDeafultButton,
                pageIndex, perCount
                );
        }
      
        
        protected void InitReport(string Title, string AddLink,
            string ExtraParam, bool showDeafultButton,
            string dbConnStringKey, 
            string deleteLink = "", string importLink = "")
        {
            if (!dbConnStringKey.HasValue())
            {
                throw new Exception("报表数据库配置错误！");
            }
            var pageIndex = Q_Int("pageIndex");
            var perCount = Q_Int("perCount");
            var ReportID =  Q("ReportID");
            var Params =  V("Params").CheckValue(Q("Params"));
            V("dbConnStringKey", dbConnStringKey);
            V("deleteLink", deleteLink);
            V("importLink", importLink);
            _InitReport(ReportID, Params, "",
                Title, AddLink,
                ExtraParam, showDeafultButton,
                pageIndex, perCount
            );
        }

        private void _InitReport(string ReportID, string Params,string dataSourceUrl,
            string Title, string AddLink,
            string ExtraParam, bool showDeafultButton,
            int pageIndex, int perCount)
        {
            V("ReportID", ReportID); V("Params", Params); V("Title", Title);
            V("AddLink", AddLink); V("dataSourceUrl", dataSourceUrl);
            V("ExtraParam", ExtraParam); V("showDeafultButton", showDeafultButton.ToString());
            V("pageIndex", pageIndex.ToString()); V("perCount", perCount.ToString());//分页参数
            V("Url", CurrentUrl()); V("UserID", DataContext.UserId);
            V("ReportControlConfig", Search.Serialize());
            //_BaseInitLayout(Title, "_Sb2ReportLayout");
        }


     
        #endregion

     
        protected string Q(string key)
        {
            return DataContext.Q(HttpContext, key);
           
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
            string value = Q(key);
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
            return Q(key);
        }
        protected object V(string key,string value)
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
   
        


        #region 权限
      
        #endregion
        #region 工作流

        //private IWorkFlowService _workFlow;
        //protected IWorkFlowService WorkFlowService
        //{
        //    get
        //    {
        //        if (_workFlow == null)
        //        {
        //            _workFlow = new WorkFlowService();
        //        }
        //        return _workFlow;
        //    }
        //}
      

        //private List<orgnization> _workFlowDoman;
        //protected List<string>  WorkFlowDoman
        //{
        // get
        //    {
        //        var uid =F("uid");
        //        if (uid==null)
        //        {
        //            throw  new Exception("未登录");
        //        }
        //        if (_workFlowDoman == null)
        //        {
        //            _workFlowDoman = Permmision.GetOrgIdByUserId(DataContext.UserId);
        //        }
        //        return _workFlowDoman.Select(a=>a.orgnization_id).ToList();
        //    }   
        //}

       
        //protected IActionResult CreateAndMoveNext(string workFlowId, string successTip, string failTip,
        //    object moveParam, Func<string, bool> doIfSuccessful, string reason = "未填写", RelationMoveParam relation = null
        //    )
        //{
        //    //var uid =F("uid"];
        //    var param = new WorkFlowParams(workFlowId, DataContext.UserId, DataContext.UnitId, moveParam, doIfSuccessful, DataContext.UserId, reason, relation);
        //    return WorkFlowService.CreateAndMoveNext(param) ?
        //        Json(State.SuccessAutoClose, successTip) : Json(State.Fail, failTip);
        //}
        //protected IActionResult MoveNext(string successTip, string failTip, 
        //    object moveParam, Func<string, bool> doIfSuccessful, string reason="未填写", RelationMoveParam relation = null)
        //{
        //    var workFlowInstanceId =F("id"); //var uid =F("uid"]; 
        //    var param=new WorkFlowParams(workFlowInstanceId,DataContext.UserId, moveParam, doIfSuccessful,DataContext.UserId,reason, relation);
        //    return WorkFlowService.MoveNext(param) ?
        //        Json(State.SuccessAutoClose, successTip) : Json(State.Fail, failTip); ;
        //}
        #endregion
        protected IActionResult Refresh()
        {
            return Content("<script>window.location.href=document.referrer</script>");
        }
      
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            HandleRequestParam();
           
            return base.OnActionExecutionAsync(context, next);
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
