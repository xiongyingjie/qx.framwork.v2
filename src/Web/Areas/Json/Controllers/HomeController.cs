using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Json.Models;

namespace Web.Areas.Json.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Json/Home/Index
        public ActionResult Index()
        {
            return Json(new
            {
                msg="调用成功！当前时间"+DateTime.Now
            },
                JsonRequestBehavior.AllowGet);
        }
        // GET: /Json/Home/Questions
        public ActionResult Questions()
        {
            return Json(new Question()
            {
                
            },
               JsonRequestBehavior.AllowGet);
        }
        // GET: /Json/Home/QuestionTypes
        public ActionResult QuestionTypes()
        {
            return Json(new List<QuestionType>()
            {
                new QuestionType()
                {
                    TypeId = "1",
                    TypeName = "热门问答"
                },
                  new QuestionType()
                {
                    TypeId = "2",
                    TypeName = "最新问答"
                }
            },
                JsonRequestBehavior.AllowGet);
        }
    }
}