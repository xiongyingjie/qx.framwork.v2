$(document).ready(function () {

});





function displayHideUI(uiid) {
    var ui = document.getElementById(uiid);
    ui.style.display = "none";
}
function displayShowUI(uiid) {
    var ui = document.getElementById(uiid);
    ui.style.display = "";
}

//表格操作函数
function init_defaulttable(id) {
    var tableid = id;
    var url = '/Contents/Home2/TableDataList?tableid=' + tableid;
    location.href = url;
}

function init_defaultlietable(id, name) {
    var tableid = id;
    var url = '/Contents/Home2/TableLieList?tableid=' + tableid + '&tablename=' + name;
    location.href = url;
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