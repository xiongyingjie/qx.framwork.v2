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


function InitReport(id) {
    //加载附加js
    var jsurl = id;//页面
    if (id.indexOf("?") > -1) {
        jsurl = id.substring(0, id.indexOf("?"));
    }
    $.ajax({
        url: srcurl(jsurl + ".js", "/web/"),
        success: function () {
            //head.load($.res(jsurl + ".js"));
        },
        error: function () {
            if (_c.isDebug()) {
                $.warn("未能加载报表的附加js,请检查项目的web目录下是否存在" + (jsurl + ".js"));
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
               
                if (_c.isDebug()) {
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

//checkbox 全选/取消全选
var g_isCheckAll = false;
function t(sName) {
    var value = $("[name='" + sName + "']").find("option:selected").text();
    return (value === undefined || value === "") ? ";" : value;
}
function v(sName) {
    var value = $("[name='" + sName + "']").val();

    return (value === undefined || value === "") ? ";" : value;
}
function GetTableData() {
    $.get("/F2Demo/GetReportConfig",
        { ReportID: "ecampus.yxxt.charge_item_instance.应缴费用查询", Params: ";", dbConnStringKey: "ecampus.yxxt", pageIndex: 1, perCount: 10 },
        function (data) {
            //var tableData = '{"params":{"pageIndex":"1","perPage":"10","maxIndex":"88","currentUrl":"http://baidu.com","title":"测试"},"header":["id","name","sex","city","age","操作"],"tableBody":[["id_1","name_1","sex_1","city_1","age_1","查看"],["id_2","name_2","sex_2","city_2","age_2","查看"],["id_3","name_3","sex_3","city_3","age_3","查看"],["id_4","name_4","sex_4","city_4","age_4","查看"]]}';
            var obj = JSON.parse(data);
            return obj;
        });

}
function GetFormData() {
    var formData = g_formControlConfig;
    // '[{"name":"user_id","id":"user_id","value":"132511232","type":"1","sequence":"1","lable":"用户id","crossWidth":"1"},{"name":"sex","id":"sex","type":"2","sequence":"2","lable":"注册时间","crossWidth":"1","value":"2","items":[{"text":"男","value":"1"},{"text":"女","value":"2"}]},{"name":"regist_time","id":"regist_time","value":"2017-04-06 17:47","type":"3","sequence":"3","lable":"注册时间","crossWidth":"1","class":"time"},{"name":"note","id":"note","value":"2017-04-06 17:47注册成功","type":"4","sequence":"1","lable":"登录","crossWidth":"3"}]';
    var obj = JSON.parse(formData);
    // console.log(obj);
    return obj;
}

function TipTableError(content) {
    var mainObj = $('#mainContent');
    mainObj.attr("style", "text-align: center;");
    mainObj.html("<hr/><lable style='color:red'>系统提示:" + content + "</lable><hr/>");
}
function swapCheck() {
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
function UpdateQueryParam() {
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

function DonwnloadExcel() {
   
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
function doUpload() {
    
}
function UploadExcel(exlData, out) {
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

function ToPdf() {
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

function ToExcel() {
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
function Add() {

    $.go("/pages/form.html?id=" + g_addLink);
}

function Delete() {
    submitChecked(g_deleteLink, "删除");
}
function submitChecked(url, tip, data) {
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
function getChecked() {
    var chkValues = [];
    $('input[type="checkbox"]:checked').each(function (i, e) {
        var id = $(e).attr('id');
        if ($.hasValue(id)) {
            chkValues.push($.trim(id));
        }
    });
    return chkValues;
}
function Query() {
    //UpdateQueryParam();
    callBackPagination(999, g_perCount, g_perCount, g_pageIndex);
    //var url = g_currentUrl + "?ReportID=" + g_reportId + "&Params=" + queryParam + "&pageIndex=1&perCount=" + g_perCount + g_extraParam;
    //location.href = url;
    //console.log("Query..." + url);
}

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

//limit每页显示条数
function callBackPagination(totalCount, showCount, limit, currPage) {

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

function createTable(currPage, limit, total) {
    UpdateQueryParam();
    $("#lb_fromIndex").html((currPage - 1) * limit + 1);
    $("#lb_toIndex").html(currPage * limit);
 
    $.Ajax({
        url: "/Report/Report2",
        data: { ReportID: g_reportId, Params: g_params, dbConnStringKey: g_dbConnStringKey, dataSourceUrl: g_dataSourceUrl, pageIndex: currPage, perCount: limit },
        success: function (data, code, msg, url) {
            
            /* //优化处理
             if (data.FinalView.length <= 1) {
                 // TipTableError("列表空空,请返回上一页");   
                 if (currPage === 1) {
                     //console.log(status + ":");
                     //console.log(data);
                     TipTableError("搜索结果为空");
                 }
                 else {
                     $.alert("没有第" + currPage + "页");
                     //console.log(g_perCount + ":" + g_perCount);
                     callBackPagination(999, 1, g_perCount, g_perCount);
                     return;
                 }
                 return;
             }*/

            var obj = data;// JSON.parse(data);
            //$.log(obj);
           // //$.log(obj.FinalJson.replace(/\n/g, "").replace(/\r/g, "").replace(/="/g, "'"));
           // //$.log(JSON.parse(obj.FinalJson.replace(/\n/g, "").replace(/\r/g, "").replace(/"/g, "'").replace(/">/g, "'")));
            //$.log(JSON.parse(obj.FinalJson.replace(/\n/g, "").replace(/\r/g, "")));
            var params = obj.pageParam;//对象
            var header = obj.header;//一维数组
            var tableBody = obj.FinalView;//二维数组
            var tableBodyAll = obj.tableBody_all;//二维数组
            var html = [], showNum = limit;

            if (total - (currPage * limit) < 0) showNum = total - ((currPage - 1) * limit);

            html.push('<table id="report-table" class="table table-striped table-bordered table-hover info" style="margin-left: 0;">');
            html.push('<thead><tr>' +
                '<th width="30px;">' +
                '<input type="checkbox" onclick="swapCheck()">' +
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
            InitMenuEvent("tbody .qx-operate", "f", true);
            //调用函数
            $.doFunction("tableReady");

        }
        //,
        //error: function () {
        //    $.loaded(); //关闭加载层
        //    $.msg("请求失败,请刷新页面", 2);
        //    if (_c.isDebug()) {
        //        $.confirm("页面出错,查看详细错误信息？", function() {
        //            $.go($.url("/Report/Report2?uid=" + $.uid +
        //                "&ReportID=" + g_reportId + "&Params=" + g_params +
        //                "&dbConnStringKey=" + g_dbConnStringKey + "&dataSourceUrl=" +
        //                g_dataSourceUrl + "&pageIndex=" + currPage + "&perCount=" + limit));
        //        });
        //    }
        //    //TipTableError("请求失败,请刷新页面！");
        //}
    });
}

function createForm() {
    var obj = GetFormData();
    var extra_bt_html = [];
    var extra_tip_html = [];
    var html = [];
    //Input = 1,
    //DateTime = 2,
    //TextArea = 3,onkeyup="SomeJavaScriptCode"

    //DropDownList = 4  onkeyup="SomeJavaScriptCode"
    //  Button = 5,
    // Tip = 6


    for (var i = 0; i < obj.length; i++) {
        if (obj[i].type === 201) {
            html.push('<li><div class="form-group form-pd">' +
                '<label class="label-wid">' + obj[i].lable + '</label>' +
                '<input type="text" onkeyup="Query()" class="form-control form-control-size" value="' + obj[i].value + '" id="' + obj[i].id + '" placeholder="">' +
                '</div></li>');
        }
        else if (obj[i].type === 204) {
            html.push('<li><div class="form-group form-pd">' +
                '<label class="label-wid">' + obj[i].lable + '</label>' +
                '<select onchange="Query()"  id="' + obj[i].id + '" class="form-control form-control-size">');

            for (var j = 0; j < obj[i].items.length; j++) {
                html.push('<option value="' + obj[i].items[j].value + '">' + obj[i].items[j].text + '</option>');
            }
            html.push('</select></div></li>');
        }
        else if (obj[i].type === 203) {
            html.push('<li><div class="form-group form-pd">' +
                '<label class="label-wid">' + obj[i].lable + '</label>' +
                '<input onchange="Query()"  type="text" value="' + obj[i].value + '" class="form-control form-control-size" id="' + obj[i].id + '">' +
                '</div></li>');

            html.push('<script type="text/javascript">$("#' + obj[i].id + '").datetimepicker({ weekStart: 1,todayBtn: 1,autoclose: 1,todayHighlight: 1,startView: 2,forceParse: 0,showMeridian: 1,})' + ';' + '<' + '/script>');
        }
        else if (obj[i].type === 209) {
            html.push('<li style="width:100%;"><div class="form-group form-pd" style="width:100%;">' +
                '<label class="label-wid">' + obj[i].lable + '</label>' +
                '<textarea onkeyup="Query()"  class="form-control" style="width:85%;height:120px;"  rows="' + obj[i].crossWidth + '" id="' + obj[i].id + '" placeholder="">' + obj[i].value +
                '</textarea>' +
                '</div></li>');
        }
        else if (obj[i].type === 103) {
            extra_bt_html.push(' <a data-url="' + obj[i].value + '" data-title="' + obj[i].lable + '" id="' + obj[i].id + '"  class="btn btn-primary extra-bt">' + obj[i].lable + '<i class="fa"></i></a>');

            // log('bt' + obj[i].lable + obj[i].value);
            //html.push('<li style="width:100%;"><div class="form-group form-pd" style="width:100%;">' +
            //    '<label class="label-wid">' + obj[i].lable + '</label>' +
            //    '<textarea onkeyup="Query()"  class="form-control" style="width:85%;height:120px;"  rows="' + obj[i].crossWidth + '" id="' + obj[i].id + '" placeholder="">' + obj[i].value +
            //    '</textarea>' +
            //    '</div></li>');
        } else if (obj[i].type === 114) {
            extra_tip_html.push(' <lable  class="btn">' + obj[i].lable + '</lable>');
            //    log('tip' + obj[i].lable);
            //html.push('<li style="width:100%;"><div class="form-group form-pd" style="width:100%;">' +
            //    '<label class="label-wid">' + obj[i].lable + '</label>' +
            //    '<textarea onkeyup="Query()"  class="form-control" style="width:85%;height:120px;"  rows="' + obj[i].crossWidth + '" id="' + obj[i].id + '" placeholder="">' + obj[i].value +
            //    '</textarea>' +
            //    '</div></li>');
        } else {
            html.push('error!');
        }

    }
    var mainObj = $('#mainForm'); var extraButton = $("#extra-bt-container"); var extraTip = $("#extra_tip-container");
    mainObj.empty(); extraButton.empty(); extraTip.empty();
    mainObj.html(html.join('')); extraButton.html(extra_bt_html.join('')); extraTip.html(extra_tip_html.join(''));

    //添加自定义按钮事件
    InitMenuEvent(".extra-bt", "d", true);
    $.doFunction("searchReady");
}


function dealTable(conditionArray, fn) { //二次处理报表  
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




