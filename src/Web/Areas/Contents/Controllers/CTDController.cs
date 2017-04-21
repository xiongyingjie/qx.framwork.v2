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
    public class CTDController : BaseContentsController, ICrud<CTD_M>
    {
        // TODO: 把<string> 更换为数据库model类型如 <Car>
        private IRepository<content_table_design> _repository;
        private IRepository<content_type> _ctrepository;
        public CTDController(IRepository<content_table_design> repository, IRepository<content_type> ctrepository)
        {
            _repository = repository;
            _ctrepository = ctrepository;
        }

        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {

                return RedirectToAction("Index", new { reportId = "Qx.Contents.内容表", Params = Params, pageIndex = 1, perCount = 10 });
            }
            InitReport("内容表", "/Contents/CTD/Create?CT_ID="+Params, pageIndex, perCount);
            return View(CTD_M.ToViewModel(_ctrepository.ToSelectItems(), Params.UnPackString(';')[0]));
        }

        // GET: Area/Controller/Create
        public ActionResult Create()
        {
            var CT_ID = Q("CT_ID");
            InitForm("添加内容表");
            CT_ID = CT_ID.UnPackString(';')[0];
            var ct=_ctrepository.Find(CT_ID);
            return View(CTD_M.ToViewModel(_ctrepository.ToSelectItems(), CT_ID,ct.TypeName));
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(CTD_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(viewModel.ToModel());
                    return RedirectToAction("Index",new { Params=viewModel.CT_ID+";"+viewModel.typename});
                }
                else
                {
                    InitForm("添加内容表");
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
            InitForm("编辑内容表");          
            return View(CTD_M.ToViewModel(_repository.Find(id),_ctrepository.ToSelectItems()));
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(CTD_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(viewModel.ToModel());
                    return RedirectToAction("Index", new { Params = viewModel.CT_ID+";"+viewModel.typename });
                }
                else
                {
                    InitForm("编辑内容表");
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