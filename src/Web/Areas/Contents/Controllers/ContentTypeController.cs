using Qx.Contents.Entity;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Contents.ViewModels;
using Web.Controllers.Base;
using Qx.Tools.CommonExtendMethods;
namespace Web.Areas.Contents.Controllers
{
    public class ContentTypeController :BaseContentsController, ICrud<ContentType_M>
    {
        // TODO: 把<string> 更换为数据库model类型如 <Car>
        private IRepository<content_type> _repository;

        public ContentTypeController(IRepository<content_type> repository)
        {
            _repository = repository;
        }

        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("Index", new { reportId = "Qx.Contents.内容分类", Params = "0", pageIndex = 1, perCount = 10 });
            }
            InitReport("内容分类", "/Contents/ContentType/Create?FatherID="+Params, pageIndex, perCount);
            return View();
        }

        // GET: Area/Controller/Create
        public ActionResult Create()
        {
            var fatherid = Q("FatherID");
            InitForm("添加内容分类");
            return View(ContentType_M.ToViewModel(fatherid));
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(ContentType_M viewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: 这里编写添加逻辑
                viewModel.CT_ID = DateTime.Now.Random();
                _repository.Add(viewModel.ToModel());
                return RedirectToAction("Index", new { reportId = "Qx.Contents.内容分类", Params = viewModel.FatherID });
            }
            else
            {
                InitForm("添加内容分类");
                return View(viewModel);
            }
            //try
            //{    


            //}
            //catch(Exception ex)
            //{
            //    return Alert("请联系开发人员\n"+ex.Message);
            //}
        }

        // GET: Area/Controller/Edit/5
        public ActionResult Edit(string id)
        {
            InitForm("编辑内容分类");
            var contype = _repository.Find(id);
            if (contype != null)
            {
                return View(ContentType_M.ToViewModel(contype));
            }
            else
            {
                return Alert("操作失败！");
            }
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(ContentType_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: 这里编写更新逻辑
                    _repository.Update(viewModel.ToModel());
                    return RedirectToAction("Index", new { reportId = "Qx.Contents.内容分类", Params = viewModel.FatherID });
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
            if (id.HasValue())
            {
                _repository.Delete(id);
                return Alert("删除成功！");
            }
            else
            {
                return Alert("操作失败！");
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