//全局变量 cdn到init中进行配置
 g_homepage = "/pages/index-m.html";//var g_homepage = "/pages/index.html";
 g_login = "/pages/login-m.html";

 g_wx_login = false;
//微信支付
  g_pay_wx = g_host + "/WeChat/WeChatPay/JsApiPayPage";
  g_pay_result_wx = window.location.origin + "/web/app/wxpay/charge-result.html?subSystem=system";
//微信授权回调
  g_login_wx = "/pages/login-wx.html";
//微信授权
  g_wx = g_wx_login ? (g_host + "/WeChat/Web/Authorize?return_url=" + window.location.origin + g_login_wx) : "";

