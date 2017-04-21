using Qx.Msg.Entity;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Msg.ViewModels.Msg;
using Web.Controllers.Base;

namespace Web.Areas.Msg.Controllers
{
    public class MsgController : BaseMsgController, ICrud<Msg_M>
    {
        // TODO: 把<string> 更换为数据库model类型如 <Car>
        private IRepository<msg> _repository;
        private IRepository<msg_user> _userrepository;
        private IRepository<msg_type> _typerepository;

        public MsgController(IRepository<msg> repository, IRepository<msg_user> userrepository, IRepository<msg_type>typerepository)
        {
            _repository = repository;
            _userrepository=userrepository;
            _typerepository = typerepository;
        }
        //Msg/Msg/Index
        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("Index", new { reportId = "QX.Msg.消息2", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("消息2", "Msg/Create/");
            return View();
        }
        // GET: Area/Controller/Create
        public ActionResult Create()
        {
            InitForm("添加消息");
            return View();
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(Msg_M viewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (_userrepository.Find(viewModel.SenderID) == null)
                    {
                        return Alert("不存在该用户！", -1);
                    }
                    if (_typerepository.Find(viewModel.MsgTypeID) == null)
                    {
                        return Alert("不存在消息类型！", -1);
                    }
                    _repository.Add(viewModel.ToModel());
                    // TODO: 这里编写添加逻辑
                    return RedirectToAction("Index", new { });
                }
                else
                {
                    InitForm("添加消息");
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
            InitForm("编辑消息");
            var categoryattr = _repository.Find(id);
            if (categoryattr != null)
            {
                return View(Msg_M.ToViewModel(categoryattr));
            }
            else
            {
                return Alert("操作失败!");
            }
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(Msg_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_userrepository.Find(viewModel.SenderID) == null)
                    {
                        return Alert("不存在该用户！", -1);
                    }
                    if (_typerepository.Find(viewModel.MsgTypeID) == null)
                    {
                        return Alert("不存在消息类型！", -1);
                    }
                    _repository.Update(viewModel.ToModel());
                    // TODO: 这里编写更新逻辑
                    return RedirectToAction("Index", new { });
                }
                else
                {
                    InitForm("编辑消息");
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
            InitForm("消息详情");
            var categoryattr = _repository.Find(id);
            if (categoryattr != null)
            {
                return View(Msg_M.ToViewModel(categoryattr));
            }
            else
            {
                return Alert("操作失败!");
            }
        }


    }
}