render([
    group([
input('商品编号', 'product-product_id', '', '4', {min:1,max:50}),
input('主条码', 'product-main_code', '', '4', {min:1,max:50}),
input('商品名称', 'product-name', '', '4', {min:1,max:100}),
input('拼音码', 'product-pinyin_code', '', '4', {min:1,max:50}),
input('参考进价', 'product-in_price', '', '4', {float:true}),
input('零售价', 'product-out_price', '', '4', {float:true}),
input('批发价', 'product-batch_out_price', '', '4', {float:true}),
input('计量单位', 'product-product_unit_id', '', '4', {min:1,max:50}),
input('商品状态', 'product-satatus', '', '4', {min:1,max:50}),
input('商品分类', 'product-product_type_id', '', '4', {min:1,max:50}),
input('商品品牌', 'product-brand_id', '', '4', {min:1,max:50}),
input('供应商', 'product-provider_id', '', '4', {min:1,max:50}),
editor('详细介绍', 'product-detail'),
input('产品类别编号', 'product-category_id', '', '4', {min:1,max:50}),
input('结构产品', 'product-is_struct', '', '4', {int:true}),
input('服务产品', 'product-is_service', '', '4', {int:true}),
input('缩略图', 'product-thumbnail', '', '4', {min:1,max:200}),
input('商品产地', 'product-produce_place', '', '4', {min:1,max:50})
],'标题')],'erp.invoicing.product@add','','添加');