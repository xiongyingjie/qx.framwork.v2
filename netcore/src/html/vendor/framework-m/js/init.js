function srcurl(src, folder) {
    if (folder == undefined) {
        folder = "/vendor/";
    }
    var version = "";
    if (src.indexOf("framework") > -1 || folder.indexOf("web") > -1) {
        var now = new Date();
        var number = now.getYear().toString() + now.getMonth().toString() + now.getDate().toString() + now.getHours().toString() + now.getMinutes().toString() + now.getSeconds().toString();
        version = "?v=" + number;
    }
    return g_cdn +folder+ src + version;
}

head.load([
//layui
srcurl("layui-m/2.0/need/layer.css"),
//framework7
srcurl("m/css/framework7.ios.min.css"),
srcurl("m/css/framework7.ios.colors.min.css"),

{ "jquery": srcurl("jquery/jquery.min.js") },
//app-lib
{ "m-js": srcurl("m/js/framework7.min.js") },
//layui
{ "layui": srcurl("layui-m/2.0/layer.js") },
//framework
{ "config": srcurl("framework/js/config.js") },
{ "form-tool-m": srcurl("framework-m/js/form-tool.js") },
{ "config-m": srcurl("framework-m/js/config-m.js") },
{ "tools": srcurl("framework/js/tools.js") },
{ "my-app": srcurl("framework-m/js/my-app.js") }
],

function () {
   
});


//特殊页面处理
head.ready(["jquery", "config", "config-m", "tools"], function () {
   
    //微信登陆
    if ($.geturl() === g_login_wx) {
        //处理微信登陆
        loginSuccess($.q("uid"));
        return;
    }
    //debugger
    //登陆验证
    var uid = $.uid();
    var unitid = $.unitid();
    if ((!$.hasValue(unitid) || !$.hasValue(uid)) && ($.geturl() !== g_login)) {
        $.warn("请登陆");
        //普通登陆
         window.location.replace(g_login);
        return;
    }

    //登陆初始化  
    if ($.geturl() === g_login) {
        if ($.hasValue(g_wx)) {
            //微信登陆
            $.loading();
            $.msg("自动登陆中...");
            window.location.replace(g_wx);
            return;
        }
        $('#login').click(function() {
            //debugger
            var userid = $('#uid').val();
            var psw = $('#psw').val();
            login(userid, psw);
        });
    } else {
        //登陆成功后
        $("#user_id").text($.cookie('user_id'));
        $("#nick_name").text($.cookie('nick_name'));
        $("#unit_name").text($.cookie('unit_name'));//显示用户id//显示用户id
        $(".fa-sign-out").click(function () {//设置退出登录
            $.cookie();
            $.msg("已退出登录");
            $.go(g_login);
        });
    }

});

function confirmPay(totalFee) {
    $.loading();
    $.go(g_pay_wx + "?openid=" + $.uid() + "&total_fee=" + totalFee + "&return_url=" + g_pay_result_wx);
}
