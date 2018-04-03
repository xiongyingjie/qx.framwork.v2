render(function(model){
var cfg=[];
cfg.push(
    group([
input('货号', 'product-product_id', '', '4', {min:1,max:50}),
input('商品名称', 'product-name', '', '4', {min:1,max:100}),
input('主条码', 'product-main_code', '', '4', {min:1,max:50}),
input('零售价', 'product-out_price', '', '4', {float:true}),
input('批发价', 'product-batch_out_price', '', '4', {float:true}),
select('计量单位', 'product-product_unit_id', 'erp.invoicing.product_unit@items&name=name', '', '4'),
input('商品品态', 'product-satatus', '', '4', {min:1,max:50}),
input('参考进价', 'product-in_price', '', '4', {float:true}),
select('商品类别', 'product-product_type_id', 'erp.invoicing.product_type@items&name=name', '', '4'),
select('商品品牌', 'product-brand_id', 'erp.invoicing.brand@items&name=name', '', '4'),
select('主供应商', 'product-provider_id', 'erp.invoicing.provider@items&name=name', '', '4'),
hide('product-pinyin_code'),
select('所属分类', 'product-category_id', 'erp.invoicing.category@items&name=name', '', '4'),
editor('详细介绍', 'product-detail'),
hide('product-lockor'),
hide('product-is_service'),
hide('product-thumbnail'),
hide('product-produce_place')
],'标题'));
return cfg;
},'','erp.invoicing.product@find&id='+q.id,'详情');