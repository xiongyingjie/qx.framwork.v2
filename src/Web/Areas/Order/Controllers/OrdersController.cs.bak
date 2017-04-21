using Djk.FastCar.Interfaces;
using Djk.Order.Interfaces;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Order.ViewModel;
using Web.Controllers.Base;

namespace Web.Areas.Order.Controllers
{
    public class OrdersController : BaseOrderController,ICrud<Order_M>
    {
        private IStockRightServices _stockRightServices;
        private IRepository<Djk.Order.Entity.order> _repository;
        public OrdersController(IStockRightServices stockRightServices, IRepository<Djk.Order.Entity.order> repository)
        {
            _stockRightServices = stockRightServices;
            _repository = repository;
        }
        public ActionResult Index(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("Index", new { ReportID = "Djk.Order.我的订单", Params = "" });
            }

            //初始化报表
            InitReport(_stockRightServices.FindAllOrders(DataContext,Params), "我的订单", "#");
            return View();
        }
        public ActionResult CheckedOrder(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("CheckedOrder", new { ReportID = "Djk.Order.待付款订单", Params = "" });
            }

            //初始化报表
            InitReport(_stockRightServices.FindCheckedOrders(DataContext,Params), "待付款订单", "#");
            return View();
        }
        public ActionResult DoneOrder(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("DoneOrder", new { ReportID = "Djk.Order.已完成订单", Params = "" });
            }

            //初始化报表
            InitReport(_stockRightServices.FindDoneOrders(DataContext,Params), "已完成订单", "#");
            return View();
        }
        public ActionResult MyDoneOrder(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("DoneOrder", new { ReportID = "Djk.Order.卖家版已完成订单", Params = "" });
            }

            //初始化报表
            InitReport(_stockRightServices.FindMyDoneOrders(DataContext, Params), "已完成订单", "#");
            return View();
        }
        public ActionResult MyOrder(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("MyOrder", new { ReportID = "Djk.Order.卖家版我的订单", Params = "" });
            }

            //初始化报表
            InitReport(_stockRightServices.FindMyAllOrders(DataContext, Params), "我的订单", "#");
            return View();
        }
        public ActionResult MyCheckedOrder(string ReportID, string Params, int pageIndex = 1, int perCount = 10)
        {
            if (!ReportID.HasValue())
            {
                return RedirectToAction("MyCheckedOrder", new { ReportID = "Djk.Order.卖家版待付款订单", Params = "" });
            }

            //初始化报表
            InitReport(_stockRightServices.FindMyCheckedOrders(DataContext, Params), "待付款订单", "#");
            return View();
        }
        public ActionResult Create()
        {
            InitForm("添加内容表");
            return View();
        }

        // POST: Area/Controller/Create
        [HttpPost]
        public ActionResult Create(Order_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
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
            InitForm("编辑内容表");
            return View();
        }

        // POST: Area/Controller/Edit/5
        [HttpPost]
        public ActionResult Edit(Order_M viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
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