render(function () {
    var cfg=[];
    cfg.push(input('', 'erp-invoicing-20180328193105', '', 6));
    cfg.push(dropdown('erp-invoicing-20180328193105',
              [
                  { text: '添加', value: '*f/debug/erp-invoicing/20180328193105/add', id: 'erp-invoicing-20180328193105-add' },
                  { text: '编辑', value: '*f/debug/erp-invoicing/20180328193105/update', id: 'erp-invoicing-20180328193105-update' },
                  { text: '详情', value: '*f/debug/erp-invoicing/20180328193105/detail', id: 'erp-invoicing-20180328193105-detail' },      
                  { text: '删除', value: 'erp.invoicing.brand@delete', id: 'erp-invoicing-20180328193105-delete' },
                  { text: '下拉', value: '*f/debug/erp-invoicing/20180328193105/items', id: 'erp-invoicing-20180328193105-items' },
                  { text: '列表', value: '*f/debug/erp-invoicing/20180328193105/list', id: 'erp-invoicing-20180328193105-list' }
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
    var testIdArray=['erp-invoicing-20180328193105',"init"];
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
