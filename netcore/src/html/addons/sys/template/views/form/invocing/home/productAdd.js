render([
    group([
input('商品编号', 'product-product_id', _c.random(), '4', {min:1,max:50}),
input('主条码', 'product-main_code', '123', '4', {min:1,max:50}),
input('商品名称', 'product-name', '测试商品', '4', {min:1,max:100}),
input('拼音码', 'product-pinyin_code', 'ceshishangpin', '4', {min:1,max:50}),
input('参考进价', 'product-in_price', '59', '4', {float:true}),
input('零售价', 'product-out_price', '56', '4', {float:true}),
input('批发价', 'product-batch_out_price', '45', '4', { float: true }),


select('计量单位', 'product-product_unit_id', 'erp.invoicing.product_unit@items&name=name', '', '4'),
//input('计量单位', 'product-product_unit_id', '', '4', {min:1,max:50}),


        select('商品状态', 'product-satatus', [{ text: '不可用', value: 0, selected: true }, { text: '可用', value: 1 }], 1, '4'),


select('商品分类', 'product-product_type_id', 'erp.invoicing.product_type@items&name=name', '4'),
//input('商品分类', 'product-product_type_id', '', '4', { min: 1, max: 50 }),


select('商品品牌', 'product-brand_id', 'erp.invoicing.brand@items&name=name', '1', '4'),
select('供应商', 'product-provider_id', 'erp.invoicing.provider@items&name=name', '2', '4'),
//input('供应商', 'product-provider_id', '', '4', {min:1,max:50}),


editor('详细介绍', 'product-detail'),
hide('product-category_id'),
hide('product-is_struct'),
hide('product-is_service'),
hide('product-thumbnail'),
hide('product-produce_place')
],'商品信息')],'erp.invoicing.product@add','','添加商品');