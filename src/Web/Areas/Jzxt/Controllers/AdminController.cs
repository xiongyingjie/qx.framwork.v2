using System.Collections.Generic;
using System.Web.Mvc;
using Qx.Msg.Interfaces;

namespace Web.Areas.Jzxt.Controllers
{
    public class AdminController : BaseJzxtController
    {
        private IMsgService _msgService;

        public AdminController(IMsgService msgService)
        {
            _msgService = msgService;
        }

        // GET: Msg/Admin/Index
        public ActionResult Index()
        {
            InitMenu(new Dictionary<string, string>()
            {
                 {"通讯组设置（管理员）","/Msg/Group/GroupEdit?ReportID=QX.Msg.通讯组设置&Params=;"},
                 //{"用户信息编辑（管理员）","/Msg/Users/UsersList?ReportID=QX.Msg.用户信息编辑&Params=;"},
                 {"我的联系人","/R/MemberMsg/MyContacter?ReportID=QX.Msg.我的通讯录&Params=;"},
                 {"我的群组","/Msg/Group/MyGroupsList?ReportID=QX.Msg.我的通讯组&Params=;"},
                 {"未读消息","/R/MemberMsg/UnReadMsg? ReportID = QX.Msg.未读消息& Params = DataContext.UserID"},
                 {"发消息","/Msg/MsgSendRecord/SendMsg"},
                 {"发件箱","/R/MemberMsg/OutBox?ReportID = QX.Msg.发件箱&Params = DataContext.UserID"},
                 {"收件箱","/R/MemberMsg/InBox? ReportID = QX.Msg.收件箱&Params = DataContext.UserID"},
                 {"草稿箱","/R/MemberMsg/Drafts?ReportID = QX.Msg.草稿箱& Params = DataContext.UserID"},               
                 {"我的收藏","/R/MemberMsg/MsgCollections/MsgCollectionsList?ReportID=QX.Msg.我的收藏&Params=;"},
                 {"定时消息发送记录","/R/MemberMsg/TimerSendRecords?ReportID=QX.Msg.定时消息发送记录&Params = DataContext.UserID"},
                 {"定时消息任务列表","/R/MemberMsg/TimerTask?ReportID = QX.Msg.定时消息任务列表&Params = DataContext.UserID"},
            });
            return View();
        }
    }
}