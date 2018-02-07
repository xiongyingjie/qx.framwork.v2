using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Web.Controllers.Base;
using xyj.core.Extensions;
using xyj.core.Models.Form;
using xyj.core.Models.Http;

namespace Web.Controllers.Filter
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class HttpGlobalExceptionFilter :BaseController, IExceptionFilter
    {
        readonly ILoggerFactory _loggerFactory;
        readonly IHostingEnvironment _env;

        public HttpGlobalExceptionFilter(ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            _loggerFactory = loggerFactory;
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            var logger = _loggerFactory.CreateLogger(context.Exception.TargetSite.ReflectedType);

            logger.LogError(new EventId(context.Exception.HResult),
                context.Exception,
                context.Exception.Message);


            
            var debug = bool.Parse(DataContext.Q(context.HttpContext,"isDebug"));
            if (debug)
            {
                var ex = context.Exception;

                var message = ex.Message;
                //if (ex.GetType() == typeof(DbEntityValidationException))
                //{
                //    var entityEx = (DbEntityValidationException)ex;
                //    message = entityEx.Message + ":<br/>" + entityEx.EntityValidationErrors.SelectMany(a => a.ValidationErrors.Select(b => b.ErrorMessage))
                //                  .ToList()
                //                  .PackString("<br/>");
                //}
                if (ex.GetType() == typeof(DbUpdateException))
                {
                    var entityEx = (DbUpdateException)ex;
                    message = entityEx.Message;
                    if (entityEx.InnerException?.InnerException != null)
                        message += ":<br/>" + entityEx.InnerException.InnerException.Message;
                }
               
                context.Result=new JsonResult(new FormUI()
                {
                    code = (int)State.Error,
                    jsonData = new { Message = message, StackTrace = ex.StackTrace, InnerException = ex.InnerException }.Serialize(),
                    msg = "请求失败",
                    url = ""
                }.Serialize());
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                context.ExceptionHandled = true;
            }



            //var json = new ErrorResponse("未知错误,请重试");

            //if (_env.IsDevelopment())
            //    json.DeveloperMessage = context.Exception;

            //context.Result = new ApplicationErrorResult(json);
            //context.HttpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

            //context.ExceptionHandled = true;
        }

        public class ApplicationErrorResult : ObjectResult
        {
            public ApplicationErrorResult(object value) : base(value)
            {
                StatusCode = (int) HttpStatusCode.InternalServerError;
            }
        }

        public class ErrorResponse
        {
            public ErrorResponse(string msg)
            {
                Message = msg;
            }

            public string Message { get; set; }
            public object DeveloperMessage { get; set; }
        }
    }
}
