render([
    group([
hide('address-address_id','#id'),
input('地点名', 'address-name', '', '4', {min:1,max:30}),
hide('address-father_id', q.father_id),
input('负责人编号', 'address-manager_id', '', '4')
],'标题')],'wx.bx.address@add','','添加');