﻿var newcolumntable;
var newtemplatetable;

var cdHeadercol = ['栏目设计ID', '栏目设计名称', '展示列数', '绑定单位ID', '更新类型', '栏目设计HTML', '栏目设计参数', 'css/js'];
var cdHeadercol_template = ['text', 'text', 'number', 'text', 'select', 'textarea', 'text', 'text'];

var options = {
    allowFileManager: true,
    imageUploadJson: '/Content/kindeditor/asp.net/upload_json.ashx',
    fileManagerJson: '/Content/kindeditor/asp.net/file_manager_json.ashx',
    width: "98%", //编辑器的宽度为70%
    height: "400px", //编辑器的高度为100px
    filterMode: false, //不会过滤HTML代码
    resizeMode: 1 //编辑器只能调整高度
};


$(document).ready(function () {

    newcolumntable = $('#newcolumntable').editTable({
        field_templates: {

            'textarea': {
                html: '<textarea name="user_textarea"/>',
                getValue: function (input) {
                    return $(input).val();
                },
                setValue: function (input, value) {
                    return $(input).text(value);
                }
            },
            'select': {
                html: '<select><option value="1">实时更新</option><option value="2">延迟更新</option></select>',
                getValue: function (input) {
                    return $(input).val();
                },
                setValue: function (input, value) {
                    var select = $(input);
                    select.find('option').filter(function () {
                        return $(this).val() == value;
                    }).attr('selected', true);
                    return select;
                }
            },
            'number': {
                html: '<input type="number" name="user_number" />',
                getValue: function (input) {
                    return $(input).val();
                },
                setValue: function (input, value) {
                    return $(input).attr("value", value);
                    //return $(input).text(value);
                }
            }
        },
        row_template: cdHeadercol_template,
        headerCols: cdHeadercol,
        first_row: false,
        data: [['']],

        // Checkbox validation
        validate_field: function (col_id, value, col_type, $element) {
            if (col_type === 'checkbox') {
                $element.parent('td').animate({ 'background-color': '#fff' });
                if (value === false) {
                    $element.parent('td').animate({ 'background-color': '#DB4A39' });
                    return false;
                }
            }
            return true;
        },
        tableClass: 'inputtable custom'
    });


    $("#sendJson_newcolumn").click(function () {

        $.ajax({
            url: '/api/json-newContentColumn?data=' + newcolumntable.getJsonData(),
            type: 'POST',
            data: {
                ajax: true,
                data: ""
                //data: newcolumntable.getJsonData()
            },
            success: function (result) {
                if (result) {
                    alert('创建成功');
                    location.reload();
                }
            }
        });
        return false;

    });

    $("#sendJson_editcolumn").click(function () {

        //var cdid = $('#cdid').val();
        $.ajax({
            url: '/api/json-editContentColumn?data=' + newcolumntable.getJsonData(),
            type: 'POST',
            data: {
                ajax: true,
                data: ""
                //data: newcolumntable.getJsonData()
            },
            success: function (result) {
                if (result) {
                    alert('保存成功')
                }
            }
        });
        return false;

    });

    $("#reset_newcolumn").click(function () {
        newcolumntable.reset();
    });

    $("#new_ccd").click(function () {
        displayHideUI("sendJson_editcolumn");
        displayShowUI("new_columntable");
        displayShowUI("sendJson_newcolumn");
        displayHideUI("hasDesignedColumnList");
        displayHideUI("new_ccd");

        newcolumntable.reset();
        var editor = KindEditor.create('textarea[name=user_textarea]', options);
    });

    $("#back_tocollist").click(function () {
        displayHideUI("new_columntable");
        displayHideUI("sendJson_newcolumn");
        displayShowUI("hasDesignedColumnList");
        displayShowUI("new_ccd");

        newcolumntable.reset();
        newtemplatetable.reset();
    });





});




//UI操作函数
function displayHideUI(uiid) {
    var ui = document.getElementById(uiid);
    ui.style.display = "none";
}
function displayShowUI(uiid) {
    var ui = document.getElementById(uiid);
    ui.style.display = "";
}

//表格操作函数
function init_columntable(id) {
    var ccdid = id;
    $.ajax({
        url: '/api/json-getContentColumnInfo?ccdid=' + ccdid,
        type: 'POST',
        data: {
            ajax: true,
            data: ccdid
        },
        success: function (result) {
            if (result) {
                newcolumntable.loadJsonData(result);

                displayHideUI("new_ccd");
                displayHideUI("hasDesignedColumnList");
                displayHideUI("sendJson_newcolumn");

                displayShowUI("new_columntable");
                //displayShowUI("sendJson_newcolumn");
                displayShowUI("sendJson_editcolumn");

                var editor = KindEditor.create('textarea[name=user_textarea]', options);
            }
            else {
                alert('加载失败，请重试');
            }
        }
    });
}

function del_columntable(id) {
    var cdid = id;
    $.ajax({
        url: '/api/json-deleteContentColumn?cdid=' + cdid,
        type: 'POST',
        data: {
            ajax: true,
            data: cdid
        },
        success: function (result) {
            if (result) {

                alert('删除成功');
                location.reload();
            }
            else {
                alert('删除失败');
            }
        }
    });
}