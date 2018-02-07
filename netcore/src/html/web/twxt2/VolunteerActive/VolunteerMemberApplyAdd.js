render([
    group([
hide('volunteer_member_apply-member_apply_id', '#id'),
hide( 'volunteer_member_apply-uid',q.id1 ),
hide('volunteer_member_apply-activity_id', q.id2),
input('手机号码', 'volunteer_member_apply-phone', '', '4', { mobile: true }),
select('性别', 'volunteer_member_apply-sex', [{ value: '女', text: '女' }, { value: '男', text: '男' }], '', '4'),
input('活动能力应答', 'volunteer_member_apply-skill_express', '', '4', {min:1,max:200}),
file('申请文件', 'volunteer_member_apply-apply_file'),
hide('volunteer_member_apply-apply_status', '0'),
hide( 'volunteer_member_apply-name', q.id3)
],'标题')],'ecampus.twxt2.volunteer_member_apply@add','','添加');



//render([
//    group([
//input('志愿服务成员申请id', 'volunteer_member_apply-member_apply_id', '', '4', { min: 1, max: 50 }),
//input('学生id', 'volunteer_member_apply-uid', '', '4', { min: 1, max: 100 }),
//input('活动id', 'volunteer_member_apply-activity_id', '', '4', { min: 1, max: 50 }),
//input('性别', 'volunteer_member_apply-sex', '', '4', { min: 1, max: 50 }),
//input('活动能力应答', 'volunteer_member_apply-skill_express', '', '4', { min: 1, max: 200 }),
//file('申请文件', 'volunteer_member_apply-apply_file'),
//input('申请状态', 'volunteer_member_apply-apply_status', '', '4', { int: true }),
//input('手机号码', 'volunteer_member_apply-phone', '', '4', { mobile: true }),
//input('姓名', 'volunteer_member_apply-name', '', '4', { min: 1, max: 50 })
//    ], '标题')], 'ecampus.twxt2.volunteer_member_apply@add', '', '添加');