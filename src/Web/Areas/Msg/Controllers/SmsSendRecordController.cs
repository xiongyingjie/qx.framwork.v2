using Qx.Msg.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Msg.ViewModels.SmsSendRecord;
using Web.Controllers.Base;

namespace Web.Areas.Msg.Controllers
{
    public class SmsSendRecordController : BaseMsgController, ICrud<SmsSendRecord_M>
    { 
        // TODO: 把<string> 更换为数据库model类型如 <Car>
        private IRepository<sms_send_record> _repository;
        private IRepository<msg> _msgrepository;


        public SmsSendRecordController(IRepository<sms_send_record> repository, IRepository<msg> msgrepository)
        {
            _repository = repository;
            _msgrepository = msgrepository;
        }
        //Msg/SmsSendRecord/Index
        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("Index", new { reportId = "QX.Msg.短信发送记录2", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("短信发送记录2", "SmsSendRecord/Create/");
            return View();
        }
        // GET: Area/SmsSendRecord/Create
        public ActionResult Create()
        {
            InitForm("创建短信发送");
            return View();
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(SmsSendRecord_M viewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(viewModel.ToModel());
                    // TODO: 这里编写添加逻辑
                    return RedirectToAction("Index", new { });
                }
                else
                {
                    InitForm("创建短信发送");
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
            InitForm("编辑短信发送");
            var categoryattr = _repository.Find(id);
            if (categoryattr != null)
            {
                return View(SmsSendRecord_M.ToModel(categoryattr));
            }
            else
            {
                return Alert("操作失败!");
            }
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(SmsSendRecord_M viewModel)
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
                    InitForm("编辑短信发送");
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

            InitForm("详情");
            var categoryattr = _repository.Find(id);
            if (categoryattr != null)
            {
                return View(SmsSendRecord_M.ToModel(categoryattr));
            }
            else
            {
                return Alert("操作失败!");
            }
            // TODO: 这里编写详情逻辑
        }


    }
}