using System;
using System.Diagnostics;
using System.Text;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Web.Models;
using xyj.acs.Interfaces;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
          
            return Content("服务器启动成功");
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
