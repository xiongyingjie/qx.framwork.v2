using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Web.Controllers.Base;
using Web.ViewModels.Demo;

namespace Web.Controllers
{
    public class CrudDemoController : AccountFilterController,ICrud<Form_M>
    {
        // TODO: 把<string> 更换为数据库model类型如 <Car>
        private IRepository<string> _repository;

        public CrudDemoController(IRepository<string> repository)
        {
            _repository = repository;
        }

        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {
                
                return RedirectToAction("Index", new { reportId = "这里填写报表编号", Params = ";", pageIndex = 1, perCount = 10 });
            }
           // InitReport("这里填写报表标题", "这里填写添加按钮地址", pageIndex, perCount);
            return View();
        }

        // GET: Area/Controller/Create
        public ActionResult Create()
        {
            InitForm("这里填写标题");
            return View();
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(Form_M viewModel)
        {
            try
            {    
                if (ModelState.IsValid)
                {
                    // TODO: 这里编写添加逻辑
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("这里填写标题");
                    return View(viewModel);
                }
                
            }
            catch(Exception ex)
            {
                return Alert("请联系开发人员\n"+ex.Message);
            }
        }

        // GET: Area/Controller/Edit/5
        public ActionResult Edit(string id)
        {
            InitForm("这里填写标题");
            return View();
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(Form_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: 这里编写更新逻辑
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("这里填写标题");
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
            return View();
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