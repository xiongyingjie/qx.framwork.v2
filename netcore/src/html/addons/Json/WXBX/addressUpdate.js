render(function(){
var cfg=[];
cfg.push(
    group([
showInput('地点编号', 'address-address_id', '', '4'),
input('地点名', 'address-name', '', '4', {min:1,max:30}),
hide( 'address-father_id'),
showInput('负责人编号', 'address-manager_id', '', '4')
],'标题'));
return cfg;
},'wx.bx.address@update&id='+q.id,'wx.bx.address@find&id='+q.id,'编辑');