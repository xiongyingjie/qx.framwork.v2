render([
    group([
hide('user_role-user_role_id', '#id'),
showinput('用户ID', 'user_role-user_id', q.user_id, '4', { min: 1, max: 100 }),
showinput('角色ID', 'user_role-role_id', q.role_id, '4', { min: 1, max: 100 }),
time('失效日期', 'user_role-expire_time', '', '4', '请选择失效日期'),
input('备注', 'user_role-note', '', '4')
    ], '确认要为用户[' + q.user_id + ']分配角色[' + q.role_id + ']吗?')], 'sys.core.user_role@add', '', '确认分配角色');