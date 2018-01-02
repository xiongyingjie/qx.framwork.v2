render([
    group([
showInput('社团名', 'association-name', '', '3'),
showTime('创建时间', 'association-createTime', '', '3'),
showInput('社团创建人', 'permission_user-nick_name', '', '3'),
//showInput('社团id', 'association-association_id', '', '4'),
showArea('描述', 'association-describe'),
showFile('相关文件', 'association-related_file')
//showInput('创建人', 'association-uid', '', '4'),
//showInput('状态（1申请中2草稿，-1已批准100开放中200关闭）', 'association-status', '', '4'),
//showInput('用户ID', 'permission_user-user_id', '', '4'),
//showInput('密码', 'permission_user-user_pwd', '', '4'),
//showEditor('邮箱', 'permission_user-email'),
//showEditor('手机号', 'permission_user-phone'),
//showInput('用户类型ID', 'permission_user-user_type_id', '', '4'),
//showEditor('备注', 'permission_user-note'),
//showTime('注册时间', 'permission_user-register_date', '', '4'),
//showTime('最近登入时间', 'permission_user-last_login_date', '', '4')
    ], '标题')], '',
'ecampus.twxt2.association@list'
.jn('permission_user.user_id', 'uid')
.eq('association_id',q.id)
, '', '详情');