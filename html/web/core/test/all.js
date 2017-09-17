render(function () {
    var cfg=[];
    cfg.push(input('', 'wx-sports-2017-09-12-19-46-08', '', 6));
    cfg.push(dropdown('wx-sports-2017-09-12-19-46-08',
              [
                  { text: '添加', value: '*f/debug/wx-sports/2017-09-12-19-46-08/add', id: 'wx-sports-2017-09-12-19-46-08-add' },
                  { text: '编辑', value: '*f/debug/wx-sports/2017-09-12-19-46-08/update', id: 'wx-sports-2017-09-12-19-46-08-update' },
                  { text: '详情', value: '*f/debug/wx-sports/2017-09-12-19-46-08/detail', id: 'wx-sports-2017-09-12-19-46-08-detail' },      
                  { text: '删除', value: 'wx.sports.base_activity@delete|match@delete', id: 'wx-sports-2017-09-12-19-46-08-delete' },
                  { text: '下拉', value: '*f/debug/wx-sports/2017-09-12-19-46-08/items', id: 'wx-sports-2017-09-12-19-46-08-items' },
                  { text: '列表', value: '*f/debug/wx-sports/2017-09-12-19-46-08/list', id: 'wx-sports-2017-09-12-19-46-08-list' }
              ]));

    cfg.push(html("<hr/>"));
    cfg.push(button("刷新", "1:5", Color.green, function () {
        location.reload();
    }));
    cfg.push(button("关闭", "6:0", Color.red, function () {
        subClose();
    }));

    return cfg;
});
function formReady() {
    var testIdArray=['wx-sports-2017-09-12-19-46-08',"init"];
    for (var i = 0; i < testIdArray.length; i++) {
        bindParam(testIdArray[i]);
    }
}
function bindParam(testId) {
    $("#" + testId).change(function () {
        //var add = $("#" + testId + "-" + "add");
        //var items = $("#" + testId + "-" + "items");
        var update = $("#" + testId + "-" + "update");
        var detail = $("#" + testId + "-" + "detail");
        var del = $("#" + testId + "-" + "delete");
        // add.attr("data-url", add.attr("data-baseurl"));
        //items.attr("data-url", items.attr("data-baseurl") + "?name=" + $(this).val());
        update.attr("data-url", update.attr("data-baseurl") + "?id=" + $(this).val());
        detail.attr("data-url", detail.attr("data-baseurl") + "?id=" + $(this).val());
        del.attr("data-url", del.attr("data-baseurl") + "&id=" + $(this).val());

    });

}
