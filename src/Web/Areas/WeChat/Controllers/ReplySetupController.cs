using System;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Web.Controllers.Base;
using Qx.Wechat.Entity;
using Web.Areas.WeChat.ViewModels;

namespace Web.Areas.WeChat.Controllers
{
    public class ReplySetupController : BaseController, ICrud<ReplySetup_M>
    {
        // GET: WeChat/ReplySetup
        private IRepository<ReplySetup> _repository;
        private IRepository<ReplyMsg> _ReplyMsg;

        public ReplySetupController(IRepository<ReplySetup> repository, IRepository<ReplyMsg> ReplyMsg)
        {
            _repository = repository;
            _ReplyMsg = ReplyMsg;
        }
        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("Index", new { reportId = "Qx.WeChat.回复设置", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("回复设置", "/WeChat/ReplySetup/Create","",true, "Qx.WeChat");
            return View();
        }

        public ActionResult Create()
        {
            InitForm("回复设置");
            return View(ReplySetup_M.ToViewModel());
        }
        [HttpPost]
        public ActionResult Create(ReplySetup_M viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    viewModel.ReplyMsgId =  DateTime.Now.Random().ToString();
                    viewModel.ReplySetupId = DateTime.Now.Random().ToString();
                    ReplyMsg replymsg = new ReplyMsg();
                    replymsg.ReplyMsgId = viewModel.ReplySetupId;
                    _repository.Add(viewModel.ToModel());              
                    _ReplyMsg.Add(replymsg); 
                    // TODO: 这里编写添加逻辑
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("回复设置");
                    return View(viewModel);
                }
            }
            catch (Exception ex)
            {
                return Alert("请联系开发人员\n" + ex.Message);
            }
        }

        public ActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }
         
        public ActionResult Details(string id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(ReplySetup_M viewModel)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(string id)
        {
            throw new NotImplementedException();
        }

    }
}