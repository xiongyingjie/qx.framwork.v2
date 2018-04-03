using System;
using System.Diagnostics;
using System.Text;
using Dapper;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Models;
using xyj.acs.Interfaces;
using erp.invoicing.Interfaces;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        private IInvoicingService _ylService;

        public HomeController(IInvoicingService ylService)
        {
            _ylService = ylService;
        }

        public IActionResult Index()
        {
           // _ylService.Test();
            return Content(DateTime.Now+ " => 服务器启动成功: " + Request.Scheme + "://" + Request.Host.Host + ":"+ Request.GetUri().Port+"\n");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
