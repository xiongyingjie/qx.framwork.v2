var defaulttable; //默认表格
var highleveltable;  //高级选项
var selfdefinetable; //自定义表格

$(document).ready(function () {
        defaulttable = $('#defaulttable').editTable({
        data: [['']],           // Fill the table with a js array (this is overridden by the textarea content if not empty)
        tableClass: 'inputtable',   // Table class, for styling
        jsonData: false,        // Fill the table with json data (this will override data property)
        headerCols: false,      // Fix columns number and names (array of column names)
        maxRows: 999,           // Max number of rows which can be added
        first_row: true,        // First row should be highlighted?
        row_template: false,    // An array of column types set in field_templates
        field_templates: false, // An array of custom field type objects

        // Validate fields
        validate_field: function (col_id, value, col_type, $element) {
            return true;
        }
    });

    var tablecolumn = [];
    tablecolumn.push('列名');
    tablecolumn.push('控件类型');

    var tablevalue = [[]];
    tablevalue.push('111');
    tablevalue.push('222');

        highleveltable = $('#highleveltable').editTable({
        field_templates: {

            'select': {
                html: '<select><option value="text">text</option><option value="textarea">textarea(富文本)</option><option value="number">number</option><option value="datetime">datetime</option><option value="checkbox">checkbox</option><option value="file">file</option><option value="color">color</option></select>',
                getValue: function (input) {
                    return $(input).val();
                },
                setValue: function (input, value) {
                    var select = $(input);
                    select.find('option').filter(function () {
                        return $(this).val() === value;
                    }).attr('selected', true);
                    return select;
                }
            }
        },
        row_template: ['text', 'select'],
        headerCols: tablecolumn,
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


    $("#sendJson_high").click(function () {
        var tname = $('#tableName').val();
        var s = highleveltable.getJsonData();
        var a = JSON.stringify(s);
        var obj = eval('(' + a + ')');
        var lie = [];
        var type = [];
        $.each($.parseJSON(obj), function (index, value) {

            $.each(value, function(i, v)
            {
                if(i === 0)
                {
                    lie.push(v);
                }
                else
                {
                    type.push(v);
                }
            })         
        });
        var url = '/Contents/Home2/AddEditPage2?lie=' + lie + '&type=' + type + '&tname=' + tname;
        window.location.href = url;
        //selfdefinition(lie, type)
        $("#high_column").val(s);
    });

    $("#sendJson_high2").click(function () {
        var s = highleveltable.getJsonData();
        var a = JSON.stringify(s);
        var obj = eval('(' + a + ')');
        var lie = [];
        var type = [];
        $.each($.parseJSON(obj), function (index, value) {

            $.each(value, function (i, v) {
                if (i === 0) {
                    lie.push(v);
                }
                else {
                    type.push(v);
                }
            })
        });
        var url = '/Contents/Home2/AddEditPage?lie=' + lie + '&type=' + type
        selfdefinition(lie, type)
        $("#high_column").val(s);
    });

    $('#sendJson_default').click(function () {
        var tname = $('#tableName').val();
        $.ajax({
            url: '/api/json-createTable?tablename=' + tname,
            type: 'POST',
            data: {
                ajax: true,
                //data: "jsonstring=" + defaulttable.getJsonData() + "&tablename=" + tname + "",
                //data: { jsonstring: defaulttable.getJsonData(), tablename: "aaa" },
                data: defaulttable.getJsonData()
            },
            success: function (result) {
                if(result)
                {
                    alert('创建成功');
                    location.href = '/Contents/Home2/TableList';
                }
            }
        });
        return false;
    });

    $("#loadJson").click(function () {
        var tableid = '10005';
        $.ajax({
            url: '/api/json-getTable/' + tableid,
            type: 'GET',
            data: {
                ajax: true,
                data: "10005"
            },
            success: function (result) {
                defaulttable.loadJsonData(result);
            }
        });
        //return false;
    });

    $("#reset").click(function () {
        defaulttable.reset();
    });

    $("#highlevel_selct").click(function () {
        displayShowUI('high_level_table'); 
        displayHideUI('default_table');
        displayHideUI('highlevel_selct');
        displayShowUI('default_selct');
        displayHideUI('highlevel_declare');
    })

    $("#default_selct").click(function () {
        displayHideUI('high_level_table');
        displayHideUI('self_define_table');
        displayShowUI('default_table');
        displayShowUI('highlevel_selct');
        displayHideUI('default_selct');
        displayShowUI('highlevel_declare');
        location.reload();
    });


});

function selfdefinition(lie, type)
{
    displayShowUI('self_define_table');
    //row_template: ['text', 'select'],
    //$.each(lie, function (idx, value) {
    //    alert(value);
    //});
    //$.each(type, function (idx, value) {
    //    alert(value);
    //});
        selfdefinetable = $('#selfdefinetable').editTable({
        data: [['']],           // Fill the table with a js array (this is overridden by the textarea content if not empty)
        tableClass: 'inputtable',   // Table class, for styling
        jsonData: false,        // Fill the table with json data (this will override data property)
        headerCols: lie,      // Fix columns number and names (array of column names)
        maxRows: 999,           // Max number of rows which can be added
        first_row: true,        // First row should be highlighted?
        row_template: type,
        field_templates: {
            'checkbox': {
                html: '<input type="checkbox"/>',
                getValue: function (input) {
                    return $(input).is(':checked');
                },
                setValue: function (input, value) {
                    if (value) {
                        return $(input).attr('checked', true);
                    }
                    return $(input).removeAttr('checked');
                }
            },
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
                html: '<select><option value="">None</option><option>All</option></select>',
                getValue: function (input) {
                    return $(input).val();
                },
                setValue: function (input, value) {
                    var select = $(input);
                    select.find('option').filter(function () {
                        return $(this).val() === value;
                    }).attr('selected', true);
                    return select;
                }
            },
            'datetime': {
                html: '<input type="date" name="user_date" />',
                getValue: function (input) {
                    return $(input).val();
                },
                setValue: function (input, value) {
                    return $(input).text(value);
                }
            },
            'color': {
                html: '<input type="color" name="user_color" />',
                getValue: function (input) {
                    return $(input).val();
                },
                setValue: function (input, value) {
                    return $(input).text(value);
                }
            },
            'file': {
                html: '<input type="file" name="user_file" />',
                getValue: function (input) {
                    var str = $(input).val();
                    var arr = str.split('\\');//注split可以用字符或字符串分割 
                    var my = arr[arr.length - 1];//文件名
                    return my;
                },
                setValue: function (input, value) {
                    return $(input).text(value);
                }
            },
            'number': {
                html: '<input type="number" name="user_number" />',
                getValue: function (input) {
                    return $(input).val();
                },
                setValue: function (input, value) {
                    return $(input).text(value);
                }
            }
        },

        // Validate fields
        validate_field: function (col_id, value, col_type, $element) {
            return true;
        }
    });

    var options = {
        allowFileManager: true,
        imageUploadJson: '/Content/kindeditor/asp.net/upload_json.ashx',
        fileManagerJson: '/Content/kindeditor/asp.net/file_manager_json.ashx',
        width: "98%", //编辑器的宽度为70%
        height: "400px", //编辑器的高度为100px
        filterMode: false, //不会过滤HTML代码
        resizeMode: 1 //编辑器只能调整高度
    };
    var editor = KindEditor.create('textarea[name=user_textarea]', options);


    $('#sendJson_self').click(function () {
        var tname = $('#tableName').val();
        var filepath = "L:\\hooyes\\Files\\";//更改保存路径
        var formData = new FormData();
        $('input[type=file]').each(function (index, element) {
            formData.append("file1", element.files[0]);
        });

        $.ajax({
            url: '/api/json-saveTableFiles?filepath=' + filepath,
            type: 'POST',
            cache: false,
            data: formData,
            processData: false,
            contentType: false,
            async: false
        }).done(function (res) {

            $.ajax({
                url: '/api/json-createSelfTable?tablename=' + tname+'&type=' + type,
                type: 'POST',
                data: {
                    ajax: true,
                    data: selfdefinetable.getJsonData()
                },
                success: function (result) {
                    if (result) {
                        alert('创建成功')
                    }
                }
            });

        }).fail(function (res) {
            alert('文件上传失败，放弃保存')
        });


        return false;
    });

    $("#loadJson_self").click(function () {
        var tableid = '10005';
        $.ajax({
            url: '/api/json-getTable/' + tableid,
            type: 'GET',
            data: {
                ajax: true,
                data: "10005"
            },
            success: function (result) {
                selfdefinetable.loadJsonData(result);
            }
        });
        //return false;
    });

    $("#reset_self").click(function () {
        selfdefinetable.reset();
    });

    $("#reset_refersh").click(function () {
        var editor = KindEditor.create('textarea[name=user_textarea]', options);
    });


    


    //$("#selfdefinetable").on("focusin", "td:nth-child(1) input, td:nth-child(2) input", function () {
    //    $(this).datepicker();
    //});
}


function displayHideUI(uiid) {
    var ui = document.getElementById(uiid);
    ui.style.display = "none";
}
function displayShowUI(uiid) {
    var ui = document.getElementById(uiid);
    ui.style.display = "";
}