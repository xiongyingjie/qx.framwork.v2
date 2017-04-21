using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;

namespace Web.Areas.WeChat.Controllers
{
    public class BaseBookTiketController : AccountFilterController
    {
     
        protected void InitReportToBookTicket(string Title, string AddLink, bool showDeafultButton = true, string ExtraParam = "")
        {
            base.InitReport(Title, AddLink, ExtraParam, showDeafultButton, "wx.book_ticket");
        }
        protected void InitReportToBookTicket(List<List<string >> dataSource,string Title, string AddLink)
        {
            base.InitReport(dataSource,Title, AddLink);
        }
    }
}