
var highleveltable;  //高级选项

$(document).ready(function () {

    var tid = $('#tableid').val();
    var tname = $('#tableName').val();

    var tablecolumn = [];
    tablecolumn.push('列ID');
    tablecolumn.push('列名');
    tablecolumn.push('控件类型');


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
                        return $(this).val() == value;
                    }).attr('selected', true);
                    return select;
                }
            }
        },
        row_template: ['text', 'text', 'select'],
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


    $.ajax({
        url: '/api/json-getTableLie',
        type: 'POST',
        data: {
            ajax: true,
            data: tid
        },
        success: function (result) {
            if (result) {
                highleveltable.loadJsonData(result);
            }
        }
    });

    $("#sendJson_high").click(function () {
        var tname = $('#tableName').val();
        $.ajax({
            url: '/api/json-saveTableLieEdit?tid=' + tid + '&tname=' + tname,
            type: 'POST',
            data: {
                ajax: true,
                //data: "jsonstring=" + defaulttable.getJsonData() + "&tablename=" + tname + "",
                //data: { jsonstring: defaulttable.getJsonData(), tablename: "aaa" },
                data: highleveltable.getJsonData()
            },
            success: function (result) {
                if (result) {
                    alert('保存成功');
                    location.href = '/Contents/Home2/TableList';
                }
            }
        });
    });

    $("#sendJson_high2").click(function () {
        location.href = '/Contents/Home2/TableList';
    });

});

