using Qx.Msg.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Msg.ViewModels.MsgSendRecord;
using Web.Controllers.Base;

namespace Web.Areas.Msg.Controllers
{
    public class MsgSendRecordController : BaseMsgController, ICrud<MsgSendRecord_M>
    {
        // TODO: 把<string> 更换为数据库model类型如 <Car>
        private IRepository<msg_send_record> _repository;
        private IRepository<msg_user> _userrepository;
        public MsgSendRecordController(IRepository<msg_send_record> repository, IRepository<msg_user> userrepository)
        {
            _repository = repository;
            _userrepository = userrepository;
        }
        //Msg/MsgSendRecord/Index
        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("Index", new { reportId = "QX.Msg.消息发送记录2", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("消息发送记录2", "MsgSendRecord/Create/");
            return View();
        }
        // GET: Area/Controller/Create
        public ActionResult Create()
        {
            InitForm("添加联系人");
            return View();
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(MsgSendRecord_M viewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (_userrepository.Find(viewModel.ReceiverID) == null)
                    {
                        return Alert("不存在该用户！", -1);
                    }
                    _repository.Add(viewModel.ToModel());
                    // TODO: 这里编写添加逻辑
                    return RedirectToAction("Index", new { });
                }
                else
                {
                    InitForm("添加联系人");
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
            InitForm("编辑联系人");
            var categoryattr = _repository.Find(id);
            if (categoryattr != null)
            {
                return View(MsgSendRecord_M.ToVoewModel(categoryattr));
            }
            else
            {
                return Alert("操作失败!");
            }
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(MsgSendRecord_M viewModel)
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
                    InitForm("编辑联系人");
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