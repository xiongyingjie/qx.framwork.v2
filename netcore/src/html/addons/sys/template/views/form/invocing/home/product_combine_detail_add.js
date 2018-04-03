render([
    group([
input('组装流水号', 'product_combine_detail-product_combine_detail_id',  _c.random(), '4', {min:1,max:50}),
hide('product_combine_detail-product_combine_id',q.id),
select('组合的商品', 'product_combine_detail-product_id', 'erp.invoicing.product@items&name=name', '', '4'),
input('组合数量', 'product_combine_detail-num', 1, '4', {int:true}),
input('备注', 'product_combine_detail-note', '', '4')
],'设置要组合的商品信息')],'erp.invoicing.product_combine_detail@add','','添加新商品到组合商品');