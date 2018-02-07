render([
    group([
showInput('角色ID', 'role-role_id', '', '4'),
showInput('角色名称', 'role-name', '', '4'),
showInput('角色类型1功能角色2数据角色', 'role-role_type', '', '4'),
showInput('所属子系统', 'role-sub_system', '', '4'),
showInput('默认角色', 'role-is_default', '', '4')
],'标题')],'','qx.permmision.v2.role@find&id='+q.id,'','详情');