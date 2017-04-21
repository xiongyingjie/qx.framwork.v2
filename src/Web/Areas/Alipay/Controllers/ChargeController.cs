using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Qx.Account.Alipay;
using Qx.Account.Interfaces;
using Qx.Account.Models;
using Web.Areas.Alipay.Models;
using Web.Controllers.Base;

namespace Web.Areas.Alipay.Controllers
{
    public class ChargeController : AccountFilterController
    {
        private IAccountPayService _accountPayService;

        public ChargeController(IAccountPayService accountPayService)
        {
            _accountPayService = accountPayService;
        }

        // GET: /Alipay/Charge

        public ActionResult Index()
        {
            InitLayout("充值");
            return View(new Orderetail() { WIDtotal_fee = 0.01 });
        }
        [HttpPost]
        public ActionResult Index(Web.Areas.Alipay.Models.Orderetail model)
        {
            model.WIDtotal_fee = double.Parse(F("WIDtotal_fee"));
            if (model.WIDtotal_fee < 0.01)
            {
                return Alert("充值金额必须>=0.01", -1);
            }

            model.WIDbody = "充值" + model.WIDtotal_fee * 100 + "健康币";
            model.WIDsubject = model.WIDbody;
            //=============================存储订单


            //1.创建支付订单
            var chargePayOrder = _accountPayService.CreatePayOrder(PLATE_ALIPAY_ACCOUNT,
                DataContext.UserID,
                model.WIDtotal_fee,
                PayOrderTypeEnum.AliPay,
                PaymentTypeEnum.Rmb);

            model.WIDout_trade_no = chargePayOrder.PayOrder.PO_ID;
            //2.同步支付订单
            _accountPayService.SyncPayOrder(chargePayOrder);



            ////////////////////////////////////////////请求参数////////////////////////////////////////////

            ////商户订单号，商户网站订单系统中唯一订单号，必填
            //string out_trade_no = "pid1234565489";

            ////订单名称，必填
            //string subject = "测试充值";

            ////付款金额，必填
            //string total_fee = "0.01";

            ////商品描述，可空
            //string body = "我是商品描述";




            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("service", Config.service);
            sParaTemp.Add("partner", Config.partner);
            sParaTemp.Add("seller_id", Config.seller_id);
            sParaTemp.Add("_input_charset", Config.input_charset.ToLower());
            sParaTemp.Add("payment_type", Config.payment_type);
            sParaTemp.Add("notify_url", Config.notify_url);
            sParaTemp.Add("return_url", Config.return_url);
            sParaTemp.Add("anti_phishing_key", Config.anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", Config.exter_invoke_ip);
            sParaTemp.Add("out_trade_no", model.WIDout_trade_no);
            sParaTemp.Add("subject", model.WIDsubject);
            sParaTemp.Add("total_fee", model.WIDtotal_fee.ToString());
            sParaTemp.Add("body", model.WIDbody);
            //其他业务参数根据在线开发文档，添加参数.文档地址:https://doc.open.alipay.com/doc2/detail.htm?spm=a219a.7629140.0.0.O9yorI&treeId=62&articleId=103740&docType=1
            //如sParaTemp.Add("参数名","参数值");

            //建立请求
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");




            return Content(sHtmlText);
        }
    }
}