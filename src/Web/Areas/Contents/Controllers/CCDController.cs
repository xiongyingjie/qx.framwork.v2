using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Contents.Entity;
using Qx.Tools.Interfaces;
using Web.Areas.Contents.ViewModels;
using Web.Controllers.Base;

namespace Web.Areas.Contents.Controllers
{
    public class CCDController : BaseContentsController,ICrud<CCD_M>
    {
        // TODO: 把<string> 更换为数据库model类型如 <Car>
        private IRepository<content_column_design> _repository;
        private IRepository<content_table_design> _ctdrepository;
        private IRepository<page_control_type> _pctrepository;
        private IRepository<data_type> _dtrepository;

        public CCDController(IRepository<content_column_design> repository, IRepository<content_table_design> ctdrepository,
            IRepository<page_control_type> pctrepository, IRepository<data_type> dtrepository)
        {
            _repository = repository;
            _ctdrepository = ctdrepository;
            _pctrepository = pctrepository;
            _dtrepository = dtrepository;
        }

        public ActionResult Index(string reportId, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("Index", new { reportId = "Qx.Contents.内容列", Params = Params, pageIndex = 1, perCount = 10 });
            }
            InitReport("内容列", "/Contents/CCD/Create?CTD_ID="+Params, pageIndex, perCount);
            return View(CCD_M.ToViewModel(_ctdrepository.ToSelectItems(), Params.UnPackString(';')[0]) );
        }

        // GET: Area/Controller/Create
        public ActionResult Create()
        {
            var CTD_ID = Q("CTD_ID");
            InitForm("添加内容列");
            CTD_ID = CTD_ID.UnPackString(';')[0];
            return View(CCD_M.ToViewModel(CTD_ID, _dtrepository.ToSelectItems(), _pctrepository.ToSelectItems()));
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(CCD_M viewModel)
        {
            try
            {    
                if (ModelState.IsValid)
                {
                    _repository.Add(viewModel.ToModel());
                    return RedirectToAction("Index",new {Params=viewModel.CTD_ID });
                }
                else
                {
                    InitForm("添加内容列");
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
            InitForm("编辑内容列");
            return View(CCD_M.ToViewModel(_repository.Find(id),_ctdrepository.ToSelectItems(),_dtrepository.ToSelectItems(),_pctrepository.ToSelectItems()));
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(CCD_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Update(viewModel.ToModel());
                    return RedirectToAction("Index", new { Params = viewModel.CTD_ID });
                }
                else
                {
                    InitForm("编辑内容列");
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
                return Alert("删除成功!");
            }
            else
                return Alert("操作失败!");
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