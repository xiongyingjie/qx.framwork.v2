render([
    group([
hide( 'user_orgnization-user_orgnization_id', '#id'),
input('机构ID', 'user_orgnization-orgnization_id', q.id),
input('用户ID', 'user_orgnization-user_id', q.userid)
    ], '确认要为用户[' + q.userid + ']分配机构[' + q.id+']吗?')], 'sys.core.user_orgnization@add', '', '确认分配机构');