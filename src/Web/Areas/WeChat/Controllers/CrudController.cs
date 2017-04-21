using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Wechat.Repository;

namespace Web.Areas.WeChat.Controllers
{
    public class CrudController : BaseWeChatController
    {
        private ImageMsgRepository _imageMsgRepository;

        public CrudController(ImageMsgRepository imageMsgRepository)
        {
            _imageMsgRepository = imageMsgRepository;
        }

        // GET: WeChat/Crud
        public ActionResult Index()
        {
            return View();
        }
    }
}