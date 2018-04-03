render(function(model){
var cfg=[];
cfg.push(
    group([
input('货号', 'product_deposit-product_deposit_id', '', '4', {min:1,max:50}),
input('商品名称', 'product_deposit-name', '', '4', {min:1,max:100}),
input('主条码', 'product_deposit-main_code', '', '4', {min:1,max:50}),
input('零售价', 'product_deposit-out_price', '', '4', {float:true}),
input('批发价', 'product_deposit-batch_out_price', '', '4', {float:true}),
select('计量单位', 'product_deposit-product_unit_id', 'erp.invoicing.product_unit@items&name=name', '', '4'),
input('参考进价', 'product_deposit-in_price', '', '4', {float:true}),
select('商品类别', 'product_deposit-product_type_id', 'erp.invoicing.product_type@items&name=name', '', '4'),
select('商品品牌', 'product_deposit-brand_id', 'erp.invoicing.brand@items&name=name', '', '4'),
select('主供应商', 'product_deposit-provider_id', 'erp.invoicing.provider@items&name=name', '', '4'),
input('拼音码', 'product_deposit-pinyin_code', '', '4'),
select('所属分类', 'product_deposit-category_id', 'erp.invoicing.category@items&name=name', '', '4'),
editor('详细介绍', 'product_deposit-detail'),
hide('product_deposit-satatus')
],'标题'));
return cfg;
},'','erp.invoicing.product_deposit@find&id='+q.id,'详情');