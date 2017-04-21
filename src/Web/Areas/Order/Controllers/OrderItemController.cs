using Qx.Tools;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System;
using System.Web.Mvc;
using Qx.Order.Entity;
using Web.Areas.Order.ViewModel;

using Web.Controllers.Base;

namespace Web.Areas.Order.Controllers
{
    public class OrderItemController : BaseOrderController,ICrud<OrderItem_M>
    {

        private IRepository<order_item> _repository;
        public OrderItemController( IRepository<order_item> repository)
        {
            
            _repository = repository;
        }
        public ActionResult Index(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Index", new { ReportID = "Djk.Order.订单项", Params = Params });
            }

            //初始化报表
            InitReport("订单项", "#","",true,"");
            return View();
        }

        // GET: Area/Controller/Create
        public ActionResult Create()
        {
            InitForm("添加订单项");
            return View();
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(OrderItem_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.Add(viewModel.ToModel());
                    return RedirectToAction("Index");
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
            InitForm("编辑订单项");
            return View();
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderItem_M viewModel)
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