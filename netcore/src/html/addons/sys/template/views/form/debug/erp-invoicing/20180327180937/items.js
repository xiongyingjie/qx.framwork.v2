render([
    group([
        pre("select('<span class='item_lable'></span>', 'product-<span class='item_key'></span>', 'erp.invoicing.product@items&name=<span class='item_name'></span>', '<span id='item_deafultValue'></span>', '4')", 1),
         select("选字段", "choose_column", "erp.invoicing.product@info", "", "4"),
         select("<span class='item_lable'>下拉</span>", "test_dropdown", "erp.invoicing.product@items&name=", "", "4")
    ], "生成数据字典")], "", "", "测试数据字典");
                    function formReady() {
    $.bindSelect("choose_column", "test_dropdown", 'erp.invoicing.product@items', true, function(src, target) {
        src.val(src.find("option:nth(1)").val());        
        $(".item_key").html(src.find("option:first").val()); 
        $(".item_name").html(src.val());
        $(".item_lable").html(src.find("option:selected").text());
                            target.change(function() {
            $("#item_deafultValue").html($(this).val());
                            });
                        });
                    }
                    