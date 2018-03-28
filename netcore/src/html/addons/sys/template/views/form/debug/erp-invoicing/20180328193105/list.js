List();
function List() {
    render(function (row,model) {
        var cfg = [
            table(model),
            button("刷新", "1:5", Color.blue, function () {
                List();
                }),
            button("关闭", "6:0", Color.blue, function () {
                    subClose();
                })
        ];
        return cfg;
            }, "", "erp.invoicing.brand@list", "列表", true);
}