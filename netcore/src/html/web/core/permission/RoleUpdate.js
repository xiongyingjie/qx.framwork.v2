render(function(){
var cfg=[];
cfg.push(
    group([
input('角色ID', 'role-role_id', $.random(), '4'),
input('角色名称', 'role-name', '', '4', { min: 1, max: 100 }),
select('角色类型', 'role-role_type', [{ text: "功能角色", value: "1" }, { text: "数据角色", value: "2" }]),
select('自动分配给新用户', 'role-is_default', [{ text: "是", value: "1" }, { text: "否", value: "0" }]),
input('所属子系统', 'role-sub_system', '-', '4', { min: 1, max: 50 })
],'标题'));
return cfg;
},'qx.permmision.v2.role@update&id='+q.id,'qx.permmision.v2.role@find&id='+q.id,'编辑');