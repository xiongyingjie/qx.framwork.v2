$(document).ready(function () {

    var lie = $('#tablelie').val();
    var type = $('#tabletype').val();
    var lies = lie.split(",");
    var types = type.split(",");
    var value = $('#tablevalue').val();
    var values = value.split(",");
    var value_g = [];
    $(values).each(function (index, element) {
        var gt = [];
        gt.push(element);
        value_g.push(gt);
    });


    addedittable = $('#addedittable').editTable({
        data: (value_g == null ? [['']] : value_g),           // Fill the table with a js array (this is overridden by the textarea content if not empty)
        tableClass: 'inputtable',   // Table class, for styling
        jsonData: false,        // Fill the table with json data (this will override data property)
        headerCols: lies,      // Fix columns number and names (array of column names)
        maxRows: 999,           // Max number of rows which can be added
        first_row: true,        // First row should be highlighted?
        row_template: types,
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
                    return $(input).find("iframe").contents().find("body").html();
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
                        return $(this).val() == value;
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
                    return $(input).attr("value", value);
                    //return $(input).val(value);
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
                    return $(input).attr("value", value);
                    //return $(input).text(value);
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

    $('#Json_addedit').click(function () {
        var tname = $('#tableName').val();
        //var filepath = "L:\\hooyes\\Files\\";//更改保存路径
        var filepath = $('#fileurl').val();
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
                url: '/api/json-createSelfTable?tablename=' + tname + '&type=' + type,
                type: 'POST',
                data: {
                    ajax: true,
                    data: addedittable.getJsonData()
                },
                success: function (result) {
                    if (result) {
                        alert('创建成功');
                        location.href = '/Contents/Home2/TableList';
                    }
                }
            });

        }).fail(function (res) {
            alert('文件上传失败，放弃保存');
        });


        return false;
    });

    $('#Json_saveaddedit').click(function () {
        var tID = $('#tableID').val();
        var relationKey = $('#relationKey').val();
        //var filepath = "L:\\hooyes\\Files\\";//更改保存路径
        var filepath = $('#fileurl').val();
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
                url: '/api/json-editTableRowAfter?tableid=' + tID + '&relationkeyID=' + relationKey,
                type: 'POST',
                data: {
                    ajax: true,
                    data: addedittable.getJsonData()
                },
                success: function (result) {
                    if (result) {
                        alert('保存成功');
                        location.href = '/Contents/Home2/TableDataList?tableid=' + tID;
                    }
                }
            });

        }).fail(function (res) {
            alert('文件上传失败，放弃保存')
        });


        return false;
    });

    $("#reset_self").click(function () {
        selfdefinetable.reset();
    });

    $("#backtoList").click(function () {
        if (confirm("将丢失当前编辑并重新开始？")) {
            location.href = '/Contents/Home2/EasyTable';
        }
    });

});