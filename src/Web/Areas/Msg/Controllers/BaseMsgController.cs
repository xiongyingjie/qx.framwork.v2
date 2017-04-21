using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Areas.Msg.Controllers
{
    public class BaseMsgController : BaseController
    {
        protected void InitReport(string Title, string AddLink, bool showDeafultButton = true, string ExtraParam = "")
        {
            base.InitReport(Title, AddLink, ExtraParam, showDeafultButton, "Qx.Msg");
        }
    }
}