render([
    group([
showInput('用户ID', 'permission_user-user_id', '', '4'),
showInput('用户名', 'permission_user-nick_name', '', '4'),
showInput('密码', 'permission_user-user_pwd', '', '4'),
showInput('邮箱', 'permission_user-email', '', '4'),
showInput('手机号', 'permission_user-phone', '', '4'),
showInput('用户类型ID', 'permission_user-user_type_id', '', '4'),
showEditor('备注', 'permission_user-note'),
showTime('注册时间', 'permission_user-register_date', '', '4'),
showTime('最近登入时间', 'permission_user-last_login_date', '', '4')
],'标题')],'','sys.core.permission_user@find&id='+q.id,'','详情');