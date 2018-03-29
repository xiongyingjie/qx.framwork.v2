var g_windows = [];


function InitPopup(positonInfo, selector) {
	
	  if (selector == undefined) {
        selector = '.qx-popup.operate';
       }

    InitMenuEvent(selector, "", positonInfo);
}


function InitMenuEvent(selector, type, positonInfo)
{
   // debugger
    //设置默认选择器
    if (selector == undefined) {
    	//selector = '.qx-menu';
        selector = '#wrapper .qx-menu';
    }
    if (type == undefined) {
        type = 'r';
    }
    if (positonInfo == undefined) {//设置默认值
        positonInfo = {
            x: 250,
            y: 45+5,
            width: ($(window).width() - 250) + "px",
            height: ($(window).height()  - 45) + "px"
        };
    }
    if ($.hasValue(positonInfo.center) && $.hasValue(positonInfo.width)) {
        positonInfo.x = ($(window).width()- positonInfo.width) / 2.0 ;
        positonInfo.y = 100;
    }

  //  debugger
    //定义弹窗事件
    var active = {
        setTop: function () {
            var that = $(this);
            var url = $.parseurl(that.attr('data-url')).destUrl;
            var id = $.random();
            var title = that.data('title') ? that.data('title') : '加载中...';
            //----计算弹窗数据
            var topHeight = $.hasValue(positonInfo.y) ? positonInfo.y : 0;
            var leftWidth = $.hasValue(positonInfo.x) ? positonInfo.x : 0;
            var formWidth = $.hasValue(positonInfo.width) ? ($.isString(positonInfo.width) ? positonInfo.width : positonInfo.width+"px") : "100%";
            var formHeight = $.hasValue(positonInfo.height) ? ($.isString(positonInfo.height) ? positonInfo.height : positonInfo.height+"px") : "100%";
            var formPositionX = topHeight;
            var formPositionY = leftWidth + 1;
            //----计算弹窗数据

            //多窗口模式,层叠置顶
            layer.open({
                type: 2 //2 =>iframe
                ,
                id: id,
                closeBtn: 1,
                title: title,
               // title: title == "未命名"?false:title,
                area: [formWidth, formHeight] //  area: ['85%', '85%']
                ,
              //  moveOut:true,
                shade: 0,
               maxmin: true,
                offset: [
                    formPositionX // Math.random()*($(window).height()-300)
                    , formPositionY //Math.random()*($(window).width()-390)
                ],
                content: url //'http://www.baidu.com'
                ,
                //scrollbar:true,
           //     btn: [ '关闭当前'],
            //    yes: function () {
             //       $(that).click();
             //   },
                //btn2: function () {
                //    layer.close();
                //},
             //   btn3: function () {
              //      layer.closeAll();
               // },
                zIndex: layer.zIndex //重点1
                ,
                success: function (layero, index) {
                    
                   // debugger
                    //将父窗口的信息高速孩子
                    $("#layui-layer-iframe" + index).contents().find("#e-title").append("<div id='father-info' data-id='" + id + "' data-index='" + index + "'</div>");
                    //$("#layui-layer-iframe" + index).contents().find("#e-title").append("<div>#layui-layer-iframe"+ index+"</div>");
                     //document.getElementById('set-title').addEventListener('click', function () {
                    //    $.alert(document.getElementById('set-title').value)
                    //    //layer.title("haha", g_windowIndex);
                    //});
                 
                    $(window).resize(function () {
                        var _width = ($(window).width() - leftWidth);
                        if ($(window).width() < 1000) {
                          
                            layer.style(index, {
                                width: $(window).width() + "px",
                                height: $(window).height() + "px",
                                top: "0px",
                                left: "0px"
                            });
                        } else {
                            layer.style(index, {
                                width: ($(window).width() - leftWidth) + "px",
                                height: ($(window).height() - topHeight - 45) + "px"
                               
                            });
                        }
                       
                    });
                    layer.setTop(layero); //重点2
                }
                , end: function (i) {
                    $.refresh();
                }
            });
        }
    }
    // $('#wrapper .layui-btn')
  //  debugger
    $(selector).each(function (i, o) {
        
        var obj = $(o);
        

        if ($.hasValue(obj.data("tip"))) {
            //添加tip
            obj.mouseover(function () {
                var that = this;
                layer.tips(obj.data("tip"), that, {
                    tips: 1 //在上方
                    
                }); //在元素的事件回调体中，follow直接赋予this即可
            });
        }
        var old = $.hasValue(obj.attr('data-url')) ? obj.attr('data-url') : obj.attr("href");
        
        if (!$.hasValue(old)) {
            
            return;
        }
        
        // 去除空格
        while (old.indexOf(" ") > -1) {
            old = old.replace(" ", "");
        }
		//debugger 
        //$.log(obj);
        //转换地址--（补全缺省地址）
        if (old.indexOf("@") == -1) {
          //  old = (old.indexOf("*") > -1 ) ? old : ("*" + type + old);
			  old = (old.indexOf("*") > -1 ) ?
			   old : (old.toLowerCase().indexOf("delete") > -1 )?
								("*d"+ old):("*" + type + old);
     
        }
        obj.removeAttr("href");//移除href防止跳转
        obj.attr("data-url", old);

        //判断类型
        //api按钮不弹窗
        if (old.indexOf("*d") > -1 || old.indexOf("@") > -1) {          
            //obj.removeAttr("class");
            //debugger
            obj.on("click", function () {
               // debugger
                var apiObj = $(this);
                var _destUrl = $.hasValue(apiObj.attr('data-url')) ? apiObj.attr('data-url') : apiObj.attr("href");
                var dest = $.parseurl(_destUrl);
                old = old.replace("*d", "");
                if (old.indexOf("(") > -1 && old.indexOf(")") > -1) { //函数
                    try {
                        eval(old);
                    } catch (ex) {//错误检测
                        $.alert("注意:运行本页面附加js中的<span style='color:red;'>" + old + "</span><br/>函数时出错<br/>1.请检查是否存在附加js文件<br/>2.请检查附加js中是否存在<span style='color:red;'>" + old + "</span><br/>函数<br/>如果你忽略该提示，页面中名为<span style='color:red;'>" + obj[0].innerText + "</span>的自定义操作将无法正常使用!");
                    }
                } else {//地址
                    //debugger
                    if (dest.destUrl.indexOf("@download") > -1) {//下载文件
                        $.Ajax({
                            url: dest.destUrl.replace("confirmDo", ""),
                            success: function (data, code, msg, url) {
                                $.dealAjax(data, code, msg, url);
                            },
                            error: function (data) {
                                if (g_debug) {
                                    $.alert("操作失败,请检查服务器是否提供了对应的api:<br/>" + $.url(url), 2);
                                } else {
                                    $.alert("操作失败", 5);
                                }
                            }
                        });

                    } else {//其他
                        confirmDo(dest.destUrl.replace("confirmDo", ""), obj[0].innerText);
                    }
                  
                }
            });
            
            return; //表单，报表 弹窗
        } else {
             obj.click(function() {
                var othis = $(this), method = 'setTop'; //othis.data('method');
                active[method] ? active[method].call(this, othis) : '';
            });
        }
    });
   
}

function setTitle(title,index) { 
    layer.title(title, index);
}
function subSetTitle(title, index) {
    var father = $("#father-info");
    // $.log(window.parent.document);
    $.log(window.parent.setTitle(title, father.data("index")));
    // window.praent.setTitle(title, index);
}
function closeWindow(index) {
    layer.close(index);
}
function subClose() {
    var father = $("#father-info");
    //$.log(father.data("index"));
    window.parent.closeWindow(father.data("index"));
}
function InitMenuAnimation()
{
    $('#side-menu').metisMenu();
    $(window).bind("load resize", function () {
        var topOffset = 50;
        var width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.navbar-collapse').addClass('collapse');
            topOffset = 100; // 2-row-menu
        } else {
            $('div.navbar-collapse').removeClass('collapse');
        }

        var height = ((this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height) - 1;
        height = height - topOffset;
        if (height < 1) height = 1;
        if (height > topOffset) {
            $("#page-wrapper").css("min-height", (height) + "px");
        }
    });

    var url = window.location;
    // var element = $('ul.nav a').filter(function() {
    //     return this.href == url;
    // }).addClass('active').parent().parent().addClass('in').parent();
    var element = $('ul.nav a').filter(function () {
        return this.href == url;
    }).addClass('active').parent();

    while (true) {
        if (element.is('li')) {
            element = element.parent().addClass('in').parent();
        } else {
            break;
        }
    }
}

/*
<li><a href="forms.html" class="active"><i class="fa fa-edit fa-fw"></i>Forms</a></li>
 */
function confirmDo(url, title) {
    url = $.trimString(url);
    $.confirm("确认" + title + "？", function () {

        $.Ajax({
            url: url,
            success: function (data, code, msg, url) {
                $.dealAjax(data, code, msg, url);
                $.refresh();

            },
            error: function (data) {
                if (_c.isDebug()) {
                    $.alert("操作失败,请检查服务器是否提供了对应的api:<br/>" + $.url(url), 2);
                } else {
                    $.alert("操作失败", 5);
                }
            }
        });
    });
}
function InitWorkFlow() {
    $.log("工作流已禁用");
    return;
    if ($.isDebugPage()) {
        return;//调试页面不拉取待办
    }
    var url = "/WorkFlow/GetToDo";
    $.Ajax({
        url: url, //调用WebService的地址和方法名称组合 ---- WsURL/方法名
        data: {uid:$.uid()},         //这里是要传递的参数,格式为 data: "{paraName:paraValue}",下面将会看到      
        success: function (data, code, msg, url) {     //回调函数,result,返回值
            //$.log(data);
            if ($.hasValue(data.All) && (data.All.length > 0)) {
                $.log("您有" + data.All.length + "条新任务,请您及时处理", 0);
                $("#workflow-tasks-num").html(data.All.length);
                var taskHtml = "";
                for (var i = 0; i < (data.All.length > 3 ? 3 : data.All.length); i++) {
                    var item = data.All[i];
                    //$.log((item.PathHistory.length + 0.00001));
                   // $.log((item.AllRelation.length));
                    taskHtml += MsgTpl("*f" + item.Url, item.Title, $.parsetime(item.Time), item.Note);
                }
                taskHtml += '<li><a class="text-center qx-menu" data-title="待办列表" data-url="*f/core/workflow/list"><strong>查看更多</strong><i class="fa fa-angle-right"></i></a></li>';
               
                // $.log($("#workflow-msg"))
                $("#workflow-tasks").html(taskHtml);
                InitMenuEvent("#workflow-tasks .qx-menu");
                InitMenuEvent(".navbar-brand qx-menu");
            } else {
                $("#workflow-tasks").html(MsgTpl("", "暂无任务", "", ""));
                $("#workflow-tasks-num").html("0");
            }
        }
    });
}

//导出excel
function JsonToExcel(tableArray, fileName) {

    var excel = '<table>';
    //设置数据  
    for (var i = 0; i < tableArray.length; i++) {
        var row = "<tr>";
        for (var j = 0; j < tableArray[i].length; j++) {
            row += '<td>' + tableArray[i][j] + '</td>';
        }
        excel += row + "</tr>";
    }
    excel += "</table>";

    var excelFile = "<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'>";
    excelFile += '<meta http-equiv="content-type" content="application/vnd.ms-excel; charset=UTF-8">';
    excelFile += '<meta http-equiv="content-type" content="application/vnd.ms-excel';
    excelFile += '; charset=UTF-8">';
    excelFile += "<head>";
    excelFile += "<!--[if gte mso 9]>";
    excelFile += "<xml>";
    excelFile += "<x:ExcelWorkbook>";
    excelFile += "<x:ExcelWorksheets>";
    excelFile += "<x:ExcelWorksheet>";
    excelFile += "<x:Name>";
    excelFile += "{worksheet}";
    excelFile += "</x:Name>";
    excelFile += "<x:WorksheetOptions>";
    excelFile += "<x:DisplayGridlines/>";
    excelFile += "</x:WorksheetOptions>";
    excelFile += "</x:ExcelWorksheet>";
    excelFile += "</x:ExcelWorksheets>";
    excelFile += "</x:ExcelWorkbook>";
    excelFile += "</xml>";
    excelFile += "<![endif]-->";
    excelFile += "</head>";
    excelFile += "<body>";
    excelFile += excel;
    excelFile += "</body>";
    excelFile += "</html>";


    var uri = 'data:application/vnd.ms-excel;charset=utf-8,' + encodeURIComponent(excelFile);

    var link = document.createElement("a");
    link.href = uri;

    link.style = "visibility:hidden";
    link.download = fileName + ".xls";

    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}




