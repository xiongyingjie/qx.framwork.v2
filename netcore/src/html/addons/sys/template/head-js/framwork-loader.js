//#jquery - pagination
(function ($) {
    $.fn.extendPagination = function (options) {
        var defaults = {
            pageId: '2',
            totalCount: '',
            showPage: '3',
            limit: '5',
            callback: function () {
                return false;
            }
        };
        $.extend(defaults, options || {});
        if (defaults.totalCount === '') {
            //alert('总数不能为空!');
            $(this).empty();
            return false;
        } else if (Number(defaults.totalCount) <= 0) {
            //alert('总数要大于0!');
            $(this).empty();
            return false;
        }
        if (defaults.showPage == '') {
            defaults.showPage = '3';
        } else if (Number(defaults.showPage) <= 0) defaults.showPage = '3';
        if (defaults.limit == '') {
            defaults.limit = '5';
        } else if (Number(defaults.limit) <= 0) defaults.limit = '5';
        var totalCount = Number(defaults.totalCount), showPage = Number(defaults.showPage),
            limit = Number(defaults.limit), totalPage = Math.ceil(totalCount / limit);
        if (totalPage > 0) {
            var html = [];
            html.push(' <ul class="pagination">');
            html.push(' <li class="previous"><a href="#">&laquo;</a></li>');
            html.push('<li class="disabled hidden"><a href="#">...</a></li>');
            if (totalPage <= showPage) {
                for (var i = 1; i <= totalPage; i++) {
                    if (i == 1) html.push(' <li class="active"><a href="#">' + i + '</a></li>');
                    else html.push(' <li><a href="#">' + i + '</a></li>');
                }
            } else {
                for (var j = 1; j <= showPage; j++) {
                    if (j == 1) html.push(' <li class="active"><a href="#">' + j + '</a></li>');
                    else html.push(' <li><a href="#">' + j + '</a></li>');
                }
            }
            html.push('<li class="disabled hidden"><a href="#">...</a></li>');
            html.push('<li class="next"><a href="#">&raquo;</a></li></ul>');
            $(this).html(html.join(''));
            if (totalPage > showPage) $(this).find('ul.pagination li.next').prev().removeClass('hidden');

            var pageObj = $(this).find('ul.pagination'), preObj = pageObj.find('li.previous'),
                currentObj = pageObj.find('li').not('.previous,.disabled,.next'),
                nextObj = pageObj.find('li.next');

            function loopPageElement(minPage, maxPage) {
                var tempObj = preObj.next();
                for (var i = minPage; i <= maxPage; i++) {
                    if (minPage === 1 && (preObj.next().attr('class').indexOf('hidden')) < 0)
                        preObj.next().addClass('hidden');
                    else if (minPage > 1 && (preObj.next().attr('class').indexOf('hidden')) > 0)
                        preObj.next().removeClass('hidden');
                    if (maxPage == totalPage && (nextObj.prev().attr('class').indexOf('hidden')) < 0)
                        nextObj.prev().addClass('hidden');
                    else if (maxPage < totalPage && (nextObj.prev().attr('class').indexOf('hidden')) > 0)
                        nextObj.prev().removeClass('hidden');
                    var obj = tempObj.next().find('a');
                    if (!isNaN(obj.html())) obj.html(i);
                    tempObj = tempObj.next();
                }
            }

            function callBack(curr) {
                defaults.callback(curr, defaults.limit, totalCount);
            }

            currentObj.click(function (event) {
                event.preventDefault();
                var currPage = Number($(this).find('a').html()), activeObj = pageObj.find('li[class="active"]'),
                    activePage = Number(activeObj.find('a').html());
                if (currPage == activePage) return false;
                if (totalPage > showPage && currPage > 1) {
                    var maxPage = currPage, minPage = 1;
                    if (($(this).prev().attr('class'))
                        && ($(this).prev().attr('class').indexOf('disabled')) >= 0) {
                        minPage = currPage - 1;
                        maxPage = minPage + showPage - 1;
                        loopPageElement(minPage, maxPage);
                    } else if (($(this).next().attr('class'))
                        && ($(this).next().attr('class').indexOf('disabled')) >= 0) {
                        if (totalPage - currPage >= 1) maxPage = currPage + 1;
                        else maxPage = totalPage;
                        if (maxPage - showPage > 0) minPage = (maxPage - showPage) + 1;
                        loopPageElement(minPage, maxPage)
                    }
                }
                activeObj.removeClass('active');
                $.each(currentObj, function (index, thiz) {
                    if ($(thiz).find('a').html() == currPage) {
                        $(thiz).addClass('active');
                        callBack(currPage);
                    }
                });
            });
            preObj.click(function (event) {
                event.preventDefault();
                var activeObj = pageObj.find('li[class="active"]'), activePage = Number(activeObj.find('a').html());
                if (activePage <= 1) return false;
                if (totalPage > showPage) {
                    var maxPage = activePage, minPage = 1;
                    if ((activeObj.prev().prev().attr('class'))
                        && (activeObj.prev().prev().attr('class').indexOf('disabled')) >= 0) {
                        minPage = activePage - 1;
                        if (minPage > 1) minPage = minPage - 1;
                        maxPage = minPage + showPage - 1;
                        loopPageElement(minPage, maxPage);
                    }
                }
                $.each(currentObj, function (index, thiz) {
                    if ($(thiz).find('a').html() == (activePage - 1)) {
                        activeObj.removeClass('active');
                        $(thiz).addClass('active');
                        callBack(activePage - 1);
                    }
                });
            });
            nextObj.click(function (event) {
                event.preventDefault();
                var activeObj = pageObj.find('li[class="active"]'), activePage = Number(activeObj.find('a').html());
                if (activePage >= totalPage) return false;
                if (totalPage > showPage) {
                    var maxPage = activePage, minPage = 1;
                    if ((activeObj.next().next().attr('class'))
                        && (activeObj.next().next().attr('class').indexOf('disabled')) >= 0) {
                        maxPage = activePage + 2;
                        if (maxPage > totalPage) maxPage = totalPage;
                        minPage = maxPage - showPage + 1;
                        loopPageElement(minPage, maxPage);
                    }
                }
                $.each(currentObj, function (index, thiz) {
                    if ($(thiz).find('a').html() == (activePage + 1)) {
                        activeObj.removeClass('active');
                        $(thiz).addClass('active');
                        callBack(activePage + 1);
                    }
                });
            });
        }
    };
})(jQuery);

//#menu-loader
var g_menuHtml = "";
var g_menuData = [];
//鼠标悬停展开
function dropdownOpen() {

    var $dropdownLi = $('li.dropdown');
    $dropdownLi.mouseover(function () {
        $(this).addClass('open');

    }).mouseout(function () {
        $(this).removeClass('open');

    });
}
function menuStageTwo(uid) {

    var lIndex = $.loading();
    //$.msg("正在获取菜单,请稍候...",0);
    $.ajax({
        url: $.url("/Open/GetMenu", true),
        data: { uid: uid },
        success: function (data, status) {
            $.loaded(lIndex);
            //$.msg("获取菜单成功!");

            var html = [];
            for (var i = 0; i < data.navbars.length; i++) {
                var nvItem = data.navbars[i];
                if (nvItem.isParent == false) {//存储最后一层菜单
                    g_menuData.push(nvItem);
                }
                if (nvItem.parentId === 'MRoot') {
                    var item = 0;
                    for (var j = 0; j < data.navbars.length; j++) {
                        var nvItemChild = data.navbars[j];
                        if (nvItemChild.parentId === nvItem.id) {
                            item++;
                            if (item == 1) {
                                if (!$.hasValue(nvItem.imageClass)) {
                                    html.push(' <li class="dropdown">' +
                                        '<a href="#"><i class="fa fa-bar-chart-o fa-fw"></i>' + nvItem.name + '<span class="fa arrow"></span></a>');
                                    html.push('<ul class="nav nav-second-level"><li><a data-url="' + nvItemChild.finalUrl + '" class="qx-menu" data-title="' + nvItemChild.name + '">' + nvItemChild.name + '</a></li>');
                                }
                                else {
                                    html.push(' <li class="dropdown>' +
                                        '<a href="#"><i class="' + nvItem.imageClass + '"></i>' + nvItem.name + '<span class="fa arrow"></span></a>');
                                    html.push('<ul class="nav nav-second-level"><li><a data-url="' + nvItemChild.finalUrl + '" class="qx-menu" data-title="' + nvItemChild.name + '">' + nvItemChild.name + '</a></li>');
                                }


                            } else {
                                html.push('<li><a data-url="' + nvItemChild.finalUrl + '" class="qx-menu" data-title="' + nvItemChild.name + '">' + nvItemChild.name + '</a></li>');
                            }

                        }
                    }
                    if (item !== 0) {
                        html.push('</ul></li>');
                    } else {
                        if (nvItem.imageClass == null) {
                            html.push(' <li>' +
                                '<a data-url="' + nvItemChild.finalUrl + '" class="qx-menu" data-title="' + nvItemChild.name + '"><i class="fa fa-bar-chart-o fa-fw"></i>' + nvItem.name + '</a>' +
                                '</li>');

                        }
                        else {
                            html.push(' <li>' +
                                '<a data-url="' + nvItemChild.finalUrl + '" class="qx-menu" data-title="' + nvItemChild.name + '"><i class="' + nvItem.imageClass + '"></i>' + nvItem.name + '</a>' +
                                '</li>');
                        }


                    }

                }
            }

            var mainObj = $('#side-menu');
            //缓存旧菜单           
            g_menuHtml = html.join('');
            mainObj.append(g_menuHtml);
            InitMenuAnimation();
            InitMenuEvent();
            //初始化搜索
            var search = $("#search-menu");
            $("#bt_clean").click(function () {
                search.val("");
                search.keyup();
                search.focus();
            });
            search.keyup(function () {
                var keyword = $.trimString($(this).val());
                $("#side-menu li.dropdown,.qx-menu-search").remove();
                if ($.hasValue(keyword)) {
                    for (var i = 0; i < g_menuData.length; i++) {
                        //  debugger
                        var item = g_menuData[i];
                        // $.log(item.text() + "contain" + that.val() + "=" + (item.text().indexOf(that.val()) > -1))
                        if (item.name.indexOf(keyword) > -1) {
                            $("#side-menu").append('<li class="qx-menu-search"><a data-url="' + item.finalUrl + '" class="qx-menu" data-title="' + item.name + '"><i class="fa fa-search fa-fw"></i> ' + item.name + '</a></li>');
                        }
                    }
                } else {//还原菜单
                    $("#side-menu").append(g_menuHtml);
                }
                InitMenuAnimation();
                InitMenuEvent();
            });
            // dropdownOpen();
        },
        error: function () {
            $.loaded(lIndex);
            if (_c.isDebug) {
                $.alert("服务器连接失败,请检查是否启动了服务器端,若问题依旧,请检查config.js中的g_host配置项是否正确！", 2);
            } else {
                $.alert("网络连接失败,请检查您的网络连接状态！", 5);
            }

        }
    });


}


//#framwork-loader
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
                if (_c.isDebug) {
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

//#table-loader
NS.Register("qx.grid");
qx.grid = new QxGrid();

function QxGrid() {
    //私有变量
    var g_dataSource;
    var g_addLink;
    var g_title;
    var g_extraParam;
    var g_reportId;
    var g_params;
    var g_perCount;
    var g_pageIndex;
    var g_showDeafultButton;
    var g_dbConnStringKey;
    var g_dataSourceUrl;
    var g_formControlConfig;
    var g_deleteLink;
    var g_currentUrl;
    var g_fixedParams;
    var g_importLink;
    //checkbox 全选/取消全选
    var g_isCheckAll = false;

    this.InitReport = function (id) {
        //加载附加js
        var jsurl = id;//页面
        if (id.indexOf("?") > -1) {
            jsurl = id.substring(0, id.indexOf("?"));
        }
        
        if (jsurl.indexOf("/") > -1) {
            jsurl = jsurl.substring(jsurl.lastIndexOf("/")+1, jsurl.length );
        }
        jsurl = srcurl(jsurl + ".js", "/views/grid/");
        $.ajax({
            url: jsurl,
            success: function () {
                //head.load($.res(jsurl + ".js"));
            },
            error: function () {
                if (_c.isDebug) {
                    $.warn("未能加载grid的附加js,请检查项目目录下是否存在" + jsurl);
                }
            }
        });
        //debugger
        //获取UI配置
        $.Ajax({
            url: id,
            success: function (data, code, msg, url) {
                var obj = data;

                g_dataSource = obj.DataSource;
                g_addLink = obj.AddLink;
                g_title = obj.Title;
                g_extraParam = obj.ExtraParam;
                g_reportId = obj.ReportId;
                g_params = obj.Params;
                g_perCount = obj.PerCount;
                g_pageIndex = obj.PageIndex;
                g_showDeafultButton = obj.ShowDeafultButton;
                g_dbConnStringKey = obj.DbConnStringKey;
                g_dataSourceUrl = obj.DataSourceUrl;
                g_formControlConfig = obj.FormControlConfig;
                g_deleteLink = obj.DeleteLink;
                g_currentUrl = obj.CurrentUrl;
                g_fixedParams = obj.FixedParams;
                g_importLink = obj.ImportLink;


                //开始生成报表
                if (typeof g_deleteLink === "undefined") {

                    if (_c.isDebug) {
                        $.confirm("获取报表搜索条件过程中出现错误,查看服务器返回数据的详细数据？", function () {
                            $.window($.url(id), "服务器返回数据详情");
                            return true;
                        });
                    }
                    return;
                }
                if (!$.hasValue(g_deleteLink)) {
                    $("#bt_delete").remove();
                }
                if (!$.hasValue(g_addLink)) {
                    $("#bt_add").remove();
                } else {
                    //b绑定导入excel的事件
                    var drop = document.getElementById('bt_uploadExcel');
                    if (drop.addEventListener) {
                        drop.addEventListener('change', handleFile, false);
                    }
                    //Add改为弹窗
                    // //$.log(g_addLink)
                    var addObj = $("#bt_add");

                    addObj.attr("data-url", ((g_addLink.indexOf("*") > -1) ? "" : "*f") + g_addLink);
                    InitMenuEvent("#bt_add", "f", true);
                }
                if (!$.hasValue(g_importLink)) {
                    $("#bt_import").remove();
                }
                if (GetFormData().length === 0) {
                    $("#bt_query").remove();
                }
                if (!$.hasValue(obj.BackUrl)) {
                    $("#bt_back").remove();
                } else {
                    $("#bt_back").click(function () {
                        $.go($.url(obj.BackUrl));
                    });
                }

                //设置标题
                $("#lb_title").html(g_title);
                $(".Query").click(Query);
                $(".Delete").click(Delete);
                $(".ToExcel").click(ToExcel);
                $(".ToPdf").click(ToPdf);
                $(".DonwnloadExcel").click(DonwnloadExcel);
                // //debugger 
                //$.log(window.praent)
                subSetTitle(g_title);
                // $.alert(document.getElementById('set-title').value)
                // setTitle(g_title,document);//设置标题
                //搜索框
                createForm();
                callBackPagination(999, g_perCount, g_perCount, g_pageIndex);
            }
        });

    }

    var t = function (sName) {
        var value = $("[name='" + sName + "']").find("option:selected").text();
        return (value === undefined || value === "") ? ";" : value;
    }
    var v = function (sName) {
        var value = $("[name='" + sName + "']").val();

        return (value === undefined || value === "") ? ";" : value;
    }
    var GetTableData = function () {
        $.get("/F2Demo/GetReportConfig",
            { ReportID: "ecampus.yxxt.charge_item_instance.应缴费用查询", Params: ";", dbConnStringKey: "ecampus.yxxt", pageIndex: 1, perCount: 10 },
            function (data) {
                //var tableData = '{"params":{"pageIndex":"1","perPage":"10","maxIndex":"88","currentUrl":"http://baidu.com","title":"测试"},"header":["id","name","sex","city","age","操作"],"tableBody":[["id_1","name_1","sex_1","city_1","age_1","查看"],["id_2","name_2","sex_2","city_2","age_2","查看"],["id_3","name_3","sex_3","city_3","age_3","查看"],["id_4","name_4","sex_4","city_4","age_4","查看"]]}';
                var obj = JSON.parse(data);
                return obj;
            });

    }
    var GetFormData = function () {
        var formData = g_formControlConfig;
        var obj = JSON.parse(formData);
        return obj;
    }


    var selectAll = function () {
        if (g_isCheckAll) {
            $("input[type='checkbox']").each(function () {
                this.checked = false;
            });
            g_isCheckAll = false;
        } else {
            $("input[type='checkbox']").each(function () {
                this.checked = true;
            });
            g_isCheckAll = true;
        }
    }

    var UpdateQueryParam = function () {
        var queryParam = "";

        var objList = GetFormData();
        //过滤tip button
        var controlObjList = [];
        for (var m = 0; m < objList.length; m++) {
            if (objList[m].type === 201 ||
                objList[m].type === 203 ||
                objList[m].type === 209 ||
                objList[m].type === 204) {
                controlObjList.push(objList[m]);
            }
        }

        for (var i = 0; i < controlObjList.length; i++) {
            var item = controlObjList[i];
            var value = "";
            //Input = 1,
            //DateTime = 2,
            //TextArea = 3,
            //DropDownList = 4

            switch (item.type) {
            case 201:
                {
                    value = $("#" + item.id).val();
                };
                break;
            case 203:
                {
                    value = $("#" + item.id).val();
                };
                break;
            case 209:
                {
                    value = document.getElementById(item.id).value;
                };
                break;
            case 204:
                {
                    var x = document.getElementById(item.id);
                    // console.log(item.id + x);
                    var selecteditem = x.options[x.selectedIndex];
                    value = $.hasValue(selecteditem) ? selecteditem.value : ";";
                };
                break;
            default:
                {
                    continue;
                    //  throw exception;
                };
                break;
            }
            //清除特殊符号;
            // //debugger
            value = value.replace(/;/g, "").replace(/;/g, "");//g代表全部替换 
            //前n-1个 有值取值并加; 无值直接匹配;   最后1个且有>1个动态参数无值不匹配;
            if (controlObjList.length === 1) {
                if ($.hasValue(value)) {
                    // value = value;
                } else {
                    if ($.hasValue(g_fixedParams)) {
                        // value = value;
                    } else {
                        value = ";";
                    }
                }
            } else {
                if (i === controlObjList.length - 1) {
                    if ($.hasValue(value)) {
                        //value = value;
                    } else {
                        // value = value
                    }
                } else {
                    if ($.hasValue(value)) {
                        value += ";";
                    } else {
                        value = ";";
                    }
                }
            }
            queryParam += value;

        }
        //清除特殊符号'
        queryParam = queryParam.replace(/'/g, "").replace(/"/g, "");//g代表全部替换 
        //前方插入固定参数
        g_params = ($.hasValue(g_fixedParams) ? g_fixedParams + ";" : "") + queryParam;
        //  console.log('参数更新后 ' + g_params);
        return g_params;
    }

    var DonwnloadExcel = function () {

        $.Ajax({
            url: "/Report/ExcelTemplate?uid=" + $.uid() + "&ReportID=" + g_reportId,
            success: function (data, code, msg, url) {
                if (code > 0) {
                    $.msg("模板已生成！", 1);
                    JsonToExcel(data, g_title + "-template");
                } else {
                    $.msg("模板生成失败！");
                }

            }
        });
        //console.log("DonwnloadExcel...");
    }
    var doUpload = function () {

    }
    var UploadExcel = function (exlData, out) {
        var objArray = JSON.parse(out).Sheet1;
        //console.log(objArray);
        var trueCount = 0;
        var failCount = 0;
        // var lIndex = $.msg("请稍候...");

        var lIndex = layer.msg('<div style="width: 300px;" class="progress progress-striped active">' +
            ' <div class="progress-bar progress-bar-success" id="upload-progress" role="progressbar"' +
            '     aria-valuenow="60" aria-valuemin="0" aria-valuemax="100"' +
            '   style="width:0%;">' +
            '           <span class="sr-only">40% 完成</span>' +
            '      </div>' +
            '  </div>', { time: 6000000 });

        setTimeout(function () {
            var progress = $("#upload-progress");
            for (var i = 0; i < objArray.length; i++) {
                var currnt = objArray[i];
                //$.log(currnt);
                $.Ajax({
                    showLoading: false,
                    url: g_importLink,
                    data: { json: JSON.stringify(currnt) },
                    success: function (data, code, msg, url) {
                        //debugger
                        if (code > -1) {
                            trueCount++;
                            //$.go($.url(data));
                        } else {
                            failCount++;
                        }
                        progress.css("width", ((100.0 * (trueCount + failCount)) / objArray.length) + "%");

                        if (trueCount + failCount == objArray.length) {
                            layer.close(lIndex);
                            $.alert("成功导入" + trueCount + "条", 1);
                            Query();
                            $("#bt_uploadExcel").val("");//清空旧值
                        }
                    }
                });
            }

        }, 100);


    }

    var ToPdf = function () {
        // 将 id 为 content 的 div 渲染成 canvas
        html2canvas($('#mainContent').dom, {

            // 渲染完成时调用,获得 canvas
            onrendered: function (canvas) {

                // 从 canvas 提取图片数据
                var imgData = canvas.toDataURL('image/jpeg');

                var doc = new jsPDF("p", "mm", "a4");
                //                               |
                // |—————————————————————————————|                     
                // A0 841×1189                           
                // A1 594×841                            
                // A2 420×594                            
                // A3 297×420                            
                // A4 210×297                            
                // A5 148×210                            
                // A6 105×148                            
                // A7 74×105                             
                // A8 52×74                              
                // A9 37×52                              
                // A10 26×37             
                //     |——|———————————————————————————|
                //                                 |——|——|
                //                                 |     |      
                doc.addImage(imgData, 'JPEG', 0, 0, 210, 297);

                doc.save('reportTable.pdf');
                $.msg("导出成功！", 1);
            }
        });

    }

    var ToExcel = function () {
        UpdateQueryParam();

        $.Ajax({
            url: "/Report/ReportToExcel2",
            data: { ReportID: g_reportId, Params: g_params, dbConnStringKey: g_dbConnStringKey, pageIndex: 1, perCount: 99999 },
            success: function (data, code, msg, url) {
                if (code > 0) {
                    //  //debugger
                    JsonToExcel(data, g_title);
                    $.msg("导出成功！", 1);
                } else {
                    $.msg("导出失败！");
                }

            }
        });
        //   console.log("ToExcel...");
    }
    var Add = function () {

        $.go("/pages/form.html?id=" + g_addLink);
    }

    var Delete = function () {
        submitChecked(g_deleteLink, "删除");
    }
    var submitChecked = function (url, tip, data) {
        var trueCount = 0;
        var falseCount = 0;
        var chkValues = getChecked();
        if (chkValues.length == 0) {
            $.alert('请先选中要' + tip + '的行！');
            return;
        }
        $.confirm("确认将勾选的" + chkValues.length + "条记录" + tip + "？", function () {
            for (var i = 0; i < chkValues.length; i++) {
                $.Ajax({
                    url: url + "?id=" + chkValues[i],
                    data: data,
                    success: function (data, code, msg, url) {
                        if (code > 0) {
                            trueCount++;
                        } else {
                            falseCount++;
                        }
                        if (chkValues.length === trueCount + falseCount) {
                            $.msg($.hasValue(msg) ? msg : '已成功将' + trueCount + '条记录' + tip, code);

                            Query();
                        }
                    }
                });
            }
        });

    }
    var getChecked = function () {
        var chkValues = [];
        $('input[type="checkbox"]:checked').each(function (i, e) {
            var id = $(e).attr('id');
            if ($.hasValue(id)) {
                chkValues.push($.trim(id));
            }
        });
        return chkValues;
    }
    var Query = function () {
        //UpdateQueryParam();
        callBackPagination(999, g_perCount, g_perCount, g_pageIndex);
        //var url = g_currentUrl + "?ReportID=" + g_reportId + "&Params=" + queryParam + "&pageIndex=1&perCount=" + g_perCount + g_extraParam;
        //location.href = url;
        //console.log("Query..." + url);
    }



    //limit每页显示条数
    var callBackPagination = function (totalCount, showCount, limit, currPage) {

        createTable(currPage, limit, totalCount);
        $('#callBackPager').extendPagination({

            totalCount: totalCount,

            showCount: showCount,

            limit: limit,

            callback: function (curr, limit, totalCount) {
                createTable(curr, limit, totalCount);
            }

        });

    }

    var createTable = function (currPage, limit, total) {
        UpdateQueryParam();
        $("#lb_fromIndex").html((currPage - 1) * limit + 1);
        $("#lb_toIndex").html(currPage * limit);

        $.Ajax({
            url: "/Report/Report2",
            data: { ReportID: g_reportId, Params: g_params, dbConnStringKey: g_dbConnStringKey, dataSourceUrl: g_dataSourceUrl, pageIndex: currPage, perCount: limit },
            success: function (data, code, msg, url) {
                var obj = data;
                var params = obj.pageParam;//对象
                var header = obj.header;//一维数组
                var tableBody = obj.FinalView;//二维数组
                var tableBodyAll = obj.tableBody_all;//二维数组
                var html = [], showNum = limit;

                if (total - (currPage * limit) < 0) showNum = total - ((currPage - 1) * limit);

                html.push('<table id="report-table" class="table table-striped table-bordered table-hover info" style="margin-left: 0;">');
                html.push('<thead><tr>' +
                    '<th width="30px;">' +
                    '<input type="checkbox" class="selectAll">' +
                    '</th>');
                for (var i = 0; i < header.length; i++) {
                    html.push(' <th width="100px;"><label for="">' + header[i] + '</label></th>');
                    if (i === header.length - 1) {
                        html.push(' <th width="300px;"><label for="">' + '操作' + '</label></th>');
                    }
                }

                html.push('</tr></thead><tbody>');

                for (var j = 1; j < tableBody.length; j++) {
                    html.push('<tr><td style="text-align:center;"><input id="' + $.trimString(tableBodyAll[j - 1][0]) + '" type="checkbox"></td>');
                    for (var k = 0; k < tableBody[j].length; k++) {
                        if (k === tableBody[j].length - 1) {
                            //$.log(g_extraParam)
                            //最后一列,额外参数处理 replace(/^label/,'tooltip')
                            //debugger 
                            html.push('<td  style="text-align:center; class="center overOut">' + $.replace(tableBody[j][k], ["[]", g_extraParam]) + '</td>');
                        } else {
                            html.push('<td data-toggle="tooltip" data-placement="bottom" title="' + tableBody[j][k] + '" class="center overOut">' + tableBody[j][k] + '</td>');
                        }
                    }
                    html.push('</tr>');
                }
                html.push('</tbody></table>');
                html.push('<script> var pymChild = new pym.Child();</script>');
                var mainObj = $('#mainContent');
                mainObj.empty();
                mainObj.html(html.join(''));

                //处理跳转地址
                //$(".qx-operate").each(function (i, o) {
                //    var obj = $(o);
                //    var old = obj.attr("href");
                //    //转换地址--（默认表单）
                //    var dest = $.parseurl(old, "f");
                //    obj.attr("href", dest.destUrl);
                //    //判断类型
                //    //删除按钮
                //    //debugger 
                //    if (dest.destType == "d") {
                //        obj.removeAttr("href");
                //        obj.removeAttr("class");
                //        obj.on("click", function () {

                //            confirmDo(dest.destUrl.replace("confirmDo", ""), obj[0].innerText);
                //        });//表单弹窗处理
                //    } else if (dest.destType == "f") {
                //        obj.removeAttr("href");
                //        obj.attr("data-url", "*f" + old);
                //        obj.attr("class", obj.attr("class")+" qx-menu");
                //    }


                //    //$.log(old);
                //});
                //debugger 
                $(".selectAll").click(selectAll);
                InitMenuEvent("tbody .qx-operate", "f", true);
                //调用函数
                $.doFunction("tableReady");

            }
        });
    }

    var createForm = function () {
        var obj = GetFormData();
        var extra_bt_html = [];
        var extra_tip_html = [];
        var html = [];


        for (var i = 0; i < obj.length; i++) {
            if (obj[i].type === 201) {
                html.push('<li><div class="form-group form-pd">' +
                    '<label class="label-wid">' + obj[i].lable + '</label>' +
                    '<input type="text"  class="form-control form-control-size Query-keyup" value="' + obj[i].value + '" id="' + obj[i].id + '" placeholder="">' +
                    '</div></li>');
            }
            else if (obj[i].type === 204) {
                html.push('<li><div class="form-group form-pd">' +
                    '<label class="label-wid">' + obj[i].lable + '</label>' +
                    '<select   id="' + obj[i].id + '" class="form-control form-control-size Query-change">');

                for (var j = 0; j < obj[i].items.length; j++) {
                    html.push('<option value="' + obj[i].items[j].value + '">' + obj[i].items[j].text + '</option>');
                }
                html.push('</select></div></li>');
            }
            else if (obj[i].type === 203) {
                html.push('<li><div class="form-group form-pd">' +
                    '<label class="label-wid">' + obj[i].lable + '</label>' +
                    '<input   type="text" value="' + obj[i].value + '" class="form-control form-control-size Query-change" id="' + obj[i].id + '">' +
                    '</div></li>');

                html.push('<script type="text/javascript">$("#' + obj[i].id + '").datetimepicker({ weekStart: 1,todayBtn: 1,autoclose: 1,todayHighlight: 1,startView: 2,forceParse: 0,showMeridian: 1,})' + ';' + '<' + '/script>');
            }
            else if (obj[i].type === 209) {
                html.push('<li style="width:100%;"><div class="form-group form-pd" style="width:100%;">' +
                    '<label class="label-wid">' + obj[i].lable + '</label>' +
                    '<textarea  class="form-control  Query-keyup" style="width:85%;height:120px;"  rows="' + obj[i].crossWidth + '" id="' + obj[i].id + '" placeholder="">' + obj[i].value +
                    '</textarea>' +
                    '</div></li>');
            }
            else if (obj[i].type === 103) {
                extra_bt_html.push(' <a data-url="' + obj[i].value + '" data-title="' + obj[i].lable + '" id="' + obj[i].id + '"  class="btn btn-primary extra-bt">' + obj[i].lable + '<i class="fa"></i></a>');

            } else if (obj[i].type === 114) {
                extra_tip_html.push(' <lable  class="btn">' + obj[i].lable + '</lable>');
            } else {
                html.push('error!');
            }

        }
        var mainObj = $('#mainForm'); var extraButton = $("#extra-bt-container"); var extraTip = $("#extra_tip-container");
        mainObj.empty(); extraButton.empty(); extraTip.empty();
        mainObj.html(html.join('')); extraButton.html(extra_bt_html.join('')); extraTip.html(extra_tip_html.join(''));

        //添加自定义按钮事件
        $(".Query-keyup").keyup(Query); $(".Query-change").change(Query);
        InitMenuEvent(".extra-bt", "d", true);
        $.doFunction("searchReady");
    }


    var dealTable = function (conditionArray, fn) { //二次处理报表  
        var table = document.getElementById("report-table");
        var thead = table.getElementsByTagName('thead')[0];
        var tbody = table.getElementsByTagName('tbody')[0];
        var trs = tbody.getElementsByTagName("tr");
        for (var i = 0; i < trs.length; i++) {
            var tr = trs[i];
            var tds = tr.getElementsByTagName("td");
            for (var j = 0; j < tds.length; j++) {
                var td = tds[j];
                if (conditionArray.indexOf(td.innerHTML) > -1) {
                    td.innerHTML = fn(td);
                    //  console.log("i:" + i + " j: " + j + " " + td.innerHTML=fn(td));
                }
            }
        }
    }
}

//#form-loader-v2
NS.Register("qx.form");
qx.form = new QxForm();
function QxForm() {

    var canSubmitTpl = function () {
        return $.qx_tpl({}, function () {/*
 
       <div class="col-lg-12">
                    <div class="col-lg-6">
                        <button class="col-lg-offset-10 btn btn-primary" id="bt_submit" type="submit">提交</button>
                    </div>
                    <div class="col-lg-6">
                        <button class="col-offset-6 btn btn-deafult" onclick="subClose()" id="bt_close" type="button">关闭</button>
                    </div>
                </div><hr/>

 */});
    }

    var InputTpl = function (label, name, value, num, reg) {
        var number = 12 / check(num, 4);
        value = check(value, "");
        label = (reg == undefined ? "" : "*") + label;
        var tip = label.replace("*", "");
        //debugger 
        return $.qx_tpl({ reg: reg, label: ($.hasValue(label) ? " <label>" + label + "</label>" : ""), name: name, value: value, number: number, tip: ($.hasValue(tip) ? tip : "id") }, function () {/*

    <div class="col-lg-{number}">
        <div class="form-group">
           {label}
            <input class="form-control"   id="{name}" name="{name}" placeholder="请输入{tip}" type="text" value="{value}">
        </div> 
    </div>
  
 */});
    }

    var ShowInputTpl = function (label, name, value, num) {
        var number = 12 / check(num);
        value = check(value, "");
        return $.qx_tpl({ name: name, label: label, value: value, number: number }, function () {/*

    <div class="col-lg-{number}">
        <div class="form-group">
            <label>{label}</label>
            <input type="text" disabled style="background-color:#FFFFFF" class="form-control" name="{name}" id="{name}" value="{value}" />
         
        </div> 
    </div>
 */});
    }

    var TimeTpl = function (label, name, value, num, tip) {
        var number = 12 / check(num);
        value = check(value, getNowFormatTime());
        tip = check(tip, "");

        return $.qx_tpl({ label: label, name: name, value: value, number: number, tip: tip }, function () {/*

    <div class="col-lg-{number}">
         <div class="form-group">
             <label>{label}</label>
             <div class="input-group date form_datetime">
                <input type="text" style="background-color:#FFFFFF" id="{name}" name="{name}"  placeholder="请设置{label}"  value="{value}" readonly="" class="form-control">
                <span class="input-group-btn">
                    <button class="btn btn-success date-set" type="button">
                       <i class="fa fa-calendar"></i>
                    </button>
                </span>
            </div>
          
          
         </div> 
     </div>

 */});
    }

    var ShowTimeTpl = function (label, name, value, num) {
        var number = 12 / check(num);
        value = check(value, "");

        return $.qx_tpl({ label: label, name: name, value: value, number: number }, function () {/*

    <div class="col-lg-{number}">
         <div class="form-group">
             <label>{label}</label>
             <div class="input-group date form_datetime">
                <input type="text" disabled style="background-color:#FFFFFF" id="{name}" name="{name}"  placeholder="请设置{label}"  value="{value}" readonly="" class="form-control">
                <span class="input-group-btn">
                    <button disabled class="btn btn-success date-set" type="button">
                       <i class="fa fa-calendar"></i>
                    </button>
                </span>
            </div>
          
       
         </div> 
     </div>

 */});
    }

    var DateTpl = function (label, name, value, num, tip) {
        var number = 12 / check(num);
        value = check(value, getNowFormatTime("onlyDate"));
        tip = check(tip, "");

        return $.qx_tpl({ label: label, name: name, value: value, number: number, tip: tip }, function () {/*

    <div class="col-lg-{number}">
         <div class="form-group">
             <label>{label}</label>
             <div class="input-group date form_date">
                <input type="text"style="background-color:#FFFFFF" id="{name}" name="{name}" value="{value}" readonly="" class="form-control">
                <span class="input-group-btn">
                    <button class="btn btn-success date-set" type="button">
                       <i class="fa fa-calendar"></i>
                    </button>
                </span>
            </div>
         </div> 
     </div>

 */});
    }

    var ShowDateTpl = function (label, name, value, num) {
        var number = 12 / check(num);
        value = check(value, "");

        return $.qx_tpl({ label: label, name: name, value: value, number: number }, function () {/*

    <div class="col-lg-{number}">
         <div class="form-group">
             <label>{label}</label>
             <div class="input-group date form_date">
                <input  disabled type="text"style="background-color:#FFFFFF" id="{name}" name="{name}" value="{value}" readonly="" class="form-control">
                <span class="input-group-btn">
                    <button  disabled class="btn btn-success date-set" type="button">
                       <i class="fa fa-calendar"></i>
                    </button>
                </span>
            </div>
         </div> 
     </div>

 */});
    }

    var SelectTpl = function (label, name, option, value, num, readonly) {

        value = check(value, "");
        option = check(option, "");
        readonly = check(readonly, false);
        var number = 12 / check(num);
        var optionHtml = "";
        var optionScript = "";
        if ($.isArray(option)) {

            for (var i = 0; i < option.length; i++) {
                optionHtml += '<option ' + ((option[i].value == value) ? "selected='selected'" : "") + '  value="' + option[i].value + '">' + option[i].text + '</option>';
            }
        } else {
            if (option.indexOf("{") > 0) {
                $.alert("select函数已升级，option参数应该为Array或Url,请修改原有函数!");
            }
            optionScript = "<script>head.ready(function(){$.fillSelect('" + name + "','" + option + "','" + value + "',false)})</script>";
        }



        return $.qx_tpl({ label: label, name: name, value: value, number: number, readonly: readonly ? "disabled" : "", option: optionHtml, optionScript: optionScript }, function () {/*

   <div class="col-lg-{number}">
      <div class="form-group">
         <label>{label}</label>
         <select class="form-control" {readonly} id="{name}" name="{name}">
              <option selected="selected" value=";">请选择{label}</option>
              {option}
         </select>
      
       </div> 
   </div>
   {optionScript}  
 */});
    }

    var ShowSelectTpl = function (label, name, option, value, num) {
        return SelectTpl(label, name, option, value, num, true);
    }

    var array_contain = function (array, obj) {
        for (var i = 0; i < array.length; i++) {
            if (array[i] == obj)//如果要求数据类型也一致,这里可使用恒等号===
                return true;
        }
        return false;
    }

    var RadioTpl = function (label, name, items, num, vertical, value) {
        value = check(value, "");
        vertical = check(vertical, true);
        if (vertical) {
            vertical = "float:left;";
        }
        var number = 12 / check(num);
        var itemHtml = "";
        for (var i = 0; i < items.length; i++) {
            itemHtml += ('<div class=""   style="' + vertical + 'margin-right:10px;padding:2px 0;"><input  type="radio" '
                + ((value == items[i].value) ? 'checked=""' : '') + ' value="' + items[i].value + '" name="'
                + name + '"><span>' + items[i].text + '</span></div>');
        }

        return $.qx_tpl({ label: label, number: number, itemHtml: itemHtml }, function () {/*
      
       <div class="col-lg-{number}" style="overflow:hidden;">
        <div class="form-group">
            <label>{label}</label><br />
            {itemHtml}
        </div> 
    </div>       
  
 */});
    }

    var ShowRadioTpl = function (label, name, items, num, vertical, value) {
        value = check(value, "");
        vertical = check(vertical, true);
        if (vertical) {
            vertical = "float:left;";
        }
        var number = 12 / check(num);
        var itemHtml = "";
        for (var i = 0; i < items.length; i++) {
            itemHtml += ('<div class=""   style="' + vertical + 'margin-right:10px;padding:2px 0;"><input disabled type="radio" '
                + ((value == items[i].value) ? 'checked=""' : '') + ' value="' + items[i].value + '" name="'
                + name + '"><span>' + items[i].text + '</span></div>');
        }

        return $.qx_tpl({ label: label, number: number, itemHtml: itemHtml }, function () {/*
      
       <div class="col-lg-{number}" style="overflow:hidden;">
        <div class="form-group">
            <label>{label}</label><br />
            {itemHtml}
        </div> 
    </div>       
  
 */});
    }

    var CheckBoxTpl = function (label, name, items, num, vertical, valueArray) {

        if (valueArray == undefined) {
            valueArray = [];
        }
        if (vertical) {
            vertical = "float:left;";
        }
        var number = 12 / check(num);
        var itemHtml = "";
        for (var i = 0; i < items.length; i++) {
            itemHtml += ('<div class=""   style="' + vertical + 'margin-right:10px;padding:2px 0;"><input  type="checkbox" '
                + (array_contain(valueArray, (items[i].value)) ? 'checked=""' : '') + ' value="' + items[i].value + '" name="'
                + name + '"><span>' + items[i].text + '</span></div>');
        }

        return $.qx_tpl({ label: label, number: number, itemHtml: itemHtml }, function () {/*
      
       <div class="col-lg-{number}" style="overflow:hidden;">
        <div class="form-group">
            <label>{label}</label><br />
            {itemHtml}
        </div> 
    </div>       
  
 */});
    }

    var ShowCheckBoxTpl = function (label, name, items, num, vertical, valueArray) {

        if (valueArray == undefined) {
            valueArray = [];
        }
        if (vertical) {
            vertical = "float:left;";
        }
        var number = 12 / check(num);
        var itemHtml = "";
        for (var i = 0; i < items.length; i++) {
            itemHtml += ('<div class=""   style="' + vertical + 'margin-right:10px;padding:2px 0;"><input  disabled type="checkbox" '
                + (array_contain(valueArray, (items[i].value)) ? 'checked=""' : '') + ' value="' + items[i].value + '" name="'
                + name + '"><span>' + items[i].text + '</span></div>');
        }

        return $.qx_tpl({ label: label, number: number, itemHtml: itemHtml }, function () {/*
      
       <div class="col-lg-{number}" style="overflow:hidden;">
        <div class="form-group">
            <label>{label}</label><br />
            {itemHtml}
        </div> 
    </div>       
  
 */});
    }

    var SwitchTpl = function (label, name, num, value, onText, offText) {

        var number = 12 / check(num);
        if (!$.hasValue(value)) {
            value = 1;
        }
        if (!$.hasValue(onText)) {
            onText = '开';
        }
        if (!$.hasValue(offText)) {
            offText = '关';
        }

        return $.qx_tpl({ name: name, label: label, number: number, value: value, onText: onText, offText: offText }, function () {/*
           
        <div class="col-lg-{number}">
            <div class="form-group">
                <label>{label}</label><br />
                <input id="{name}"  type="checkbox"/>
            </div> 
        </div>       

           <script>
                head.ready(function() {
                var obj=$('#{name}');

                obj.wrap('<div class="make-switch" />').parent().bootstrapSwitch();
                obj.bootstrapSwitch('setOnLabel', '{onText}');
                obj.bootstrapSwitch('setOffLabel', '{offText}');
                obj.bootstrapSwitch('setState', {value} === 1); // true || false
                obj.on('switch-change', function (e, data) {
                        var $el = $(data.el), value = data.value;
                        if (!value) {
                           obj.val('0');
                        } else {
                           obj.val('1');
                        }
                    });
                })
            </script>
            
  
 */});
    }

    var ShowSwitchTpl = function (label, name, num, value, onText, offText) {

        var number = 12 / check(num);
        if (!$.hasValue(value)) {
            value = 1;
        }
        if (!$.hasValue(onText)) {
            onText = '开';
        }
        if (!$.hasValue(offText)) {
            offText = '关';
        }

        return $.qx_tpl({ name: name, label: label, number: number, value: value, onText: onText, offText: offText }, function () {/*
           
        <div class="col-lg-{number}">
            <div class="form-group">
                <label>{label}</label><br />
                <input id="{name}" disabled type="checkbox"/>
            </div> 
        </div>       

           <script>
                head.ready(function() {
                var obj=$('#{name}');

                obj.wrap('<div class="make-switch" />').parent().bootstrapSwitch();
                obj.bootstrapSwitch('setOnLabel', '{onText}');
                obj.bootstrapSwitch('setOffLabel', '{offText}');
                obj.bootstrapSwitch('setState', {value} === 1); // true || false
                obj.on('switch-change', function (e, data) {
                        var $el = $(data.el), value = data.value;
                        if (!value) {
                           obj.val('0');
                        } else {
                           obj.val('1');
                        }
                    });
                })
            </script>
            
  
 */});
    }

    var AreaTpl = function (label, name, value, num, tip, height) {
        tip = check(tip, "");
        value = check(value, "");
        height = check(height, 200);
        var number = 12 / check(num, 1);
        return $.qx_tpl({ height: height, label: label, name: name, value: value, number: number, tip: tip }, function () {/*

    <div class="col-lg-{number}">
        <div class="form-group">
            <label>{label}</label>
            <textarea  style="height:{height}px" class="form-control" id="{name}" name="{name}" >{value}</textarea>
            
        </div> 
    </div>
   


 */});
    }

    var ShowAreaTpl = function (label, name, value, num, height) {

        value = check(value, "");
        height = check(height, 200);
        var number = 12 / check(num, 1);
        return $.qx_tpl({ height: height, label: label, name: name, value: value, number: number }, function () {/*

    <div class="col-lg-{number}">
        <div class="form-group">
            <label>{label}</label>
            <textarea disabled style="background-color:#FFFFFF;height:{height}px" readonly="readonly" class="form-control" id="{name}" name="{name}" >{value}</textarea>
            
        </div> 
    </div>
   


 */});
    }

    var ShowRichBoxTpl = function (label, name, value, num, tip) {
        tip = check(tip, "");
        var number = 12 / check(num, 1);
        return $.qx_tpl({ label: label, name: name, value: value, number: number, tip: tip }, function () {/*

   <div class="col-lg-{number}">
      <div class="form-group">
         <label>{label}</label>
         <div class="form-control" rows="3" name="{name}" style="height:auto">
            <div id="{name}" class="q_content">
                <p>
                   {value}
                </p>
            </div> 
         </div>
      </div>
    </div>


 */});
    }

    var RichBoxTpl = function (label, name, value, num, height) {
        value = check(value, "");
        //$.log(value);
        height = check(height, 300);
        var number = 12 / check(num, 1);
        return $.qx_tpl({ label: label, name: name, value: value, number: number, height: height }, function () {/*

  <div class='col-lg-{number}'>
       <div class='form-group'>
        <label>{label}</label>
         <script id="{name}" type="text/plain" style="width:100%;height:{height}px;">{value}</script>
    
       </div>
       <script>   
        head.ready(["umeditor-config","umeditor","umeditor-zh"],function() {
             var ue = UM.getEditor('{name}');         
                ue.ready(function () {
            
                var old= ue.getContent();
                if(!$.hasValue(old))
                {
                 value = ue.setContent('{value}');
                }          
               });
        })
       </script>
 </div>

 */});
    }

    var ImageTpl = function (type, value, num, tip) {
        tip = check(tip, "");
        var number = 12 / check(num, 3);
        return $.qx_tpl({ type: type, value: value, number: number, tip: tip }, function () {/*

  <div class="col-lg-{number}">
           <img src="{value}" class="img-{type}">    
  </div>

 */});
    }

    var ButtonTpl = function (id, label, num, color, onclick) {
        //debugger
        color = check(color, Color.red);
        if (!$.hasValue(onclick)) {
            onclick = function () { };
        }

        var offset = 0;
        var number = 1;
        //debugger
        if (("" + num).indexOf(':') > -1) {
            var temp = num.split(':');

            number = temp[0];
            offset = temp[1];
        } else {
            number = num;
            number = 12 / number;
        }
        return $.qx_tpl({ id: id, label: label, number: number, offset: offset, color: color, onclick: (onclick !== undefined) ? onclick.toString() : "" }, function () {/*

     <div class="col-lg-{number} col-lg-offset-{offset}">
            <button type="button" class="btn btn-{color}" id="{id}">{label}</button>
     </div>
     <script type="text/javascript">
      var bObj=document.getElementById("{id}");
      bObj.onclick={onclick};
     </script>

 */});
    }

    var TabTpl = function (tabId, cfg, num) {
        var subTitle = "";
        var subContent = "";
        for (var i = 0; i < cfg.length; i++) {
            var id = $.random();
            subTitle += '<li class="' + (i === 0 ? 'active' : '') + '"><a href="#' + id + '" data-toggle="tab" aria-expanded="false">' + cfg[i].title + '</a></li>';
            subContent += ' <div class="tab-pane fade ' + (i === 0 ? 'active in' : '') + '" id="' + id + '">' + _render(cfg[i].content) + '</div>';
        }

        var number = 12 / check(num, 1);
        return $.qx_tpl({ id: tabId, subTitle: subTitle, subContent: subContent, number: number }, function () {/*
 
             <div id="{id}" class="col-lg-{number}">
                   <ul class="nav nav-tabs">
                        {subTitle}
                    </ul>
                    <div class="tab-content">
                        
                             {subContent}
                    </div>
             </div>

 */});
    }

    var GroupTpl = function (id, html, title, num) {
        var formContent = "";
        formContent += _render(html);
        var number = 12 / check(num, 1);

        return $.qx_tpl({ id: id, title: title, formContent: formContent, number: number }, function () {/*
 
             <div id="{id}" class="col-lg-{number}">
                   <div class="row">  
                        <div class="list-group">
                               <a href="#" class="list-group-item active">
                                  <h4 class="list-group-item-heading">
                                    {title}
                                   </h4>
                               </a>
                              <div class="list-group-item list-group-item-heading">
                                  <div class="row">  
                                       {formContent}
                                  </div>
                              </div>
                          </div>
                    </div>  
             </div>

 */});
    }

    var PreTpl = function PreTpl(id, code, num) {
        var number = 12 / check(num, 1);
        return $.qx_tpl({ id: id, code: code, number: number }, function () {/*
 
         <div id="{id}" class="col-lg-{number}">
              <div class="form-group">
                 <label>代码</label>
                 <pre>{code}</pre>
              </div>
         </div>

 */});
    }

    var DropDownTpl = function (id, label, li, num, color) {
        var number = 12 / check(num, 6);
        color = check(color, Color.blue);
        var liHtml = new Array();

        for (var i = 0; i < li.length; i++) {
            liHtml.push('<li role="presentation"><a role="menuitem" data-baseurl="' +
                li[i].value + '" id="' +
                li[i].id + '" data-url="' +
                li[i].value + '" class="qx-menu" data-title="' +
                li[i].text + '">' + li[i].text + '</a></li>');
        }

        //$.log(liHtml)
        return $.qx_tpl({ id: id, label: label, liHtml: liHtml.join(''), color: color, number: number }, function () {/*

    <div  id="{id}" class="col-lg-{number}">
       <div class="btn-group">
	    <button type="button" class="btn btn-{color} dropdown-toggle" 
			    data-toggle="dropdown">
		    {label} <span class="caret"></span>
	    </button>
	    <ul class="dropdown-menu" role="menu">
		    {liHtml}
	    </ul>
       </div>
    </div>

       <script>
            InitMenuEvent('#{id} .qx-menu')
       </script>

 */});
    }

    var PanelTpl = function (id, title, body, footer, color, num) {
        color = check(color, Color.red);
        footer = check(footer, "");
        var number = 12 / check(num, 1);
        //debugger 
        return $.qx_tpl({ id: id, title: title, body: _render(body), footer: footer, color: color, number: number }, function () {/*
 
            
    <div  id="{id}" class="col-lg-{number}">
         <div class="panel panel-{color}">
            <div class="panel-heading">
                <h3 class="panel-title">
                    {title}
                </h3>
            </div>
            <div class="panel-body">
                {body}
            </div>
            <div class="panel-footer">
                {footer}
            </div>
        </div>
    </div>

 */});
    }

    var ListGroupTpl = function (id, title, libody, num) {
        var number = 12 / check(num);
        var liHtml = new Array();
        for (var i = 0; i < libody.length; i++) {
            liHtml.push('<a href="#" class="list-group-item"><h4 class="list-group-item-heading">' + libody[i].title +
                '</h4><p class="list-group-item-text">' + libody[i].body + '</p></a>');
        }
        return $.qx_tpl({ id: id, title: title, liHtml: liHtml.join(""), number: number }, function () {/*
 
            
    <div id="{id}" class="col-lg-{number}">
         <div class="list-group">
            <a href="#" class="list-group-item active">
                <h4 class="list-group-item-heading">
                    {title}
                </h4>
            </a>
            {liHtml}
        </div>
    </div>

 */});
    }

    var MediaTpl = function (id, imgurl, header, text, num) {
        var number = 12 / check(num);
        return $.qx_tpl({ id: id, imgurl: imgurl, header: header, text: text, number: number }, function () {/*
 
            
    <div id="{id}" class="col-lg-{number}">
         <div class="media">
            <a class="media-left" href="#">
                <img class="media-object" src="{imgurl}"
                     alt="媒体对象">
            </a>
            <div class="media-body">
                <h4 class="media-heading">{header}</h4>
                {text}
            </div>
        </div>
    </div>

 */});
    }

    var AlertTpl = function (id, text, num, color) {
        var number = 12 / check(num, 1);
        return $.qx_tpl({ id: id, text: text, number: number, color: color }, function () {/*
 
            
    <div id="{id}" class="col-lg-{number}">
         <div class="alert alert-{color} alert-dismissable">
	        <button type="button" class="close" data-dismiss="alert"
			        aria-hidden="true">
		        &times;
	        </button>
	        {text}
        </div>
    </div>

 */});
    }

    var ThumbNailTpl = function (id, imgurl, body, num) {
        var number = 12 / check(num);
        return $.qx_tpl({ id: id, imgurl: imgurl, body: body, number: number }, function () {/*
 
            
    <div id="{id}" class="col-lg-{number}">
         <div class="thumbnail">
            <img src="{imgurl}"
             alt="通用的占位符缩略图"/>
            <div class="caption">
                {body}
            </div>
         </div>
    </div>

 */});
    }

    var PageHeaderTpl = function (id, title, subtitle, num) {
        var number = 12 / check(num);
        return $.qx_tpl({ id: id, title: title, subtitle: subtitle, number: number }, function () {/*
 
            
    <div id="{id}" class="col-lg-{number}">
         <div class="page-header">
            <h1>{title}
                <small>{subtitle}</small>
            </h1>
        </div>
    </div>

 */});
    }

    var CarouselTpl = function (id, imageUrl, num) {
        //console.log(imageUrl);
        var number = 12 / check(num, 1);
        var liHtml = new Array();
        var imgHtml = new Array();
        for (var i = 0; i < imageUrl.length; i++) {
            liHtml.push('<li data-target="#myCarousel" data-slide-to="' + i + '" class="' + (i === 0 ? "active" : "") + '"></li>');
            imgHtml.push('<div class="item ' + (i === 0 ? "active" : "") + '"><img src="' + imageUrl[i].imgurl + '"><div class="carousel-caption">标题' + (i) + ' </div></div>  ');
        }

        return $.qx_tpl({ id: id, liHtml: liHtml.join(""), imgHtml: imgHtml.join(""), number: number }, function () {/*
 
            
    <div id="{id}"  class="col-lg-{number}">
        <div id="myCarousel" class="carousel slide">
            <!-- 轮播（Carousel）指标 -->
            <ol class="carousel-indicators">
               {liHtml}
            </ol>
            <!-- 轮播（Carousel）项目 -->
            <div class="carousel-inner">
                {imgHtml}
            </div>
            <!-- 轮播（Carousel）导航 -->
            <a class="carousel-control left" href="#myCarousel"
               data-slide="prev">
                &lsaquo;
            </a>
            <a class="carousel-control right" href="#myCarousel"
               data-slide="next">
                &rsaquo;
            </a>
        </div>
    </div>

 */});
    }
    var FileUploadTpl3rd = function (label, name, num, folder, url) {
        folder = check(folder, "/userfiles/uploads/files/");
        url = check(url, "http://upload.qiniu.com/");
        var number = 12 / check(num, 2);
        return $.qx_tpl({ label: label, name: name, url: url, folder: folder, number: number }, function () {/*
       <input type="hidden" name="{name}" id="{name}">
      <div class="col-lg-{number}" style="">
        <div class="form-group">
            <label>{label}</label>
            
        <div class="hide" id="closeBox-{name}">
            <div class="row fileupload-buttonbar">
                <div class="col-lg-12">
            
                    <button type="button" class="btn btn-info" id="showButton-{name}">
                        <i class="glyphicon glyphicon-chevron-down"></i>
                        <span>展开{label}</span>
                    </button>
                </div>
                <!-- The global progress state -->
            </div>
        </div>

        <div class="" id="mainBox-{name}">
            <form id="fileupload-{name}" action="http://upload.qiniu.com/" method="post" enctype="multipart/form-data">
              <input name="key" type="hidden" value="<resource_key>">
              <input name="x:<custom_name>" type="hidden" value="<custom_value>">
              <input name="token" type="hidden" value="<upload_token>">
              <input name="crc32" type="hidden" />
              <input name="accept" type="hidden" />
             

               <input type="hidden" name="folder"  value="{folder}">
               <input type="hidden" name="controlName" value="{name}">

                <div class="row fileupload-buttonbar">
                    <div class="col-lg-12">
                 
                        <span class="btn btn-success fileinput-button">
                            <i class="glyphicon glyphicon-plus"></i>
                            <span>添加{label}</span>
                             <input name="file" type="file" />
                        </span>
                        <button type="submit" class="btn btn-primary start hide" id="startButton-{name}">
                            <i class="glyphicon glyphicon-upload"></i>
                            <span>开始上传</span>
                        </button>
                        <button type="button" class="btn btn-info hide" id="tagButton-{name}">
                            <i class="glyphicon glyphicon-chevron-up"></i>
                            <span>全部折叠</span>
                        </button>
                        <input type="checkbox" class="toggle hide" id="checkboxButton-{name}">
                        <!-- The global file processing state -->
                        <span class="fileupload-process"></span>
                    </div>
              
                   
                </div>
              
                <table role="presentation" class="table table-striped"><tbody class="files"></tbody></table>
            </form>


        </div>
      
        <div id="blueimp-gallery" class="blueimp-gallery blueimp-gallery-controls" data-filter=":even">
            <div class="slides"></div>
            <h3 class="title"></h3>
            <a class="prev">‹</a>
            <a class="next">›</a>
            <a class="close">×</a>
            <a class="play-pause"></a>
            <ol class="indicator"></ol>
        </div>
   

        </div> 
    </div>    
    <script>
         //初始化
         initFile('{name}','{url}','{folder}');
    </script>

 */});
    }
    var FileUploadTpl = function (label, name, num, folder, url) {
        folder = check(folder, "/userfiles/uploads/files/");
        url = check(url, "/open/upload");
        var number = 12 / check(num, 2);
        return $.qx_tpl({ label: label, name: name, url: url, folder: folder, number: number }, function () {/*
       <input type="hidden" name="{name}" id="{name}">
      <div class="col-lg-{number}" style="">
        <div class="form-group">
            <label>{label}</label>
            
        <div class="hide" id="closeBox-{name}">
            <div class="row fileupload-buttonbar">
                <div class="col-lg-12">
            
                    <button type="button" class="btn btn-info" id="showButton-{name}">
                        <i class="glyphicon glyphicon-chevron-down"></i>
                        <span>展开{label}</span>
                    </button>
                </div>
                <!-- The global progress state -->
            </div>
        </div>

        <div class="" id="mainBox-{name}">
            <form id="fileupload-{name}" action="" method="POST" enctype="multipart/form-data">
               <input type="hidden" name="folder"  value="{folder}">
             <input type="hidden" name="controlName" value="{name}">
                <div class="row fileupload-buttonbar">
                    <div class="col-lg-12">
                 
                        <span class="btn btn-success fileinput-button">
                            <i class="glyphicon glyphicon-plus"></i>
                            <span>添加{label}</span>
                            <input type="file" name="files[]" multiple>
                        </span>
                        <button type="submit" class="btn btn-primary start hide" id="startButton-{name}">
                            <i class="glyphicon glyphicon-upload"></i>
                            <span>开始上传</span>
                        </button>
                        <button type="button" class="btn btn-info hide" id="tagButton-{name}">
                            <i class="glyphicon glyphicon-chevron-up"></i>
                            <span>全部折叠</span>
                        </button>
                        <input type="checkbox" class="toggle hide" id="checkboxButton-{name}">
                        <!-- The global file processing state -->
                        <span class="fileupload-process"></span>
                    </div>
              
                   
                </div>
              
                <table role="presentation" class="table table-striped"><tbody class="files"></tbody></table>
            </form>


        </div>
      
        <div id="blueimp-gallery" class="blueimp-gallery blueimp-gallery-controls" data-filter=":even">
            <div class="slides"></div>
            <h3 class="title"></h3>
            <a class="prev">‹</a>
            <a class="next">›</a>
            <a class="close">×</a>
            <a class="play-pause"></a>
            <ol class="indicator"></ol>
        </div>
   

        </div> 
    </div>    
    <script>
         //初始化
         initFile('{name}','{url}','{folder}');
    </script>

 */});
    }

    var FileItemTpl = function (item, name, canDelete) {
        item.remove = true;
        //$.warn(item);
        var savedUrl = item.url; var id = $.random();
        item.url = $.url((item.url.indexOf("-split-") > -1) ? encodeURI(item.url) : "");
        item.name = $.hasValue(item.name) ? item.name : $.getFileName(item.url);
        return ' <tr id="' + id + '" class="template-download fade in">' +
            '<td><input type="checkbox" name="delete" value="1" class="toggle"><span class="preview"> </span></td>' +//复选框
            '<td><p class="name"><a target="_blank" href="' + item.url + '" download="' + item.name + '">' + item.name + '</a></p></td>' +//文件名
            '<td><span class="size">' + ($.hasValue(item.size) ? item.size : "") + '</span></td>' +//文件大小
            '<td><a href="' + item.url + '" download="' + item.name + '" class="btn btn-primary"><i class="glyphicon glyphicon-download-alt"></i><span>下载</span></a>&nbsp;' +//下载按钮
            (canDelete ? '<a onclick=\'deleteFile("/open/Delete?savedPath=' + savedUrl + '","' + id + '","' + name + '", "' + savedUrl + '")\' class="btn btn-danger"><i class="fa fa-remove"></i><span>删除</span></a>' : '') +//删除按钮
            '</td></tr>';//deleteFile(fileUrl, selector, controlName, savedPath)
    }

    var FileItemsTpl = function (files, name, canDelete) {
        //debugger 
        if (!$.hasValue(files)) {
            files = [];
        }
        if (!$.isArray(files)) {
            var temp = [];	//自动转换字符串为数组
            var fileArray = files.split(';');
            for (var i = 0; i < fileArray.length; i++) {
                if ($.hasValue(fileArray[i])) {
                    temp.push({ url: fileArray[i], name: $.getFileName(fileArray[i]) });
                }
            }
            files = temp;
        }
        var bodyHtml = "";
        for (var i = 0; i < files.length; i++) {
            bodyHtml += FileItemTpl(files[i], name, canDelete);
        }
        return bodyHtml;
    }

    var ShowFileTpl = function (id, label, files, num) {
        var oldValue = files;
        //没有文件直接终止
        //if (($.isArray(files)&&files.length == 0)||!$.hasValue(files)) {
        //	return "";
        //}
        //读取旧值
        if ($.isArray(files)) {
            oldValue = files.join(';');
        }
        //debugger
        var number = 12 / check(num, 2); $.log(files);
        return $.qx_tpl({ id: id, label: label, bodyHtml: FileItemsTpl(files, id), number: number, oldValue: oldValue }, function () {/*
 
 <div class="col-lg-{number}">
    <div class="form-group">
    <input  value="{oldValue}"  id="{id}" name="{id}" type="hidden"  >
        <label>{label}</label>
        <div class="hide" id="closeBox-busyness-{id}">
            <div class="row fileupload-buttonbar">
                <div class="col-lg-12">
                    <button type="button" class="btn btn-info" id="showButton-busyness">
                        <i class="glyphicon glyphicon-chevron-down"></i>
                        <span>展开{label}</span>
                    </button>
                </div>
            </div>
        </div>
        <div  id="mainBox-busyness-{id}">       
           
                <table role="presentation" class="table table-striped" id="fileupload-{id}">
                    <tbody class="files" >
                   {bodyHtml}
                    </tbody>
                </table>
        </div>
     </div>
    </div>
 */});
    }

    var HideTpl = function (name, value) {

        value = check(value, "");

        return $.qx_tpl({ name: name, value: value }, function () {/*

          <input class="form-control" value="{value}"  id="{name}" name="{name}" type="hidden"  >

 */});
    }

    var TableTpl = function (header, body, num, id) {
        //debugger 
        id = check(id, $.random());
        var number = 12 / check(num, 1);
        var tableScript = "";

        var bodyHtml = "";
        var headerHtml = "";
        if ($.hasValue(body) && $.isString(body) && !$.hasValue(header)) {
            //传入的是url
            tableScript = "<script>head.ready(function(){$.fillTable('" + id + "','" + body + "')})</script>";
        } else {
            header = check(header, []);


            if ($.hasValue(body) && !$.isArray(body)) {
                body = [body];
            }
            bodyHtml = "<tbody>";
            for (var j = 0; j < body.length; j++) {
                bodyHtml += '<tr>';
                if (!$.isArray(body[j])) {//兼容非数组的对象
                    var _arr = $.toArray(body[j]);
                    body[j] = _arr.v;//对象转数组
                    if (header.length === 0) {
                        header = _arr.p;//自动给标题赋值
                    }
                }
                for (var k = 0; k < body[j].length; k++) {
                    bodyHtml += '<td>' + body[j][k] + '</td>';
                }
                bodyHtml += '</tr>';
            }
            bodyHtml += "</tbody>";

            headerHtml = "<thead> <tr>";
            if (header.length === 0 && body.length === 0) {
                header.push("无数据");
            }
            for (var i = 0; i < header.length; i++) {
                headerHtml += '<th>' + header[i] + '</th>';
            }
            headerHtml += "</tr></thead>";
        }


        return $.qx_tpl({ id: id, bodyHtml: bodyHtml, headerHtml: headerHtml, number: number, tableScript: tableScript }, function () { /*
   
   <div class="col-lg-{number}" id="{id}">
                <div class="table-responsive">
                    <table class="table table-bordered table-hover table-striped">
                        {headerHtml}
                       <div id="{id}-content">
					    {bodyHtml}
					   </div>
                    </table>
                </div>
    </div>
	{tableScript}
        */ });
    }

    var CovertToUI = function (src) {
        var data = {};
        data.model = {};
        data.fields = [];
        data.option = {};
        data.option.title = src.TypeName;
        data.option.source = "";

        for (var i = 0; i < src.Columns.length; i++) {
            data.fields.push({
                type: src.Columns[i].PageControlName,
                label: src.Columns[i].ColumnName,
                name: src.Columns[i].ColumnID,
                value: src.Columns[i].Value,
                num: 4,//数据源无
                tip: "输入" + src.Columns[i].ColumnName
                //validators: { int:true}
            });
        }
        return data;

    }


    this.FileItemsTpl = function (files, name, canDelete) {

        if (!$.hasValue(files)) {
            files = [];
        }
        if (!$.isArray(files)) {
            var temp = [];	//自动转换字符串为数组
            var fileArray = files.split(';');
            for (var i = 0; i < fileArray.length; i++) {
                if ($.hasValue(fileArray[i])) {
                    temp.push({ url: fileArray[i], name: $.getFileName(fileArray[i]) });
                }
            }
            files = temp;
        }



        var bodyHtml = "";
        for (var i = 0; i < files.length; i++) {
            bodyHtml += FileItemTpl(files[i], name, canDelete);
        }
        return bodyHtml;
    }

    this.ShowFileTpl = function (id, label, files, num) {
        var oldValue = files;
        //没有文件直接终止
        //if (($.isArray(files)&&files.length == 0)||!$.hasValue(files)) {
        //	return "";
        //}
        //读取旧值
        if ($.isArray(files)) {
            oldValue = files.join(';');
        }
        //debugger
        var number = 12 / check(num, 2); $.log(files);
        return $.qx_tpl({ id: id, label: label, bodyHtml: FileItemsTpl(files, id), number: number, oldValue: oldValue }, function () {/*
 
 <div class="col-lg-{number}">
    <div class="form-group">
    <input  value="{oldValue}"  id="{id}" name="{id}" type="hidden"  >
        <label>{label}</label>
        <div class="hide" id="closeBox-busyness-{id}">
            <div class="row fileupload-buttonbar">
                <div class="col-lg-12">
                    <button type="button" class="btn btn-info" id="showButton-busyness">
                        <i class="glyphicon glyphicon-chevron-down"></i>
                        <span>展开{label}</span>
                    </button>
                </div>
            </div>
        </div>
        <div  id="mainBox-busyness-{id}">       
                <div class="row fileupload-buttonbar">
                    <div class="col-lg-12">
                     <input type="checkbox" class="toggle" id="checkboxButton-busyness-{id}">
                        <span class="btn btn-success fileinput-button">
                                    <i class="glyphicon glyphicon-cloud-download"></i>
                                    <span>批量下载</span>
                                </span>
                        <button type="button" class="btn btn-info" id="tagButton-busyness-{id}">
                            <i class="glyphicon glyphicon-chevron-up"></i>
                            <span>全部折叠</span>
                        </button>
                       
                    </div>
                </div>
                <table role="presentation" class="table table-striped" id="fileupload-{id}">
                    <tbody class="files" >
                   {bodyHtml}
                    </tbody>
                </table>
        </div>
     </div>
    </div>
 */});
    }



    this.input = function (label, name, value, num, validators, tip) {
        var dest = InputTpl(label, name, value, num, validators);
        if (!$.hasValue(tip)) {
            //默认提示
            tip = "请输入正确的" + label;
        }
        return push({ id: name, label: label, type: 201, tip: tip, html: dest, validators: validators });

    }

    this.showInput = function (label, name, value, num) {
        var dest = ShowInputTpl(label, name, value, num);
        return push({ id: name, type: 211, html: dest });
    }

    this.time = function (label, name, value, num, tip) {
        var dest = TimeTpl(label, name, value, num, tip);
        return push({ id: name, type: 202, html: dest });
    }

    this.showTime = function (label, name, value, num) {
        var dest = ShowTimeTpl(label, name, value, num);
        return push({ id: name, type: 216, html: dest });
    }

    this.date = function (label, name, value, num, tip) {
        var dest = DateTpl(label, name, value, num, tip);
        return push({ id: name, type: 203, html: dest });
    }

    this.showDate = function (label, name, value, num) {
        var dest = ShowDateTpl(label, name, value, num);
        return push({ id: name, type: 217, html: dest });
    }

    this.select = function (label, name, option, value, num, readonly) {
        var dest = SelectTpl(label, name, option, value, num, readonly);
        return push({ id: name, type: 204, html: dest });
    }

    this.showSelect = function (label, name, option, value, num) {
        var dest = ShowSelectTpl(label, name, option, value, num);
        return push({ id: name, type: 218, html: dest });
    }

    this.radio = function (label, name, items, num, vertical, value) {

        var dest = RadioTpl(label, name, items, num, vertical, value);
        return push({ id: name, type: 205, html: dest });
    }

    this.showRadio = function (label, name, items, num, vertical, value) {

        var dest = ShowRadioTpl(label, name, items, num, vertical, value);
        return push({ id: name, type: 219, html: dest });
    }

    this.editor = function (label, name, value, num, height) {
        var dest = RichBoxTpl(label, name, value, num, height);
        return push({ id: name, type: 206, html: dest });
    }

    this.showEditor = function (label, name, value, num, height) {
        var dest = ShowRichBoxTpl(label, name, value, num, height);
        return push({ id: name, type: 220, html: dest });
    }

    this.checkbox = function (label, name, items, num, vertical, valueArray) {
        var dest = CheckBoxTpl(label, name, items, num, vertical, valueArray);
        return push({ id: name, type: 207, html: dest });
    }

    this.showCheckbox = function (label, name, items, num, vertical, valueArray) {
        var dest = ShowCheckBoxTpl(label, name, items, num, vertical, valueArray);
        return push({ id: name, type: 221, html: dest });
    }

    this._switch = function (label, name, num, value, onText, offText) {
        var dest = SwitchTpl(label, name, num, value, onText, offText);
        return push({ id: name, type: 208, html: dest });
    }

    this.showSwitch = function (label, name, num, value, onText, offText) {
        var dest = ShowSwitchTpl(label, name, num, value, onText, offText);
        return push({ id: name, type: 208, html: dest });
    }

    this.area = function (label, name, value, num, height, validators, tip) {
        var dest = AreaTpl(label, name, value, num, tip, height);
        //  return push({ id: name, type: 209, html: dest });
        return push({ id: name, type: 209, html: dest, label: label, tip: tip, validators: validators });

    }

    this.showArea = function (label, name, value, num, height, validators, tip) {
        var dest = ShowAreaTpl(label, name, value, num, tip, height);
        return push({ id: name, type: 215, html: dest, label: label, tip: tip, validators: validators });

    }

    this.file = function (label, name, num, folder, url) {
        var dest = FileUploadTpl(label, name, num, folder, url);
        return push({ id: name, type: 210, html: dest });
    }
    this.file3rd = function (label, name, num, folder, url) {
        var dest = FileUploadTpl3rd(label, name, num, folder, url);
        return push({ id: name, type: 210, html: dest });
    }

    this.hide = function (name, value) {

        var dest = HideTpl(name, value);


        return push({ id: name, type: 212, html: dest });

    }

    this.hides = function (nameArray, valueArray) {

        var hideArray = [];
        for (var i = 0; i < nameArray.length; i++) {
            hideArray.push(hide(nameArray[i]));
        }
        return push({ id: $.random(), type: 115, html: _render(hideArray) });

    }

    this.hideTime = function (name, value) {
        if (arguments.length > 2 && _c.isDebug) {
            $.alert("警告:请检查页面中hideTime参数是否正确:" + name);
        }
        var dest = (HideTpl(name, value));


        return push({ id: name, type: 223, html: dest });

    }

    this.hideTimes = function (nameArray, valueArray) {

        var hideArray = [];
        for (var i = 0; i < nameArray.length; i++) {
            hideArray.push(hideTime(nameArray[i]));
        }
        return push({ id: $.random(), type: 116, html: _render(hideArray) });

    }

    this.showRichBox = function (label, name, value, num, tip) {
        alert("请修改");
        var dest = ShowRichBoxTpl(label, name, value, num, tip);
        return { id: name, type: 213, html: dest };
    }

    this.showfile = function (label, name, files, num, folder, url) {

        name = $.hasValue(name) ? name : $.random();
        var dest = ShowFileTpl(name, label, files, num);

        return push({ id: name, type: 214, html: dest });
    }

    this.showFile = function (label, name, files, num) {
        return showfile(label, name, files, num);
    }

    this.table = function (body, head, num) {
        var dest = "";
        var id = $.random();
        dest = TableTpl(head, body, num, id);
        return push({ id: id, type: 100, html: dest });
    }

    this.tab = function (contents, num) {
        var id = $.random();
        var dest = TabTpl(id, contents, num);
        return { id: id, type: 104, html: dest };
    }

    this.group = function (html, title, num) {
        var id = $.random();
        var dest = GroupTpl(id, html, title, num);
        return { id: id, type: 105, html: dest };
    }

    this.renderTable = function (cfgArray) {

        if (!$.isArray(cfgArray)) {
            cfgArray = [cfgArray];
        }

        $.each(cfgArray, function (i, o) {
            var cfg = o;
            debugger
            //参数
            var id = cfg.id;
            var head = cfg.head;
            var store = cfg.store;
            var row = cfg.row;

            var num = cfg.num;
            var destBody = [];
            store.query(function (data) {//请求数据
                if (!$.isArray(data)) {
                    data = [data];
                }
                $.each(data, function (i, o) {

                    if ($.hasValue(row)) {
                        var processedRow = row(o, i, data);
                        //解析操作列-最后一个是数组
                        var op = processedRow[processedRow.length - 1];
                        if ($.isArray(op)) {

                            if (head.length === processedRow.length - 1) {
                                head.push("操作");//自动添加操作列
                            }
                            var opHtml = "";
                            $.each(op, function (index, opObj) {
                                opHtml += "<a class='qx-popup operate' data-url='" + opObj.url + "'>" + opObj.text + "</a>&nbsp;&nbsp;";
                            });
                            processedRow.pop(op);
                            processedRow.push(opHtml);
                        }



                        //
                        /*if(!$.hasValue(processedRow)||!$.isArray(processedRow)){
                            $.warn("table的body函数没有返回正确的数组,已跳过索引为"+i+"的数据");
                            continue;
                        }else{
                            o=processedRow;
                        }*/
                        o = processedRow;
                    }
                    destBody.push(o);
                });
                $("#" + id).html(_render(table(destBody, head, num)));

                if (i === cfgArray.length - 1) {
                    // debugger
                    InitPopup(cfg);//最后一个，初始化弹窗 
                }
            });
        });
    }

    //id管理器
    var g_formIdArray = [];

    //初始化页面控件
    this.InitFormControl = function (htmlArray, submiturl, dataUrl, title, overWrite, data) {

        //设置标题
        if ($.hasValue(title)) {
            subSetTitle(title);
        } else {
            //$.alert("请为Form页设置标题,语法如下:<br/>render(htmlArray, submiturl, dataUrl, <span class='red'>title</span>)",2);
        }

        //渲染HTML
        var htmlString = "";
        //debugger
        if (typeof (htmlArray) == "function") {
            htmlString = _render(htmlArray());
        } else {
            htmlString = $.isArray(htmlArray) ? _render(htmlArray) : htmlArray;
        }

        if ($.hasValue(submiturl)) {
            htmlString += canSubmitTpl();
        }
        var body = $('#body');
        if (overWrite === undefined || !overWrite) {
            //debugger
            body.append(htmlString);
        }
        else {
            body.empty();
            body.html(htmlString);
        }

        //-----渲染结束
        var idArray = [];
        for (var k = 0; k < g_formIdArray.length; k++) {
            idArray.push(g_formIdArray[k].id);
        }
        //重复id检测
        var repeatedId = idArray.getdistinct();
        if (repeatedId.length > 0) {
            if (_c.isDebug) {
                $.confirm("检测到表单中存在重复id,是否查看重复id？", function () {
                    $.diy(repeatedId.join("<br/>") + "<br/><p style='color:red'>提示：请务必更正重复id,否则数据提交会出现未知错误!<p>", "重复id如下");
                    return true;
                });
            }
        }
        //赋初值
        if ($.hasValue(data)) {
            //debugger 
            for (var i = 0; i < g_formIdArray.length; i++) {
                var currentId = g_formIdArray[i].id;
                //debugger 
                $.set(currentId, g_formIdArray[i].type, data[currentId]);
            }
        }

        //时间控件
        $(".form_datetime").datetimepicker({
            autoclose: true,
            language: 'zh',
            todayBtn: true,
            initialDate: new Date(),
            todayHighlight: true,
            format: "yyyy-mm-dd hh:ii",
            pickerPosition: 'bottom-left'

        });
        //$.log($(".form_datetime"))
        //日期控件
        $('.form_date').datetimepicker({
            weekStart: 1,
            language: 'zh',
            todayHighlight: true,
            todayBtn: true,
            autoclose: 1,
            initialDate: new Date(),
            startView: 2,
            minView: 2,
            forceParse: 0,
            format: 'yyyy-mm-dd',
            pickerPosition: 'bottom-left'
        });
        //返回按钮
        // $("#back").click(back);
        //初始化验证
        InitValidation(submiturl);
        $.doFunction("formReady");
        //var sb = $("#submit");
        //sb.click(function (e) {
        //    //sb.submit();
        //    submitForm(submiturl);
        //    //setTimeout(function () {
        //    //   // sb.attr("class", ($("#submit").attr("class").replace("disabled", "")));
        //    //    //sb.removeAttr("disabled");

        //    //    e.preventDefault();
        //    //}, 100);       
        //});


    }

    this.getFormData = function () {

        var json = "{";
        for (var i = 0; i < g_formIdArray.length; i++) {
            var currentId = g_formIdArray[i].id;
            var value = $.val(currentId, g_formIdArray[i].type);
            json += "\"" + currentId + "\":" + "\"" + value + "\"";
            if (i === g_formIdArray.length - 1) {
                json += "}";
            } else {
                json += ",";
            }
        }

        var obj = JSON.parse(json);
        obj._json = JSON.stringify(obj);
        $.log(obj);
        return obj;

    }

    /*
    http://www.cnblogs.com/huangcong/p/5335376.html
    http://bv.doc.javake.cn/validators/
    notEmpty：非空验证；
    
    stringLength：字符串长度验证；
    
    regexp：正则表达式验证；
    
    emailAddress：邮箱地址验证（都不用我们去写邮箱的正则了~~）
    
    除此之外，在文档里面我们看到它总共有46个验证类型，我们抽几个常见的出来看看：
    
    base64：64位编码验证；
    
    between：验证输入值必须在某一个范围值以内，比如大于10小于100；
    
    creditCard：身份证验证；
    
    date：日期验证；
    
    ip：IP地址验证；
    
    numeric：数值验证；
    
    phone：电话号码验证；
    
    uri：url验证；
    
    fields= {
                syllabus_version: {
                    message: 'The username is not valid',
                    validators: {
                        notEmpty: {
                            message: 'The username is required and can\'t be empty'
                        },
                        stringLength: {
                            min: 6,
                            max: 30,
                            message: 'The username must be more than 6 and less than 30 characters long'
                        },
                        regexp: {
                            regexp: /^[a-zA-Z0-9_\.]+$/,
                            message: 'The username can only consist of alphabetical, number, dot and underscore'
                        },
                        different: {
                            field: 'password',
                            message: 'The username and password can\'t be the same as each other'
                        }
                    }
                },
                syllabus_name: {
                    validators: {
                        notEmpty: {
                            message: 'The email address is required and can\'t be empty'
                        },
                        emailAddress: {
                            message: 'The input is not a valid email address'
                        }
                    }
                },
                syll_author: {
                    validators: {
                        notEmpty: {
                            message: 'The password is required and can\'t be empty'
                        },
                        identical: {
                            field: 'confirmPassword',
                            message: 'The password and its confirm are not the same'
                        },
                        different: {
                            field: 'username',
                            message: 'The password can\'t be the same as username'
                        }
                    }
                },
                confirmPassword: {
                    validators: {
                        notEmpty: {
                            message: 'The confirm password is required and can\'t be empty'
                        },
                        identical: {
                            field: 'password',
                            message: 'The password and its confirm are not the same'
                        },
                        different: {
                            field: 'username',
                            message: 'The password can\'t be the same as username'
                        }
                    }
                },
                captcha: {
                    validators: {
                        callback: {
                            message: 'Wrong answer',
                            callback: function (value, validator) {
                                var items = $('#captchaOperation').html().split(' '), sum = parseInt(items[0]) + parseInt(items[2]);
                                return value == sum;
                            }
                        }
                    }
                }
            }
    */

    this.InitValidation = function (submiturl) {
        //debugger 
        if (g_valitacionString.length > 0) { //清除最后一个,
            //debugger
            g_valitacionString = g_valitacionString.substring(0, g_valitacionString.length - 1);
            g_valitacionString = '{' + g_valitacionString + '}';
            var fields = JSON.parse(g_valitacionString);
            $.log(fields);
            $('#form').bootstrapValidator({
                message: '输入不正确',
                feedbackIcons: {
                    valid: 'glyphicon glyphicon-ok',
                    invalid: 'glyphicon glyphicon-remove',
                    validating: 'glyphicon glyphicon-refresh'
                },
                submitButtons: '#bt_submit',
                fields: fields
            }).on('success.form.bv', function (e) {
                // Prevent form submission
                e.preventDefault();
                submitForm(submiturl);
            });;
        } else {
            $("#form").attr('novalidate', 'novalidate').on('submit', function (e) {
                // //debugger
                e.preventDefault();
                submitForm(submiturl);
                //return false; 
            });
        }

        //重写提交事件onsubmit="return check()"
        //$("#form").
        //    attr('novalidate', 'novalidate')//.
        //attr('onsubmit', 'return submitForm("'+submiturl+'")');

        //document.getElementById("form").
        //   addEventListener("submit", function () {
        //      //debugger
        //        return false;
        //        submitForm(submiturl);
        //    });
    };

    this.submitForm = function (submiturl, doAfterSuccess) {
        //var validItems = $("small");
        //for (var i = 0; i < validItems.length; i++) {
        //    if ($(validItems[i]).css("display") == "block")
        //    {
        //        $.alert("输入不符合要求，请根据页面提示进行修改");
        //        return false;
        //    }  
        //}
        //抓取页面数据
        var fdata = getFormData();

        //解析提交地址
        //debugger
        var url = "";
        if (submiturl === "*") {
            url += $.getsubmiturl();
        } else {
            url += $.hasValue(submiturl) ? submiturl : $.getsubmiturl();
        }
        $.Ajax({
            url: url, //调用WebService的地址和方法名称组合 ---- WsURL/方法名
            data: fdata,         //这里是要传递的参数,格式为 data: "{paraName:paraValue}",下面将会看到      
            success: function (data, code, msg, url) {     //回调函数,result,返回值
                if ($.hasValue(doAfterSuccess)) {
                    if (code == 2 || code == -1) {
                        $.alert(msg);
                    } else {
                        doAfterSuccess(data, code, msg, url);
                    }

                    return;
                }
                $.dealAjax(data, code, msg, url);
                InitWorkFlow();//刷新待办
                //debugger 
            }
        });
        $("#bt_close").focus();
    }

    //验证规则串
    var g_valitacionString = "";

    this.push = function (obj) {
        if (obj.type > 200 && obj.type < 300) {
            if (obj.type == 201 || obj.type == 202 || obj.type == 203 || obj.type == 209) {
                //判断是否需要验证
                if (typeof obj.validators != "undefined") {
                    //处理FastConfig同时兼容旧版本
                    if (typeof obj.validators == "string") {
                        var reg = obj.validators;
                        obj.validators = {};
                        if (reg.length > 0) {
                            obj.validators.regexp = {
                                regexp: reg,
                                message: obj.tip
                            }
                        }

                    }
                    //自动添加非空验证
                    obj.validators.notEmpty = {
                        message: $.hasValue(obj.tip) ? obj.tip : obj.label + ' 是必填项'
                    }

                    if (obj.validators.max != undefined) {
                        obj.validators.stringLength = {
                            max: obj.validators.max,
                            message: $.hasValue(obj.tip) ? obj.tip : obj.label + '输入的最大长度为' + obj.validators.max + '个字符'
                        }
                    }
                    if (obj.validators.min != undefined) {
                        obj.validators.stringLength = {
                            min: obj.validators.min,
                            message: $.hasValue(obj.tip) ? obj.tip : obj.label + '要求至少输入' + obj.validators.max + '个字符'
                        }
                    }
                    if (obj.validators.max != undefined && obj.validators.min != undefined) {
                        obj.validators.stringLength = {
                            min: obj.validators.min,
                            max: obj.validators.max,
                            message: $.hasValue(obj.tip) ? obj.tip : obj.label + '要求输入' + obj.validators.min + '-' + obj.validators.max + '个字符'
                        }
                    }
                    if (obj.validators.email != undefined) {
                        obj.validators.emailAddress = {
                            message: $.hasValue(obj.tip) ? obj.tip : obj.label + '要求输入正确邮箱地址,如：123@sever.com'
                        }
                    }
                    if (obj.validators.idno != undefined) {
                        obj.validators.regexp = {
                            regexp: "^(\\d{6})(\\d{4})(\\d{2})(\\d{2})(\\d{3})([0-9]|X)$",
                            message: obj.tip + ",必须为18位"
                        }
                    }
                    if (obj.validators.float != undefined) {
                        obj.validators.regexp = {
                            regexp: "^(-?\\d+)(\\.\\d+)?$",
                            message: obj.tip + ",如1.2"
                        }
                    }
                    if (obj.validators.pfloat != undefined) {
                        obj.validators.regexp = {
                            regexp: "^[1-9]\\d*\\.\\d*|0\\.\\d*[1-9]\\d*$",
                            message: obj.tip + ",如1.2"
                        }
                    }
                    if (obj.validators.nfloat != undefined) {
                        obj.validators.regexp = {
                            regexp: "^-[1-9]\\d*\\.\\d*|-0\\.\\d*[1-9]\\d*$",
                            message: obj.tip + ",如-1.2"
                        }
                    }
                    if (obj.validators.int != undefined) {
                        obj.validators.regexp = {
                            regexp: "^-?[1-9]\\d*$",
                            message: obj.tip + ",如6"
                        }
                    }
                    if (obj.validators.pint != undefined) {
                        obj.validators.regexp = {
                            regexp: "^[1-9]\\d*$",
                            message: obj.tip + ",如6"
                        }
                    }
                    if (obj.validators.nint != undefined) {
                        obj.validators.regexp = {
                            regexp: "^-[1-9]\\d*$",
                            message: obj.tip + ",如-6"
                        }
                    }
                    if (obj.validators.mobile != undefined) {
                        obj.validators.regexp = {
                            regexp: "^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\\d{8}$",
                            message: obj.tip + ",如155****7595"
                        }
                    }
                    //拼接对象
                    g_valitacionString += '"' + obj.id + '":' +
                        '{"validators":' +
                        JSON.stringify(obj.validators) +
                        '},';
                }

            }
            g_formIdArray.push({ id: obj.id, type: obj.type });
        }
        return obj;
    }

    //form界面渲染入口
    this.render = function (htmlArray, submiturl, dataUrl, title, overWrite) {
        if ($.isFunction(htmlArray)) {
            htmlArray = htmlArray();
        }
        if ($.isObject(htmlArray) && !$.hasValue(submiturl)) {
            //debugger
            render2(htmlArray);
            return;
        }

        if ($.isString(htmlArray) && !$.hasValue(submiturl)) {

            $.ajax({
                url: $.url("/open/gettable?id=" + htmlArray, true),
                success: function (data) {
                    //debugger
                    render2(CovertToUI(data));
                }
            });
            return;
        }

        //是否有绑定值
        if ($.hasValue(dataUrl)) {
            // var url = $.url($.getsubmiturl());
            $.Ajax({
                url: dataUrl, //参数1
                // data: q,
                success: function (data, code, msg, url) {
                    //debugger
                    if ($.isArray(data) && data.length > 0) {
                        data = data[0]; //取单行记录
                    } else if (!$.hasValue(data)) {
                        $.warn("从" + url + "获取的数据为空");
                    }
                    $.log(data);
                    model = data;

                    InitFormControl(htmlArray, submiturl, dataUrl, title, overWrite, data);
                }
            });
        } else {
            InitFormControl(htmlArray, submiturl, dataUrl, title, overWrite);
        }
    }

    function render2(formConfig) {
        //debugger
        var htmlArray = [];
        var fields = formConfig.fields;
        var option = formConfig.option;
        var dataUrl = option.source;
        for (var i = 0; i < fields.length; i++) {
            var htmlObj = "";
            var cfg = fields[i];
            switch (cfg.type) {
            case "input":
                {
                    htmlObj = qx.form.input(cfg.label, cfg.name, cfg.value, cfg.num, cfg.tip, cfg.reg);
                }
                break;
            case "showinput":
                {
                    htmlObj = qx.form.showInput(cfg.label, cfg.name, cfg.value, cfg.num);
                }
                break;
            case "time":
                {
                    htmlObj = qx.form.time(cfg.label, cfg.name, cfg.value, cfg.num, cfg.tip);
                }
                break;
            case "showTime":
                {
                    htmlObj = qx.form.showTime(cfg.label, cfg.name, cfg.value, cfg.num);
                }
                break;
            case "date":
                {
                    htmlObj = qx.form.date(cfg.label, cfg.name, cfg.value, cfg.num, cfg.tip);
                }
                break;
            case "showDate":
                {
                    htmlObj = qx.form.showDate(cfg.label, cfg.name, cfg.value, cfg.num);
                }
                break;
            case "select":
                {
                    htmlObj = qx.form.select(cfg.label, cfg.name, cfg.option, cfg.value, cfg.num, cfg.readonly);
                }
                break;
            case "showSelect":
                {
                    htmlObj = qx.form.showSelect(cfg.label, cfg.name, cfg.option, cfg.value, cfg.num);
                }
                break;
            case "radio":
                {
                    htmlObj = qx.form.radio(cfg.label, cfg.name, cfg.items, cfg.num, cfg.vertical, cfg.value);
                }
                break;
            case "showRadio":
                {
                    htmlObj = qx.form.showRadio(cfg.label, cfg.name, cfg.items, cfg.num, cfg.vertical, cfg.value);
                }
                break;
            case "editor":
                {
                    htmlObj = qx.form.editor(cfg.label, cfg.name, cfg.value, cfg.num, cfg.height);
                }
                break;
            case "showEditor":
                {
                    htmlObj = qx.form.showEditor(cfg.label, cfg.name, cfg.value, cfg.num, cfg.height);
                }
                break;
            case "checkbox":
                {
                    htmlObj = qx.form.checkbox(cfg.label, cfg.name, cfg.items, cfg.num, cfg.vertical, cfg.valueArray);
                }
                break;
            case "showCheckbox":
                {
                    htmlObj = qx.form.showCheckbox(cfg.label, cfg.name, cfg.items, cfg.num, cfg.vertical, cfg.valueArray);
                }
                break;
            case "_switch":
                {
                    htmlObj = qx.form._switch(cfg.label, cfg.name, cfg.num, cfg.value, cfg.onText, cfg.offText);
                }
                break;
            case "showSwitch":
                {
                    htmlObj = qx.form.showSwitch(cfg.label, cfg.name, cfg.num, cfg.value, cfg.onText, cfg.offText);
                }
                break;
            case "area":
                {
                    htmlObj = qx.form.area(cfg.label, cfg.name, cfg.value, cfg.num, cfg.height, cfg.validators, cfg.tip);
                }
                break;
            case "showArea":
                {
                    htmlObj = qx.form.showArea(cfg.label, cfg.name, cfg.value, cfg.num, cfg.height, cfg.validators, cfg.tip);
                }
                break;
            case "file":
                {
                    htmlObj = qx.form.file(cfg.label, cfg.name, cfg.num, cfg.folder, cfg.url);
                }
                break;
            case "showfile":
                {
                    htmlObj = qx.form.showfile(cfg.label, cfg.name, cfg.files, cfg.num, cfg.folder, cfg.url);
                }
                break;
            case "image":
                {
                    htmlObj = qx.form.image(cfg.imType, cfg.value, cfg.num, cfg.tip);
                }
                break;
            case "button":
                {
                    htmlObj = qx.form.button(cfg.label, cfg.num, cfg.color, cfg.onclick);
                }
                break;
            case "tab":
                {
                    htmlObj = qx.form.tab(cfg.contents, cfg.num);
                }
                break;
            case "pre":
                {
                    htmlObj = qx.form.pre(cfg.code, cfg.num);
                }
                break;
            case "dropdown ":
                {
                    htmlObj = qx.form.dropdown(cfg.label, cfg.li, cfg.color, cfg.num);
                }
                break;
            case "panel":
                {
                    htmlObj = qx.form.panel(cfg.title, cfg.body, cfg.num, cfg.color, cfg.footer);
                }
                break;
            case "listgroup":
                {
                    htmlObj = qx.form.listgroup(cfg.title, cfg.libody, cfg.num);
                }
                break;
            case "media":
                {
                    htmlObj = qx.form.media(cfg.imgurl, cfg.header, cfg.text, cfg.num);
                }
                break;
            case "_alert":
                {
                    htmlObj = qx.form.alert(cfg.text, cfg.num, cfg.color);
                }
                break;
            case "thumbnail":
                {
                    htmlObj = qx.form.thumbnail(cfg.imgurl, cfg.body, cfg.num);
                }
                break;
            case "pageheader":
                {
                    htmlObj = qx.form.pageheader(cfg.title, cfg.subtitle, cfg.num);
                }
                break;
            case "carousel":
                {
                    htmlObj = qx.form.carousel(cfg.imgUrl, cfg.num);
                }
                break;
            case "html":
                {
                    htmlObj = qx.form.html(cfg.html);
                }
                break;
            case "hide":
                {
                    htmlObj = qx.form.hide(cfg.name, cfg.value);
                }
                break;
            case "hides":
                {
                    htmlObj = qx.form.hides(cfg.nameArray, cfg.valueArray);
                }
                break;
            case "hideTime":
                {
                    htmlObj = qx.form.hideTime(cfg.name, cfg.value);
                }
                break;
            case "hideTimes":
                {
                    htmlObj = qx.form.hideTimes(cfg.nameArray, cfg.valueArray);
                }
                break;
            }
            htmlArray.push(htmlObj);
        }

        //是否有绑定值
        if ($.hasValue(dataUrl)) {

            $.Ajax({
                url: dataUrl, //参数1
                data: q,
                success: function (data, code, msg, url) {

                    formConfig.model = data;
                    $.log(formConfig.model);
                    InitFormControl(htmlArray, formConfig.model.target, dataUrl, option.title, option.overWrite, formConfig.model);
                }
            });
        } else {
            InitFormControl(htmlArray, formConfig.model.target, dataUrl, option.title, option.overWrite);
        }

    }

    this._render = function (htmlArray) {
        var htmlString = "";
        if (!$.isArray(htmlArray) && $.isObject(htmlArray)) {
            htmlArray = [htmlArray];
        }
        for (var i = 0; i < htmlArray.length; i++) {
            var _html = htmlArray[i].html;
            htmlString += _html == undefined ? htmlArray[i] : _html;

        }
        return htmlString;
    }

    //form入口
    this.InitForm = function (id) {
       
        if (!$.hasValue(id)) {
            $.warn("参数错误:没有指定目标form！"); return;
        }
        id = _c.route(id);
        var jsurl = id;//页面
        
        if (id.indexOf("?") > -1) {
            jsurl = id.substring(0, id.indexOf("?"));
            var param = id.substring(id.indexOf("?"));//取出参数部分
            q = $.qall(param);//给form页赋参数
        }
    
        jsurl=(srcurl(jsurl + ".js", "/views/form/"));
        $.ajax({
            url: jsurl,
            success: function () {
                //head.load($.res(jsurl + ".js"));
            },
            error: function () {
                if (_c.isDebug) {
                    $.alert("未能正确加载界面,请检查项目的web目录下是否存在" + jsurl, 2, back);
                } else {
                    $.alert("加载界面出错,即将返回上一页", 5, back);
                }
            }
        });
        //css
        var cssurl = "";
        var actionName = "";
        var cssIndex = jsurl.lastIndexOf("/");
        
        if (cssIndex> -1) {
            cssurl = jsurl.substring(0, cssIndex);
            actionName = jsurl.substring(cssIndex+1, jsurl.length);
        } else {
            cssurl = jsurl;
            actionName = jsurl;
        }
        
        cssurl = (cssurl + "/css/" + actionName) .replace(".js", ".css");
        

        $.ajax({
            url: cssurl,
            success: function (data) {
                //塞入html中
                $("body").append("<style>" + data + "</style>");
                //head.load($.res(jsurl + ".js"));
            },
            error: function () {
                $.log("未能正确加载界面css,请检查项目的web目录下是否存在" + (cssurl));
            }
        });
        

    }

    //输入验证
    this.checkReg = function (reg, Id, tip) {
        //不验证
        if (!$.hasValue(reg)) {
            return;
        }
        var reg = new RegExp(reg);
        var obj = $('#' + Id);
        var msgobj = $('#msg-' + Id);
        var value = obj.val();
        var Null = true;
        var illegal = true;
        //如果没值
        Null = !$.hasValue(value);
        illegal = !reg.test(obj.val());

        if (Null) {
            obj.addClass('warning');
            msgobj.html("该值为必填项！");
            return;

        } else {
            obj.removeClass('warning');
            if (illegal) {
                obj.addClass('warning');
                msgobj.html(tip);

            } else {
                obj.removeClass('warning');
                msgobj.html("&#12288;&#12288;&#12288;");

            }

        }

    }

    //file初始化
    this.initFile = function (id, url, folder) {
        if (folder.length > 0 && folder[0] == '/') {
            folder = folder.substring(1, folder.length - 1);
        }
        url = $.url(url + "?folder=" + folder + "&uid=" + $.uid() + "&unitid=" + $.unitid(), true);//转换地址
        var contentId = '#fileupload-' + id;
        var startButton = "#startButton-" + id;
        var cancelButton = "#cancelButton-" + id;
        var deleteButton = '#deleteButton-' + id;
        var checkboxButton = "#checkboxButton-" + id;
        var tagButton = "#tagButton-" + id;
        var mainBox = '#mainBox-' + id;
        var closeBox = "#closeBox-" + id;
        var showButton = "#showButton-" + id;




        //$(contentId).fileupload('option', {
        //    url: url,
        //    // Enable image resizing, except for Android and Opera,
        //    // which actually support image resizing, but fail to
        //    // send Blob objects via XHR requests:
        //    disableImageResize: /Android(?!.*Chrome)|Opera/
        //        .test(window.navigator.userAgent),
        //    maxFileSize: 999000//,
        //   // acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i
        //});

        $(contentId).fileupload({
            url: url,
            //disableImageResize: /Android(?!.*Chrome)|Opera/
            //.test(window.navigator && navigator.userAgent),
            //redirect: "http://" + window.location.host + "/pages/result.html?",//回调页面
            add: function (e, data) {
                if (e.isDefaultPrevented()) {
                    return false;
                }
                $(startButton).removeClass("hide");
                $(cancelButton).removeClass("hide");
                $(deleteButton).removeClass("hide");
                $(checkboxButton).removeClass("hide");
                $(tagButton).removeClass("hide");
                var $this = $(this),
                    that = $this.data('blueimp-fileupload') ||
                        $this.data('fileupload'),
                    options = that.options;
                data.context = that._renderUpload(data.files)
                    .data('data', data)
                    .addClass('processing');
                options.filesContainer[
                    options.prependFiles ? 'prepend' : 'append'
                ](data.context);
                that._forceReflow(data.context);
                that._transition(data.context);
                data.process(function () {
                    return $this.fileupload('process', data);
                }).always(function () {
                    data.context.each(function (index) {
                        $(this).find('.size').text(
                            that._formatFileSize(data.files[index].size)
                        );
                    }).removeClass('processing');
                    that._renderPreviews(data);
                }).done(function () {

                    data.context.find('.start').prop('disabled', false);
                    if ((that._trigger('added', e, data) !== false) &&
                        (options.autoUpload || data.autoUpload) &&
                        data.autoUpload !== false) {
                        data.submit();
                    }
                }).fail(function () {
                    if (data.files.error) {
                        data.context.each(function (index) {
                            var error = data.files[index].error;
                            if (error) {
                                $(this).find('.error').text(error);
                            }
                        });
                    }
                });
            }
        });
        //跨域
        //$(contentId).fileupload(
        // 'option',
        // 'redirect',
        // window.location.href.replace(
        //     /\/[^\/]*$/,
        //     '/pages/result.html?%s'
        // )
        //);

        $(contentId).addClass('fileupload-processing');

        $.ajax({
            // Uncomment the following to send cross-domain cookies:
            //xhrFields: {withCredentials: true},
            url: $(contentId).fileupload('option', 'url'),
            dataType: 'json',
            context: $(contentId)[0]
        }).always(function () {
            $(this).removeClass('fileupload-processing');

        }).done(function (result) {
            $(this).fileupload('option', 'done')
                .call(this, $.Event('done'), { result: result });

        });



        $(tagButton).click(function () {
            $(mainBox).slideUp();
            setTimeout(function () {
                $(closeBox).removeClass('hide');
            }, 500);

        });

        $(showButton).click(function () {
            $(mainBox).slideDown();
            setTimeout(function () {
                $(closeBox).addClass('hide');
            }, 500);

        });

    };

    //删除文件
    this.deleteFile = function (fileUrl, selector, controlName, savedPath) {
        $.Ajax({//删除文件的api地址，div选择器，文件name属性，文件存储的实际相对路径
            url: fileUrl,
            data: { controlName: controlName, savedPath: savedPath },
            success: function (data, code, msg) {
                if (code != 1) {
                    $.msg("删除失败，请刷新页面后重试", code);
                    return;
                }
                var old = $("#" + data.controlName);
                var newPath = old.val().replace(data.savedPath + ";", "").replace(data.savedPath, "");
                old.val(newPath);
                $("#" + selector).remove();
                $.msg("文件已删除", code);
            }
        });

    }

    this.pre = function (code, num) {
        var id = $.random();
        var dest = PreTpl(id, code, num);
        return { id: id, type: 106, html: dest };
    }

    this.dropdown = function (label, li, color, num) {
        var id = $.random();
        var dest = DropDownTpl(id, label, li, num, color);
        return { id: id, type: 107, html: dest };
    }

    this.panel = function (title, body, num, color, footer) {

        var id = $.random();
        var dest = PanelTpl(id, title, body, footer, color, num);
        return { id: id, type: 108, html: dest };
    }

    this.listgroup = function (title, libody, num) {
        var id = $.random();
        var dest = ListGroupTpl(id, title, libody, num);
        return { id: id, type: 109, html: dest };
    }

    this.media = function (imgurl, header, text, num) {
        var id = $.random();
        var dest = MediaTpl(id, imgurl, header, text, num);
        return { id: id, type: 110, html: dest };
    }

    this.alert = function (text, num, color) {
        var id = $.random();
        var dest = AlertTpl(id, text, num, color);
        return { id: id, type: 111, html: dest };
    }

    this.thumbnail = function (imgurl, body, num) {
        var id = $.random();
        var dest = ThumbNailTpl(id, imgurl, body, num);
        return { id: id, type: 112, html: dest };
    }

    this.pageheader = function (title, subtitle, num) {
        var id = $.random();
        var dest = PageHeaderTpl(id, title, subtitle, num);
        return { id: id, type: 113, html: dest };
    }

    this.carousel = function (imageUrl, num) {
        var id = $.random();
        var dest = CarouselTpl(id, imageUrl, num);
        return { id: id, type: -1, html: dest };
    }

    this.html = function (htmlString) {
        var id = $.random();
        return push({ id: id, type: 101, html: htmlString });

    }

    this.image = function (type, value, num, tip) {
        var dest = ImageTpl(type, value, num, tip);
        return { id: name, type: 102, html: dest };
    }

    this.button = function (label, num, color, onclick) {
        var id = $.random();
        var dest = ButtonTpl(id, label, num, color, onclick);
        return { id: id, type: 103, html: dest };
    }
}

//#form-loader
function CanSubmitTpl() {
    return $.qx_tpl({}, function () {/*
 
       <div class="col-lg-12">
                    <div class="col-lg-6">
                        <button class="col-lg-offset-10 btn btn-primary" id="bt_submit" type="submit">提交</button>
                    </div>
                    <div class="col-lg-6">
                        <button class="col-offset-6 btn btn-deafult" onclick="subClose()" id="bt_close" type="button">关闭</button>
                    </div>
                </div><hr/>

 */});
}

function TaskTpl(url, title, time, note, progress) {

    return $.qx_tpl({ url: url, title: title, time: time, note: note, progress: progress == 0 ? progress + 1 : progress }, function () { /*

<li>
     <a class="qx-menu" data-title="{title}" data-url="{url}">
         <div>
             <p>
                 <strong>{title}</strong>
                 <span class="pull-right text-muted">{progress}% Complete</span>
             </p>
            <div class="progress progress-striped active">
                <div class="progress-bar progress-bar-success" role="progressbar" aria-valuenow="{progress}" aria-valuemin="0" aria-valuemax="100" style="width: {progress}%">
                 <span class="sr-only">{progress}% Complete (success)</span>
                </div>
            </div>
             <p>
                 {note}
             </p>
         </div>
      </a>
</li>
<li>
<hr/>
</li>
*/ });
}

function MsgTpl(url, title, time, note) {
    return $.qx_tpl({ url: url, title: title, time: time, note: note }, function () {/*

 <li>
       <a class="qx-menu" data-title="{title}" data-url="{url}">
         <div>
           <strong>{title}</strong>
                <span class="pull-right text-muted">
                      <em>{time}</em>
                </span>
         </div>
      <div>
        {note}
      </div>
     </a>
 </li>
  <li class="divider"></li>
 */});
}


function FileItemsTpl(files, name, canDelete) {
    return qx.form.FileItemsTpl(files, name, canDelete);
}

function ShowFileTpl(id, label, files, num) {
    return qx.form.ShowFileTpl(id, label, files, num);
}


function input(label, name, value, num, validators, tip) {
    return qx.form.input(label, name, value, num, validators, tip);
}

function showinput(label, name, value, num) {

    return qx.form.showInput(label, name, value, num);

}

function showInput(label, name, value, num) {
    return showinput(label, name, value, num);
}

function time(label, name, value, num, tip) {
    return qx.form.time(label, name, value, num, tip);
}

function showTime(label, name, value, num) {
    return qx.form.showTime(label, name, value, num);
}

function date(label, name, value, num, tip) {
    return qx.form.date(label, name, value, num, tip);
}

function showDate(label, name, value, num) {
    return qx.form.showDate(label, name, value, num);
}

function select(label, name, option, value, num, readonly) {
    return qx.form.select(label, name, option, value, num, readonly)
}

function showSelect(label, name, option, value, num) {
    return qx.form.showSelect(label, name, option, value, num);
}

function radio(label, name, items, num, vertical, value) {
    return qx.form.radio(label, name, items, num, vertical, value);
}

function showRadio(label, name, items, num, vertical, value) {
    return qx.form.showRadio(label, name, items, num, vertical, value);
}

function editor(label, name, value, num, height) {
    return qx.form.editor(label, name, value, num, height);
}

function showEditor(label, name, value, num, height) {
    return qx.form.showEditor(label, name, value, num, height);
}

function checkbox(label, name, items, num, vertical, valueArray) {
    return qx.form.checkbox(label, name, items, num, vertical, valueArray);
}

function showCheckbox(label, name, items, num, vertical, valueArray) {
    return qx.form.showCheckbox(label, name, items, num, vertical, valueArray);
}

function _switch(label, name, num, value, onText, offText) {
    return qx.form._switch(label, name, num, value, onText, offText);
}

function showSwitch(label, name, num, value, onText, offText) {
    return qx.form.showSwitch(label, name, num, value, onText, offText);
}

function area(label, name, value, num, height, validators, tip) {
    return qx.form.area(label, name, value, num, height, validators, tip);

}

function showArea(label, name, value, num, height, validators, tip) {
    return qx.form.showArea(label, name, value, num, height, validators, tip);

}

function file(label, name, num, folder, url) {
    return qx.form.file(label, name, num, folder, url);
}

function file3rd(label, name, num, folder, url) {
    return qx.form.file3rd(label, name, num, folder, url);
}

function hideTime(name, value) {
    return qx.form.hideTime(name, value);

}

function hide(name, value) {
    return qx.form.hide(name, value);

}

function hides(nameArray, valueArray) {
    return qx.form.hides(nameArray, valueArray);

}

function hideTimes(nameArray, valueArray) {
    return qx.form.hideTimes(nameArray, valueArray);

}

function showRichBox(label, name, value, num, tip) {
    return qx.form.showRichBox(label, name, value, num, tip);
}

function showfile(label, name, files, num, folder, url) {
    return qx.form.showfile(label, name, files, num, folder, url);
}

function showFile(label, name, files, num) {
    return qx.form.showFile(label, name, files, num);
}

function table(body, head, num) {
    return qx.form.table(body, head, num);
}

function renderTable(cfgArray) {
    return qx.form.renderTable(cfgArray);
}

function tab(contents, num) {
    return qx.form.tab(contents, num);
}

function group(html, title, num) {
    return qx.form.group(html, title, num);
}

//初始化页面控件
function InitFormControl(htmlArray, submiturl, dataUrl, title, overWrite, data) {
    return qx.form.InitFormControl(htmlArray, submiturl, dataUrl, title, overWrite, data);
}

function getFormData() {
    return qx.form.getFormData();
}

/*
http://www.cnblogs.com/huangcong/p/5335376.html
http://bv.doc.javake.cn/validators/
notEmpty：非空验证；

stringLength：字符串长度验证；

regexp：正则表达式验证；

emailAddress：邮箱地址验证（都不用我们去写邮箱的正则了~~）

除此之外，在文档里面我们看到它总共有46个验证类型，我们抽几个常见的出来看看：

base64：64位编码验证；

between：验证输入值必须在某一个范围值以内，比如大于10小于100；

creditCard：身份证验证；

date：日期验证；

ip：IP地址验证；

numeric：数值验证；

phone：电话号码验证；

uri：url验证；

fields= {
            syllabus_version: {
                message: 'The username is not valid',
                validators: {
                    notEmpty: {
                        message: 'The username is required and can\'t be empty'
                    },
                    stringLength: {
                        min: 6,
                        max: 30,
                        message: 'The username must be more than 6 and less than 30 characters long'
                    },
                    regexp: {
                        regexp: /^[a-zA-Z0-9_\.]+$/,
                        message: 'The username can only consist of alphabetical, number, dot and underscore'
                    },
                    different: {
                        field: 'password',
                        message: 'The username and password can\'t be the same as each other'
                    }
                }
            },
            syllabus_name: {
                validators: {
                    notEmpty: {
                        message: 'The email address is required and can\'t be empty'
                    },
                    emailAddress: {
                        message: 'The input is not a valid email address'
                    }
                }
            },
            syll_author: {
                validators: {
                    notEmpty: {
                        message: 'The password is required and can\'t be empty'
                    },
                    identical: {
                        field: 'confirmPassword',
                        message: 'The password and its confirm are not the same'
                    },
                    different: {
                        field: 'username',
                        message: 'The password can\'t be the same as username'
                    }
                }
            },
            confirmPassword: {
                validators: {
                    notEmpty: {
                        message: 'The confirm password is required and can\'t be empty'
                    },
                    identical: {
                        field: 'password',
                        message: 'The password and its confirm are not the same'
                    },
                    different: {
                        field: 'username',
                        message: 'The password can\'t be the same as username'
                    }
                }
            },
            captcha: {
                validators: {
                    callback: {
                        message: 'Wrong answer',
                        callback: function (value, validator) {
                            var items = $('#captchaOperation').html().split(' '), sum = parseInt(items[0]) + parseInt(items[2]);
                            return value == sum;
                        }
                    }
                }
            }
        }
*/

function InitValidation(submiturl) {
    return qx.form.InitValidation(submiturl);
};

function submitForm(submiturl, doAfterSuccess) {
    return qx.form.submitForm(submiturl, doAfterSuccess);
}

function push(obj) {
    return qx.form.push(obj);
}

//form界面渲染入口
function render(htmlArray, submiturl, dataUrl, title, overWrite) {
    return qx.form.render(htmlArray, submiturl, dataUrl, title, overWrite);
}

function _render(htmlArray) {
    return qx.form._render(htmlArray);
}

//form入口
function InitForm(id) {
    return qx.form.InitForm(id);
}

//输入验证
function checkReg(reg, Id, tip) {
    return qx.form.checkReg(reg, Id, tip);
}

//file初始化
function initFile(id, url, folder) {
    return qx.form.initFile(id, url, folder);
};

//删除文件
function deleteFile(fileUrl, selector, controlName, savedPath) {
    return qx.form.deleteFile(fileUrl, selector, controlName, savedPath);
}

function pre(code, num) {
    return qx.form.pre(code, num);
}

function dropdown(label, li, color, num) {
    return qx.form.dropdown(label, li, color, num);
}

function panel(title, body, num, color, footer) {
    return qx.form.panel(body, title, num, color, footer);
}

function listgroup(title, libody, num) {
    return qx.form.listgroup(title, libody, num);
}

function media(imgurl, header, text, num) {
    return qx.form.media(imgurl, header, text, num);
}

function _alert(text, num, color) {
    return qx.form.alert(text, num, color);
}

function thumbnail(imgurl, body, num) {
    return qx.form.thumbnail(imgurl, body, num);
}

function pageheader(title, subtitle, num) {
    return qx.form.pageheader(title, subtitle, num);
}

function carousel(imageUrl, num) {
    return qx.form.carousel(imageUrl, num);
}

function html(htmlString) {
    return qx.form.html(htmlString);

}

function image(type, value, num, tip) {
    return qx.form.image(type, value, num, tip);
}

function button(label, num, color, onclick) {
    return qx.form.button(label, num, color, onclick);
}


