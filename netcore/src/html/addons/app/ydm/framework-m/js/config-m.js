﻿//全局变量app cdn到init中进行配置

g_framwork_dir = "/web/app/" + g_app+"/framework-m/";

g_homepage = "/web/app/" + g_app +"/index.html";//var g_homepage = "/pages/index.html";

//g_homepage = "/web/app/" + g_app+"/index.html";//var g_homepage = "/pages/index.html";
g_login = g_framwork_dir+"login-m.html";
g_bind = g_framwork_dir + "bind-m.html";

g_wx_login = false ;
//微信支付

g_charge_wx = g_framwork_dir+"charge.html";//充值
g_charge_result_wx =g_framwork_dir+ "charge-result.html";//充值结果
g_wallet_wx = g_framwork_dir+"wallet.html";//钱包
g_withdraw_wx = g_framwork_dir + "-withdraw.html";//提现

  g_pay_wx = g_host_wx + "/WeChat/WeChatPay/JsApiPayPage";
  g_pay_result_wx = window.location.origin + g_charge_result_wx + "?subSystem=" + g_app;
//微信授权回调
  g_login_wx = g_framwork_dir+"login-wx.html";
//微信授权;后面的参数是subSystem
  g_wx = g_wx_login ? (g_host_wx + "/WeChat/Web/Authorize?return_url=" + window.location.origin + g_login_wx + "?subSystem=" + g_app ) : "";

