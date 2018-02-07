render([
    group([
showInput('设备编号', 'device-device_id', '', '4'),
showInput('类型ID', 'device-device_type_id', '', '4'),
showInput('地点编号', 'device-address_id', '', '4'),
showInput('设备名称', 'device-name', '', '4'),
showInput('品牌编号', 'device-brand_id', '', '4'),
showInput('设备型号', 'device-model', '', '4'),
showInput('负责维修的部门编号', 'device-repair_dept', '', '4'),
showInput('0正常1维修中2报废3其他', 'device-state_id', '', '4')
],'标题')],'','wx.bx.device@find&id='+q.id,'','详情');