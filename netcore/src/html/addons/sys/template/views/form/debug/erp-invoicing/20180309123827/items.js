render([
    group([
        pre("select('下拉', 'test_dropdown', 'erp.invoicing.product@items&name=<span id='item_name'></span>', '<span id='item_deafultValue'></span>', '4')", 1),
         select("选字段", "choose_column", "erp.invoicing.product@info", "", "4"),
         select("<span id='item_lable'>下拉</span>", "test_dropdown", "erp.invoicing.product@items&name=", "", "4")
    ], "下拉代码生成")], "", "", "下拉测试");
                    function formReady() {
    $.bindSelect("choose_column", "test_dropdown", 'erp.invoicing.product@items', true, function(src, target) {
        $("#item_name").html(src.val());
        $("#item_lable").html(src.find("option:selected").text());
                            target.change(function() {
            $("#item_deafultValue").html($(this).val());
                            });
                        });
                    }
                    