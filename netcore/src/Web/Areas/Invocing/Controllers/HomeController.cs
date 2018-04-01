using System;
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

        //Invocing/Home/storage_list
        public IActionResult storage_list(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("storage_list",
                    new
                    {
                        reportId = "erp.invoicing.RZT.仓库信息设置",
                        Params = "仓库编码;仓库名称;联系人;电话;地址;邮箱",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("仓库编码");
            Search.Add("仓库名称");
            Search.Add("联系人");
            Search.Add("电话");
            Search.Add("地址");
            Search.Add("邮箱");
            InitReport("仓库信息设置", "/Invocing/Home/storage_add", "", true, "erp.invoicing");
            return ReportJson();
        }

        //Invocing/Home/product_type_list
        public IActionResult product_type_list(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("product_type_list",
                    new
                    {
                        reportId = "erp.invoicing.RBM.商品分类设置",
                        Params = "商品分类编号;分类名称",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("商品分类编号");
            Search.Add("分类名称");
            InitReport("商品分类设置", "/Invocing/Home/product_type_add", "", true, "erp.invoicing");
            return ReportJson();
        }

        //Invocing/Home/product_list
        public IActionResult product_list(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("product_list",
                    new
                    {
                        reportId = "erp.invoicing.RKM.商品信息设置",
                        Params = "货号;商品名称;主条码;零售价;批发价;参考进价;产品类别;品牌名称;货商名称",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("货号");
            Search.Add("商品名称");
            Search.Add("主条码");
            Search.Add("零售价");
            Search.Add("批发价");
            Search.Add("参考进价");
            Search.Add("产品类别");
            Search.Add("品牌名称");
            Search.Add("货商名称");
            InitReport("商品信息设置", "/Invocing/Home/product_add", "", true, "erp.invoicing");
            return ReportJson();
        }

        //Invocing/Home/provider_list
        public IActionResult provider_list(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("provider_list",
                    new
                    {
                        reportId = "erp.invoicing.R76.供应商信息管理",
                        Params = "货商编码;货商名称;联系人;电话;电子邮件;货商分类RPM;发票类型R7T",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("货商编码");
            Search.Add("货商名称");
            Search.Add("联系人");
            Search.Add("电话");
            Search.Add("电子邮件");
            Search.Add("货商分类");
            Search.Add("发票类型");
            InitReport("供应商信息管理", "/Invocing/Home/provider_add", "", true, "erp.invoicing");
            return ReportJson();
        }
        //Invocing/Home/customer_list
        public IActionResult customer_list(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("customer_list",
                    new
                    {
                        reportId = "erp.invoicing.RHR.客户信息设置",
                        Params = "客户编码;客户名称;联系人;电话;电子邮件;客户分类;发票类型;区域;地址",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("客户编码");
            Search.Add("客户名称");
            Search.Add("联系人");
            Search.Add("电话");
            Search.Add("电子邮件");
            Search.Add("客户分类");
            Search.Add("发票类型");
            Search.Add("区域");
            Search.Add("地址");
            InitReport("客户信息设置", "/Invocing/Home/customer_add", "", true, "erp.invoicing");
            return ReportJson();
        }
        //Invocing/Home/brand_list
        public IActionResult brand_list(string reportId, string Params)
        {
            if (!reportId.HasValue())
            {
                return RedirectToAction("brand_list",
                    new
                    {
                        reportId = "erp.invoicing.R45.品牌管理",
                        Params = "品牌编号;品牌名称",
                        pageIndex = 1,
                        perCount = 10
                    });
            }

            Search.Add("品牌编号");
            Search.Add("品牌名称");
            InitReport("品牌管理", "/Invocing/Home/brand_add", "", true, "erp.invoicing");
            return ReportJson();
        }
    }


}