using Qx.Tools.CommonExtendMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qx.wechat.Interfaces;
using Qx.Account.Interfaces;
using Qx.Account.Models;
using Qx.Account.WeixinPay.business;
using Qx.Account.WeixinPay.lib;
using Web.Areas.WeChat.ViewModels.WeChatPay;
using Web.Controllers.Base;

namespace Web.Areas.WeChat.Controllers
{
    public class WeChatPayController : BaseController
    {
        private IWechatServices _wechatServices;

    
        private IAccountPayService _accountPayService;
        public WeChatPayController(IAccountPayService accountPayService, IWechatServices wechatServices)
        {
            _accountPayService = accountPayService;
            _wechatServices = wechatServices;
        }

        // GET: /WeChat/WeChatPay
        public ActionResult Index()
        {
            return RedirectToAction("ProductPage");
        }
        // GET: /WeChat/WeChatPay/ProductPage
        public ActionResult ProductPage(string total_fee = "1")
        {
            var wxEditAddrParam = "";
            var openid = "";
            //JsApiPay jsApiPay = new JsApiPay(HttpContext);
            //try
            //{
            //    //调用【网页授权获取用户信息】接口获取用户的openid和access_token
            //    jsApiPay.GetOpenidAndAccessToken();
            //    //获取收货地址js函数入口参数
            //    wxEditAddrParam = jsApiPay.GetEditAddressParameters();
            //    openid = jsApiPay.openid;
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<span style='color:#FF0000;font-size:20px'>" + "页面加载出错，请重试" + "</span>" + ex.Message + "<hr/>" + ex.InnerException + "<hr/>" + ex.StackTrace);
            //}

            return View(ProductPage_M.Init(wxEditAddrParam, openid, total_fee));
        }

        public ActionResult BuyProduct(double total_fee)
        {
            string openid = DataContext.UserId;
            if (openid != null)
            {
                return RedirectToAction("JsApiPayPage", new { openid = openid, total_fee = total_fee, return_url= "/WeChat/WeChatPay/ChargeResult" });
               // return Content("/WeChat/WeChatPay/JsApiPayPage?openid="+ openid + "&total_fee="+ total_fee);
            }
            else
            {
                return Content("error");
            }
        }
        //   /WeChat/WeChatPay/JsApiPayPage?uid=123&total_fee=0.01return_url=oksMlwPF5Y1KQvoi8AklF-lUwnYQ&
        public ActionResult JsApiPayPage( double total_fee,string return_url)
        {
            string openid = DataContext.UserId;
            if (!openid.HasValue() || !return_url.HasValue())
            {
                return Content("参数错误");
            }
            var money = (int) (total_fee*100);
            var wxJsApiParam = "";
            //检测是否给当前页面传递了相关参数
            if (string.IsNullOrEmpty(openid))
            {
                return Content("<span style='color:#FF0000;font-size:20px'>" + "页面传参出错,请返回重试" + "</span>"); ;
            }

            //若传递了相关参数，则调统一下单接口，获得后续相关接口的入口参数
            JsApiPay jsApiPay = new JsApiPay(HttpContext);
            jsApiPay.openid = openid;
            jsApiPay.total_fee = money;
            var poid = "";
            //JSAPI支付预处理
            try
            {
                //1.创建支付订单
                var chargePayOrder = _accountPayService.CreatePayOrder(Qx.Account.Configs.Setting.PLATE_WECHAT_ACCOUNT,
                   openid,
                    total_fee,
                    PayOrderTypeEnum.WeChatPay,
                    PaymentTypeEnum.Rmb);
                poid = chargePayOrder.PayOrder.PO_ID;
                var trade_no = chargePayOrder.PayOrder.PO_ID;
                //2.同步支付订单
                _accountPayService.SyncPayOrder(chargePayOrder);

                //3.通知微信服务器
                WxPayData unifiedOrderResult = jsApiPay.GetUnifiedOrderResult(trade_no,"充值"+ (total_fee) +"元");
                wxJsApiParam = jsApiPay.GetJsApiParameters();//获取H5调起JS API参数   
                if (!wxJsApiParam.HasValue()) throw new Exception("下单失败");
                               
                //在页面上显示订单信息
                return View("JsApiPayPage", JsApiPayPage_M.Init(wxJsApiParam,
                                        "<span style='color:#00CD00;font-size:20px'>充值" + total_fee + "元</span><br/><span style='color:#00CD00;font-size:20px'>" + "</span>",
                    //"<span style='color:#00CD00;font-size:20px'>订单详情：</span><br/><span style='color:#00CD00;font-size:20px'>" + unifiedOrderResult.ToPrintStr() + "</span>",
                    total_fee + "", poid, DataContext.UserId, return_url
                    ));

            }
            catch (Exception ex)
            {
                return View("JsApiPayPage", JsApiPayPage_M.Init(wxJsApiParam,
                    "<span style='color:#FF0000;font-size:20px'>" + "下单失败，请返回重试" + "<hr/>" + ex.Data + "<hr/>" + ex.InnerException + "<hr/>" + ex.Message + "<hr/>" + ex.StackTrace + "</span>", "", poid, DataContext.UserId, return_url));
            }

        }
        // GET: /WeChat/WeChatPay/ResultNotifyPage/
        public void ResultNotifyPage()
        {
            var redirectAction = "";

            var res = new WxPayData();
            var appid = RequstParam["appid"];
            var attach = RequstParam["attach"];
            var bank_type = RequstParam["bank_type"];
            var cash_fee = RequstParam["cash_fee"];
            var fee_type = RequstParam["fee_type"];
            var is_subscribe = RequstParam["is_subscribe"];
            var mch_id = RequstParam["mch_id"];
            var nonce_str = RequstParam["nonce_str"];
            var openid = RequstParam["openid"];
            var out_trade_no = RequstParam["out_trade_no"];
            var result_code = RequstParam["result_code"];
            var return_code = RequstParam["return_code"];
            var sign = RequstParam["sign"];
            var time_end = RequstParam["time_end"];
            var total_fee = RequstParam["total_fee"];
            var transaction_id = RequstParam["transaction_id"];

            //检查支付结果中transaction_id是否存在
            if (transaction_id.HasValue() && out_trade_no.HasValue())
            {
                //1.开始处理
                var chargePayOrder = _accountPayService.FindPayOrder(out_trade_no); 
                if (chargePayOrder != null)
                {
                    chargePayOrder.ToNextState(transaction_id);
                    _accountPayService.SyncPayOrder(chargePayOrder);

                    if (result_code.ToUpper().Contains("SUCCESS") &&
                        return_code.ToUpper().Contains("SUCCESS") &&
                            chargePayOrder.IsValid(transaction_id))
                    {
                        //防止重复处理
                        if (!chargePayOrder.IsEnd)
                        {
                            chargePayOrder.ToNextState();
                            //2.同步支付订单
                            _accountPayService.SyncPayOrder(chargePayOrder);

                            //3.发送成功通知
                            //var url = "http://wx.52xyj.cn/WeChat/BookTiketWeb/MyWallet";
                            //var acc = _accountPayService.FindAccount(openid);
                            //_wechatServices.Send_Charge_Ok_Msg(openid, url, 
                            //    acc.Account.LastUpdateTime.ToStr(),
                            //    (int.Parse(total_fee)/100.0)+"元",
                            //   (acc.Account.Balance/100.0) + "元");
                        }
                        res.SetValue("return_code", "SUCCESS");
                        res.SetValue("return_msg", "OK");
                        Log.Info(this.GetType().ToString(), "order query success : " + res.ToXml());
                        redirectAction = "ChargeOK";

                    }
                    else
                    {
                       // chargePayOrder.Failed();
                       // _accountPayService.SyncPayOrder(chargePayOrder);

                        res.SetValue("return_code", "FAIL");
                        res.SetValue("return_msg", "订单查询失败");
                        Log.Error(this.GetType().ToString(), "Order query failure : " + res.ToXml());
                        redirectAction = "ChargeFailed";

                    }
                  

                }


            }
            else
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                res.SetValue("return_code", "FAIL");
                res.SetValue("return_msg", "支付结果中微信订单号不存在");
                Log.Error(this.GetType().ToString(), "The Pay result is error : " + res.ToXml());
                redirectAction = "ChargeFailed";
            }
           // Response.Write(res.ToXml());
           // Response.End();
            ResultNotify resultNotify = new ResultNotify(HttpContext);
            resultNotify.ProcessNotify();
           // return RedirectToAction(redirectAction, "BookTiketWeb", new { transaction_id = transaction_id });
        }

        public ActionResult ChargeResult(string num)
        {
            return Content("成功充值"+ num+"元");
        }
    }
}