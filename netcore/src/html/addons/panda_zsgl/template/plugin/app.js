
/*! head.load - v1.0.3 */
(function (n, t) { "use strict"; function w() { } function u(n, t) { if (n) { typeof n == "object" && (n = [].slice.call(n)); for (var i = 0, r = n.length; i < r; i++)t.call(n, n[i], i) } } function it(n, i) { var r = Object.prototype.toString.call(i).slice(8, -1); return i !== t && i !== null && r === n } function s(n) { return it("Function", n) } function a(n) { return it("Array", n) } function et(n) { var i = n.split("/"), t = i[i.length - 1], r = t.indexOf("?"); return r !== -1 ? t.substring(0, r) : t } function f(n) { (n = n || w, n._done) || (n(), n._done = 1) } function ot(n, t, r, u) { var f = typeof n == "object" ? n : { test: n, success: !t ? !1 : a(t) ? t : [t], failure: !r ? !1 : a(r) ? r : [r], callback: u || w }, e = !!f.test; return e && !!f.success ? (f.success.push(f.callback), i.load.apply(null, f.success)) : e || !f.failure ? u() : (f.failure.push(f.callback), i.load.apply(null, f.failure)), i } function v(n) { var t = {}, i, r; if (typeof n == "object") for (i in n) !n[i] || (t = { name: i, url: n[i] }); else t = { name: et(n), url: n }; return (r = c[t.name], r && r.url === t.url) ? r : (c[t.name] = t, t) } function y(n) { n = n || c; for (var t in n) if (n.hasOwnProperty(t) && n[t].state !== l) return !1; return !0 } function st(n) { n.state = ft; u(n.onpreload, function (n) { n.call() }) } function ht(n) { n.state === t && (n.state = nt, n.onpreload = [], rt({ url: n.url, type: "cache" }, function () { st(n) })) } function ct() { var n = arguments, t = n[n.length - 1], r = [].slice.call(n, 1), f = r[0]; return (s(t) || (t = null), a(n[0])) ? (n[0].push(t), i.load.apply(null, n[0]), i) : (f ? (u(r, function (n) { s(n) || !n || ht(v(n)) }), b(v(n[0]), s(f) ? f : function () { i.load.apply(null, r) })) : b(v(n[0])), i) } function lt() { var n = arguments, t = n[n.length - 1], r = {}; return (s(t) || (t = null), a(n[0])) ? (n[0].push(t), i.load.apply(null, n[0]), i) : (u(n, function (n) { n !== t && (n = v(n), r[n.name] = n) }), u(n, function (n) { n !== t && (n = v(n), b(n, function () { y(r) && f(t) })) }), i) } function b(n, t) { if (t = t || w, n.state === l) { t(); return } if (n.state === tt) { i.ready(n.name, t); return } if (n.state === nt) { n.onpreload.push(function () { b(n, t) }); return } n.state = tt; rt(n, function () { n.state = l; t(); u(h[n.name], function (n) { f(n) }); o && y() && u(h.ALL, function (n) { f(n) }) }) } function at(n) { n = n || ""; var t = n.split("?")[0].split("."); return t[t.length - 1].toLowerCase() } function rt(t, i) { function e(t) { t = t || n.event; u.onload = u.onreadystatechange = u.onerror = null; i() } function o(f) { f = f || n.event; (f.type === "load" || /loaded|complete/.test(u.readyState) && (!r.documentMode || r.documentMode < 9)) && (n.clearTimeout(t.errorTimeout), n.clearTimeout(t.cssTimeout), u.onload = u.onreadystatechange = u.onerror = null, i()) } function s() { if (t.state !== l && t.cssRetries <= 20) { for (var i = 0, f = r.styleSheets.length; i < f; i++)if (r.styleSheets[i].href === u.href) { o({ type: "load" }); return } t.cssRetries++; t.cssTimeout = n.setTimeout(s, 250) } } var u, h, f; i = i || w; h = at(t.url); h === "css" ? (u = r.createElement("link"), u.type = "text/" + (t.type || "css"), u.rel = "stylesheet", u.href = t.url, t.cssRetries = 0, t.cssTimeout = n.setTimeout(s, 500)) : (u = r.createElement("script"), u.type = "text/" + (t.type || "javascript"), u.src = t.url); u.onload = u.onreadystatechange = o; u.onerror = e; u.async = !1; u.defer = !1; t.errorTimeout = n.setTimeout(function () { e({ type: "timeout" }) }, 7e3); f = r.head || r.getElementsByTagName("head")[0]; f.insertBefore(u, f.lastChild) } function vt() { for (var t, u = r.getElementsByTagName("script"), n = 0, f = u.length; n < f; n++)if (t = u[n].getAttribute("data-headjs-load"), !!t) { i.load(t); return } } function yt(n, t) { var v, p, e; return n === r ? (o ? f(t) : d.push(t), i) : (s(n) && (t = n, n = "ALL"), a(n)) ? (v = {}, u(n, function (n) { v[n] = c[n]; i.ready(n, function () { y(v) && f(t) }) }), i) : typeof n != "string" || !s(t) ? i : (p = c[n], p && p.state === l || n === "ALL" && y() && o) ? (f(t), i) : (e = h[n], e ? e.push(t) : e = h[n] = [t], i) } function e() { if (!r.body) { n.clearTimeout(i.readyTimeout); i.readyTimeout = n.setTimeout(e, 50); return } o || (o = !0, vt(), u(d, function (n) { f(n) })) } function k() { r.addEventListener ? (r.removeEventListener("DOMContentLoaded", k, !1), e()) : r.readyState === "complete" && (r.detachEvent("onreadystatechange", k), e()) } var r = n.document, d = [], h = {}, c = {}, ut = "async" in r.createElement("script") || "MozAppearance" in r.documentElement.style || n.opera, o, g = n.head_conf && n.head_conf.head || "head", i = n[g] = n[g] || function () { i.ready.apply(null, arguments) }, nt = 1, ft = 2, tt = 3, l = 4, p; if (r.readyState === "complete") e(); else if (r.addEventListener) r.addEventListener("DOMContentLoaded", k, !1), n.addEventListener("load", e, !1); else { r.attachEvent("onreadystatechange", k); n.attachEvent("onload", e); p = !1; try { p = !n.frameElement && r.documentElement } catch (wt) { } p && p.doScroll && function pt() { if (!o) { try { p.doScroll("left") } catch (t) { n.clearTimeout(i.readyTimeout); i.readyTimeout = n.setTimeout(pt, 50); return } e() } }() } i.load = i.js = ut ? lt : ct; i.test = ot; i.ready = yt; i.ready(r, function () { y() && u(h.ALL, function (n) { f(n) }); i.feature && i.feature("domloaded", !0) }) })(window);


//tool.js
var g_selectReady = true;
var NS = {
    Register: function () {
        // body...
        var arg = arguments[0];
        var arr = arg.split('.');
        var context = window;
        for (var i = 0; i < arr.length; i++) {
            var str = arr[i];
            if (!context[str]) {
                context[str] = {};
            }
            context = context[str];
        };
    },
    REG: function () {
        Register();
    }
}


//#框架加载器
var g_moudel = "panda_zsgl";
if (g_moudel === "{g_moudel}") {
    alert("警告:没有为模块在配置值:g_moudel");
    throw SyntaxError("警告:没有为模块在配置值:g_moudel");
}
var _c = {
    security: {
        encrypt_key: "xyj",
        decrypt_key: "xyj",
        expire:7
    },
    dir : {
        app: "/addons/" + g_moudel + "/template",//注意末尾不能有/
        pc: "/addons/" + g_moudel + "/template"//注意末尾不能有/
    },
    runtime: {
        debug: true,
        fake: false,
        warn: true,
        third_login: true,
        route: [
            { src: "/sports/crud/", target: "" },
            { src: "/sports/admin/", target: "" }
        ]
    },
    sever: {
        host: "https://app.52xyj.cn",//业务服务器
        cdn: "https://cdn.52xyj.cn/xyj.framwork",
        host_sys: "https://api.52xyj.cn",//框架服务器[权限,报表]
        host_wx: "https://api.52xyj.cn" //微信服务器
    }
   
};

_c.app = {
    login: _c.dir.app + "/pages/login-m.html", 
    login_auto: _c.dir.app + "/pages/login-auto-m.html",
    homepage: _c.dir.app + "/mobile/index.html",
    login_third:"we7"
    //bind: _c.dir.app + "/pages/bind-m.html",
    //wx_login: _c.sever.host_wx + "/WeChat/Web/Authorize?return_url=" + window.location.origin + g_login_wx, //微信自动登陆
    //pay_wx: _c.sever.host_wx + "/WeChat/WeChatPay/JsApiPayPage", //微信支付回调
    //pay_result_wx: window.location.origin + "/web/app/wxpay/charge-result.html?subSystem=system", //微信授权回调
    //wx: _c.sever.host + "/WeChat/WeChatPay/JsApiPayPage", //微信授权
    //charge_wx: "/web/app/" + g_app + "/framework-m/" + "charge.html", //充值
    //charge_result_wx: "/web/app/" + g_app + "/framework-m/" + "charge-result.html", //充值结果
    //wallet_wx: "/web/app/" + g_app + "/framework-m/" + "wallet.html", //钱包
    //withdraw_wx: "/web/app/" + g_app + "/framework-m/" + "-withdraw.html" //提现
};

_c.pc= {
    login: _c.dir.pc + "/pages/login.html",
    login_auto: _c.dir.pc + "/pages/login-auto.html",
    homepage: _c.dir.pc + "/pages/index.html",
    login_third: "we7",
    local_res: _c.dir.pc + "/web/",
    leftmenu: true,
    topmenu: false,
    form: _c.dir.pc + "/pages/form.html",
    report: _c.dir.pc + "/pages/report.html"
}

_c.isDebug = _c.runtime.debug;
_c.isApp = (window.location.pathname.toLowerCase() == _c.app.login_auto || window.location.pathname.toLowerCase() == _c.app.login)//当前页面是移动端自动登陆页
    ? true
    : (window.location.pathname.toLowerCase() == _c.pc.login_auto || window.location.pathname.toLowerCase() == _c.pc.login)//当前页面是pc端自动登陆页
    ? false
    : (_c.dir.app !== "" && window.location.pathname.toLowerCase().indexOf("/mobile/") > -1);
_c.root = _c.isApp ? _c.dir.app : _c.dir.pc;
_c.login = _c.isApp ? _c.app.login : _c.pc.login;
_c.login_auto = _c.isApp ? _c.app.login_auto : _c.pc.login_auto;
_c.homepage = _c.isApp ? _c.app.homepage : _c.pc.homepage;
_c.login_third = _c.runtime.third_login?(_c.isApp ? _c.app.login_third : _c.pc.login_third):"";
//_c.pc.login_3rd_result = _c.dir.pc +"/pages/login-3rd-result.html";
//_c.pc.login_3rd = _c.sever.host + "/Oauth2/YiBan?returnUrl=" +localUrl(_c.pc.login_3rd_result);
//_c.pc.login_out_3rd = _c.sever.host + "/Json/Login/Logout?returnUrl=" + ;
_c.isAutoLoginPage = function () {
    return $.geturl() === _c.app.login_auto || $.geturl() === _c.pc.login_auto;
}
_c.isLoginPage = function () {
    return $.geturl() === _c.login;
}
_c.isVisitor = function () {
    
    return $.geturl() !== _c.login &&
        (!$.hasValue($.unitid()) || !$.hasValue($.uid()));
}
_c.route = function (srcurl) {
    var url = (srcurl + "").replace("//", "/").toLowerCase(); 
    
    for (var i = 0; i < _c.runtime.route.length; i++) {//兼容旧版程序，路由映射
        var item = _c.runtime.route[i];
        if (url.indexOf(item.src) > -1) {//只要替换成功就跳出
            url = url.replace(item.src, item.target);
            break;
        }
    }
    return url;
}
function localUrl(url) {
    return window.location.protocol + "//" + window.location.host + _c.dir.pc +url;
}
function srcurl(src, folder) {

    //1.框架文件（framework目录）  2.程序文件（web目录）   3.cdn资源(调用时无folder参数)
    //自动补齐
    if (folder == undefined) {//3

        if (_c.sever.cdn.indexOf("http") > -1) { //远程cdn
            folder = _c.sever.cdn + "/vendor/";
        } else {//本地cdn
            folder = ((_c.sever.cdn === "/" || _c.sever.cdn === "") ? "/vendor/" : _c.root)
        }
    } else {//1,2
        folder = _c.root + folder;
    }
    var version = "";
    //添加版本号
    if (src.indexOf("head-js") > -1 || folder.indexOf("web") > -1) {
        var now = new Date();
        var number = now.getYear().toString() + now.getMonth().toString() + now.getDate().toString() + now.getHours().toString() + now.getMinutes().toString() + now.getSeconds().toString();
        version = "?v=" + number;
    }
    return folder + src + version;

}
_c.app.lib = {
    src: [
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
        { "layui": srcurl("layui-m/2.0/layer.js") }//,
        //framework
        // { "tools": srcurl("tools.js","/plugin/") } //,
        //{ "form-tool": srcurl("framework-m/js/form-tool.js", "/web/app/bx/") }
    ],
    ready: function () {
        FastClick.attach(document.body);
    }
};

_c.pc.lib = {
    src: [
        srcurl("app.css", "/plugin/"),
        srcurl("bootstrap/css/bootstrap.min.css"),
        srcurl("metisMenu/metisMenu.min.css"),
        srcurl("sb2-dist/css/sb-admin-2.css"),
        srcurl("morrisjs/morris.css"),
        srcurl("font-awesome/css/font-awesome.min.css"),
        //bootstrap-switch
        srcurl("bootstrap-switch/static/stylesheets/bootstrap-switch.css"),
        srcurl("bootstrap-switch/static/stylesheets/bootstrap-switch-conquer.css"),
        srcurl("bootstrap-switch/static/stylesheets/flat-ui-fonts.css"),
        //bootstrap-datetime
        srcurl("bootstrap-datetimepicker/css/datetimepicker.css"),
        //bootstrap-daterangepicker
        srcurl("bootstrap-daterangepicker/daterangepicker-bs3.css"),
        //form-validation 
        srcurl("bootstrap-validator/0.5.3/css/bootstrapValidator.css"),
        //datatables-plugins
        srcurl("datatables-plugins/dataTables.bootstrap.css"),
        //datatables-responsive
        srcurl("datatables-responsive/dataTables.responsive.css"),
        srcurl("layui/1.0.9/css/layui.css"),
       
        //umeditor
        srcurl("umeditor/themes/default/css/umeditor.css"),


        //fileUpload
        //srcurl("fileUpload/file/css/style.css"),
        srcurl("fileUpload/file/css/jquery.fileupload.css"),
        srcurl("fileUpload/file/css/blueimp-gallery.min.css"),
        srcurl("fileUpload/file/css/jquery.fileupload.css"),
        srcurl("fileUpload/file/css/jquery.fileupload-ui.css"),


        //framework
        { "jquery": srcurl("jquery/jquery.js") },
        { "bootstrap": srcurl("bootstrap/js/bootstrap.min.js") },
        { "metisMenu": srcurl("metisMenu/metisMenu.min.js") },
        { "raphael": srcurl("raphael/raphael.min.js") },
        { "morris": srcurl("morrisjs/morris.min.js") },
        //{ "morris-data": srcurl("sb2-dist/data/morris-data.js") },
        { "sb-admin-2": srcurl("sb2-dist/js/sb-admin-2.js") },
        //bootstrap-datetime 
        { "bootstrap-datetimepicker": srcurl("bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js") },
        { "bootstrap-datetimepicker-zh": srcurl("bootstrap-datetimepicker/js/locales/bootstrap-datetimepicker.zh-CN.js") },
        //form-validation
        { "form-validation": srcurl("bootstrap-validator/0.5.3/js/bootstrapValidator.js") },
        { "form-validation-zh": srcurl("bootstrap-validator/0.5.3/js/language/zh_CN.js") },
        //bootstrap-switch 
        { "bootstrap-switch": srcurl("bootstrap-switch/static/js/bootstrap-switch.min.js") },
        //echarts 
        { "bootstrap-switch": srcurl("echarts/3.5.2/echarts.min.js") },
        //umeditor
        { "umeditor-config": srcurl("umeditor/umeditor.config.js") },
        { "umeditor": srcurl("umeditor/umeditor.js") },
        { "umeditor-zh": srcurl("umeditor/lang/zh-cn/zh-cn.js") },
        //bootstrap-daterangepicker
        { "bootstrap-daterangepicker": srcurl("bootstrap-daterangepicker/daterangepicker.js") },
        { "bootstrap-daterangepicker-moment": srcurl("bootstrap-daterangepicker/moment.min.js") },
        //jquery.cookie
        { "jquery-cookie": srcurl("jquery/jquery.cookie.js") },
        //layui
        { "layui": srcurl("layui/1.0.9/layui.js") },
        //jquery-dataTables
        { "jquery-dataTables": srcurl("datatables/js/jquery.dataTables.min.js") },
        //dataTables-bootstrap
        { "dataTables-bootstrap": srcurl("datatables-plugins/dataTables.bootstrap.min.js") },
        //dataTables.responsive
        { "dataTables.responsive": srcurl("datatables-responsive/dataTables.responsive.js") },
        //importxls
        { "importxls-shim": srcurl("importxls/js/shim.js") },
        { "importxls-xls": srcurl("importxls/js/xls.js") },
        //exportxls
        //{ "exportxls": srcurl("exportxls/js/tableExport.js") },
        //export2
        { "export-xlsx-core": srcurl("tableExport.jquery.plugin/libs/js-xlsx/xlsx.core.min.js") },
        { "export-FileSaver": srcurl("tableExport.jquery.plugin/libs/FileSaver/FileSaver.min.js") },
        { "export-jspdf": srcurl("tableExport.jquery.plugin/libs/jsPDF/jspdf.min.js") },
        { "export-jspdf-autotable": srcurl("tableExport.jquery.plugin/libs/jsPDF-AutoTable/jspdf.plugin.autotable.js") },
        { "export-html2canvas": srcurl("tableExport.jquery.plugin/libs/html2canvas/html2canvas.min.js") },
        { "export-tableExport": srcurl("tableExport.jquery.plugin/tableExport.js") },
        /*
            <script type="text/javascript" src="tableExport.jquery.plugin/libs/js-xlsx/xlsx.core.min.js"></script>
            <script type="text/javascript" src="tableExport.jquery.plugin/libs/FileSaver/FileSaver.min.js"></script>
          <script type="text/javascript" src="tableExport.jquery.plugin/libs/jsPDF/jspdf.min.js"></script>
          <script type="text/javascript" src="tableExport.jquery.plugin/libs/jsPDF-AutoTable/jspdf.plugin.autotable.js"></script>
          <script type="text/javascript" src="tableExport.jquery.plugin/libs/html2canvas/html2canvas.min.js"></script>
            <script type="text/javascript" src="tableExport.jquery.plugin/tableExport.js"></script>
        */
        //html-to-pdf
        { "exportxls-jspdf": srcurl("html-to-pdf/js/jspdf.min.js") },
        { "exportxls-html2canvas": srcurl("html-to-pdf/js/html2canvas.min.js") },
        //pym
        { "pym": srcurl("pym-js/src/pym.js") },
        //fileUpload
        { "widget": srcurl("fileUpload/file/js/vendor/jquery.ui.widget.js") },
        { "tmpl": srcurl("fileUpload/file/js/tmpl.min.js") },
        { "load-image": srcurl("fileUpload/file/js/load-image.all.min.js") },
        { "canvas-to-blob": srcurl("fileUpload/file/js/canvas-to-blob.min.js") },
        { "blueimp": srcurl("fileUpload/file/js/jquery.blueimp-gallery.min.js") },
        { "iframe": srcurl("fileUpload/file/js/jquery.iframe-transport.js") },
        { "fileupload": srcurl("fileUpload/file/js/jquery.fileupload.js") },
        { "fileupload-process": srcurl("fileUpload/file/js/jquery.fileupload-process.js") },
        { "fileupload-image": srcurl("fileUpload/file/js/jquery.fileupload-image.js") },
        { "fileupload-audio": srcurl("fileUpload/file/js/jquery.fileupload-audio.js") },
        { "fileupload-video": srcurl("fileUpload/file/js/jquery.fileupload-video.js") },
        { "fileupload-validate": srcurl("fileUpload/file/js/jquery.fileupload-validate.js") },
        { "fileupload-ui": srcurl("fileUpload/file/js/jquery.fileupload-ui.js") },
        //framework
        // { "tools": srcurl("tools.js", "/plugin/") },
        { "importxls-acc": srcurl("importxls/js/excel.acc.js") },
        { "app-extension-pc": srcurl("app.extension.pc.js", "/plugin/") }  
    ],
    ready: function () {
        layui.config({
            dir: srcurl("layui/1.0.9/") //layui.js 所在路径（注意,如果是script单独引入layui.js,无需设定该参数。）,一般情况下可以无视
            ,
            version: false //一般用于更新模块缓存,默认不开启。设为true即让浏览器不缓存。也可以设为一个固定的值,如：201610
            ,
            debug: false //用于开启调试模式,默认false,如果设为true,则JS模块的节点会保留在页面
            ,
            base: srcurl("layui/1.0.9/lay/modules/") //设定扩展的Layui模块的所在目录,一般用于外部模块扩展
        }).use("index");
    }
};

_c.lib = _c.isApp ? _c.app.lib : _c.pc.lib;




//加载资源
head.load(_c.lib.src);
head.ready(_c.lib.ready);
//扩展jquery-使用命名空间定义函数
head.ready(["jquery", "layui"], function () {
    $.extend({
        //ajax
        Ajax: function (cfg) {
            var showLoading = cfg.showLoading == undefined ? true : cfg.showLoading;
            if (cfg.url.indexOf("@") > -1) {
                cfg.url = cfg.url.replace(/@/g, "-"); //ecampus.twxt.fake_api@add  
                if (cfg.url.indexOf("?cmd=") === -1) {
                    cfg.url = "/db/index?cmd=" + cfg.url; //ecampus.twxt.fake_api@add  
                }
            }
            var url = $.url(cfg.url, (cfg.url.length > 6 && cfg.url.substring(0, 5).toLowerCase() === "/open"));

            if (cfg.data == undefined) {
                cfg.data = {};
            }
            if (cfg.data.uid == undefined) {
                cfg.data.uid = $.uid();
            }
            if (cfg.data.uname == undefined) {
                cfg.data.uname = $.cookie("nick_name");
            }
            cfg.data.isDebug = _c.isDebug;
            cfg.data.unitid = $.unitid();
            var lIndex = showLoading ? $.loading() : -1;

            $.ajax({
                type: "Post",
                url: url, //参数1
                data: cfg.data,
                success: function (response, status) {
                    if (showLoading) {
                        $.loaded(lIndex);
                    }
                    // //debugger
                    try {
                        var result = response;
                        if (typeof (response) == "string") {
                            if (response.indexOf("<head") > 0) { //返回格式为html
                                $.dealError(url, "<p style='color:red;'>已成功与服务器取得连接,但服务器响应了错误格式的数据，这个格式疑似html代码,点击确认查看渲染后的视图</p>", result);

                                return;
                            } else { //返回格式为jsonString
                                result = $.toObject(response);
                            }
                        } else { //返回格式为json
                            result = response;
                        }

                        if (result.code === -1) { //被服务器捕获的500错误
                            var errorMsg = $.toObject(result.jsonData);
                            $.dealError(url, errorMsg.Message, errorMsg.StackTrace.replace(/\r\n/g, "<br/><br/>"));

                            return;
                        } else { //正常返回

                            var data = $.toObject(result.jsonData);
                            cfg.success(data, result.code, result.msg, result.url);
                            return;
                        }
                    } catch (ex) {
                        $.dealError(ex.message, ex.message, ex.stack);
                    }

                },
                error: function (xmlHttpRequest, textStatus, errorThrown) {
                    $.loaded(lIndex);
                    //debugger 

                    if (_c.isDebug) {
                        var errorData = xmlHttpRequest.responseText; //500错误时需要整体序列化
                        if (typeof (errorData) == "string") {
                            if (!$.hasValue(xmlHttpRequest.responseText)) {
                                $.alert("服务器连接失败,请检查是否启动了服务器端,若问题依旧,请检查config.js中的 _c.sever.host配置项是否正确！", 2);
                                return;
                            } else {
                                $.dealError(url, "服务器错误:请确保服务器端代码已通过编译！", errorData);
                                return;
                            }
                        }

                        try { //服务器处理过的错误
                            var errorMsg = $.toObject(errorData.jsonData);
                            $.dealError(url, errorMsg.Message, errorMsg.StackTrace.replace(/\r\n/g, "<br/><br/>"));
                        } catch (ex) { //致命错误
                            //debugger
                            $.dealError(url, "服务器错误:请确保服务器已成功启动！", errorData);
                        }

                        //$.log(errorMsg);
                        //$.log(xmlHttpRequest.responseText);
                        //$.confirm("请求服务器的过程中出现错误,请检查:<br/>1.是否启动了服务器端<br/>2.服务器是否提供了正确的api<br/>3.检查config.js中的 _c.sever.host配置项是否正确<br/>4.若问题依旧,请点击确认查看详细错误信息", function () {
                        //    $.go(url);
                        //}, 2);
                    } else {
                        $.alert("网络连接失败,请检查您的网络连接状态！", 5);
                    }
                }
            });
        },
        dealError: function (errorSrc, errorMessage, stack) {
            $.warn(stack);
            $.alert("请求出错！点击确认查看详情<hr/><p style='color:red;'>" + errorMessage + "</p>", 2, function () {
                try {
                    //iframe窗
                    layer.open({
                        type: 1,
                        title: "来自" + errorSrc + "的详细错误信息",
                        closeBtn: 1, //不显示关闭按钮
                        shade: [0],
                        area: [600 + 'px', 450 + 'px'],
                        offset: 'rb', //右下角弹出
                        //time: 20000, //2秒后自动关闭
                        anim: 2,
                        skin: 'layer-ext-moon',
                        content: stack //errorMsg.StackTrace.replace(/\r\n/g, "<br/><br/>")
                    });
                } catch (ex) {
                    $.warn("dealError函数依赖于layui");
                }

            });
        },
        dealAjax: function (data, code, msg, url) { //回调函数,result,返回值 
            //debugger 
            switch (code) {
            case 1:
                {
                    $.msg(msg, code);
                };
                break;
            case 2:
                {
                    $.msg(msg, code);
                };
                break;
            case 3:
                {
                    $.confirm(msg, function () {
                        if ($.hasValue(url)) {
                            $.go($.parseurl(url).destUrl);
                        }
                    }, "", "", "", code);
                };
                break;
            case 5:
                {
                    $.confirm(msg, function () {
                        if ($.hasValue(url)) {
                            $.go($.parseurl(url).destUrl);
                        }
                    }, "", "", "", code);
                };
                break;
            case 6:
                {
                    $.confirm(msg, function () {
                        if ($.hasValue(url)) {
                            $.go($.parseurl(url).destUrl);
                        }
                    }, "", "", "", code);
                };
                break;
            case 7:
                {
                    $.confirm(msg, function () {
                        var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
                        parent.layer.close(index); //再执行关闭   
                        return true;
                    }, "", "", "", 3);
                };
                break;
            case 8:
                {
                    $.confirm(msg, function () {
                        layer.close();
                        return true;
                    }, "", "", "", 5);
                };
                break;
            case 9:
                { //下载文件
                    // //debugger 

                    // $.log(data.info);
                    // $.log(data.name);
                    if (!$.hasValue(data[data.name])) {
                        $.msg("用户没有上传文件", 0);
                        return;
                    }
                    $.ajax({
                        url: $.url(data[data.name]),
                        success: function () {
                            $.go($.url(data[data.name]));
                        },
                        error: function () {
                            $.msg("服务器文件已丢失", 2);
                        }
                    });
                    return;

                };
                break;
            case 10:
                {
                    $(".btn").remove();
                    $.msg(msg + "<br/><span id='lb_time'>3</span>秒后自动关闭窗口", 1);
                    setTimeout(function () {
                        var index = parent.layer.getFrameIndex(window.name); //先得到当前iframe层的索引
                        parent.layer.close(index); //再执行关闭   
                    }, 3000);

                };
                break;
                deafult: {
                    if (_c.isDebug) {
                        $.alert("服务器返回了错误的code,请检查api的返回值");
                    }
                }
            }
            try {
                refresh(data, code, msg, url);
            } catch (ex) {
                $.warn("刷新失败" + ex);
            }
        },
        // 转为对象 
        toJson: function (obj) {
            return JSON.stringify(obj);
        },
        // 转为json  
        toObject: function (jsonString) {
            if (jsonString == undefined) {
                return "";
            }
            jsonString = jsonString.replace(/\n/g, "");
            return JSON.parse(jsonString);
        },
        // 批量替换  
        replace: function (str, arr) {
            // debugger
            if (!$.hasValue(str)) return "";
            if ($.isArray(arr) && arr.length > 0 && !$.isArray(arr[0])) {
                arr = [arr];
            }

            for (var i = 0; i < arr.length; i++) {
                var item = arr[i];
                while (str.indexOf(item[0]) > -1) {
                    str = str.replace(item[0], item[1]);
                }
            }
            return str;
        },
        // 加密算法可以公开  
        encrypt: function (plainText, key) {
            if (key == undefined) {
                key = g_encrypt_key;
            }
            return plainText ^ key;
        },
        // 解密算法也可以公开  
        decrypt: function (cipherText, key) {
            if (key == undefined) {
                key = g_decrypt_key;
            }
            return cipherText ^ key;
        },
        notEmpty_m: function (nameArray, tip) {
            if (!$.hasValue(tip)) {
                tip = "请将信息填写完整";

            }
            // debugger
            if (!$.isArray(nameArray)) {
                nameArray = [nameArray];
            }
            for (var i = 0; i < nameArray.length; i++) {
                var v = $.val_m(nameArray[i]);
                if (!$.hasValue(v)) {
                    $.alert(tip);
                    return false;
                }
            }
            return true;
        },
        hasElem: function (array, targetElem, key) {
            for (var i = 0; i < array.length; i++) {
                {
                    var item = array[i];
                    if (item[key] == targetElem[key]) {
                        return true;
                    }
                }
            }
            return false;
        },
        pushRange: function (array, targetArray) {
            if (!$.hasValue(targetArray)) {
                targetArray = [];
            }
            var result = [];
            for (var i = 0; i < array.length; i++) {
                {
                    var item = array[i];
                    result.push(item);
                }
            }
            for (var j = 0; j < targetArray.length; j++) {
                {
                    var item = array[j];
                    result.push(item);
                }
            }
            return result;
        },
        union: function (array, targetArray, key, doBeforeCompare) {
            var result = $.pushRange(array);
            for (var i = 0; i < targetArray.length; i++) {
                {
                    var item = targetArray[i];
                    item = $.hasValue(doBeforeCompare) ? doBeforeCompare(item) : item;
                    if (!$.hasElem(array, item, key)) {
                        result.push(item);
                    }
                }
            }
            return result;
        },
        intersect: function (array, targetArray, key, doBeforeCompare) {
            var result = [];
            for (var i = 0; i < array.length; i++) {
                {
                    var item = array[i];
                    item = $.hasValue(doBeforeCompare) ? doBeforeCompare(item) : item;
                    if ($.hasElem(targetArray, item, key)) {
                        result.push(item);
                    }
                }
            }
            return result;
        },
        except: function (array, targetArray, key, doBeforeCompare) {
            var result = [];
            for (var i = 0; i < array.length; i++) {
                {
                    var item = array[i];
                    item = $.hasValue(doBeforeCompare) ? doBeforeCompare(item) : item;

                    if (!$.hasElem(targetArray, item, key)) {
                        result.push(item);
                    }
                }
            }
            return result;
        },
        //检查页面是否合法-移动版
        checkPage: function () {
            var domsFromId = $("input[id*='-'],textarea[id*='-'],select[id*='-']"); //只住区input和area
            if (domsFromId.length > 0) {
                $.alert("页面不规范，请打开控制台查看修改建议！");
                $.warn("移动端页面的数据控件(input,select,textarea)的id不能包含字符'-',当前不符合规范的如下:");
                for (var i = 0; i < domsFromId.length; i++) {
                    var item = $(domsFromId[i]);
                    $.log('id="' + item.attr("id") + '"');
                }

            }

        },
        //取表单值-移动版
        vals_m: function (id, type) {

            var domsFromName = $("input[name*='-'],textarea[name*='-'],select[name*='-']"); //只住区input和area
            var domsFromId = $("input[id*='-'],textarea[id*='-'],select[id*='-']"); //只住区input和area
            var doms = $.union(domsFromName, domsFromId, "outerHTML");



            var json = "{";
            for (var i = 0; i < doms.length; i++) {
                var dom = $(doms[i]);
                var currentId = $.hasValue(dom.attr("name")) ? dom.attr("name") : dom.attr("id");
                var value = $.val_m(dom);
                json += "\"" + currentId + "\":" + "\"" + value + "\"";
                if (i === doms.length - 1) {
                    json += "}";
                } else {
                    json += ",";
                }
            }
            if (doms.length === 0) json = "{}";
            return $.toObject(json);
        },
        //取值-移动版
        val_m: function (domOrNameOrClass, doAfterGetValue) {
            if (!$.hasValue(domOrNameOrClass)) {
                return "";
            }
            var dom;
            //debugger
            if ($.isString(domOrNameOrClass)) {
                dom = $("input[name='" + domOrNameOrClass + "'],textarea[name='" + domOrNameOrClass + "'],textarea[select='" + domOrNameOrClass + "']");
                if (dom.length === 0) {
                    dom = $("." + domOrNameOrClass);
                    if (dom.length === 0) {
                        dom = $("#" + domOrNameOrClass);
                        if (dom.length === 0) {
                            $.warn("未找到该元素：" + domOrNameOrClass);
                            return "";
                        }
                    }
                }
            } else {
                dom = domOrNameOrClass;

            }

            var v = dom.data("values"); //dom.val();
            if (!$.hasValue(v) && $.hasValue(dom.attr("value"))) {
                v = dom.attr("value");
            }
            if (!$.hasValue(v) && $.hasValue(dom.val())) {
                v = dom.val();
            }
            if ($.hasValue(doAfterGetValue)) {
                doAfterGetValue(v, dom);
            }
            return $.htmlEncode(v);
        },
        //取值
        val: function (id, type, uiType) {
            //debugger 
            var value = "";
            uiType = $.checkValue(uiType, 'pc');
            switch (uiType) {
            case "pc":
            {
                switch (type) {
                case 201:
                case 203:
                case 209:
                case 210:
                case 211:
                case 212:
                case 213:
                case 214: //文本框
                    {
                        value = $('#' + id).val(); //jquery取值
                        //value=document.getElementById(id).value;//js取值
                    }
                    break;
                case 202:
                case 223: //时间
                    {
                        //debugger
                        return $('#' + id).val(); //时间不转码
                    }
                    break;
                case 204: //下拉框
                    {
                        //debugger
                        //把val()改为text(),value改为text可以实现取文本
                        value = $("#" + id + " option:selected").val(); //jquery取值
                        /*//js取值
                           var myselect=document.getElementById(id); 
                           var index=myselect.selectedIndex ; 
                           value=myselect.options[index].value; 
                          */
                    }
                    break;
                case 205: //单选框
                    {
                        value = $("input[name=" + id + "]:checked").val(); //jq 取值
                        //  obj = document.getElementsByName(id);//js取值

                    }
                    break;
                case 206: //编辑器
                    {
                        var ue = UM.getEditor(id);
                        ue.ready(function () {
                            //获取html内容,
                            value = $.htmlEncode(ue.getContent());
                        });
                    }
                    break;
                case 207: //多选框
                    {
                        //var chk_value = []; //定义一个数组     jq取值 
                        //$("input[name=" + id + "]:checked").each(function () { //遍历每一个名字为nodes的复选框,其中选中的执行函数
                        //    chk_value.push($(this).val()); //将选中的值添加到数组chk_value中      
                        //});
                        //var groups = chk_value.join(",");
                        //value = groups;
                        ////jq 取值
                        //$("input:checkbox[value=3]").attr('checked', 'true'); //jq 赋值 
                        ////      			 obj = document.getElementsByName(id);//js取值
                        ////				    check_val = [];
                        ////				    for(k in obj){
                        ////				        if(obj[k].checked)
                        ////				           check_val.push(obj[k].value)
                        ////				    }
                        ////				      value=check_val;
                        var length = $('#' + id + ' .weui-check__label').length
                        var str = ""
                        for (var i = 0; i < length; i++) {
                            if ($('#' + id + ' .weui-check__label').eq(i).find('input[type=checkbox]').is(':checked')) {
                                str += $('#' + id + ' .weui-check__label').eq(i).find('.weui-cell__bd p').text();
                            }
                        }
                        var groups = str.join(",");
                        value = groups;

                    }
                    break;
                case 208: //开关
                    {
                        value = $('#' + id).val(); //jquery取值
                    }
                    break;


                }
            }
            case "weui":
            {
                switch (type) {
                case 201:
                case 203:
                case 209:
                case 210:
                case 211:

                case 212:
                case 213:
                case 214:
                case 222:
                case 223:
                case 224:
                case 225:
                case 226://文本框
                    {
                        value = $('#' + id).val(); //jquery取值
                        //value=document.getElementById(id).value;//js取值
                    }
                    break;
                case 202:
                case 223: //时间
                    {
                        //debugger
                        return $('#' + id).val(); //时间不转码
                    }
                    break;
                case 204: //下拉框
                    {
                        //debugger
                        //把val()改为text(),value改为text可以实现取文本
                        value = $("#" + id + " option:selected").val(); //jquery取值
                        /*//js取值
                           var myselect=document.getElementById(id); 
                           var index=myselect.selectedIndex ; 
                           value=myselect.options[index].value; 
                          */
                    }
                    break;
                case 205: //单选框
                    {
                        value = $("input[name=" + id + "]:checked").val(); //jq 取值
                        //  obj = document.getElementsByName(id);//js取值

                    }
                    break;
                case 206: //编辑器
                    {
                        var ue = UE.getEditor(id);
                        ue.ready(function () {
                            //获取html内容,
                            value = $.htmlEncode(ue.getContent());
                        });
                    }
                    break;
                case 207: //多选框
                    {
                        var chk_value = []; //定义一个数组     jq取值 
                        $("input[name=" + id + "]:checked").each(function () { //遍历每一个名字为nodes的复选框,其中选中的执行函数
                            chk_value.push($(this).val()); //将选中的值添加到数组chk_value中      
                        });
                        var groups = chk_value.join(",");
                        value = groups;
                        //jq 取值
                        $("input:checkbox[value=3]").attr('checked', 'true'); //jq 赋值 
                        //      			 obj = document.getElementsByName(id);//js取值
                        //				    check_val = [];
                        //				    for(k in obj){
                        //				        if(obj[k].checked)
                        //				           check_val.push(obj[k].value)
                        //				    }
                        //				      value=check_val;

                    }
                    break;
                case 208: //开关
                    {
                        value = $('#' + id).val(); //jquery取值
                    }
                    break;


                }
            }
            }


            //编码后返回
            return $.hasValue(value) ? $.htmlEncode(value) : "";
        },
        htmlEncode: function (html) {
            return HtmlUtil.htmlEncodeByRegExp(html);
        },
        htmlDecode: function (html) {
            return HtmlUtil.htmlDecodeByRegExp(html);
        },
        set_m: function (doms, v, p) {
            //debugger
            if (doms == undefined) return;
            for (var i = 0; i < doms.length; i++) {
                var dom = $(doms[i]);
                if (dom == undefined) break;

                //$.log(dom.attr("type"))
                //图片
                if (dom.attr("src") != undefined) {

                    if ($.hasValue(v)) {
                        if (v.toLowerCase().indexOf("http") > -1) {
                            dom.attr("src", v);
                        } else {
                            dom.attr("src", $.url(v));
                        }
                    } //文本框
                } else if (dom.attr("type") === "text") {
                    // dom.attr("name", p);//设置name属性
                    dom.val(v); //设置value属性
                } else if (dom[0].tagName === "SELECT") { //下拉框
                    // debugger 
                    dom.val(v);
                } else if (dom[0].tagName === "P") { //下拉框
                    // debugger 
                    dom.html($.htmlDecode(v));
                }
                {
                    if (!$.hasValue(dom.attr("name"))) {
                        dom.attr("name", p);//页面没有该name时才改变name
                    }
                    dom.html($.htmlDecode(v));
                    //debugger
                    $.warn(
                        {
                            msg: "set_m函数出错，出现无法判断的控件类型,已经采用默认方法赋值(html元素优先，hide第二)", dom_type:
                                dom.attr("type"), dom_id:
                                dom.attr("id")
                        });
                    //$.log(dom.type.toLowerCase())
                    //dom.attr("name", p);//设置name属性

                }


            }
        },
        set: function (id, type, vaule) {
            var currentId = id;
            var notTrimValue = $.htmlDecode(vaule);//解码
            var value = $.trimString(notTrimValue);
            var defultValue = $.hasValue(value) ? value : "-12580";
            switch (type) {
            case 201: case 211: case 212: case 213://文本框
            {
                //  debugger
                if ($.hasValue(value))//无值的时候不操作
                    $('#' + currentId).val(value);//jquery赋值
                //document.getElementById(currentId).value='newvalue'//js赋值
            } break;
            case 202: case 216: case 223://时间
            {
                //   debugger 
                if ($.hasValue(notTrimValue))//无值的时候不操作
                    $('#' + currentId).val($.parsetime(notTrimValue));
            } break;
            case 203: case 217://日期
            {
                // debugger
                if ($.hasValue(value))
                    $('#' + currentId).val($.parsedate(value));
            } break;
            case 204: case 218://下拉框202
            {
                //debugger
                if ($.hasValue(value)) {
                    $("#" + currentId).val(value);//设置选中
                    $("#" + currentId).data("value", value);//缓存从服务器读取回来的值
                }
            } break;
            case 205: case 219://单选框
            {
                $.log($.hasValue(value));
                if ($.hasValue(value)) {
                    $("input:radio[value=" + defultValue + "]").attr('checked', 'true'); //jq 赋值 
                    /*  obj = document.getElementsByName(currentId);//eckbox取值    
                        for(k in obj){
                            if(obj[k].checked)
                               value= obj[k].value
                        }    */ //js赋值
                }

            } break;
            case 206: case 220://编辑器
            {
                if ($.hasValue(notTrimValue)) {
                    var ue = UM.getEditor(currentId);
                    ue.ready(function () {
                        //设置编辑器的内容
                        //debugger 
                        ue.setContent($.htmlDecode(notTrimValue));
                    });
                }

            } break;
            case 220: //编辑器查看
            {
                // debugger
                if ($.hasValue(notTrimValue))
                    $('#' + currentId).html($.htmlDecode(notTrimValue));
            } break;
            case 207: case 221://多选框
            {
                if ($.hasValue(value)) {
                    for (var k = 0; k < notTrimValue.length; k++) {
                        $("input:checkbox[value=" + notTrimValue[k] + "]").attr('checked', 'true'); //jq 赋值 
                        // document.getElementsByName(currentId)[2].checked = true; //js赋值 
                    }
                }


            } break;
            case 208: case 222://开关
            {
            } break;
            case 209: case 215: //多行文本框
            {
                if ($.hasValue(notTrimValue)) {
                    $('#' + currentId).val(notTrimValue);  // jq赋值
                    // document.getElementById(currentId).value = "221";//js赋值   
                }

            } break;
            case 210: case 214://文件
            {

                if ($.hasValue(value)) {
                    //把文件值放进hide中
                    $('#' + currentId).val(value);
                    //构造文件操作界面
                    $('#fileupload-' + currentId + ' tbody').html(FileItemsTpl(value, currentId, type == 210));
                }

            } break;
            default:
            }
        },

        getFileName: function (path) {
            var dest = path.split("-split-")[1];
            // var dest = path.substring(path.lastIndexOf('/')+1).split("-split-")[0];

            return $.hasValue(dest) ? decodeURI(dest) : "";
        },

        //模板
        qx_tpl: function (obj, tplFn) {
            return getTpl(tplFn).format(obj);
        },
        //页面层-自定义
        diy: function (content, title) {
            if (title == undefined) {
                title = false;
            }
            try {
                layer.open({
                    type: 1,
                    title: title,
                    closeBtn: 1,
                    shadeClose: true,
                    skin: 'layui-layer-lan',
                    content: "<div >" + content + "</div>"
                });
            } catch (ex) {
                $.warn("diy函数依赖于layui");
            }

        },

        //提示框
        window: function (url, title, width, height, closeBtn) {

            if (title == undefined) {
                title = false;
            }
            if (width == undefined) {
                width = 600;
            }
            if (height == undefined) {
                height = 450;
            }
            if (closeBtn == undefined) {
                closeBtn = 0;
            }
            //iframe窗
            try {
                layer.open({
                    type: 2,
                    title: title,
                    closeBtn: closeBtn, //不显示关闭按钮
                    shade: [0],
                    area: [width + 'px', height + 'px'],
                    offset: 'rb', //右下角弹出
                    //time: 20000, //2秒后自动关闭
                    anim: 2,
                    skin: 'layer-ext-moon',
                    content: [url, 'yes'] //iframe的url,no代表不显示滚动条

                });
            } catch (ex) {

                $.warn("window函数依赖于layui");
            }

        },
        //提示框
        alert: function (content, icon, fn) {
            if (icon == undefined) {
                icon = 0;
            }
            var realFn = function (index) {
                if ($.hasValue(fn)) {
                    fn(index);
                }
                layer.close(index);
            };
            try {

                layer.alert(content, {
                    icon: icon,
                    title: "提示",
                    skin: "layer-ext-moon" //该皮肤由layer.seaning.com友情扩展。关于皮肤的扩展规则,去这里查阅
                }, realFn);
            } catch (ex) {
                return layer.open({
                    content: content
                    , btn: '我知道了'
                });

            }

        },
        //消息框
        msg: function (content, icon) {
            if (icon == undefined) {
                icon = 1;
            }
            if (content.indexOf("请稍后") > -1) {
                icon = 0;
            }
            try {
                var index = layer.msg(content, {
                    icon: icon,
                    time: 2000 //2秒关闭（如果不配置，默认是3秒）
                });
                return index;
            } catch (ex) {
                //移动版本
                return layer.open({
                    content: content
                    , skin: 'msg'
                    , time: 2 //2秒后自动关闭
                });

            }
        },
        //打开加载层
        loading: function (style) {

            if (style == undefined) {
                style = 1;
            }
            try {
                var index = layer.load(style, {
                    shade: [0.1, '#fff'] //0.1透明度的白色背景
                });
                return index;
            } catch (ex) {
                //移动版本
                return layer.open({ type: 2 });
            }
        },

        //关闭加载层
        loaded: function (index) {
            try {
                if ($.hasValue(index)) {
                    layer.close(index);
                } else {
                    console.error("关闭所有loading:index=>" + index);
                    layer.closeAll('loading'); //关闭加载层 
                }
            } catch (ex) {

                layer.close(index);
            }
        },
        //确认框
        confirm: function (content, confirmDoWhat, whenCancleDo, whenDoSuccess, whenDoFail, icon) {
            //debugger
            if (content == undefined) {
                content = "请确认您的操作！";
            }
            if (!$.hasValue(icon)) {
                icon = 3;
            }
            try {
                var iii = layer.confirm(content,
                    { icon: icon, title: '确认？', btn: ["确认", "取消"] },
                    function () {
                        layer.close(iii);
                        var ok = confirmDoWhat();
                        if ($.hasValue(ok)) {
                            if (ok) {
                                if (!$.hasValue(whenDoSuccess)) {
                                    $.msg("操作成功", 1);
                                } else {
                                    whenDoSuccess();
                                }
                            }
                            else {
                                if (!$.hasValue(whenDoFail)) {
                                    $.msg("操作成功", 1);
                                } else {
                                    whenDoFail();
                                }
                            }

                        }
                    }, function () {
                        if (!$.hasValue(whenCancleDo)) {
                            $.msg("操作已取消", 0);
                        } else {
                            whenCancleDo();
                        }

                    });
            } catch (ex) {
                layer.open({
                    content: content
                    , btn: ['确认', '取消']
                    , yes: function (index) {
                        layer.close(index);
                        var ok = confirmDoWhat();
                        if ($.hasValue(ok)) {
                            if ($.hasValue(ok)) {
                                if (ok) {
                                    if (!$.hasValue(whenDoSuccess)) {
                                        $.msg("操作成功", 1);
                                    } else {
                                        whenDoSuccess();
                                    }
                                }
                                else {
                                    if (!$.hasValue(whenDoFail)) {
                                        $.msg("操作成功", 1);
                                    } else {
                                        whenDoFail();
                                    }
                                }

                            }
                        }
                        //location.reload();  
                    }, no: function (index) {
                        if (!$.hasValue(whenCancleDo)) {
                            $.msg("操作已取消", 0);
                        } else {
                            whenCancleDo();
                        }
                    }
                });
            }

        },
        sleep: function (millis, fn) {
            var intervalId = setInterval(function () {
                {
                    fn();
                    clearInterval(intervalId);
                }
            }, millis);
        },
        //获取网页
        getsubmiturl: function () {
            //thisURL = document.URL;     // http://localhost:81/Test/1.htm?Did=123
            //thisHREF = document.location.href; // http://localhost:81/Test/1.htm?Did=123
            //thisSLoc = self.location.href;   // http://localhost:81/Test/1.htm?Did=123
            //thisDLoc = document.location;   // http://localhost:81/Test/1.htm?Did=123

            //thisTLoc = top.location.href;   // http://localhost:81/Test/1.htm?Did=123
            //thisPLoc = parent.document.location;// http://localhost:81/Test/1.htm?Did=123
            //thisTHost = top.location.hostname; // localhost
            //thisHost = location.hostname;   // localhost

            //thisU1 = window.location.protocol; // http:
            //thisU2 = window.location.host;   // localhost:81
            //thisU3 = window.location.pathname; // /Test/1.htm
            //debugger 
            var fullUrl = document.URL;
            var hostProtal = window.location.protocol + "//" + window.location.host;
            var relativeUrl = fullUrl.replace(hostProtal, "").
                replace("/pages/form.html?id=", "").
                replace("#", "");
            if (relativeUrl.length > 0 && relativeUrl[0] == '/') {
                relativeUrl = relativeUrl.substring(1);
            }
            return "/" + relativeUrl;
        },
        //获取网页
        geturl: function () {
            //thisURL = document.URL;     // http://localhost:81/Test/1.htm?Did=123
            //thisHREF = document.location.href; // http://localhost:81/Test/1.htm?Did=123
            //thisSLoc = self.location.href;   // http://localhost:81/Test/1.htm?Did=123
            //thisDLoc = document.location;   // http://localhost:81/Test/1.htm?Did=123

            //thisTLoc = top.location.href;   // http://localhost:81/Test/1.htm?Did=123
            //thisPLoc = parent.document.location;// http://localhost:81/Test/1.htm?Did=123
            //thisTHost = top.location.hostname; // localhost
            //thisHost = location.hostname;   // localhost

            //thisU1 = window.location.protocol; // http:
            //thisU2 = window.location.host;   // localhost:81
            //thisU3 = window.location.pathname; // /Test/1.htm
            return window.location.pathname;
        },
        //获取完整网页
        getfullurl: function (encodeUrl, extraParam) {
            //thisURL = document.URL;     // http://localhost:81/Test/1.htm?Did=123
            //thisHREF = document.location.href; // http://localhost:81/Test/1.htm?Did=123
            //thisSLoc = self.location.href;   // http://localhost:81/Test/1.htm?Did=123
            //thisDLoc = document.location;   // http://localhost:81/Test/1.htm?Did=123

            //thisTLoc = top.location.href;   // http://localhost:81/Test/1.htm?Did=123
            //thisPLoc = parent.document.location;// http://localhost:81/Test/1.htm?Did=123
            //thisTHost = top.location.hostname; // localhost
            //thisHost = location.hostname;   // localhost

            //thisU1 = window.location.protocol; // http:
            //thisU2 = window.location.host;   // localhost:81
            //thisU3 = window.location.pathname; // /Test/1.htm
            var src = document.URL;
            src = src.replace(/undefined/g, "empty");
            return $.hasValue(encodeUrl) ? encodeURIComponent(src + extraParam) : src;
        },
        addparam: function (name, value) {
            var currentUrl = window.location.href.split('#')[0];
            if (/\?/g.test(currentUrl)) {
                if (/name=[-\w]{4,25}/g.test(currentUrl)) {
                    currentUrl = currentUrl.replace(/name=[-\w]{4,25}/g, name + "=" + value);
                } else {
                    currentUrl += "&" + name + "=" + value;
                }
            } else {
                currentUrl += "?" + name + "=" + value;
            }
            if (window.location.href.split('#')[1]) {
                window.location.href = currentUrl + '#' + window.location.href.split('#')[1];
            } else {
                window.location.href = currentUrl;
            }
        },
        //用户标识
        uid: function (uid) {
            if (uid == undefined) {//read
                uid = $.cookie("uid");
                if (!$.hasValue(uid)) {
                    try {
                        uid = $.q("uid");
                    } catch (ex) {
                        //清除cookie
                        $.cookie();
                    }
                }
                return uid;
            } else {//write
                $.cookie("uid", uid);
            }
        },
        //用户标识
        user_id: function () {
            return $.cookie("user_id");
        },
        user: function () {
            return { uid: $.cookie("user_id"), name: $.cookie("nick_name"), unit: $.cookie("unit_name") };
        },
        cookie: function (name, value, time) {
            if (time == undefined) {
                time = "d" + _c.security.expire;//默认*天过期
            }
            //设置过期时间
            var str = time;
            var str1 = str.substring(1, str.length) * 1;
            var str2 = str.substring(0, 1);
            if (str2 == "s") {
                time = str1 * 1000;
            } else if (str2 == "h") {
                time = str1 * 60 * 60 * 1000;
            } else if (str2 == "d") {
                time = str1 * 24 * 60 * 60 * 1000;
            }


            if (name == undefined) {
                // debugger 
                //清除
                var keys = document.cookie.match(/[^ =;]+(?=\=)/g);
                if (keys) {
                    for (var i = keys.length; i--;) {
                        $.cookie(keys[i], "", "d0");
                    }
                }
            } else if (value == undefined) {//read
                var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
                if (arr = document.cookie.match(reg))
                    return unescape(arr[2]);
                else
                    return null;
            } else {//write
                var exp = new Date();
                exp.setTime(exp.getTime() + time * 1);
                //debugger
                document.cookie = name + "=" + escape(value) + ";expires=" + exp.toGMTString() + ";path=/;";
            }
        },
        //用户单位
        unitid: function (unitid) {
            if (unitid == undefined) {
                unitid = $.cookie("unitid");
                if (unitid == undefined) {
                    try {
                        unitid = $.q("unitid");
                    } catch (ex) {
                        unitid = "";
                    }

                }
                return unitid;
            } else {
                $.cookie("unitid", unitid);
            }
        },
        parsedate: function (str) {
            try {
                debugger
                // $.log(str)
                if (str.length > 10) {
                    str = str.substring(0, 10);
                }
                var d = new Date(Date.parse(str.replace(/-/g, "/").replace(/T/g, " ")));
                var year = d.getFullYear();
                var month = d.getMonth() + 1;
                var day = d.getDate();
                var dateStr = year + "-" +
                    (month < 10 ? "0" + month : month) + "-" +
                    (day < 10 ? "0" + day : day);
                return dateStr;
            } catch (e) {
                $.warn("日期转换异常:" + e);
                return str;
            }
        },
        parsetime: function (str) {
            try {
                // debugger 
                //$.log(str)
                var d = new Date(Date.parse(str.replace(/-/g, "/").replace(/T/g, " ")));
                var year = d.getFullYear();
                var month = d.getMonth() + 1;
                var day = d.getDate();
                var hour = d.getHours();
                var minute = d.getMinutes();
                var second = d.getSeconds();
                var dateStr = year + "-" +
                    (month < 10 ? "0" + month : month) + "-" +
                    (day < 10 ? "0" + day : day) + " " +
                    (hour < 10 ? "0" + hour : hour) + ":" +
                    (minute < 10 ? "0" + minute : minute);
                //    + ":" +  (second < 10 ? "0" + second : second);
                return dateStr;
            } catch (e) {
                $.warn("时间转换异常:" + e);
                return str;
            }
        },
        //随机码
        random: function () {
            return Guid.random();
        },
        //跳转网页
        go: function (url, waitSecond) {
            if (waitSecond >= 3) {
                waitSecond--;
            }
            if (!$.hasValue(waitSecond)) waitSecond = 0;
            setTimeout(function () {
                if ($.isInt(url)) {
                    history.go(url);
                    return;
                }
                //防止$.q出错
                url = url.replace(/undefined/g, "empty");
                location.href = url;
            }, waitSecond * 1000);
        },
        //转换网页
        url: function (url, isFramWorkUrl) {
            if ($.hasValue(isFramWorkUrl) && isFramWorkUrl === true) {//是框架网址i
                return _c.sever.host_sys + url;
            }
            return (("" + url).length > 4) && (("" + url).toLowerCase().substring(0, 4) === "http") ? url : _c.sever.host + url;

        },
        //转换路由地址
        parseurl: function (url, type) {

            // //debugger
            var result = {};
            result.url = url;
            result.type = type;
            if (url.indexOf("@") > -1) {
                //crud
                result.destUrl = url;
                result.destType = "@";
            }
            else if (url.indexOf("http") > -1) {
                //http
            } else if (url.indexOf("*r") > -1) {
                //report
                result.destUrl = _c.pc.report + "?id=" + url.replace("*r", "");
                result.destType = "r";
            }
            else if (url.indexOf("*d") > -1 || url.indexOf("删除") > -1 || url.toLowerCase().indexOf("delete") > -1) {
                //delete
                result.destUrl = 'confirmDo' + url.replace('*d', '');
                result.destType = "d";
            } else if (url.indexOf("*h") > -1) {
                //html
                result.destUrl = ($.res(url.replace('*h', "")) + ".html?uid=" + $.uid() + "&unitid=" + $.unitid());
                result.destType = "h";
            } else if (url.indexOf("*f") > -1) {
                //form 
                result.destUrl = (_c.pc.form + "?id=" + url.replace('*f', ""));
                result.destType = "f";
            } else {
                //$.log(type)
                if (type != undefined) {
                    switch (type) {
                    case "http":
                        {
                            //http
                        };
                        break;
                    case "h":
                        {
                            //html
                            result.destUrl = ($.res(url.replace('*h', "")) + ".html?uid=" + $.uid());
                            result.destType = "h";
                        };
                        break;
                    case "f":
                        {
                            //form 
                            result.destUrl = (_c.pc.form + "?id=" + url.replace('*f', ""));
                            result.destType = "f";

                        };
                        break;
                    }

                } else {
                    //report
                    result.destUrl = _c.pc.report + "?id=" + url;
                    result.destType = "r";
                }
            }
            return result;//$.trim(url);
        },
        //清除空格
        trimString: function (s, isGlobal) {
            if (s == undefined) {
                return "";
            }
            s = s + "";

            s = s.replace(/(^\s+)|(\s+$)/g, "");
            s = s.replace(/\s/g, "");
            return s;
        },
        //本地资源
        res: function (url) {
            if (url[0] == "/") {//去除第一个/
                url = url.substring(1);
            }

            return g_local_res + url;
        },
        //获取body
        body: function (html) {
            return html.substring(html.indexOf("<body>") + 6, html.indexOf("</body>"));

        },
        //打印日志
        log: function (obj) {
            if (_c.isDebug) {
                console.log(obj);
            }

        },
        //打印警告
        warn: function (obj) {
            if (_c.isDebug) {
                console.warn(obj);
            }
        },
        //刷新界面-如果想整页刷新需要将ajaxOnly设为false
        refresh: function (ajaxOnly) {
            ajaxOnly = $.hasValue(ajaxOnly) ? ajaxOnly : true;

            if ($.geturl().indexOf(_c.pc.report) > -1) {//是报表？
                $(".Query").click();//报表刷新-页面内定义
            } else {
                if (ajaxOnly) {
                    $(".Query").click();
                    $.doFunction("refresh");//局部刷新-页面内定义
                } else {
                    location.reload();
                }

            }

        },
        //判断文件是否存在
        hasfile: function (path, doIfExsit) {
            if (path.indexOf("http") > -1) {
                path = $.url(path);
            }

            $.ajax({
                url: path,
                success: doIfExsit,
                error: function () {
                    $.warn('不存在文件');
                }
            });

        },
        loadBll: function () {

            //加载业务js
            var id = $.geturl();
            var jsurl = id;//页面
            var flagIndex = id.lastIndexOf("/");
            if (flagIndex > -1) {
                var front = id.substring(0, flagIndex);
                //  debugger
                var behind = id.substring(flagIndex);
                jsurl = front + "/bll" + behind.replace(".html", "");
            }
            $.ajax({
                url: jsurl + ".js",
                success: function () {
                    //head.load($.res(jsurl + ".js"));
                },
                error: function () {
                    if (_c.isDebug) {
                        $.warn("未能加载业务js,请检查项目的web目录下是否存在" + (jsurl + ".js"));
                    }
                }
            });
        },
        //动态加载js
        load: function (array) {
            var othis = this;
            for (var i = 0; i < array.length; i++) {
                var oHead = document.getElementsByTagName('head')[0];
                var item = array[i];
                if (item.substring(item.length - 3).toLowerCase() === ".js") {
                    var script = document.createElement("script");
                    script.type = "text/javascript";
                    script.src = item;
                    oHead.appendChild(script);
                    othis.log("js loaded: " + item);
                } else if (item.substring(item.length - 4).toLowerCase() === ".css") {
                    var link = document.createElement("link");
                    link.rel = "stylesheet";
                    link.href = item;
                    oHead.appendChild(link);
                    othis.log("css loaded: " + item);
                } else {
                    othis.warn("你可能引用了一个假的js或css =>" + item);
                }
            }
        },//绑定函数
        bindFunction: function (pre) {
            if (!$.hasValue(pre)) {
                pre = "bt-";
            }
            $('[id^=' + pre + ']').each(function () {
                var target = $(this);
                var id = target.attr("id");
                var href = target.attr("href");
                //删除onclick 和 href等属性
                target.removeAttr("onclick");
                target.removeAttr("href");

                $("#" + id).click(function () {
                    // debugger 
                    $.doFunction(id.replace(pre, ""), href + "','" + target.prop("outerHTML"));
                });
            });
        },//批量请求
        getMemberByUrl: function (url, isSqlQeury) {
            if ($.hasValue(isSqlQeury)) {
                url = "/db/index?cmd=" + url.replace("@", "-");
            }
            if (url.indexOf("&") > -1) {
                url = url.substring(0, url.indexOf("&"));
            }

            return url.replace(/=/g, "_").replace(/&/g, "_").replace(/\?/g, "_").replace(/\//g, "_").replace(/@/g, "_");

        },
        Ajaxs: function (dataUrlArray, doAfterSuccessful, autoToObjectIfSingle, timeOut) {
            // debugger
            //当只有单个成员时，自动转为对象【默认不转】
            autoToObjectIfSingle = $.hasValue(autoToObjectIfSingle) ? autoToObjectIfSingle : false;
            if (!$.hasValue(timeOut)) {//转换为数组
                timeOut = 20;//20秒超时
            }

            if (!$.isArray(dataUrlArray)) {//转换为数组
                dataUrlArray = [dataUrlArray];
            }


            var resultArray = [];
            for (var h = 0; h < dataUrlArray.length; h++) {
                var dataUrl = dataUrlArray[h];
                // debugger
                $.Ajax({
                    url: dataUrl,
                    success: function (data, code, msg, url) {
                        if ($.hasValue(data.ReportId) &&
                            $.hasValue(data.PageIndex) &&
                            $.hasValue(data.PerCount)) {//报表请求
                            $.Ajax({
                                url: "/Report/Report2",
                                data: {
                                    ReportID: data.ReportId,
                                    Params: data.Params,
                                    DbConnStringKey: data.DbConnStringKey,
                                    dataSourceUrl: data.DataSourceUrl,
                                    pageIndex: data.PageIndex,
                                    perCount: data.PerCount
                                },
                                success: function (reportData, code, msg, url) {
                                    var obj = {};//报表请求
                                    obj[data.ReportId] = $.toObject(reportData.FinalJson);
                                    resultArray.push(obj);
                                }
                            });

                        } else {//普通请求
                            if ($.isArray(data)) {//数组成员
                                //  debugger
                                var memberName = $.getMemberByUrl(url);
                                var obj = {};
                                obj[memberName] = data;
                                resultArray.push(obj);
                            } else {//普通成员
                                resultArray.push(data);
                            }

                        }

                    }
                });
            }
            //等待完成
            var frequency = 4;//每秒刷新频率
            var freshCount = timeOut * frequency;//总共刷新次数
            var intervalId = setInterval(function () {
                try {
                    if (resultArray.length < dataUrlArray.length) {
                        $.log("wating..." + (freshCount--));
                        if (freshCount < 0) {
                            //清除定时器
                            clearInterval(intervalId);
                            $.warn("请求超时");
                        }
                    } else {
                        //清除定时器
                        clearInterval(intervalId);
                        //合并结果

                        var finalData = resultArray[0];
                        //debugger
                        //针对只有一个成员进行优化
                        if (resultArray.length === 1) {

                            var theFirstProperOfTheOnlyMember = finalData[$.toArray(finalData).p[0]];
                            if ($.isObject(theFirstProperOfTheOnlyMember) || $.isArray(theFirstProperOfTheOnlyMember)) {
                                finalData = theFirstProperOfTheOnlyMember;
                                //针对只有一个成员的第一个成员进行优化
                                if (autoToObjectIfSingle && $.isArray(theFirstProperOfTheOnlyMember) && theFirstProperOfTheOnlyMember.length === 1) {
                                    //debugger
                                    finalData = theFirstProperOfTheOnlyMember[0];
                                }
                            }
                        } else {
                            for (var j = 1; j < resultArray.length; j++) {
                                $.extend(finalData, resultArray[j]);// Merge object2 into object1
                            }
                        }

                        $.log(finalData);

                        //成功后的回掉函数
                        if ($.hasValue(doAfterSuccessful)) {
                            doAfterSuccessful(finalData);
                        } else {
                            $.warn("Ajaxs(dataUrlArray, doAfterSuccessful)没有传入doAfterSuccessful处理函数");
                        }
                    }
                } catch (ex) {
                    //异常时清除定时器
                    clearInterval(intervalId);
                    $.warn(ex);
                }
            }, 1000.0 / frequency);
        },//doBeforeSubmit返回false时会终止提交
        submitPage: function (url, doAfterSuccess, doBeforeSubmit) {
            var formData = $.vals_m();//用户填写的
            var jsonPageData = $("#page-data").val();//原来的-依赖于bindPage
            var submitData = {};
            //  debugger
            if ($.hasValue(jsonPageData)) {//有旧数据-处理后提交
                submitData = $.toObject(jsonPageData);
                var arr = $.toArray(formData); //转换类型用于遍历
                for (var i = 0; i < arr.p.length; i++) {
                    var p = arr.p[i];
                    var v = arr.v[i];
                    if (submitData[p] != undefined) {
                        submitData[p] = v; //更新值
                    } else {
                        submitData[p] = v; //添加值
                    }
                }
            } else {//无旧数据-直接提交
                submitData = formData;
            }

            //包装数据
            var d = {};
            if ($.hasValue(doBeforeSubmit)) {//预处理
                var dealed = doBeforeSubmit(submitData);
                if ($.hasValue(dealed)) {
                    if (dealed == false) {
                        //当返回false时终止向下执行
                        $.warn("submitPage函数已被doBeforeSubmit参数在提交前强制终止");
                        return;
                    }
                    submitData = dealed;
                } else {
                    $.warn("submitPage: function (url, doAfterSuccess, doBeforeSubmit)的doBeforeSubmit参数没有返回正确的对象");
                }
            }
            d._json = $.toJson(submitData);
            $.log(d);
            $.Ajax({
                url: url,
                data: d,
                success: function (data, code, msg, url) {
                    if ($.hasValue(doAfterSuccess)) {
                        doAfterSuccess(data, code, msg, url);
                    } else {
                        $.dealAjax(data, code, msg, url);
                    }
                }
            });
        },
        bindPage: function (dataUrlArray, tplArray, doBeforeBinded, doAfterBinded) {
            //检查页面是否规范2017-12-24
            $.checkPage();
            // debugger
            $.Ajaxs(dataUrlArray, function (data) {
                // debugger
                //缓存最原始的数据
                $("body").append("<input type='hidden' id='page-data' value='" + $.toJson(data) + "'>");

                //前置处理函数
                if ($.hasValue(doBeforeBinded)) {

                    try { //整体前置处理
                        _data = doBeforeBinded(data);
                    } catch (ex) {
                        $.warn("bindPagede(dataUrlArray,tplArray,doBeforeBinded,doAfterBinded)的doBeforeBinded处理函数执行出错:" + ex);
                    }
                    if (_data == undefined) {//整体前置处理结果检测
                        $.warn("bindPagede(dataUrlArray,tplArray,doBeforeBinded,doAfterBinded)的doBeforeBinded处理函数没有return正确的对象，已忽略前置处理函数并自动选择处理前的成员");
                    } else {
                        data = _data;
                    }
                }

                //普通值
                var arr = $.toArray(data);
                for (var i = 0; i < arr.p.length; i++) {
                    var p = arr.p[i];
                    var v = arr.v[i];
                    //debugger
                    var dom = $("#" + p);//id
                    if (!$.hasValue(dom)) {
                        var domForShow = $("." + p); //class
                        if (!$.hasValue(domForShow)) {
                            var domForSubmit = $("input[name*='" + p + "'],textarea[name*='" + p + "']");//name 只住区input和area
                            $.set_m(domForSubmit, v, p);
                        } else {
                            $.set_m(domForShow, v, p);
                        }
                    } else {
                        $.set_m(dom, v, p);
                    }

                }

                //列表
                if (tplArray == undefined) tplArray = [];
                if (tplArray.length > 0 && $.isString(tplArray[0])) {
                    //判断是否只有一个配置 即一维数组
                    tplArray = [tplArray]; //自动转为二维数组
                }

                for (var k = 0; k < tplArray.length; k++) {
                    var hsaChildTpl = false;
                    var tplObj = tplArray[k];//模板对象
                    var targetId = tplObj[0]; //容器id
                    var tplFnObj = tplObj[1]; //模板函数对象
                    var tplData;
                    //debugger
                    //自动获取成员
                    var autoSelectMember;

                    for (var r = 0; r < dataUrlArray.length; r++) {
                        var currntDataUrlArray = dataUrlArray[r];
                        var key = $.getMemberByUrl(currntDataUrlArray, true);
                        //  debugger
                        if (($.isArray(data[key]) || $.hasValue(data[key])) && k === r) { //第1次尝试
                            autoSelectMember = data[key];
                            $.log("已为" + targetId + "的doBeforeBinded自动匹配数据源成员" + key + "");
                            //$.log("已为"+targetId+"的doBeforeBinded自动选择成员" + key + "数据源：" + currntDataUrlArray);
                            break;
                        } else {
                            //第2次尝试
                            key = $.getMemberByUrl(currntDataUrlArray, true);
                            if (($.isArray(data[key]) || $.hasValue(data[key])) && k === r) {
                                autoSelectMember = data[key];
                                $.log("已为" + targetId + "的doBeforeBinded自动匹配数据源成员" + key + "");
                                //$.log("已为"+targetId+"的doBeforeBinded自动选择成员" + key + "数据源：" + currntDataUrlArray);
                                break;
                            }
                        }
                    }
                    //自动获取成员的结果
                    var dataToDealForDoBeforeBinded;
                    if ($.isArray(autoSelectMember) || $.hasValue(autoSelectMember)) {
                        dataToDealForDoBeforeBinded = autoSelectMember;
                    } else {
                        dataToDealForDoBeforeBinded = data;
                        $.log("为" + targetId + "的doBeforeBinded自动匹配数据源成员失败,已忽略自动匹配并自动选择自动匹配前的成员");
                    }
                    //debugger
                    //自动转数组
                    if (!$.isArray(dataToDealForDoBeforeBinded)) {
                        dataToDealForDoBeforeBinded = [dataToDealForDoBeforeBinded];
                    }
                    //是否存在前置处理函数?
                    if (tplObj.length === 3) {
                        try {//前置处理函数
                            tplData = tplObj[2](dataToDealForDoBeforeBinded);
                        } catch (ex) {
                            $.warn("bindPage(dataUrlArray,tplArray,doBeforeBinded,doAfterBinded)的tplArray参数中的tplArray[" + k + "][3]前置处理函数执行出错:" + ex);
                        }

                        if (tplData == undefined) { //前置处理函数结果检测
                            tplData = dataToDealForDoBeforeBinded;
                            $.warn("bindPage(dataUrlArray,tplArray,doBeforeBinded,doAfterBinded)的tplArray参数中的tplArray[" + k + "][3]前置处理函数没有return正确的对象,已忽略前置处理函数并自动选择处理前的成员");
                        }
                    } else {
                        tplData = dataToDealForDoBeforeBinded;
                    }

                    var tplFn = tplFnObj;//模板函数
                    //  var subTplFn;
                    var parentTplFn;
                    var doBeforeFillParentTpl;
                    if ($.isArray(tplFnObj)) {
                        //包含嵌套
                        hsaChildTpl = true;
                        tplFn = tplFnObj[0];//子模板函数
                        parentTplFn = tplFnObj[1];//父模板函数
                        doBeforeFillParentTpl = tplFnObj[2];//嵌套模板前置处理函数
                    }

                    if (data == undefined) {
                        $.warn(targetId + "的数据源如下为空，请确保填写了正确url");
                        break;
                    }
                    //if (tplData == undefined) {
                    //    tplData = data;
                    //    $.warn("bindPage(dataUrlArray,tplArray,doBeforeBinded,doAfterBinded)的tplArray参数中的tplArray[" + k + "][3]前置处理函数没有return正确的对象");
                    //}
                    $.log(targetId + "的数据源如下:");
                    $.log(tplData);
                    var target = $("#" + targetId);
                    if (target.length === 0) {
                        $.warn("没有找到id=" + targetId + "的容器,请确保传入了正确的容器id");
                        break;
                    }
                    if (!$.isArray(tplData)) {
                        $.warn(targetId + "的模板数据不是Array类型，请确保前置处理函数返回了正确的模板数据");
                        break;
                    }
                    //开始解析模板
                    var tiHtml = "";
                    for (var ti = 0; ti < tplData.length; ti++) {
                        tiHtml += $.qx_tpl(tplData[ti], tplFn);
                    }
                    if (hsaChildTpl) {
                        //处理嵌套
                        var parentTplData;
                        if (!$.hasValue(doBeforeFillParentTpl)) {

                            if ($.isArray(data) && data.length > 0) {
                                $.warn("嵌套父模板数据为空,请确保嵌套模板前置处理函数doBeforeFillParentTpl返回了正确的对象:由于模板数据是数组，已默认选取了第一个元素");
                                parentTplData = data[0];
                            } else {
                                $.warn("嵌套父模板数据为空,请确保嵌套模板前置处理函数doBeforeFillParentTpl返回了正确的对象:由于模板数据不是数组，已默认选取整个对象");
                                parentTplData = data;
                            }
                        } else {
                            parentTplData = doBeforeFillParentTpl(data);
                            if (!$.hasValue(parentTplData)) {
                                if ($.isArray(data) && data.length > 0) {
                                    $.warn("嵌套父模板数据为空,请确保嵌套模板前置处理函数doBeforeFillParentTpl返回了正确的对象:由于模板数据是数组，已默认选取了第一个元素");
                                    parentTplData = data[0];
                                } else {
                                    $.warn("嵌套父模板数据为空,请确保嵌套模板前置处理函数doBeforeFillParentTpl返回了正确的对象:由于模板数据不是数组，已默认选取整个对象");
                                    parentTplData = data;
                                }
                            }
                        }
                        parentTplData["sub-tpl"] = tiHtml;
                        //debugger
                        $.log(targetId + "的嵌套父模板数据源如下:");
                        $.log(parentTplData);
                        tiHtml = $.qx_tpl(parentTplData, parentTplFn);
                    }
                    target.html(tiHtml);
                }
                if ($.hasValue(doAfterBinded)) {
                    doAfterBinded(data);
                }
            }, true);


        },//联动下拉
        bindSelect: function (bindedId, targetId, url, isFirst, doAfterBinded) {

            var src = $("#" + bindedId);

            //debugger
            src.change(function () {
                //取出旧值
                var oldBindedValue = $.val(bindedId, 204);
                var oldTargetValue = $.val(targetId, 204);
                //注意是大写的Ajax
                $.Ajax({
                    url: url,
                    //204代表select下拉框控件
                    data: { id: oldBindedValue, name: oldBindedValue },
                    //注意success中四个参数的顺序
                    success: function (data, code, msg, url) {
                        var target = $("#" + targetId);
                        target.html($.getOptionHtml(data, oldTargetValue));
                        target.change();
                        //写回旧值
                        $.set(bindedId, 204, oldBindedValue);
                        $.set(targetId, 204, oldTargetValue);
                        $.refresh();
                        if ($.hasValue(doAfterBinded)) {
                            doAfterBinded(src, target);
                        }
                        //待优化  提交次数过多	
                    }
                });
            });
            if ($.hasValue(isFirst) && isFirst) {
                $("#" + bindedId).change();
            }
        },
        //根据配置生成selectHtml
        getOptionHtml: function (data, value, addDefaultOption) {
            if (!$.hasValue(addDefaultOption)) {
                addDefaultOption = false;
            }
            if (typeof data == "string") {
                if (data.length <= 0) {
                    return "";
                }//转换为对象
                data = $.toObject(data);
            }
            var optionHtml = [];

            if (addDefaultOption) {
                optionHtml.push('<option value=";">全部</option>');
            }

            for (var i = 0; i < data.length; i++) {
                //debugger
                var _v = $.hasValue(data[i].value) ? data[i].value : data[i].Value;
                var _t = $.hasValue(data[i].text) ? data[i].text : data[i].Text;
                // debugger
                optionHtml.push('<option ' + (value == _v ? 'selected="selected"' : '') + ' value="' + _v + '">' + _t + '</option>');
            }
            return optionHtml.join('');
        },
        fillTable: function (tableId, url) {
            debugger
            if (!$.hasValue(url))
                return;
            //注意是大写的Ajax
            $.Ajax({
                url: url,
                success: function (data, code, msg, url) {
                    $("#" + tableId + "-content").html(table(data).html);
                }
            });
        },

        fillSelect: function (selectId, urlOrSelectItems, value, addDefaultOption) {
            /*	if ($.isArray(selectId)&&!$.isString(selectId)) {//兼容二维数组
                    for (var i = 0; i < selectId.length; i++) {
                        var item = selectId[i];
                        //防止数组越界
                        $.fillSelect(item[0],item[1],item[2],item[3]);
                    }
                }*/
            // debugger 
            if (!$.hasValue(urlOrSelectItems))
                return;
            //传入的是url
            if ($.isString(urlOrSelectItems)) {
                var url = urlOrSelectItems;
                //注意是大写的Ajax
                $.Ajax({
                    url: url,
                    success: function (data, code, msg, url) {
                        var severValue = $("#" + selectId).data("value"); //服务器值优先
                        $("#" + selectId).html($.getOptionHtml(data, $.hasValue(severValue) ? severValue : value, addDefaultOption));
                    }
                });
            } else {//传入的是数据
                var items = urlOrSelectItems;
                $("#" + selectId).html($.getOptionHtml(items, value));
            }


        },
        //当报表搜索框加载完成后的回调
        //searchReady: function (Fn) {
        //document.write("<script>"+Fn.toString()+"</script>");
        //},
        //判断是否是调试页面
        isDebugPage: function () {
            return document.URL.indexOf("/pages/form.html?id=/core/test/all") > -1 ||
                document.URL.indexOf("/pages/form.html?id=/debug/") > -1;
        },
        //判断是否有值
        hasValue: function (value) {
            if (typeof (value) == "undefined")
                return false;
            if (typeof (value) == "function")
                return true;
            value = $.isString(value) ? $.trim(value).replace(_c.root, "") : value;
            return (value === "；" || value === ";" || value === "empty" || value === "#" || value === null || value == "undefined" || value === '' || value.length === 0) ? false : true;
        },
        //判断是否有值
        checkValue: function (obj, valueIfEmpty) {
            if (!$.hasValue(obj))
                obj = valueIfEmpty;
            return obj;
        },
        //判断是否是函数
        isFunction: function (obj) {
            try {
                if (typeof obj === "function") { //是函数    其中 FunName 为函数名称
                    return true;
                    // alert("is function");
                } else { //不是函数
                    // alert("not is function");
                    return false;
                }
            } catch (e) { }
            return false;
        },
        //判断函数是否存在
        hasFunction: function (funcName) {
            try {
                if (typeof (eval(funcName)) == "function") {
                    return true;
                }
            } catch (e) { }
            return false;
        },
        doFunction: function (funcName, param) {

            if ($.hasFunction(funcName)) {
                try {
                    eval(funcName + "(" + (param == undefined ? "" : "'" + param.replace(/[\r\n]/g, "") + "'") + ")");
                } catch (ex) {
                    $.log(ex);
                    $.alert(funcName + "()函数执行出错,打开控制台查看详细信息:<br/>" + ex.message);
                }
            } else {
                $.warn("在本页面中未找到" + funcName + "函数:");
            }
        },
        //对象转数组
        toArray: function (obj) {
            var title = [];
            var bodyRow = [];
            for (var p in obj) {//遍历对象属性和值
                if (typeof (obj[p]) != "function") {
                    title.push(p);
                    bodyRow.push(obj[p]);
                } else {
                    //item[p]();
                }
            }
            return { p: title, v: bodyRow };
        },//判断变量是否为数组
        isArray: function (o) {
            return Object.prototype.toString.call(o) === '[object Array]' && !$.isObject(o);
        },//判断变量是否为数组
        isObject: function (o) {
            if (o instanceof Array) {
                return false;//'Array'
            } else if (o instanceof Object) {
                return true;//'Object';
            } else {
                return false;//'param is no object type';
            }

        },
        isArray2: function (o) {
            return ($.isArray(o) && o.length > 0 && $.isArray(o[0]));
        }, //判断变量是否为字符串
        isString: function (str) {
            return (typeof str == 'string') && str.constructor == String;
        },
        isInt: function (x) {

            try {
                var t = Number(x);
                return (typeof t === 'number') && (x % 1 === 0);
            } catch (ex) {
                return false;
            }


        },
        //编辑器
        editor: function (id) {
            head.ready(function () {
                KindEditor.ready(function (K) {
                    var options = {
                        allowFileManager: true,
                        cssPath: '/Include/KindEditor/plugins/code/prettify.css',
                        imageUploadJson: '/Include/KindEditor/asp.net/upload_json.ashx',
                        fileManagerJson: '/Include/KindEditor/asp.net/file_manager_json.ashx',
                        width: "98%", //编辑器的宽度为70%
                        height: "400px", //编辑器的高度为100px
                        filterMode: false, //不会过滤HTML代码
                        resizeMode: 1, //编辑器只能调整高度
                        afterBlur: function () { this.sync() }, //假如没有这一句,获取到的id为content的值空白
                        afterCreate: function () {
                            $.log('KindEditor[' + id + ']ok');
                            //var self = this;
                            //K.ctrl(document, 13, function () {
                            //    self.sync();
                            //    K('form[name=example]')[0].submit();
                            //});
                            //K.ctrl(self.edit.doc, 13, function () {
                            //    self.sync();
                            //    K('form[name=example]')[0].submit();
                            //});
                        }
                    };
                    var editor = K.create('#' + id, options);
                    prettyPrint();
                });
            });
        },
        //设为子页面
        setSubPage: function (id) {
            var script = document.createElement("script");
            script.type = "text/javascript";
            script.innerText = "var pymChild = new pym.Child(); ";
            document.body.appendChild(script);
        },

        //获取地址栏参数
        q: function (name) {
            // //debugger 
            var currntUrl = $.getfullurl();
            //特殊处理
            if (currntUrl.indexOf(_c.pc.form) > 0 || currntUrl.indexOf(_c.pc.report) > 0) {
                return currntUrl.substr(currntUrl.indexOf("?id=") + 4);
            }
            //-------------
            var data = {};
            var aPairs, aTmp;
            var queryString = new String(window.location.search);
            queryString = queryString.substr(1, queryString.length); //remove   "?"     
            aPairs = queryString.split("&");
            for (var i = 0; i < aPairs.length; i++) {
                aTmp = aPairs[i].split("=");
                data[aTmp[0]] = aTmp[1];
            }
            return data[name];
        },
        qall: function (s) {
            var url = s.replace(/\s/g, ""); //获取url中"?"符后的字串 
            var theRequest = new Object();
            if (url.indexOf("?") != -1) {
                var str = url.substr(1);
                strs = str.split("&");
                for (var i = 0; i < strs.length; i++) {
                    theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
                }
            }
            return theRequest;
        }

    });
});

//特殊页面处理
window.onload = function () {
    $.log(_c);
    //debugger 
    var uid = $.uid();
    var unitid = $.unitid();
    //处理自动登陆
    if (_c.isAutoLoginPage()) {
        // debugger
        $("body").html("");
        $.loading();
        $.msg("请稍后...");
        autoLogin($.q("userId"), $.q("roleString"));
        return;
    }
    if (_c.isLoginPage()) {
        debugger
        if ($.hasValue(_c.login_third)) {
            
            //第三方登陆
            $("body").html("");
            $.loading();
            if (_c.login_third == "we7") {
                $("body").html("");
                $.alert("页面会话超时，请关闭页面后重新进入！")
            } else {
                $.msg("请稍后...");
                window.location.replace(_c.login_third);
            }
           
            return;
        }
        $('#login').click(function () {
            var userid = $('#uid').val();
            var psw = $('#psw').val();
            login(userid, psw);
        });
        return;
    }
    //登陆验证
    if (_c.isVisitor()) {
        $.warn("请登陆");
        if ($.hasValue(_c.login_third)) {
            if (_c.login_third == "we7") {
                $("body").html("");
                $.alert("页面会话超时，请关闭页面后重新进入！")
            } else {
                $.msg("请稍后...");
                $.go(_c.login_third + "?returnUrl=" + _c.login_auto);
            }
           
        } else {
            $.go(_c.login);
        }
        return;
    }
    //登陆成功后
    $("#user_id").text($.cookie('user_id'));
    $("#nick_name").val($.cookie('nick_name')); $(".nick_name").text($.cookie('nick_name'));
    $("#unit_name").text($.cookie('unit_name'));//显示用户id//显示用户id
    $(".fa-sign-out").click(function () {//设置退出登录
        $.cookie();
        $.msg("已退出登录");
        $.go(_c.pc.login);
    });

    if (_c.isApp) {
        $.loadBll();//加载业务js
        $.bindFunction();//自动绑定页面参数
        $(".back").click(function () { $.go(-1) });//后退按钮

    } else {
        //需要拉取工作流待办
        InitWorkFlow();
        //报表初始化
        if ($.geturl() === _c.pc.report) {
            //id为报表的数据api地址
            qx.grid.InitReport($.q("id"));
        }
        //表单初始化
        else if ($.geturl() === _c.pc.form) {
            //sdebugger 
            //id为js路径或自定义页面路径
            InitForm($.q("id"));
        }
        //首页初始化
        else if ($.geturl() === _c.pc.homepage) {
            menuStageTwo(uid);
        }
        else {
        }
    }



};

//扩展String
String.prototype.append = function (str, arr) {
    if (!$.hasValue(arr)) {
        arr = [];
    }
    return this + $.replace(str, arr);
}
String.prototype.jn =
    String.prototype.join = function (another, colnumnOrTable) {//如何判断传入的是列名还是表名？
        if (!$.hasValue(colnumnOrTable)) {//自动补全目标表的列名 （和本库相关，后端框架会自动补全库名）
            colnumnOrTable = another.split('.')[1];
        }///else if (colnumnOrTable.indexOf(".") === -1) {//自动补全目标表的列名（和本库无关，colnumn传入的是目标表名）
        //    colnumnOrTable = colnumnOrTable + "." + another.split('.')[1];
        //}
        return this.append("&search.join:" + another + "=" + colnumnOrTable);
    }
String.prototype.in = function (colnumn, arr) {
    return this.append("&search.in:" + colnumn + "=('" + arr.join("','") + "')");
}
String.prototype.eq =
    String.prototype.equal = function (colnumn, value) {
        return this.append("&search.equal:" + colnumn + "=" + value);
    }
String.prototype.neq =
    String.prototype.notequal = function (colnumn, value) {
        return this.append("&search.notequal:" + colnumn + "=" + value);
    }
String.prototype.bg =
    String.prototype.biger = function (colnumn, value) {
        return this.append("&search.biger:" + colnumn + "=" + value);
    }
String.prototype.be =
    String.prototype.bigerequal = function (colnumn, value) {
        return this.append("&search.bigerequal:" + colnumn + "=" + value);
    }
String.prototype.ls =
    String.prototype.less = function (colnumn, value) {
        return this.append("&search.less:" + colnumn + "=" + value);
    }
String.prototype.le =
    String.prototype.lessequal = function (colnumn, value) {
        return this.append("&search.lessequal:" + colnumn + "=" + value);
    }
String.prototype.lk =
    String.prototype.like = function (colnumn, value) {

        if (!$.hasValue(value)) {//传入条件值为空等价于没有like条件
            return this;
        }
        return this.append("&search.like:" + colnumn + "=" + value, '\'');
    }
String.prototype.gp =
    String.prototype.group = function (colnumn, value) {
        if (!$.hasValue(value)) {
            value = "_auto";
        }
        return this.append("&search.groupby:" + colnumn + "=" + value);
    }
String.prototype.ob =
    String.prototype.orderby = function (colnumn, value) {
        if (!$.hasValue(value)) {
            value = "+";
        }
        return this.append("&search.orderby:" + colnumn + "=" + value);
    }

String.prototype.query = function (doAfterSuccess, autoToObject) {
    var url = this;
    $.Ajaxs(url, function (data) {
            // debugger
            var memberName = $.getMemberByUrl(url, true);
            var member = data[memberName];
            // debugger
            if (!$.hasValue(member)) {
                member = $.hasValue(data) ? data : [];
            }
            doAfterSuccess(member);
        }, autoToObject
    );
}
String.prototype.submit = function (data, doAfterSuccess) {
    // debugger
    $.Ajax({
            url: this,
            data: data,
            success: function (data, code, msg, url) {
                doAfterSuccess(data, code, msg, url);
            }
        }
    );
}
String.prototype.excute = function (doAfterSuccessForEach) {
    this.query(function (data) {
        for (var i = 0; i < data.length; i++) {
            var item = data[i];
            doAfterSuccessForEach(item, i, data.length);
        }
    });
}
String.prototype.format = function (args) {
    // debugger
    if (arguments.length > 0) {
        var result = this;
        var reg;
        if (arguments.length == 1 && typeof (args) == "object") {
            for (var key in args) {
                if (!$.isInt(key)) {
                    reg = new RegExp("({" + key + "})", "g");
                    result = result.replace(reg, args[key]);
                }
            }
        } else {
            for (var i = 0; i < arguments.length; i++) {
                if (arguments[i] == undefined) { return ""; } else {
                    reg = new RegExp("({[" + i + "]})", "g");
                    result = result.replace(reg, arguments[i]);
                }
            }
        } return result;
    } else { return this; }
}
//扩展string.tpl
/*{}.prototype.tpl = function (tplFn) {
    return getTpl(tplFn).format(this);
}*/
//扩展Array
//寻找重复元素
Array.prototype.getdistinct = function () {
    // 遍历arr,把元素分别放入tmp数组(不存在才放)
    var tmp = new Array();
    var tmp2 = new Array();
    for (var i in this) {
        //该元素在tmp内部不存在才允许追加
        if (tmp.indexOf(this[i]) == -1) {
            tmp.push(this[i]);
        } else {
            {
                if (tmp2.indexOf(this[i]) == -1) {
                    tmp2.push(this[i]);
                }
            }
        }
    }
    return tmp2;
}
//去除重复元素
Array.prototype.distinct = function () {
    // 遍历arr,把元素分别放入tmp数组(不存在才放)
    var tmp = new Array();
    for (var i in this) {
        //该元素在tmp内部不存在才允许追加
        if (tmp.indexOf(this[i]) == -1) {
            tmp.push(this[i]);
        }
    }
    return tmp;
}
function back() {
    history.go(-1);
}

function checkForm(fn) {
    if (event.keyCode == 13) {
        fn();
    }
}
var HtmlUtil = {
    /*1.用浏览器内部转换器实现html转码*/
    htmlEncode: function (html) {
        //1.首先动态创建一个容器标签元素，如DIV
        var temp = document.createElement("div");
        //2.然后将要转换的字符串设置为这个元素的innerText(ie支持)或者textContent(火狐，google支持)
        (temp.textContent != undefined) ? (temp.textContent = html) : (temp.innerText = html);
        //3.最后返回这个元素的innerHTML，即得到经过HTML编码转换的字符串了
        var output = temp.innerHTML;
        temp = null;
        return output;
    },
    /*2.用浏览器内部转换器实现html解码*/
    htmlDecode: function (text) {
        //1.首先动态创建一个容器标签元素，如DIV
        var temp = document.createElement("div");
        //2.然后将要转换的字符串设置为这个元素的innerHTML(ie，火狐，google都支持)
        temp.innerHTML = text;
        //3.最后返回这个元素的innerText(ie支持)或者textContent(火狐，google支持)，即得到经过HTML解码的字符串了。
        var output = temp.innerText || temp.textContent;
        temp = null;
        return output;
    },
    /*3.用正则表达式实现html转码*/
    htmlEncodeByRegExp: function (str) {
        var s = "";
        if (!$.hasValue(str)) return "";
        s = ("" + str).replace(/&/g, "&amp;");
        s = s.replace(/</g, "&lt;");
        s = s.replace(/>/g, "&gt;");
        s = s.replace(/ /g, "&nbsp;");
        s = s.replace(/\'/g, "&#39;");
        s = s.replace(/\"/g, "&quot;");
        s = s.replace(/\r/g, "&nbsp;");
        s = s.replace(/\n/g, "#br");
        return s;
    },
    /*4.用正则表达式实现html解码*/
    htmlDecodeByRegExp: function (str) {
        var s = "";
        if (!$.hasValue(str)) return "";
        s = ("" + str).replace(/&amp;/g, "&");
        s = s.replace(/&lt;/g, "<");
        s = s.replace(/&gt;/g, ">");
        s = s.replace(/&nbsp;/g, " ");
        s = s.replace(/&#39;/g, "\'");
        s = s.replace(/&quot;/g, "\"");
        s = s.replace(/&nbsp;/g, "\r");
        s = s.replace(/#br/g, "\n");
        return s;
    }
};





//生成 Guid 
function Guid(g) {
    var arr = new Array(); /*存放32位数值的数组*/    if (typeof (g) == "string") { /*如果构造函数的参数为字符串*/        InitByString(arr, g); } else { InitByOther(arr); } /*返回一个值,该值指示 Guid 的两个实例是否表示同一个值。*/    this.Equals = function (o) { if (o && o.IsGuid) { return this.ToString() == o.ToString(); } else { return false; } }; /*Guid对象的标记*/    this.IsGuid = function () { }; /*返回 Guid 类的此实例值的 String 表示形式。*/    this.ToString = function (format) { if (typeof (format) == "string") { if (format == "N" || format == "D" || format == "B" || format == "P") { return ToStringWithFormat(arr, format); } else { return ToStringWithFormat(arr, "D"); } } else { return ToStringWithFormat(arr, "D"); } }; /*由字符串加载*/    function InitByString(arr, g) { g = g.replace(/\{|\(|\)|\}|-/g, ""); g = g.toLowerCase(); if (g.length != 32 || g.search(/[^0-9,a-f]/i) != -1) { InitByOther(arr); } else { for (var i = 0; i < g.length; i++) { arr.push(g[i]); } } } /*由其他类型加载*/    function InitByOther(arr) { var i = 32; while (i--) { arr.push("0"); } }
    /*
        根据所提供的格式说明符,返回此 Guid 实例值的 String 表示形式。
        N  32 位： xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        D  由连字符分隔的 32 位数字 xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
        B  括在大括号中、由连字符分隔的 32 位数字：{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}
        P  括在圆括号中、由连字符分隔的 32 位数字：(xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)
        */
} function ToStringWithFormat(arr, format) { switch (format) { case "N": return arr.toString().replace(/,/g, ""); case "D": var str = arr.slice(0, 8) + "-" + arr.slice(8, 12) + "-" + arr.slice(12, 16) + "-" + arr.slice(16, 20) + "-" + arr.slice(20, 32); str = str.replace(/,/g, ""); return str; case "B": var str = ToStringWithFormat(arr, "D"); str = "{" + str + "}"; return str; case "P": var str = ToStringWithFormat(arr, "D"); str = "(" + str + ")"; return str; default: return new Guid(); } } Guid.Empty = new Guid();/*Guid 类的默认实例,其值保证均为零。*/Guid.NewGuid = function () { var g = ""; var i = 32; while (i--) { g += Math.floor(Math.random() * 16.0).toString(16); } return new Guid(g); }; Guid.random = function () { var g = ""; var i = 32; while (i--) { g += Math.floor(Math.random() * 16.0).toString(16); } return new Guid(g).ToString(); }


//获取时间
function getNowFormatTime(onlydate) {

    var date = new Date();
    var seperator1 = "-";
    var seperator2 = ":";
    var strMonth = date.getMonth() + 1;
    var strDay = date.getDate();
    if (strMonth >= 1 && strMonth <= 9) {
        strMonth = "0" + strMonth;
    }
    if (strDay >= 0 && strDay <= 9) {
        strDay = "0" + strDay;
    }
    if (onlydate != undefined) {
        return date.getFullYear() + seperator1 + strMonth + seperator1 + strDay;

    } else {
        var strHour = date.getHours();
        var strMinute = date.getMinutes();
        var strSeconds = date.getSeconds();
        if (strHour >= 1 && strHour <= 9) {
            strHour = "0" + strHour;
        }
        if (strMinute >= 1 && strMinute <= 9) {
            strMinute = "0" + strMinute;
        }
        if (strSeconds >= 1 && strSeconds <= 9) {
            strSeconds = "0" + strSeconds;
        }
        return date.getFullYear() + seperator1 + strMonth + seperator1 + strDay
            + " " + strHour + seperator2 + strMinute
            + seperator2 + strSeconds;
    }

}
//基于bootstrap的Color
var Color = function () { }; Color.red = "danger"; Color.blue = "primary"; Color.green = "success"; Color.orange = "warning"; Color.white = "default";

//检查变量
function check(value, valueIfUndefined) {
    return ($.hasValue(value) ? value :
        (valueIfUndefined == undefined) ? 4 : valueIfUndefined);
}

//获取代码块模板
function getTpl(fn) {
    var startIndex = 0;
    var endIndex = 0;
    var temp = fn.toString().split('\n');
    for (var i = 0; i < temp.length; i++) {
        if (temp[i].indexOf("/*") > -1) {
            if (startIndex === 0) {
                startIndex = i;//第一行
                break;
            }
        }
    }
    for (var j = temp.length - 1; j >= 0; j--) {
        if (temp[j].indexOf("*/") > -1) {
            if (endIndex === 0) {
                endIndex = j;//最后一行
                break;
            }
        }
    }

    return temp.slice(startIndex + 1, endIndex).join('\n') + '\n';
    //fn.toString().split('\n').slice(1, -1).join('\n') + '\n';
    //return fn.toString().replace('function () {/*', '').replace('*/', '');
}



function loginRedirect(units, index) {
    //debugger
    //$.msg('请稍后...', 0);
    // $.msg('即将以' + units.name[index] + "的身份进入系统", 0);
    $.cookie('unit_name', units.name[index]);
    $.unitid(units.id[index]);//加密版


    if ($.hasValue(_c.bind)) {//跳转到绑定地址
        $.go(_c.bind);
        return;
    }

    setTimeout(function () {
        window.location.replace(_c.homepage);
    }, 10);
}
function chooseOrgToLogin(units) {
    //debugger
    if (units.id.length > 1) {
        //选择机构
        try {
            layer.confirm('请选择以什么机构进入系统？', {
                btn: units.name
            }, function () {
                loginRedirect(units, 0);
            }, function () {
                loginRedirect(units, 1);
            }, function () {
                loginRedirect(units, 2);
            }, function () {
                loginRedirect(units, 3);
            }, function () {
                loginRedirect(units, 4);
            });
        } catch (ex) {
            $.msg("已随机选择一个机构");
            setTimeout(function () {
                loginRedirect(units, 0);
            }, 1000);

            //layer.open({
            //    content: '请选择以什么机构进入系统-暂不支持移动端多机构选择？'
            //    , btn: units.name
            //    , yes: function (index) {
            //        loginRedirect(units, 0);
            //    }
            //});
        }

    } else if (units.id.length == 1) {
        loginRedirect(units, 0);
    } else {
        $.alert("未分配组织机构,无法登陆！", 5);
    }
}

function loginSuccess(uid) {
    // debugger
    $.uid(uid); //存储加密版uid
    //根据uid获取用户信息
    $.Ajax({
        url: "/open/userInfo",
        success: function (data, code) {
            if (code === 1) {
                $.cookie('nick_name', data.nick_name);//存储用户名称
                $.cookie('user_id', data.user_id);//存储未加密uid
                var units = $.toObject(data.units);
                chooseOrgToLogin(units);//选择组织机构
            } else {
                $.warn(data);
                $.alert("获取用户信息失败！", 5);
            }
        }
    });
}
function login(userId, psw) {
    var index = $.loading();
    $.ajax({
        url: $.url("/Open/login", true),
        data: { userId: userId, psw: psw },
        success: function (result) {
            $.loaded(index);
            var code = result.code;
            var data = $.toObject(result.jsonData);
            if (code === 1) {
                //登陆成功-获取加密后的uid
                loginSuccess(data.uid);
            } else {
                $.alert("用户名或密码错误！", 5);
            }
        }, error: function (xmlHttpRequest, textStatus, errorThrown) {
            $.loaded(index);
            if (_c.isDebug) {
                $.alert("服务器连接失败,请检查服务器是否正常运转！", 2);
            } else {
                $.alert("网络连接失败,请检查您的网络连接状态！", 5);
            }


        }
    });
}

function autoLogin(userId, roleString) {
    if (!$.hasValue(userId)) {
        $.alert("身份已过期，请重新登陆！", 5);
        $.go(_c.root + "/index.html", 3);
        return;
    }
    if (!$.hasValue(roleString)) {
        roleString = "";
    }
    var index = $.loading();
    $.ajax({
        url: $.url("/Open/autoLogin?userId=" + userId + "&roleString=" + roleString, true),
        success: function (result) {
            $.loaded(index);
            var code = result.code;
            var data = $.toObject(result.jsonData);
            if (code === 1) {
                //登陆成功-获取加密后的uid
                loginSuccess(data.uid);
            } else {
                $.alert("身份已过期，请重新登陆！", 5);
                $.go(_c.root + "/index.html", 3);
            }
        }, error: function (xmlHttpRequest, textStatus, errorThrown) {
            $.loaded(index);
            if (_c.isDebug) {
                $.alert("服务器连接失败,请检查服务器是否正常运转！", 2);
            } else {
                $.alert("网络连接失败,请检查您的网络连接状态！", 5);
            }


        }
    });
}

function confirmPay(totalFee) {
    $.loading();
    $.go(g_pay_wx + "?uid=" + $.uid() + "&total_fee=" + totalFee + "&return_url=" + g_pay_result_wx);
}
function YibanLogin() {

    $.go(_c.sever.host + "/Oauth2/YiBan?returnUrl=" +localUrl(_c.pc.login_3rd_result));
}

function hide_m(objArray) {
    if (!$.isArray2(objArray)) {
        objArray = [objArray];
    }
    for (var i = 0; i < objArray.length; i++) {
        var arr = objArray[i];
        var name = arr[0];
        var value = arr.length > 1 ? arr[1] : "";
        $("body").append(' <input class="hidden" name="' + name + '" type="text" value="' + value + '">');
    }
}