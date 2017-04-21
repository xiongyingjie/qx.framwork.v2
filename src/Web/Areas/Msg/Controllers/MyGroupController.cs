using System.Web.Mvc;
using Qx.Msg.Interfaces;
using Qx.Tools.CommonExtendMethods;

namespace Web.Areas.Msg.Controllers
{
    public class MyGroupController : BaseMsgController
    {
        // GET: Msg/MyGroup
        private IMsgService _repository;
        public MyGroupController(IMsgService repository)
        {
            _repository = repository;
        }
        // GET: Msg/MyGroup/MyGroupList
        public ActionResult MyGroupList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("MyGroupList", new { ReportID = "QX.Msg.我的群组3", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport(_repository.MyGroup(DataContext.UserID, Params), "我的群组3", "ContacterAdd");
            return View();
        }
        // GET: Msg/MyGroup/MyGroupDetails
        public ActionResult MyGroupDetails(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("MyGroupDetails", new { ReportID = "QX.Msg.我的群组详情3", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport(_repository.GroupDetails(Params.UnPackString(';')[0], Params.UnPackString(';')[1]), "我的群组详情3", "ContacterAdd?Group" + Params.UnPackString(';')[0]);
            return View();
        }
    }
}