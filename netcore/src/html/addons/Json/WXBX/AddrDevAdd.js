render([
    group([
hide('device-device_id','#id'),
hide('device-address_id', q.id),
input('设备名称', 'device-name', '', '4', {min:1,max:20}),
select('品牌', 'device-brand_id', 'wx.bx.brand@items&name=name'),
input('设备型号', 'device-model', '', '4', { min: 1, max: 20 }),
select('类型ID', 'device-device_type_id', 'wx.bx.device_type@items&name=name'),
//input('负责维修的部门编号', 'device-repair_dept', '', '4', {int:true}),
select('设备状态', 'device-state_id', 'wx.bx.dev_state@items&name=name','0')
],'标题')],'wx.bx.device@add','','添加');