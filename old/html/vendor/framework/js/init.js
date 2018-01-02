/// <reference path="../../form-validation/js/framework/bootstrap.min.js" />
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
"https://cdn.bootcss.com/bootstrap-validator/0.5.3/css/bootstrapValidator.min.css",
//datatables-plugins
srcurl("datatables-plugins/dataTables.bootstrap.css"),
//datatables-responsive
srcurl("datatables-responsive/dataTables.responsive.css"),

srcurl("layui/1.0.9/css/layui.css"),
srcurl("framework/css/framwork.css"),

//fileUpload
//srcurl("fileUpload/file/css/style.css"),
srcurl("fileUpload/file/css/jquery.fileupload.css"),
srcurl("fileUpload/file/css/blueimp-gallery.min.css"),
srcurl("fileUpload/file/css/jquery.fileupload.css"),
srcurl("fileUpload/file/css/jquery.fileupload-ui.css"),


//framework-config
{ "config": srcurl("framework/js/config.js") },
{ "config-pc": srcurl("framework/js/config-pc.js") },
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
{ "form-validation": "https://cdn.bootcss.com/bootstrap-validator/0.5.3/js/bootstrapValidator.min.js" },
{ "form-validation-bootstrap": "https://cdn.bootcss.com/bootstrap-validator/0.5.3/js/bootstrapValidator.min.js" },
{ "form-validation-zh": "https://cdn.bootcss.com/bootstrap-validator/0.5.3/js/language/zh_CN.min.js" },
//bootstrap-switch 
{ "bootstrap-switch": srcurl("bootstrap-switch/static/js/bootstrap-switch.min.js") },
//ueditor
{ "ueditor-config": srcurl("ueditor/ueditor.config.js") },
{ "ueditor": srcurl("ueditor/ueditor.all.min.js") },
{ "ueditor-zh": srcurl("ueditor/lang/zh-cn/zh-cn.js") },
//bootstrap-daterangepicker
{ "bootstrap-daterangepicker": srcurl("bootstrap-daterangepicker/daterangepicker.js")},
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
{ "jquery-pagination": srcurl("framework/js/extendPagination.js") },
{ "tools": srcurl("framework/js/tools.js")},
{ "menu-loader":srcurl("framework/js/menu-loader.js")},
{ "framwork-loader": srcurl("framework/js/framwork-loader.js") },
{ "importxls-acc": srcurl("importxls/js/excel.acc.js") },
{ "table-loader": srcurl("framework/js/table-loader.js") },
{ "form-tool": srcurl("framework/js/form-tool.js") }
//{ "form-loader": "/vendor/framework/js/form-loader.js")},


],

function () {
   
});

//加载layui
head.ready(["layui"], function () {
     layui.config({
        dir: srcurl("layui/1.0.9/") //layui.js 所在路径（注意,如果是script单独引入layui.js,无需设定该参数。）,一般情况下可以无视
     , version: false //一般用于更新模块缓存,默认不开启。设为true即让浏览器不缓存。也可以设为一个固定的值,如：201610
     , debug: false //用于开启调试模式,默认false,如果设为true,则JS模块的节点会保留在页面
     , base: srcurl("layui/1.0.9/lay/modules/") //设定扩展的Layui模块的所在目录,一般用于外部模块扩展
    }).use("index");
});

//特殊页面处理
window.onload = function () {
    //debugger 
    var uid = $.uid();
    var unitid = $.unitid();
    //登陆验证
    if ((!$.hasValue(unitid) || !$.hasValue(uid) )&& ($.geturl() !== g_login)) {
        $.warn("请登陆");
        $.go(g_login);
        return;
    }
    //登陆初始化
    if ($.geturl() === g_login) {
        $('#login').click(function() {
            var userid = $('#uid').val();
            var psw = $('#psw').val();
            login(userid, psw);
        });
    }
    else
    {
        //登陆成功后
        $("#user_id").text($.cookie('user_id'));
        $("#nick_name").text($.cookie('nick_name'));
        $("#unit_name").text($.cookie('unit_name'));//显示用户id//显示用户id
        $(".fa-sign-out").click(function () {//设置退出登录
            $.cookie();
            $.msg("已退出登录");
            $.go(g_login);
        });
        //需要拉取工作流待办
        InitWorkFlow();
        //报表初始化
        if ($.geturl() === g_report) {
            //id为报表的数据api地址
 
            InitReport($.q("id"));
        }
        //表单初始化
        else if ($.geturl() === g_form) {
		//sdebugger 
            //id为js路径或自定义页面路径
            InitForm($.q("id"));
        }

        //首页初始化
        else if ($.geturl() === g_homepage) {
            //加载菜单
            if (g_leftmenu) {
                menuStageTwo(uid);
            }
            if (g_topmenu) {
                topMenuStageTwo(uid);
            }
        }
        else {

        }
    }
   
   };     





