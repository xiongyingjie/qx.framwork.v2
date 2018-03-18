
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
input('产品类别编号', 'product-category_id', '', '4', {min:1,max:50}),
input('结构产品', 'product-is_struct', '', '4', {int:true}),
input('服务产品', 'product-is_service', '', '4', {int:true}),
input('缩略图', 'product-thumbnail', '', '4', {min:1,max:200}),
input('商品产地', 'product-produce_place', '', '4', {min:1,max:50}),
input('单位编号', 'product_unit-product_unit_id', '', '4', {min:1,max:50}),
input('单位名称', 'product_unit-name', '', '4', {min:1,max:50}),
input('品牌编号', 'brand-brand_id', '', '4', {min:1,max:50}),
input('品牌名称', 'brand-name', '', '4', {min:1,max:50}),
input('排序', 'brand-sequence', '', '4', {int:true}),
input('品牌网址', 'brand-url', '', '4', {min:1,max:100}),
input('品牌图标', 'brand-logo', '', '4', {min:1,max:100}),
input('品牌说明', 'brand-descripe', '', '4', {min:1,max:100}),
input('备注', 'brand-note', '', '4', {min:1,max:100}),
input('产品类别编号', 'category-category_id', '', '4', {min:1,max:50}),
input('产品类别', 'category-name', '', '4', {min:1,max:50}),
input('类别状态', 'category-status', '', '4', {int:true}),
file('备注', 'category-note'),
hide('provider-provider_id'),
input('供应商名称', 'provider-name', '', '4', {min:1,max:50}),
input('地址', 'provider-address', '', '4', {min:1,max:50}),
input('联系人', 'provider-contactor', '', '4', {min:1,max:50}),
input('联系电话', 'provider-phone', '', '4', {min:1,max:50}),
input('邮箱', 'provider-email', '', '4', {min:1,max:50}),
input('状态', 'provider-status', '', '4', {int:true})
],'标题'));
return cfg;
},'','erp.invoicing.product@find|product_unit@find|brand@find|category@find|provider@find&id='+q.id,'详情');