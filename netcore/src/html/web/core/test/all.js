render(function () {
    var cfg=[];
    cfg.push(input('', 'ecampus-twxt2-2017-11-24-15-27-55', '', 6));
    cfg.push(dropdown('ecampus-twxt2-2017-11-24-15-27-55',
              [
                  { text: '添加', value: '*f/debug/ecampus-twxt2/2017-11-24-15-27-55/add', id: 'ecampus-twxt2-2017-11-24-15-27-55-add' },
                  { text: '编辑', value: '*f/debug/ecampus-twxt2/2017-11-24-15-27-55/update', id: 'ecampus-twxt2-2017-11-24-15-27-55-update' },
                  { text: '详情', value: '*f/debug/ecampus-twxt2/2017-11-24-15-27-55/detail', id: 'ecampus-twxt2-2017-11-24-15-27-55-detail' },      
                  { text: '删除', value: 'ecampus.twxt2.association_member@delete', id: 'ecampus-twxt2-2017-11-24-15-27-55-delete' },
                  { text: '下拉', value: '*f/debug/ecampus-twxt2/2017-11-24-15-27-55/items', id: 'ecampus-twxt2-2017-11-24-15-27-55-items' },
                  { text: '列表', value: '*f/debug/ecampus-twxt2/2017-11-24-15-27-55/list', id: 'ecampus-twxt2-2017-11-24-15-27-55-list' }
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
    var testIdArray=['ecampus-twxt2-2017-11-24-15-27-55',"init"];
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
