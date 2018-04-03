render(function(model){
var cfg=[];
cfg.push(
    group([
input('组装流水号', 'product_combine_detail-product_combine_detail_id', '', '4', {min:1,max:50}),
        hide('product_combine_detail-product_combine_id',q.id),
select('组合的商品', 'product_combine_detail-product_id', 'erp.invoicing.product@items&name=name', '', '4'),
input('组合数量', 'product_combine_detail-num', '', '4', {int:true}),
input('备注', 'product_combine_detail-note', '', '4')
],'标题'));
return cfg;
},'','erp.invoicing.product_combine_detail@find&id='+q.id,'详情');