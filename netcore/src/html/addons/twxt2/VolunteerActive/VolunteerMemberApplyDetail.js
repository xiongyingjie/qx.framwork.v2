render([
    group([
hide('volunteer_member_apply-member_apply_id', ''),
hide('volunteer_member_apply-uid', ''),
hide('volunteer_member_apply-activity_id', ''),
showInput('姓名', 'volunteer_member_apply-name', '', '3'),
showInput('性别', 'volunteer_member_apply-sex', '', '3'),
showInput('手机号码', 'volunteer_member_apply-phone', '', '3'),
showArea('活动能力应答', 'volunteer_member_apply-skill_express'),
showFile('申请文件', 'volunteer_member_apply-apply_file'),
hide('volunteer_member_apply-apply_status', '')
],'标题')],'','ecampus.twxt2.volunteer_member_apply@find&id='+q.id,'','详情');



//render([
//    group([
//showInput('志愿服务成员申请id', 'volunteer_member_apply-member_apply_id', '', '4'),
//showInput('学生id', 'volunteer_member_apply-uid', '', '4'),
//showInput('活动id', 'volunteer_member_apply-activity_id', '', '4'),
//showInput('性别', 'volunteer_member_apply-sex', '', '4'),
//showInput('活动能力应答', 'volunteer_member_apply-skill_express', '', '4'),
//showFile('申请文件', 'volunteer_member_apply-apply_file'),
//showInput('申请状态', 'volunteer_member_apply-apply_status', '', '4'),
//showInput('手机号码', 'volunteer_member_apply-phone', '', '4'),
//showInput('姓名', 'volunteer_member_apply-name', '', '4')
//    ], '标题')], '', 'ecampus.twxt2.volunteer_member_apply@find&id=' + q.id, '', '详情');