render([
    group([
showInput('角色组ID', 'role_group-role_group_id', '', '4'),
showInput('角色组名称', 'role_group-role_group_name', '', '4'),
showInput('父亲ID', 'role_group-father_id', '', '4')
],'标题')],'','sys.core.role_group@find&id='+q.id,'','详情');