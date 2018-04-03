render(function(model){
var cfg=[];
cfg.push(
    group([
input('商品分类编号', 'product_type-product_type_id', '', '4', {min:1,max:50}),
input('分类名称', 'product_type-name', '', '4', {min:1,max:50}),
showSelect('上级分类', 'product_type-father_id', 'erp.invoicing.product_type@items&name=name', '', '4'),
input('备注', 'product_type-note', '', '4')
],'标题'));
return cfg;
},'','erp.invoicing.product_type@find&id='+q.id,'详情');