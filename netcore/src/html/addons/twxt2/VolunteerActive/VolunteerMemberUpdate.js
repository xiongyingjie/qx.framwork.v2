render(function () {
    var cfg = [];
    cfg.push(
        group([
    hide('volunteer_member-vid', ''),
    hide('volunteer_member-member_apply_id', ''),
    hide('volunteer_member-activity_id', ''),
    file('志愿服务总结文件', 'volunteer_member-volunteer_file'),
    hide('volunteer_member-score')
        ], '标题'));
    return cfg;
}, 'ecampus.twxt2.volunteer_member@update&id=' + q.id, 'ecampus.twxt2.volunteer_member@find&id=' + q.id, '编辑');

//render(function () {
//    var cfg = [];
//    cfg.push(
//        group([
//    input('正式成员id', 'volunteer_member-vid', '', '4', { min: 1, max: 50 }),
//    input('成员申请id', 'volunteer_member-member_apply_id', '', '4', { min: 1, max: 50 }),
//    input('活动id', 'volunteer_member-activity_id', '', '4', { min: 1, max: 50 }),
//    file('志愿服务总结文件', 'volunteer_member-volunteer_file'),
//    area('得分情况', 'volunteer_member-score')
//        ], '标题'));
//    return cfg;
//}, 'ecampus.twxt2.volunteer_member@update&id=' + q.id, 'ecampus.twxt2.volunteer_member@find&id=' + q.id, '编辑');