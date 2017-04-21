using Qx.Msg.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Msg.ViewModels.TimerMsg;
using Web.Controllers.Base;

namespace Web.Areas.Msg.Controllers
{
    public class TimerMsgController : BaseMsgController, ICrud<TimerMsg_M>
    {
        // TODO: 把<string> 更换为数据库model类型如 <Car>
        private IRepository<timer_msg> _repository;
        private IRepository<msg> _msgrepository;


        public TimerMsgController(IRepository<timer_msg> repository, IRepository<msg>msgrepository)
        {
            _repository = repository;
            _msgrepository =msgrepository;
        }
        //Msg/TimerMsg/Index
        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("Index", new { reportId = "QX.Msg.定时消息2", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("定时消息2", "TimerMsg/Create/");
            return View();
        }
        // GET: Area/Controller/Create
        public ActionResult Create()
        {
            InitForm("创建定时消息");
            return View();
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(TimerMsg_M viewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (_msgrepository.Find(viewModel.MsgID) == null)
                    {
                        return Alert("没有此消息",-1);                       
                     }
                    _repository.Add(viewModel.ToModel());
                    // TODO: 这里编写添加逻辑
                    return RedirectToAction("Index", new { });
                }
                else
                {
                    InitForm("创建定时消息");
                    return View(viewModel);
                }

            }
            catch (Exception ex)
            {
                return Alert("请联系开发人员\n" + ex.Message);
            }
        }

        // GET: Area/Controller/Edit/5
        public ActionResult Edit(string id)
        {
            InitForm("编辑定时消息");
            var categoryattr = _repository.Find(id);
            if (categoryattr != null)
            {
                return View(TimerMsg_M.ToViewModel(categoryattr));
            }
            else
            {
                return Alert("操作失败!");
            }
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(TimerMsg_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(viewModel.ToModel());
                    // TODO: 这里编写更新逻辑
                    return RedirectToAction("Index", new { });
                }
                else
                {
                    InitForm("编辑定时消息");
                    return View(viewModel);
                }

            }
            catch (Exception ex)
            {
                return Alert("请联系开发人员\n" + ex.Message);
            }
        }

        // GET: Area/Controller/Delete/5
        public ActionResult Delete(string id)
        {
            // TODO: 这里编写删除逻辑
            if (id.HasValue())
            {
                _repository.Delete(id);
                return Alert("操作成功!");
            }
            else
            {
                return Alert("操作失败!");
            }
        }

        // GET: Area/Controller/Details/5
        public ActionResult Details(string id)
        {
            InitForm("这里填写标题");
            // TODO: 这里编写详情逻辑
            return View();
        }


    }
}