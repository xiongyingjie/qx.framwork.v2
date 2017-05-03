//var g_dataSource = '@dataSource';
//var g_addLink = '@AddLink';
//var g_title = '@Title';
//var g_extraParam = '@ExtraParam';
//var g_reportId = '@ReportID';
//var g_params = '@Params';
//var g_perCount = @perCount;
//var g_pageIndex = @pageIndex;
//var g_showDeafultButton = @showDeafultButton;
//var g_area = '@area';
//var g_formControlConfig = '@formControlConfig';
//var g_deleteLink = '@deleteLink';
//var g_currentUrl = '@CurrentUrl';
//var g_fixedParams = '@Params.Substring(0, Params.IndexOf("!fixed"))';
    function t(sName) {
        var value = $("[name='" + sName + "']").find("option:selected").text();
        return (value == undefined || value == "") ? ";" : value;
    }
    function v(sName) {
        var value = $("[name='" + sName + "']").val();

        return (value == undefined || value == "") ? ";":value;
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

    //checkbox 全选/取消全选
    var g_isCheckAll = false;
    function swapCheck() {
        if (g_isCheckAll) {
            $("input[type='checkbox']").each(function() {
                this.checked = false;
            });
            g_isCheckAll = false;
        } else {
            $("input[type='checkbox']").each(function() {
                this.checked = true;
            });
            g_isCheckAll = true;
        }
    }

    $().ready(function () {
        if (!hasValue(g_deleteLink)) {
            $("#bt_delete").remove();
        }
       
        if (!hasValue(g_addLink)) {
            $("#bt_add").remove();
        }
        if (GetFormData().length==0) {
            $("#bt_query").remove();
        }
        createForm();
        callBackPagination(999, g_perCount, g_perCount, g_pageIndex);
    });


    function UpdateQueryParam() {
        var queryParam = "";
        var objList = GetFormData();
        //过滤tip button
        var controlObjList = [];
        for (var m = 0; m < objList.length; m++) {
            if (objList[m].type === 1 ||
                    objList[m].type === 2 ||
                    objList[m].type === 3 ||
                    objList[m].type === 4) {
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
                case 1:
                    {
                        value = $("#" + item.id).val();
                    };
                    break;
                case 2:
                    {
                        value = $("#" + item.id).val();
                    };
                    break;
                case 3:
                    {
                        value = document.getElementById(item.id).value;
                    };
                    break;
                case 4:
                    {
                        var x = document.getElementById(item.id);
                       // console.log(item.id + x);
                        value = x.options[x.selectedIndex].value;
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
           // debugger
            value = value.replace(/;/g, "").replace(/;/g, "");//g代表全部替换 
            //前n-1个 有值取值并加; 无值直接匹配;   最后1个且有>1个动态参数无值不匹配;
            if (controlObjList.length === 1) {
                if (hasValue(value)) {
                   // value = value;
                } else {
                    if (hasValue(g_fixedParams)) {
                        // value = value;
                    } else {
                        value = ";";
                    }
                }
            } else {
                if (i === controlObjList.length - 1) {
                    if (hasValue(value)) {
                        //value = value;
                    } else {
                        // value = value
                    }
                } else {
                    if (hasValue(value)) {
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
        g_params = (hasValue(g_fixedParams) ? g_fixedParams + ";" : "") + queryParam;
      //  console.log('参数更新后 ' + g_params);
        return g_params;
    }
    function ToExcel() {
        UpdateQueryParam();
        $.ajax({
            url: "/Report/ReportToExcel2",
            data: { ReportID: g_reportId, Params: g_params, dbConnStringKey: g_dbConnStringKey, pageIndex: 1, perCount: 99999 },
            success: function (data, status, xhr) {
                if (hasValue(data)) {
                    console.log(data);
                    location.href = data;
                } else {
                    alert("导出失败！");
                }
            },
            error: function () {
                alert("导出失败,请刷新页面重试！");
            }
        });
        console.log("ToExcel...");
    }
    function Add() {
        console.log("Add...");
        location.href = g_addLink;
       
    }
    function Delete() {
        var chk_value = [];
        $('input[type="checkbox"]:checked').each(function () {
            if (hasValue(chk_value[i])) {
                chk_value.push($(this).attr('id'));
            }
        });
        if (chk_value.length == 0) {
            alert('请先选中要删除的行！');
        } else {
            alert('Delete...' + chk_value);
        }
        

 
       
    }
    function Query() {
        //UpdateQueryParam();
        callBackPagination(999, g_perCount, g_perCount, g_pageIndex);
        //var url = g_currentUrl + "?ReportID=" + g_reportId + "&Params=" + queryParam + "&pageIndex=1&perCount=" + g_perCount + g_extraParam;
        //location.href = url;
        //console.log("Query..." + url);
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
        $.ajax({
            type: 'POST',
            async : true,
            url: "/Report/Report2",
            data: { ReportID: g_reportId, Params: g_params, dbConnStringKey: g_dbConnStringKey, pageIndex: currPage, perCount: limit },
            success: function (data, status, xhr) {
                //优化处理
                if (data.FinalView.length <= 1) {
                    // TipTableError("列表空空,请返回上一页");   
                    if (currPage == 1) {
                        console.log(status + ":");
                        console.log(data);
                        TipTableError("搜索结果为空");
                    }
                    else {
                        alert("没有第" + currPage + "页");
                        callBackPagination(999, g_perCount, g_perCount, g_pageIndex);
                        return;
                    }
                    return;
                }

                var obj = data;// JSON.parse(data);
                console.log(obj);
                var params = obj.pageParam;//对象
                var header = obj.header;//一维数组
                var tableBody = obj.FinalView;//二维数组
                var html = [], showNum = limit;

                if (total - (currPage * limit) < 0) showNum = total - ((currPage - 1) * limit);

                html.push(' <table class="table table-striped table-bordered table-hover info" style="margin-left: 0;">');
                html.push(' <thead><tr>' +
                    '<th width="30px;">' +
                    '<input type="checkbox" onclick="swapCheck()">' +
                    '</th>');
                for (var i = 0; i < header.length; i++) {
                    html.push(' <th width="100px;"><label for="">' + header[i] + '</label></th>');
                    if (i == header.length - 1) {
                        html.push(' <th width="300px;"><label for="">' + '操作' + '</label></th>');
                    }
                }

                html.push('</tr></thead><tbody>');

                for (var j = 1; j < tableBody.length; j++) {
                    html.push('<tr><td style="text-align:center;"><input id="' + tableBody[j][0] + '" type="checkbox"></td>');
                    for (var k = 0; k < tableBody[j].length; k++) {
                        if (k == tableBody[j].length - 1) {
                            //最后一列,额外参数处理 replace(/^label/,'tooltip')
                            html.push('<td  style="text-align:center; class="center overOut">' + tableBody[j][k].replace("[]", g_extraParam) + '</td>');
                        } else {
                            html.push('<td data-toggle="tooltip" data-placement="bottom" title="' + tableBody[j][k] + '" class="center overOut">' + tableBody[j][k] + '</td>');
                        }
                    }
                    html.push('</tr>');
                }
                html.push('</tbody></table>');
                var mainObj = $('#mainContent');
                mainObj.empty();
                mainObj.html(html.join(''));

              
            },
            error: function () {
                TipTableError("请求失败,请刷新页面！");
            }
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
            if (obj[i].type === 1) {
                html.push('<li><div class="form-group form-pd">' +
                    '<label class="label-wid">' + obj[i].lable + '</label>' +
                    '<input type="text" onkeyup="Query()" class="form-control form-control-size" value="' + obj[i].value + '" id="' + obj[i].id + '" placeholder="">' +
                    '</div></li>');
            }
            else if (obj[i].type === 4) {
                html.push('<li><div class="form-group form-pd">' +
                    '<label class="label-wid">' + obj[i].lable + '</label>' +
                    '<select onchange="Query()"  id="' + obj[i].id + '" class="form-control form-control-size">');

                for (var j = 0; j < obj[i].items.length; j++) {
                    html.push('<option value="' + obj[i].items[j].value + '">' + obj[i].items[j].text + '</option>');
                }
                html.push('</select></div></li>');
            }
            else if (obj[i].type === 2) {
                html.push('<li><div class="form-group form-pd">' +
                    '<label class="label-wid">' + obj[i].lable + '</label>' +
                    '<input onchange="Query()"  type="text" value="' + obj[i].value + '" class="form-control form-control-size" id="' + obj[i].id + '">' +
                    '</div></li>');

                html.push('<script type="text/javascript">$("#' + obj[i].id + '").datetimepicker({ weekStart: 1,todayBtn: 1,autoclose: 1,todayHighlight: 1,startView: 2,forceParse: 0,showMeridian: 1,})' + ';' + '<' + '/script>');
            }
            else if (obj[i].type === 3) {
                html.push('<li style="width:100%;"><div class="form-group form-pd" style="width:100%;">' +
                    '<label class="label-wid">' + obj[i].lable + '</label>' +
                    '<textarea onkeyup="Query()"  class="form-control" style="width:85%;height:120px;"  rows="' + obj[i].crossWidth + '" id="' + obj[i].id + '" placeholder="">' + obj[i].value +
                    '</textarea>' +
                    '</div></li>');
            }
            else if (obj[i].type === 5) {
                extra_bt_html.push(' <a href="' + obj[i].value + '"  class="btn btn-danger">' + obj[i].lable + '<i class="fa"></i></a>');

               // log('bt' + obj[i].lable + obj[i].value);
                //html.push('<li style="width:100%;"><div class="form-group form-pd" style="width:100%;">' +
                //    '<label class="label-wid">' + obj[i].lable + '</label>' +
                //    '<textarea onkeyup="Query()"  class="form-control" style="width:85%;height:120px;"  rows="' + obj[i].crossWidth + '" id="' + obj[i].id + '" placeholder="">' + obj[i].value +
                //    '</textarea>' +
                //    '</div></li>');
            } else if (obj[i].type === 6) {
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

    }
 