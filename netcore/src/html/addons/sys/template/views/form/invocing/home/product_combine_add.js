﻿render([
    group([
input('货号', 'product_combine-product_combine_id', _c.random(), '4', {min:1,max:50}),
input('组合名称', 'product_combine-name', '', '4', {min:1,max:50}),
input('组装单价(元)', 'product_combine-price', '', '4', {float:true}),
input('组合条码', 'product_combine-main_code', '', '4'),
hideTime('product_combine-create_time'),
area('备注', 'product_combine-note')
],'标题')],'erp.invoicing.product_combine@add','','添加');