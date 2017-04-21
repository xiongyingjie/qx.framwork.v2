using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Areas.WorkFlow.Controllers
{
    public class BaseWorkFlowController : BaseController
    {
        protected void InitReport(string Title, string AddLink, string ExtraParam, int pageIndex, int perCount, bool showDeafultButton = true)
        {
            base.InitReport(Title, AddLink, ExtraParam, showDeafultButton, "Qx.WorkFlow");
        }
    }
}