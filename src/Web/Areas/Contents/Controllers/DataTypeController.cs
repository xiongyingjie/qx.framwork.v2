using Qx.Contents.Entity;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Controllers.Base;
using Qx.Tools.CommonExtendMethods;
using Web.Areas.Contents.ViewModels;

namespace Web.Areas.Contents.Controllers
{
    public class DataTypeController : BaseContentsController, ICrud<DataType_M>
    {
        // TODO: 把<string> 更换为数据库model类型如 <Car>
        private IRepository<data_type> _repository;

        public DataTypeController(IRepository<data_type> repository)
        {
            _repository = repository;
        }

        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("Index", new { reportId = "Qx.Contents.数据类型", Params = ";", pageIndex = 1, perCount = 10 });
            }
            InitReport("数据类型", "/Contents/DataType/Create", pageIndex, perCount);
            return View();
        }

        // GET: Area/Controller/Create
        public ActionResult Create()
        {
            InitForm("添加数据类型");
            return View(new DataType_M());
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(DataType_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    viewModel.DT_ID = DateTime.Now.Random().ToString();
                    _repository.Add(viewModel.ToModel());
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("添加数据类型");
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
            InitForm("编辑数据类型");
            return View(DataType_M.ToViewModel(_repository.Find(id)));
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(DataType_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(viewModel.ToModel());
                    return RedirectToAction("Index");
                }
                else
                {
                    InitForm("编辑数据类型");
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
                return Alert("删除成功");
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