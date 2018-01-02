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
function topMenuStageTwo(uid) {
        $.post($.url("/Open/GetMenu"), { uid: uid }, function (data, status) {
            var html = [];
          
            for (var i = 0; i < data.Navbars.length; i++) {
             
                if (data.Navbars[i].ParentId === 'MRoot') {
                    var item = 0;
                    for (var j = 0; j < data.Navbars.length; j++) {
                        if (data.Navbars[j].ParentId === data.Navbars[i].Id) {
                            item++;
                            if (item == 1) {
                                html.push(' <li class="dropdown">' +
                                       '  <a href="#" class="dropdown-toggle tophide" data-toggle="dropdown">' + data.Navbars[i].Name + '<b class="caret"></b></a>');
                                html.push('<ul class="dropdown-menu"><li><a data-url="' + data.Navbars[j].FinalUrl + '" class="qx-menu" data-title="' + data.Navbars[j].Name + '">' + data.Navbars[j].Name + '</a></li>');
                            } else {
                                html.push('<li><a data-url="' + data.Navbars[j].FinalUrl + '" class="qx-menu" data-title="' + data.Navbars[j].Name + '">' + data.Navbars[j].Name + '</a></li>');
                            }

                        }
                    }
                    if (item !== 0) {
                        html.push('</ul></li>');
                    } else {
                        if (data.Navbars[i].ImageClass == null) {
                            html.push(' <li>' +
                            '<a data-url="' + data.Navbars[j].FinalUrl + '" class="qx-menu" data-title="' + data.Navbars[j].Name + '"><i class="fa fa-bar-chart-o fa-fw"></i>' + data.Navbars[i].Name + '</a>' +
                            '</li>');

                        }
                        else {
                            html.push(' <li>' +
                           '<a data-url="' + data.Navbars[j].FinalUrl + '" class="qx-menu" data-title="' + data.Navbars[j].Name + '"><i class="' + data.Navbars[i].ImageClass + '"></i>' + data.Navbars[i].Name + '</a>' +
                           '</li>');
                        }


                    }

                }
            }

            var mainObj = $('#top-menu');
            mainObj.empty();
            mainObj.html(html.join(''));


            InitMenuAnimation();
            InitMenuEvent();
            dropdownOpen();
        });
    

}

function menuStageTwo(uid) {
       var lIndex= $.loading();
        //$.msg("正在获取菜单,请稍候...",0);
        $.ajax({
            url: $.url("/Open/GetMenu"),
            data: { uid: uid },
            success: function (data, status) {
                $.loaded(lIndex);  
                //$.msg("获取菜单成功!");
                var html = [];
                for (var i = 0; i < data.Navbars.length; i++) {
                    if (data.Navbars[i].IsParent == false) {//存储最后一层菜单
                        g_menuData.push(data.Navbars[i]);
                    }
                    if (data.Navbars[i].ParentId === 'MRoot') {
                        var item = 0;
                        for (var j = 0; j < data.Navbars.length; j++) {
                            if (data.Navbars[j].ParentId === data.Navbars[i].Id) {
                                item++;
                                if (item == 1) {
                                    if (data.Navbars[i].ImageClass == null) {
                                        html.push(' <li class="dropdown">' +
                                        '<a href="#"><i class="fa fa-bar-chart-o fa-fw"></i>' + data.Navbars[i].Name + '<span class="fa arrow"></span></a>');
                                        html.push('<ul class="nav nav-second-level"><li><a data-url="' + data.Navbars[j].FinalUrl + '" class="qx-menu" data-title="' + data.Navbars[j].Name + '">' + data.Navbars[j].Name + '</a></li>');
                                    }
                                    else {
                                        html.push(' <li class="dropdown>' +
                                       '<a href="#"><i class="' + data.Navbars[i].ImageClass + '"></i>' + data.Navbars[i].Name + '<span class="fa arrow"></span></a>');
                                        html.push('<ul class="nav nav-second-level"><li><a data-url="' + data.Navbars[j].FinalUrl + '" class="qx-menu" data-title="' + data.Navbars[j].Name + '">' + data.Navbars[j].Name + '</a></li>');
                                    }


                                } else {
                                    html.push('<li><a data-url="' + data.Navbars[j].FinalUrl + '" class="qx-menu" data-title="' + data.Navbars[j].Name + '">' + data.Navbars[j].Name + '</a></li>');
                                }

                            }
                        }
                        if (item !== 0) {
                            html.push('</ul></li>');
                        } else {
                            if (data.Navbars[i].ImageClass == null) {
                                html.push(' <li>' +
                                '<a data-url="' + data.Navbars[j].FinalUrl + '" class="qx-menu" data-title="' + data.Navbars[j].Name + '"><i class="fa fa-bar-chart-o fa-fw"></i>' + data.Navbars[i].Name + '</a>' +
                                '</li>');

                            }
                            else {
                                html.push(' <li>' +
                               '<a data-url="' + data.Navbars[j].FinalUrl + '" class="qx-menu" data-title="' + data.Navbars[j].Name + '"><i class="' + data.Navbars[i].ImageClass + '"></i>' + data.Navbars[i].Name + '</a>' +
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
                var search=$("#search-menu");
                $("#bt_clean").click(function() {
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
                            if (item.Name.indexOf(keyword) > -1) {
                                $("#side-menu").append('<li class="qx-menu-search"><a data-url="' + item.FinalUrl + '" class="qx-menu" data-title="' + item.Name + '"><i class="fa fa-search fa-fw"></i> ' + item.Name + '</a></li>');
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
                if (g_debug) {
                    $.alert("服务器连接失败,请检查是否启动了服务器端,若问题依旧,请检查config.js中的g_host配置项是否正确！", 2);
                } else {
                    $.alert("网络连接失败,请检查您的网络连接状态！", 5);
                }

            }
        });

     
}

function menuStageThree(uid) {
        $.post($.url("/Open/GetMenu"), { uid: uid }, function (data, status) {
            var html = [];
            var obj = new Object();
            obj.rootArray = new Array();
            var one = 0;
            for (i = 0; i < data.Navbars.length; i++) {
                if (data.Navbars[i].ParentId == 'MRoot') {
                    obj.rootArray[one] = data.Navbars[i];
                    obj.rootArray[one].stageTwo = new Array();
                    var two = 0;
                    for (j = 0; j < data.Navbars.length; j++) {
                        if (data.Navbars[j].ParentId == data.Navbars[i].Id) {
                            obj.rootArray[one].stageTwo[two] = data.Navbars[j];
                            obj.rootArray[one].stageTwo[two].stageThree = new Array();

                            for (z = 0; z < data.Navbars.length; z++) {
                                if (data.Navbars[z].ParentId == data.Navbars[j].Id) {
                                    obj.rootArray[one].stageTwo[two].stageThree.push(data.Navbars[z]);
                                }
                            }
                            two++;
                        }
                    }
                    one++;
                }
            }
            html.push('<li class="sidebar-search"><div class="input-group custom-search-form"><input type="text" class="form-control" placeholder="Search..."><span class="input-group-btn"><button class="btn btn-default" type="button"><i class="fa fa-search"></i></button></span></div></li>');

            for (i = 0; i < obj.rootArray.length; i++) {

                if (obj.rootArray[i].stageTwo.length == 0) {
                    html.push(' <li>' +
                        '<a data-url="' + obj.rootArray[i].FinalUrl + '" class="qx-menu" data-title="' + obj.rootArray[i].Name + '"><i class="' + obj.rootArray[i].ImageClass + '"></i>' + obj.rootArray[i].Name + '</a>' +
                        '</li>');
                } else {
                    html.push(' <li>' +
                        '<a href="#"><i class="' + obj.rootArray[i].ImageClass + '"></i>' + obj.rootArray[i].Name + '<span class="fa arrow"></span></a>');
                    html.push('<ul class="nav nav-second-level">');
                    for (j = 0; j < obj.rootArray[i].stageTwo.length; j++) {
                        if (obj.rootArray[i].stageTwo[j].stageThree.length == 0) {
                            html.push('<li><a data-url="' + obj.rootArray[i].stageTwo[j].FinalUrl + '" class="qx-menu" data-title="' + obj.rootArray[i].stageTwo[j].Name + '">' + obj.rootArray[i].stageTwo[j].Name + '</a></li>');
                        } else {
                            html.push(' <li>' +
                                '<a href="#"><i class="' + obj.rootArray[i].stageTwo[j].ImageClass + '"></i>' + obj.rootArray[i].stageTwo[j].Name + '<span class="fa arrow"></span></a>');
                            html.push('<ul class="nav nav-third-level">');
                            for (z = 0; z < obj.rootArray[i].stageTwo[j].stageThree.length; z++) {
                                html.push('<li><a data-url="' + obj.rootArray[i].stageTwo[j].stageThree[z].FinalUrl + '" class="qx-menu" data-title="' + obj.rootArray[i].stageTwo[j].stageThree[z].Name + '">' + obj.rootArray[i].stageTwo[j].stageThree[z].Name + '</a></li>');
                            }
                            html.push('</ul></li>');
                        }
                    }
                    html.push('</ul></li>');
                }
            }


            var mainObj = $('#side-menu');
            mainObj.empty();
            mainObj.html(html.join(''));

            InitMenuAnimation();
            InitMenuEvent();

        });
}

//菜单模块
function queryMenu(url, params) {
    if (url.indexOf("http") > -1) {
        console.log("remote requesting to" + url);
        params = "dist_url=" + url;
        url = "/sb/grap";
    } else {
        params = "";
        console.log("local requesting to " + url);
    }
    $.ajax({
        url: url,
        type: "GET",
        data: params,
        // context: document.body,
        success: function (result) {
            //console.log("queryMenu result" + result)
            $("#qx-page-wrapper").html(result);
        },
        error: function () {
            alert('fail');
        }
    });
}