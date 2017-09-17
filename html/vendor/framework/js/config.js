//全局变量 cdn到init中进行配置
var g_encrypt_key = "xyj";
var g_decrypt_key = "xyj";
var g_debug = false;
var g_fake = false;
var g_warn = true;
//var g_fakehost = "http://localhost:29128/fake?id=";
//var g_host = "http://ent.wx.52xyj.cn:9999";
var g_host = "http://localhost:39128";
//var g_host = "http://wx.52xyj.cn";
var g_local_res = "/web/";
//COMMON
var g_homepage;
var g_login;

//PC
var g_leftmenu;//左栏菜单
var g_topmenu;//顶部菜单
var g_form;//表单地址
var g_report;//报表地址
//WX
var g_host_wx;//微信服务器地址
var g_framwork_dir;//框架目录
var g_wx_login;//微信自动登陆
var g_pay_wx;//微信支付
var g_pay_result_wx;//微信支付回调
var g_login_wx;//微信授权回调
var g_wx;//微信授权
var g_charge_wx;//充值
var g_charge_result_wx;//充值结果
var g_wallet_wx;//钱包
var g_withdraw_wx;//提现



