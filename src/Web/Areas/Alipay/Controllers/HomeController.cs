using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using Qx.Account.Alipay;
using Qx.Account.Interfaces;
using Qx.Account.Models;
using Qx.Tools.CommonExtendMethods;
using Web.Areas.Alipay.Models;

namespace Web.Areas.Alipay.Controllers
{
    public class HomeController : BaseAliPayController
    {
        private IAccountPayService _accountPayService;

        public HomeController(IAccountPayService accountPayService)
        {
            _accountPayService = accountPayService;
        }

        // GET: /Alipay/Home
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Charge()
        {
            InitLayout("充值");
            return View(new Orderetail() {WIDtotal_fee = 0.01});
        }
        [HttpPost]
        public ActionResult Charge(Web.Areas.Alipay.Models.Orderetail model)
        {
            model.WIDtotal_fee = double.Parse(F("WIDtotal_fee"));
            if (model.WIDtotal_fee < 0.01)
            {
                return Alert("充值金额必须>=0.01", -1);
            }

            model.WIDbody = "充值"+ model.WIDtotal_fee*100+"健康币";
            model.WIDsubject = model.WIDbody;
            //=============================存储订单


            //1.创建支付订单
            var chargePayOrder = _accountPayService.CreatePayOrder(PLATE_ALIPAY_ACCOUNT,
                DEMO_CHARGE_ACCOUNT,
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
        [HttpPost]
        public ActionResult Index(Web.Areas.Alipay.Models.Orderetail model)
        {
            model.WIDout_trade_no = F("WIDout_trade_no");//废弃
            model.WIDbody = F("WIDbody");
            model.WIDtotal_fee =double.Parse(F("WIDtotal_fee")) ;
            model.WIDsubject = F("WIDsubject");

            if (!model.WIDout_trade_no.HasValue())
            {
                return Alert("信息不完整！",-1);
            }

            //=============================存储订单


            //1.创建支付订单
            var chargePayOrder = _accountPayService.CreatePayOrder(PLATE_ALIPAY_ACCOUNT,
                DEMO_CHARGE_ACCOUNT,
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


           

            return  Content(sHtmlText);
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }
        public void notify_url()
        {
            SortedDictionary<string, string> sPara = GetRequestPost();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码


                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表
                    


                    //商户订单号

                    string out_trade_no = Request.Form["out_trade_no"];

                    //支付宝交易号

                    string trade_no = Request.Form["trade_no"];

                    //交易状态
                    string trade_status = Request.Form["trade_status"];


                    //1.开始处理
                    var chargePayOrder = _accountPayService.FindPayOrder(out_trade_no);
                    chargePayOrder.Pending(trade_no);
                    if (Request.Form["trade_status"] == "TRADE_FINISHED")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //请务必判断请求时的total_fee、seller_id与通知时获取的total_fee、seller_id为一致的
                        //如果有做过处理，不执行商户的业务程序

                        //注意：
                        //退款日期超过可退款期限后（如三个月可退款），支付宝系统发送该交易状态通知
                        
                        if (chargePayOrder.IsValid(trade_no))
                        {
                            chargePayOrder.Finished();
                            //2.同步支付订单
                            _accountPayService.SyncPayOrder(chargePayOrder);
                        }
                        else
                        {
                            //忽略
                            
                        }

                    }
                    else if (Request.Form["trade_status"] == "TRADE_SUCCESS")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //请务必判断请求时的total_fee、seller_id与通知时获取的total_fee、seller_id为一致的
                        //如果有做过处理，不执行商户的业务程序

                        //注意：
                        //付款完成后，支付宝系统发送该交易状态通知

                        if (chargePayOrder.IsValid(trade_no))
                        {
                            chargePayOrder.Successful();
                            //2.同步支付订单
                            _accountPayService.SyncPayOrder(chargePayOrder);
                        }
                        else
                        {
                            //忽略  
                        }

                    }
                    else
                    {
                        if (chargePayOrder.IsValid(trade_no))
                        {
                            chargePayOrder.Pending(trade_no);
                            //2.同步支付订单
                            _accountPayService.SyncPayOrder(chargePayOrder);
                        }
                    }

                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                    Response.Write("success");  //请不要修改或删除

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("无通知参数");
            }
        }



        /// <summary>
        /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestGet()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.QueryString;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
            }

            return sArray;
        }
        public ActionResult return_url()
        {
            SortedDictionary<string, string> sPara = GetRequestGet();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.QueryString["notify_id"], Request.QueryString["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码


                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中页面跳转同步通知参数列表

                    //商户订单号

                    string out_trade_no = Request.QueryString["out_trade_no"];

                    //支付宝交易号

                    string trade_no = Request.QueryString["trade_no"];

                    //交易状态
                    string trade_status = Request.QueryString["trade_status"];
                    
                    
                    //1.开始处理
                    var chargePayOrder = _accountPayService.FindPayOrder(out_trade_no);
                    if (Request.QueryString["trade_status"] == "TRADE_FINISHED" || Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                    {
                        //判断该笔订单是否在商户网站中已经做过处理
                        //如果没有做过处理，根据订单号（out_trade_no）在商户网站的订单系统中查到该笔订单的详细，并执行商户的业务程序
                        //如果有做过处理，不执行商户的业务程序

                        ////Finished...
                        //if (chargePayOrder.IsValid(trade_no)&& Request.QueryString["trade_status"] == "TRADE_FINISHED")
                        //{
                        //    chargePayOrder.Finished();
                        //    //2.同步支付订单
                        //    _accountPayService.SyncPayOrder(chargePayOrder);
                        //}
                        ////Successful...
                        //if (chargePayOrder.IsValid(trade_no) && Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                        //{
                        //    chargePayOrder.Successful();
                        //    //2.同步支付订单
                        //    _accountPayService.SyncPayOrder(chargePayOrder);
                        //}
                       
                    }
                    else
                    {
                        //Pending...
                        //chargePayOrder.Pending(trade_no);
                        ////2.同步支付订单
                        //_accountPayService.SyncPayOrder(chargePayOrder);
                        Response.Write("trade_status=" + Request.QueryString["trade_status"]);

                    }
                 
                   
                    //打印页面
                    Response.Write("验证成功<br />");
                    return RedirectToAction("ChargeOk",new { chargeNum = chargePayOrder .PayOrder.PayNum, out_trade_no = out_trade_no });
                    //——请根据您的业务逻辑来编写程序（以上代码仅作参考）——

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    Response.Write("验证失败");
                    return RedirectToAction("ChargeFalse");
                }
            }
            else
            {
                Response.Write("无返回参数");
                return RedirectToAction("ChargeError");
            }
        }

        public ActionResult ChargeOk(double chargeNum,string out_trade_no)
        {
            V("chargeNum", chargeNum);
            V("out_trade_no", out_trade_no);
            InitLayout("充值成功");
            return View();
        }
        public ActionResult ChargeFalse()
        {
            InitLayout("充值失败");
            return View();
        }
        public ActionResult ChargeError()
        {
            InitLayout("充值出错！");
            return View();
        }
    }
}