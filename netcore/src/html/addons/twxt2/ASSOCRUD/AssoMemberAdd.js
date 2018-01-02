render([
    group([
hide( 'association_member-asso_member_id', '#id'),
hide( 'association_member-association_id', q.id),
hide('association_member-student_id', '#uid'),
//select('部门名称', 'association_member-department_id', 'ecampus.twxt2.asso_depart@Items&name=department_name&association_id=' + q.id, '', '4', false, { min: 1, max: 50 }),
select('部门名称', 'association_member-department_id', '/twxt2/AssoCRUD/DepartSelect?id='+q.id, '', '4', false, { min: 1, max: 50 }),
hide('association_member-status', '1'),
input('特长', 'association_member-merit', '', '4', { min: 1, max: 50 }),
input('爱好', 'association_member-prefer', '', '4', { min: 1, max: 50 }),
input('手机号码', 'association_member-phone', '', '4', '^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\\d{8}$', { min: 1, max: 50 }),
select('性别', 'association_member-sex', [{ text: "男", value: "男" }, { "text": "女", value: "女" }], '', '4', false, { min: 1, max: 50 }),
input('邮箱', 'association_member-email', '', '4', '^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$', { min: 1, max: 50 }),
hide('association_member-apply_time','#now'),
file('附件', 'association_member-relatedfile')
    ], '标题')], 'ecampus.twxt2.association_member@add', '', '添加');