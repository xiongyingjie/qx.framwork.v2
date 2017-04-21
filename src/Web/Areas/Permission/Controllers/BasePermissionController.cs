using System;
using Web.Controllers.Base;

namespace Web.Areas.Permission.Controllers
{
    public class BasePermissionController : AccountFilterController
    {
        protected void InitReport(string Title, string AddLink, int pageIndex, int perCount, string ExtraParam = "", bool showDeafultButton = true)
        {
            base.InitReport(Title, AddLink,  ExtraParam,showDeafultButton, "Qx.Permission");
        }

        protected string BackToReport
        {
            get
            {
                return "该属性已禁用";
            }
           
    }
    }
}
