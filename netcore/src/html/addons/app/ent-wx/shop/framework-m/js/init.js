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
//srcurl("m/css/framework7.ios.min.css"),
//srcurl("m/css/framework7.ios.colors.min.css"),

{ "jquery": srcurl("jquery/jquery.min.js") },
//app-lib
//{ "m-js": srcurl("m/js/framework7.min.js") },
//layui
{ "layui": srcurl("layui-m/2.0/layer.js") },
//framework
{ "config": srcurl("framework/js/config.js") },
{ "config-m": srcurl("framework-m/js/config-m.js", "/web/app/ent-wx/shop/") },
{ "tools": srcurl("framework/js/tools.js") }//,
//{ "my-app": srcurl("framework-m/js/my-app.js") }
],

function () {
   
});


//特殊页面处理
head.ready(["jquery", "config", "config-m", "tools"], function () {
    //微信登陆
    if ($.geturl() === g_login_wx) {
       // debugger
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
            //$.msg("自动登陆中...");
         //   debugger 
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
        $.loadBll();//加载业务js
        $.bindFunction();//自动绑定页面参数
        $(".back").click(function() { $.go(-1) });
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
    $.go(g_pay_wx + "?uid=" + $.uid() + "&total_fee=" + totalFee + "&return_url=" + g_pay_result_wx);
}

//initWeuiSelect
function initWeuiSelect(containerId, dataUrl,memberName, textMember, valueMember) {
    if (!$.hasValue(textMember)) {
        textMember = "Text";
        valueMember = "Value";
    }
    head.load(["js/jquery-weui.js", "lib/fastclick.js"], function () {
        FastClick.attach(document.body);
        $.Ajaxs(dataUrl, function (data) {
            var _data = data[memberName];
            var arr = [];
            for (var i = 0; i < _data.length; i++) {
                arr.push({ title: _data[i][textMember], value: _data[i][valueMember] });
            }
            $("#" + containerId).select({
                title: "请选择队伍类型",
                items: arr//,
                //onChange: function (d) {
                //    console.log(this, d);
                //},
                //onClose: function () {
                //    console.log("close");
                //},
                //onOpen: function () {
                //    console.log("open");
                //}
            });
        });
    });
}

function initF7Select(containerId, dataUrl, memberName, textMember, valueMember, doAfterBinded) {
    if (!$.hasValue(textMember)) {
        textMember = "Text";
        valueMember = "Value";
    }
    $.Ajaxs(dataUrl, function (data) {
        var _data = data[memberName];
        var optionHtml ="";     
        for (var i = 0; i < _data.length; i++) {
            var t = _data[i][textMember];
            var v = _data[i][valueMember];
            optionHtml += ('<option value="' + v + '">' + t + '</option>');
        }
        $("#" + containerId).html(optionHtml);
        if ($.hasValue(doAfterBinded)) {
            doAfterBinded(_data);
        }
    });
}

function hide(objArray) {
    if (!$.isArray2(objArray)) {
        objArray = [objArray];
    }
    for (var i = 0; i < objArray.length; i++) {
        var arr = objArray[i];
        var name = arr[0];
        var value =arr.length>1? arr[1]:"";
        $("body").append(' <input class="hidden" name="' + name + '" type="text" value="' + value + '">');
    }
  
}