render([
    group([
hide( 'user_orgnization-user_orgnization_id', '#id'),
input('机构ID', 'user_orgnization-orgnization_id', q.id),
input('用户ID', 'user_orgnization-user_id', q.userid)
    ], '标题')], 'qx.permmision.v2.user_orgnization@add', '', '添加');