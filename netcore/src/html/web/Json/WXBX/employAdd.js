render([
    group([
input('人员编号', 'employ-user_id', '', '4', {min:1,max:50}),
input('姓名', 'employ-name', '', '4', {min:1,max:10}),
input('联系电话', 'employ-phone', '', '4'),
select('人员类型', 'employ-type', 'wx.bx.employ_type@items&name=name', '', '4')
],'标题')],'wx.bx.employ@add','','添加');