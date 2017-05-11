using Qx.Contents.Exceptions;
using Qx.Contents.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Areas.Contents.Controllers
{
    public class ColumnAPIController : Controller
    {
        private WebSiteService _webSiteService;
        public ColumnAPIController(WebSiteService webSiteService)
        {
            _webSiteService = webSiteService;
        }

        [HttpGet]
        [Route("api/json-getSigleColumn/{id}")]
        public JsonResult GetSigleColumnDesign(string id)
        {
            try
            {
                var result = _webSiteService.GetSigleColumnDesign(id);
                return result;
            }
            catch (ParamNumberInccorectException)
            {
                throw;
            }
            catch (ParmFlagInccorectException)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/json-getMutiPleColumn/{id}")]
        public JsonResult GetMultipleColumnDesign(string id)
        {
            try
            {
                var result = _webSiteService.GetMultipleColumnDesign(id);
                return result;
            }
            catch (ParamNumberInccorectException)
            {
                throw;
            }
            catch (ParmFlagInccorectException)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("api/json-getDynamicQuote/{id}")]
        public JsonResult GetDynamicQuote(string id)
        {
            try
            {
                var result = _webSiteService.GetLibrarys();
                return result;
            }
            catch (GetLibraryFailException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/postTableDetail/{id}")]
        public JsonResult PostTableDetail(string id)
        {
            try
            {
                var result = _webSiteService.GetLibrarys();
                return result;
            }
            catch (GetLibraryFailException)
            {
                throw;
            }
        }
    }
}
