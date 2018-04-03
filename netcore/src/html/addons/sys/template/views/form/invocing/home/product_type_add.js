
render([
    group([
        input('商品分类编号', 'product_type-product_type_id', q.fid+'.', '4', {min:1,max:50}),
input('分类名称', 'product_type-name', '', '4', {min:1,max:50}),
select('上级分类', 'product_type-father_id', 'erp.invoicing.product_type@items&name=name', q.fid, '4'),
input('备注', 'product_type-note', '', '4')
],'标题')],'erp.invoicing.product_type@add','','添加');