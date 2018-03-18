render(function(model){
var cfg=[];
cfg.push(
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
hide('product-category_id'),
hide('product-is_struct'),
hide('product-is_service'),
hide('product-thumbnail'),
hide('product-produce_place')
],'标题'));
return cfg;
},'erp.invoicing.product@update&id='+q.id,'erp.invoicing.product@find&id='+q.id,'编辑');