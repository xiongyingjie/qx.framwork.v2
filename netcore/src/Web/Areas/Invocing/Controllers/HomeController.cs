﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Base;
using xyj.core.Extensions;

namespace Web.Areas.Invocing.Controllers
{
    [Area("Invocing")]
    public class HomeController : BaseController
    {
        public IActionResult storage_list()
        {
            throw new NotImplementedException();
        }
    
//Invocing/Home/RNFBM8437UD
public IActionResult RNFBM8437UD(string reportId, string Params)
{
if (!reportId.HasValue())
  {
    return RedirectToAction("RNFBM8437UD", 
        new { 
           reportId = "erp.invoicing.RWD.RNFBM8437UD",Params = "", pageIndex = 1, perCount = 10 
            });
  }
  
  InitReport("RNFBM8437UD", "#", "", true,"erp.invoicing");
  return ReportJson();
}
//Invocing/Home/test001
public IActionResult test001(string reportId, string Params)
{
if (!reportId.HasValue())
  {
    return RedirectToAction("test001", 
        new { 
           reportId = "erp.invoicing.RSH.test001",Params = "品牌编号;品牌名称;", pageIndex = 1, perCount = 10 
            });
  }
  
Search.Add("品牌编号");
Search.Add("品牌名称");
  InitReport("test001", "#", "", true,"erp.invoicing");
  return ReportJson();
}
//Invocing/Home/brand_001
public IActionResult brand_001(string reportId, string Params)
{
if (!reportId.HasValue())
  {
    return RedirectToAction("brand_001", 
        new { 
           reportId = "erp.invoicing.RM8.品牌管理_001",Params = "品牌编号;品牌名称", pageIndex = 1, perCount = 10 
            });
  }
  
Search.Add("品牌编号");
Search.Add("品牌名称");
  InitReport("品牌管理_001", "#", "", true,"erp.invoicing");
  return ReportJson();
}

//Invocing/Home/brand_list
public IActionResult brand_list(string reportId, string Params)
{
if (!reportId.HasValue())
  {
    return RedirectToAction("brand_list", 
        new { 
           reportId = "erp.invoicing.RR2.品牌管理002",Params = "品牌编号;品牌名称", pageIndex = 1, perCount = 10 
            });
  }
  
Search.Add("品牌编号");
Search.Add("品牌名称");
  InitReport("brand", "/Invocing/Home/brand_add", "", true,"erp.invoicing");
  return ReportJson();
}}
}