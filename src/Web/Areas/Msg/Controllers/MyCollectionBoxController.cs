using System.Web.Mvc;
using Qx.Msg.Interfaces;
using Qx.Tools.CommonExtendMethods;

namespace Web.Areas.Msg.Controllers
{
    public class MyCollectionBoxController : BaseMsgController
    {
        // GET: Msg/MyCollectionBox
        private IMsgService _repository;
        public MyCollectionBoxController(IMsgService repository)
        {
            _repository = repository;
        }
        // GET:  Msg/MyCollectionBox/MyCollectionList
        public ActionResult MyCollectionList(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("MyCollectionList", new { ReportID = "QX.Msg.我的收藏3", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport(_repository.MyCollectionBoxMsg(DataContext.UserID, Params), "我的收藏3", "#");
            return View();
        }
    }
} 