render([
    group([
hide('成员id', 'association_member-asso_member_id', '#id', '4', { min: 1, max: 50 }),
hide('社团id', 'association_member-association_id', q.id, '4', { min: 1, max: 50 }),
hide('学生id', 'association_member-student_id', '#uid', '4', { min: 1, max: 100 }),
select('部门名称', 'association_member-department_id', 'ecampus.twxt2.asso_depart@Items&name=department_name', '', '4', false, { min: 1, max: 50 }),
hide('1待审核2在团3离团-1审核不通过', 'association_member-status', '1', '4', { int: true }),
input('特长', 'association_member-merit', '', '4', { min: 1, max: 50 }),
input('爱好', 'association_member-prefer', '', '4', { min: 1, max: 50 }),
input('手机号码', 'association_member-phone', '', '4', '^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\\d{8}$', { min: 1, max: 50 }),
input('邮箱', 'association_member-email', '', '4', { min: 1, max: 50 }),
file('附件', 'association_member-relatedfile')
    ], '参加社团申请')], 'ecampus.twxt2.association_member@add', '', '参加社团申请');