render(function(){
var cfg=[];
cfg.push(
    group([
input('角色组ID', 'role_group-role_group_id', '', '4', {min:1,max:100}),
input('角色组名称', 'role_group-role_group_name', '', '4', {min:1,max:100}),
input('父亲ID', 'role_group-father_id', '', '4', {min:1,max:100})
],'标题'));
return cfg;
},'sys.core.role_group@update&id='+q.id,'sys.core.role_group@find&id='+q.id,'编辑');