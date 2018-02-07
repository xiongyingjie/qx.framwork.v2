render(function(){
var cfg=[];
cfg.push(
    group([
hide('volunteer_activity-activity_id', ''),
input('志愿活动名称', 'volunteer_activity-activity_name', '', '4', { min: 1, max: 50 }),
input('志愿活动地点', 'volunteer_activity-activity_place', '', '4', {min:1,max:50}),
time('志愿活动时间', 'volunteer_activity-activity_time', '', '4'),
area('志愿活动简介', 'volunteer_activity-activity_express'),
hide('volunteer_activity-activity_people', '#uid'),
hide('volunteer_activity-organize_id', '团委'),
file('活动文件', 'volunteer_activity-activity_file'),
hide('volunteer_activity-activity_status', ''),
area('条件与要求', 'volunteer_activity-activity_ability')
],'标题'));
return cfg;
},'ecampus.twxt2.volunteer_activity@update&id='+q.id,'ecampus.twxt2.volunteer_activity@find&id='+q.id,'编辑');




//render(function () {
//    var cfg = [];
//    cfg.push(
//        group([
//    input('志愿活动id', 'volunteer_activity-activity_id', '', '4', { min: 1, max: 50 }),
//    input('志愿活动地点', 'volunteer_activity-activity_place', '', '4', { min: 1, max: 50 }),
//    input('志愿活动时间', 'volunteer_activity-activity_time', '', '4'),
//    input('志愿活动名称', 'volunteer_activity-activity_name', '', '4', { min: 1, max: 50 }),
//    area('志愿活动简介', 'volunteer_activity-activity_express'),
//    input('活动负责人', 'volunteer_activity-activity_people', '', '4', { min: 1, max: 50 }),
//    input('组织单位id', 'volunteer_activity-organize_id', '', '4', { min: 1, max: 50 }),
//    file('活动文件', 'volunteer_activity-activity_file'),
//    input('活动状态', 'volunteer_activity-activity_status', '', '4', { int: true }),
//    area('条件与要求', 'volunteer_activity-activity_ability')
//        ], '标题'));
//    return cfg;
//}, 'ecampus.twxt2.volunteer_activity@update&id=' + q.id, 'ecampus.twxt2.volunteer_activity@find&id=' + q.id, '编辑');