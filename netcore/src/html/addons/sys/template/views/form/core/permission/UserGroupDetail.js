render([
    group([
showInput('用户组ID', 'user_group-user_group_id', '', '4'),
showInput('用户组名称', 'user_group-user_group_name', '', '4'),
showInput('父亲ID', 'user_group-father_id', '', '4')
],'标题')],'','sys.core.user_group@find&id='+q.id,'','详情');