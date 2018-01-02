render([
    group([
input('地点编号', 'address_id', '', '4', {min:1,max:50}),
input('地点名', 'name', '', '4', {min:1,max:30}),
input('父地点编号', 'father_id', '', '4', {min:1,max:50}),
input('负责人编号', 'manager_id', '', '4', {min:1,max:50})
],'标题')],'wx.bx.address@add','','添加');