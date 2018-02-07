render([
    group([
showInput('用户名', 'permission_user-nick_name', '', '4'),
showInput('性别', 'association_member-sex', '', '4'),
showInput('部门名', 'asso_depart-department_name', '', '4'),
showTime('申请加入的时间', 'association_member-apply_time', '', '4'),
showInput('爱好', 'association_member-prefer', '', '4'),
showInput('手机号码', 'association_member-phone', '', '4'),
showInput('邮箱', 'association_member-email', '', '4')
//hide('成员id', 'association_member-asso_member_id', '', '4'),
//hide('社团id', 'association_member-association_id', '', '4'),
//hide('学生id', 'association_member-student_id', '', '4'),
//hide('所在部门编号', 'association_member-department_id', '', '4'),
//hide('入社团时间', 'association_member-enroll_time', '', '4'),
//hide('1待审核2在团3离团-1审核不通过', 'association_member-status', '', '4'),
//hide('审核人', 'association_member-auditor', '', '4'),
//hide('特长', 'association_member-merit', '', '4'),
//hide('附件', 'association_member-relatedfile'),
//hide('社团id', 'asso_depart-association_id', '', '4'),
//hide('部门id', 'asso_depart-department_id', '', '4'),
//hide('部门描述', 'asso_depart-describe'),
//hide('创建时间', 'asso_depart-create_time', '', '4'),
//hide('用户ID', 'permission_user-user_id', '', '4'),
//hide('密码', 'permission_user-user_pwd', '', '4'),
//hide('邮箱', 'permission_user-email'),
//hide('手机号', 'permission_user-phone'),
//hide('用户类型ID', 'permission_user-user_type_id', '', '4'),
//hide('备注', 'permission_user-note'),
//hide('注册时间', 'permission_user-register_date', '', '4'),
//hide('最近登入时间', 'permission_user-last_login_date', '', '4')
    ], '用户详情')], '',
'ecampus.twxt2.association_member@list'
.jn('asso_depart.department_id')
.jn('permission_user.user_id', 'student_id')
.eq('asso_member_id',q.id)
, '', '详情');