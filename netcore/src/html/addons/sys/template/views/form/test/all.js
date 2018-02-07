render(function () {
    var cfg=[];
    cfg.push(input('', 'sys-app-20180108022144', '', 6));
    cfg.push(dropdown('sys-app-20180108022144',
              [
                  { text: '添加', value: '*f/debug/sys-app/20180108022144/add', id: 'sys-app-20180108022144-add' },
                  { text: '编辑', value: '*f/debug/sys-app/20180108022144/update', id: 'sys-app-20180108022144-update' },
                  { text: '详情', value: '*f/debug/sys-app/20180108022144/detail', id: 'sys-app-20180108022144-detail' },      
                  { text: '删除', value: 'sys.app.panda_site_clothes_site@delete', id: 'sys-app-20180108022144-delete' },
                  { text: '下拉', value: '*f/debug/sys-app/20180108022144/items', id: 'sys-app-20180108022144-items' },
                  { text: '列表', value: '*f/debug/sys-app/20180108022144/list', id: 'sys-app-20180108022144-list' }
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
    var testIdArray=['sys-app-20180108022144',"init"];
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
