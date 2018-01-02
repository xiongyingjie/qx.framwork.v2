render([
    group([
input('用户组ID', 'user_group-user_group_id', '', '4', {min:1,max:100}),
input('用户组名称', 'user_group-user_group_name', '', '4', {min:1,max:100}),
input('父亲ID', 'user_group-father_id', '', '4', {min:1,max:100})
],'标题')],'qx.permmision.v2.user_group@add','','添加');