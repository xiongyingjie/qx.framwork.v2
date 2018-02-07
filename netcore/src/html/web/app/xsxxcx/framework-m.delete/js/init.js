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
//jquery-weui
//srcurl("jquery-weui/lib/weui.min.css"),
//srcurl("jquery-weui/css/jquery-weui.css"),
//srcurl("jquery-weui/demos/css/demos.css"),

{ "jquery": srcurl("jquery/jquery.min.js") },
//jquery-weui
{ "fastclick": srcurl("jquery-weui/lib/fastclick.js") },
//{ "jquery-weui": srcurl("jquery-weui/js/jquery-weui.js") },
//layui
{ "layui": srcurl("layui-m/2.0/layer.js") },
//framework
{ "config": srcurl("framework/js/config.js") },
{ "config-m": srcurl("framework-m/js/config-m.js", "/web/app/"+g_app+"/") },
{ "tools": srcurl("framework/js/tools.js") }//,
//{ "form-tool": srcurl("framework-m/js/form-tool.js", "/web/app/bx/") }
],
function () {
    FastClick.attach(document.body);
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
            $("body").html("");
            $.msg("自动登陆中...");
            //debugger 
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
        $("#nick_name").val($.cookie('nick_name')); $(".nick_name").text($.cookie('nick_name'));
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
//function initWeuiSelect(containerId, dataUrl, memberName, textMember, valueMember, doAfterInit) {
//    $.Ajaxs(dataUrl, function (data) {
//        var _data = data[memberName];
         
//        var arr = [];
//        for (var i = 0; i < _data.length; i++) {
//            var _t = $.isString(textMember) ?
//                ($.hasValue(textMember) ?
//                _data[i][textMember] :
//                _data[i]["Text"]) :
//                textMember(_data[i]);
//            var _v = $.isString(valueMember) ?
//             ($.hasValue(valueMember) ?
//             _data[i][valueMember] :
//             _data[i]["Value"]) :
//             valueMember(_data[i]);

//            arr.push({ title: _t, value: _v });
//        }
//        $("#" + containerId).select({
//            title: "请选择",
//            items: arr//,
//            //onChange: function (d) {
//            //    console.log(this, d);
//            //},
//            //onClose: function () {
//            //    console.log("close");
//            //},
//            //onOpen: function () {
//            //    console.log("open");
//            //}
//        });
//        if ($.hasValue(doAfterInit)) {
//            doAfterInit(_data);
//        }
//    });
//}
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
//initWeuiSelect
function initWeuiSelect(containerId, dataUrl, memberName, textMember, valueMember, doAfterInit) {

    if (containerId.indexOf("choose") === -1) {//自动加select前缀
        containerId = "choose-" + containerId;
    }
    head.load(["/vendor/jquery-weui/js/jquery-weui.js", "/vendor/jquery-weui/lib/fastclick.js"], function () {
        FastClick.attach(document.body);
        $.Ajaxs(dataUrl, function (data) {
            var _data = data;//data[memberName];
            debugger 
            if (!$.isArray(_data)) {
                _data = [_data];
            }
           
            if (_data.length === 1) {//获取值
                var deafultValue = $.hasValue(valueMember) ?
                  ($.isFunction(valueMember) ?
                  valueMember(_data[0]) :
                  _data[0][valueMember]) :
                 _data[0]["Value"];
                //赋值
                var containerDom = $("#" + containerId);
                if ($.hasValue(containerDom.attr("name"))) {
                    hide([containerDom.attr("name"), deafultValue]);
                    containerDom.attr("name", "converted-" + containerId);
                } else {
                    hide([containerId, deafultValue]);
                }
                $("#" + containerId.replace("choose", "select")).remove();

                $.log("已为" + containerId + "自动选择唯一值");
                return;
            }

            var arr = [];
            for (var i = 0; i < _data.length; i++) {
                var _t = $.hasValue(textMember) ?
                    ($.isFunction(textMember) ?
                    textMember(_data[i]) :
                    _data[i][textMember]) :
                   _data[i]["Text"];
                var _v = $.hasValue(valueMember) ?
                    ($.isFunction(valueMember) ?
                    valueMember(_data[i]) :
                    _data[i][valueMember]) :
                   _data[i]["Value"];

                arr.push({ title: _t, value: _v });
            }
            $("#" + containerId).select({
                title: "请选择",
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
            if ($.hasValue(doAfterInit)) {
                doAfterInit(_data);
            }
        });
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