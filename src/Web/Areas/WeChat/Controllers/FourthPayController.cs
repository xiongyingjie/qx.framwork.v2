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
using Qx.Tools;
using Web.Areas.WeChat.ViewModels.WeChatPay;
using Web.Controllers.Base;

namespace Web.Areas.WeChat.Controllers
{
  
    public class FourthPayController : BaseController
    {
        private IWechatServices _wechatServices;


        private IAccountPayService _accountPayService;
        public FourthPayController(IAccountPayService accountPayService)
        {
            _accountPayService = accountPayService;
        }

        #region models
        public class PayRequest
        {
            /// <summary>
            /// 商户编号
            /// </summary>
            public string instId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string mercId { get; set; }
            /// <summary>
            /// 订单编号不可重复，不支持中文
            /// </summary>
            public string mercOrderId { get; set; }
            /// <summary>
            /// W-微信，Z-支付宝     
            /// </summary>
            public string txnType { get; set; }
            /// <summary>
            /// 交易日期 YYYYMMDD
            /// </summary>
            public string txnDate { get; set; }
            /// <summary>
            ///交易时间 HHMMSS
            /// </summary>
            public string txnTime { get; set; }
            /// <summary>
            /// 币种 默认：CNY-人民币
            /// </summary>
            public string ccy { get; set; }
            /// <summary>
            /// 交易金额  单位：分
            /// </summary>
            public int txnAmt { get; set; }
            /// <summary>
            /// 结果通知URL
            /// </summary>
            public string notifyUrl { get; set; }
            /// <summary>
            /// 商品名称
            /// </summary>
            public string productName { get; set; }
            /// <summary>
            /// 商品描述
            /// </summary>
            public string productDesc { get; set; }
            /// <summary>
            /// 支付方式
            /// </summary>
            public string payMethod { get; set; }
            /// <summary>
            /// 支付授权码
            /// </summary>
            public string authCode { get; set; }
            /// <summary>
            /// 备注信息
            /// </summary>
            public string remark { get; set; }
            /// <summary>
            ///  终端IP
            /// </summary>
            public string clientIp { get; set; }

            /// <summary>
            /// MD5(instId + mercId + mercOrderId + txnType + txnDate + txnTime + ccy + txnAmt + key）
            /// </summary>
            public string md5value {
                get
                {
                    return
                        (instId + mercId + mercOrderId + txnType + txnDate + txnTime + ccy + txnAmt + MD5_KEY)
                        .Encrypt(EncryptType.Md5);
                }
            }
        }
     public   class PayResponse
        {
            /// <summary>
            /// 商户编号
            /// </summary>
            public string mercId { get; set; }
            /// <summary>
            /// 订单编号
            /// </summary>
            public string mercOrderId { get; set; }


            /// <summary>
            /// 响应码 000000-提交成功
            /// </summary>
            public string rspCode { get; set; }
            /// <summary>
            /// 响应码描述
            /// </summary>
            public string rspMsg { get; set; }
            /// <summary>
            /// 支付状态
            /// 被扫交易需判断
            ///S：支付成功（无后续通知）
            ///F：支付失败（无后续通知）
            ///C：订单已创建未支付（有后续通知）

            /// </summary>
            public string txnStatus { get; set; }
            /// <summary>
            ///响应数据 主扫且成功响应时存在
            /// </summary>
            public string rspData { get; set; }
            /// <summary>
            /// md5value=MD5(mercId + mercOrderId + rspCode + key）
            /// </summary>
            public string md5value { get; set; }
            public bool Successful
            {
                get
                {
                    return rspCode == "000000";
                }
            }

        }

        public class OrderRequest
        {
            /// <summary>
            /// 原订单商户编号
            /// </summary>
            public string mercId { get; set; }
            /// <summary>
            ///原订单编号 订单编号不可重复，不支持中文
            /// </summary>
            public string mercOrderId { get; set; }
            /// <summary>
            /// 原交易日期 YYYYMMDD
            /// </summary>
            public string txnDate { get; set; }
            /// <summary>
            /// MD5校验码 MD5(mercId + mercOrderId + txnDate + key）
            /// </summary>
            public string md5value { get; set; }
        }
        public class OrderResponse
        {
            /// <summary>
            /// char(15) 	原订单商户编号
            /// </summary>
            public string mercId { get; set; }
            /// <summary> 
            /// 原订单编号 订单编号不可重复，不支持中文
            /// </summary>
            public string mercOrderId { get; set; }


            /// <summary>
            /// 原交易日期  YYYYMMDD
            /// </summary>
            public string txnDate { get; set; }
            /// <summary>
            /// 响应码 000000-查询成功
            /// </summary>
            public string rspCode { get; set; }
            /// <summary>
            /// 响应信息
            /// </summary>
            public string rspMsg { get; set; }
            /// <summary>
            /// 支付状态
            /// S：支付成功
            /// F：支付失败
            /// C：订单已创建未支付;
            /// E：订单创建失败
            /// P：订单处理中
            /// </summary>
            public string txnStatus { get; set; }
            /// <summary>
            /// MD5(mercId + mercOrderId + txnDate + rspCode + key)
            /// </summary>
            public string md5value { get; set; }


        }

        public class PayResultResponse
        {
            /// <summary>
            /// 原订单商户编号
            /// </summary>
            public string mercId { get; set; }
            /// <summary>
            /// 原订单编号 订单编号不可重复，不支持中文
            /// </summary>
            public string mercOrderId { get; set; }


            /// <summary>
            ///原交易日期 YYYYMMDD
            /// </summary>
            public string txnDate { get; set; }

            /// <summary>
            /// 支付状态
            /// S：支付成功
            /// F：支付失败
            /// </summary>
            public string txnStatus { get; set; }

            /// <summary>
            ///MD5校验码 MD5(mercId + mercOrderId + txnDate + txnStatus + key)
            /// </summary>
            public string md5value { get; set; }
            public bool Successful
            {
                get
                {
                    return txnStatus == "S";
                }
            }

        }
        #endregion

        T Post<T>(string api, Dictionary<string, string> param=null)
        {
            if (param == null)
            {
                param=new Dictionary<string, string>();
            }
            return HttpPost(PAY_SEVER, api, param).Deserialize<T>();
        }

        private static string MD5_KEY = "1234567890.testkey";
        private string PAY_SEVER = "http://103.47.137.53:8092";
        private string RETURN_NOTIFY = "http://api.52xyj.cn/WeChat/FourthPay/ResultNotifyPage";
        // GET: /WeChat/FourthPay
        public ActionResult Index()
        {
            return RedirectToAction("Charge");
        }
        // GET: /WeChat/FourthPay/ProductPage
        public ActionResult Charge(string openid= "test", int total_fee = 1)
        {
            //1.创建支付订单
            var chargePayOrder = _accountPayService.CreatePayOrder(Qx.Account.Configs.Setting.PLATE_WECHAT_ACCOUNT,openid,total_fee,PayOrderTypeEnum.VipCard, PaymentTypeEnum.Jkb
                   );
            var  poid = chargePayOrder.PayOrder.PO_ID;
            //2.同步支付订单
            _accountPayService.SyncPayOrder(chargePayOrder);
            //3.发起请求
            var p = new PayRequest()
            {
                instId = "999999",
                mercOrderId = "NO12345678900001",
                mercId = "OLP999999000001",
                txnType = "W",
                txnDate = DateTime.Now.FormatDate(true),
                txnTime = DateTime.Now.FormatTime(false,true),
                ccy = "CNY",
                txnAmt = total_fee,
                notifyUrl = RETURN_NOTIFY,
                productName = "测试productName",
                productDesc = "测试productDesc"
            };
            var response = Post<PayResponse>($"/posm/qrpayreq.tran?olpdat={p.Serialize()}");
            if (!response.Successful)
            {//请求失败时删除本地订单
                _accountPayService.DeletePayOrder(poid);
           
            }
            return Content(response.Successful ? "下单成功,订单号为："+ poid : "下单失败:"+ response.rspMsg+ response.rspData);
        }


        // GET: /WeChat/FourthPay/ResultNotifyPage/
        public ActionResult ResultNotifyPage(PayResponse result)
        {
            var redirectAction = "";

            //检查支付结果中transaction_id是否存在
            string transaction_id= result.mercOrderId;
            if (transaction_id.HasValue() )
            {
                //1.开始处理
                var chargePayOrder = _accountPayService.FindPayOrder(transaction_id);
                if (chargePayOrder != null)
                {
                    chargePayOrder.ToNextState(transaction_id);
                    _accountPayService.SyncPayOrder(chargePayOrder);

                    if (result.Successful &&
                            chargePayOrder.IsValid(transaction_id))
                    {
                        //防止重复处理
                        if (!chargePayOrder.IsEnd)
                        {
                            chargePayOrder.ToNextState();
                            //2.同步支付订单
                            _accountPayService.SyncPayOrder(chargePayOrder);

                       }
                       
                          redirectAction = "ChargeOK";

                    }
                    else
                    {
                           redirectAction = "ChargeFailed";

                    }


                }


            }
            else
            {
                //若transaction_id不存在，则立即返回结果给微信支付后台
                  //Log.Error(this.GetType().ToString(), "The Pay result is error : " + res.ToXml());
                redirectAction = "ChargeFailed";
            }
            return RedirectToAction(redirectAction);

        }

        public ActionResult ChargeResult(string num)
        {
            return Content("成功充值" + num + "元");
        }
    }
}