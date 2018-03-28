render([
    group([
input('产品类别编号', 'category-category_id', '', '4', {min:1,max:50}),
input('产品类别', 'category-name', '', '4'),
input('类别状态', 'category-status', '', '4'),
file('备注', 'category-note')
],'标题')],'erp.invoicing.category@add','','添加');