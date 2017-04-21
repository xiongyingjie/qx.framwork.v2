using System;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Web.Controllers.Base;
using Qx.Wechat.Entity;
using Web.Areas.WeChat.ViewModels;


namespace Web.Areas.WeChat.Controllers
{
    public class NewsMsgItemController : BaseWeChatController, ICrud<NewsMsgItem_M>
    {
        // GET: WeChat/NewsMsgItem
        private IRepository<NewsMsgItem> _repository;

        public NewsMsgItemController(IRepository<NewsMsgItem> repository)
        {
            _repository = repository;
        }

        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("Index", new { reportId = "Qx.WeChat.新图文消息", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("新图文消息", "/WeChat/NewsMsgItem/Create");
            return View();
        }

        public ActionResult Create()
        {
            InitForm("添加新图文消息");
            return View(NewsMsgItem_M.ToViewModel());
        }
        [HttpPost]
        public ActionResult Create(NewsMsgItem_M viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //viewModel.ReplyMsgId =  DateTime.Now.Random().ToString();
                    viewModel.NewsMsgItemId = DateTime.Now.Random().ToString();
                    _repository.Add(viewModel.ToModel());
                    // TODO: 这里编写添加逻辑
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("添加新图文消息");
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
            if (id.HasValue())
            {
                _repository.Delete(id);
                return Alert("操作成功!");
            }
            // TODO: 这里编写删除逻辑
            else
            {
                return Alert("操作失败!");
            }
        }

        public ActionResult Details(string id)
        {
            throw new NotImplementedException();
        }
        public ActionResult Edit(string id)
        {
            InitForm("编辑新图文消息");
            var newmsgitem = _repository.Find(id);
            if (newmsgitem != null)
            {
                return View(NewsMsgItem_M.ToViewModel(newmsgitem));
            }
            else
            {
                return Alert("操作失败!");
            }
        }
        [HttpPost]
        public ActionResult Edit(NewsMsgItem_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(viewModel.ToModel());
                    // TODO: 这里编写更新逻辑
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("编辑新图文消息");
                    return View(viewModel);
                }

            }
            catch (Exception ex)
            {
                return Alert("请联系开发人员\n" + ex.Message);
            }
        }

    }
}