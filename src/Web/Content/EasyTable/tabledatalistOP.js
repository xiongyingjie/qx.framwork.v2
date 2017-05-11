$(document).ready(function () {

    var tableid = $("#tableid").val();
    init_defaulttable(tableid);
});




//表格操作函数
function init_defaulttable(id) {
    var tableid = id;
    $.ajax({
        url: '/api/json-getTable?tableid=' + tableid,
        type: 'GET',
        data: {
            ajax: true,
            data: tableid
        },
        success: function (result) {
            var a = JSON.stringify(result);
            var obj = eval('(' + a + ')');
            var lie = [];
            var values = [];
            $.each($.parseJSON(obj), function (index, value) {

                if (index == 0) {
                    $.each(value, function (i, v) {
                        lie.push(v);
                    });
                }
                else {
                    var newt = [];
                    $.each(value, function (i, v) {

                        newt.push(v);
                        //alert(v);

                    });
                    values.push(newt);
                }
            });
            //defaulttable.loadJsonData(result);多行string文本编辑时使用该方法

            var defaulttable = $('#defaulttable').editTable({
                data: values,           // Fill the table with a js array (this is overridden by the textarea content if not empty)
                tableClass: 'inputtable',   // Table class, for styling
                jsonData: false,        // Fill the table with json data (this will override data property)
                headerCols: lie,      // Fix columns number and names (array of column names)
                maxRows: 999,           // Max number of rows which can be added
                first_row: true,        // First row should be highlighted?
                row_template: false,    // An array of column types set in field_templates
                field_templates: false, // An array of custom field type objects

                // Validate fields
                validate_field: function (col_id, value, col_type, $element) {
                    return true;
                }
            });

            // Add row
            $(".editrow").on('click', function () {

                var relationkeyID = $(this).parent('td').prev().find('input[type="text"]').val();

                var lie1 = lie;
                var values1 = [];
                var nowObj = $(this).parent('td').prev();
                while (true) {
                    if (nowObj.html()) {
                        var newt1 = [];
                        var rowvalue = newt1.push(nowObj.find('input[type="text"]').val());
                        values1.push(newt1);
                        nowObj = nowObj.prev();
                        continue;
                    }
                    else {
                        break;
                    }

                }
                lie1.pop();
                $.ajax({
                    url: '/api/json-editTableRowBefore?tableid=' + tableid,
                    type: 'POST',
                    data: {
                        ajax: true,
                        data: ""
                    },
                    success: function (result) {
                        if (result) {
                            location.href = '/Contents/Home2/AddEditPage_Edit?lie=' + lie1 + '&type=' + result + '&tid=' + tableid + '&value=' + values1 + '&relationkeyID=' + relationkeyID;
                        }
                    }
                });
            });

            // Delete row
            $(".delrow2").on('click', function () {

                var relationkeyID = $(this).parent('td').prev().find('input[type="text"]').val();
                alert(relationkeyID);

                $.ajax({
                    url: '/api/json-deleteTableRow?relationkeyID=' + relationkeyID,
                    type: 'POST',
                    data: {
                        ajax: true,
                        data: addedittable.getJsonData()
                    },
                    success: function (result) {
                        if (result) {
                            alert('删除成功');
                            $(this).closest('tr').remove();
                            //location.href = '/Contents/Home2/TableList';
                        }
                        else {
                            alert('删除失败');
                        }
                    }
                });
            });
        }
    });
}

function del_defaulttable(id) {
    //alert($(this).val());
    var tableid = id;
    $.ajax({
        url: '/api/json-deleteTable?tableid=' + tableid,
        type: 'POST',
        data: {
            ajax: true,
            data: tableid
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


function isEmptyObject(e) {
    var t;
    for (t in e)
        return !1;
    return !0
}