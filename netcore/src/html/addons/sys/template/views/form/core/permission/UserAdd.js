render([
    group([
input('用户ID', 'permission_user-user_id', '', '4', {min:1,max:100}),
input('用户名', 'permission_user-nick_name', '', '4', {min:1,max:100}),
input('密码', 'permission_user-user_pwd', '', '4', { min: 1, max: 100 }),
select('用户类型ID', 'permission_user-user_type_id', 'sys.core.user_type@items&name=name', '0', '4', false, { min: 1, max: 50 }),
        select('子系统', 'permission_user-sub_system_reg_id', 'sys.core.sub_system_reg@items&name=site', 'deafult', '4', false, { min: 1, max: 50 }),
input('邮箱', 'permission_user-email', '', '4'),
input('手机号', 'permission_user-phone', '', '4'),
hide('permission_user-note','从web版添加'),
hide('permission_user-register_date', '#now'),
hide('permission_user-last_login_date', '#now')
],'标题')],'sys.core.permission_user@add','','添加');