render(function(){
var cfg=[];
cfg.push(
    group([
input('设备编号', 'device-device_id', '', '4', {min:1,max:50}),
input('类型ID', 'device-device_type_id', '', '4', {min:1,max:50}),
input('地点编号', 'device-address_id', '', '4', {min:1,max:50}),
input('设备名称', 'device-name', '', '4', {min:1,max:20}),
input('品牌编号', 'device-brand_id', '', '4', {min:1,max:50}),
input('设备型号', 'device-model', '', '4', {min:1,max:20}),
input('负责维修的部门编号', 'device-repair_dept', '', '4', {int:true}),
input('0正常1维修中2报废3其他', 'device-state_id', '', '4', {int:true})
],'标题'));
return cfg;
},'wx.bx.device@update&id='+q.id,'wx.bx.device@find&id='+q.id,'编辑');