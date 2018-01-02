render([
    group([
showInput('志愿活动名称', 'volunteer_activity-activity_name', '', '3'),
showInput('志愿活动地点', 'volunteer_activity-activity_place', '', '3'),
showTime('志愿活动时间', 'volunteer_activity-activity_time', '', '3'),
showArea('志愿活动简介', 'volunteer_activity-activity_express'),
showFile('活动文件', 'volunteer_activity-activity_file'),
showArea('条件与要求', 'volunteer_activity-activity_ability')
],'标题')],'','ecampus.twxt2.volunteer_activity@find&id='+q.id,'','详情');

//render([
//    group([
//showInput('志愿活动id', 'volunteer_activity-activity_id', '', '4'),
//showInput('志愿活动地点', 'volunteer_activity-activity_place', '', '4'),
//showInput('志愿活动时间', 'volunteer_activity-activity_time', '', '4'),
//showInput('志愿活动名称', 'volunteer_activity-activity_name', '', '4'),
//showArea('志愿活动简介', 'volunteer_activity-activity_express'),
//showInput('活动负责人', 'volunteer_activity-activity_people', '', '4'),
//showInput('组织单位id', 'volunteer_activity-organize_id', '', '4'),
//showFile('活动文件', 'volunteer_activity-activity_file'),
//showInput('活动状态', 'volunteer_activity-activity_status', '', '4'),
//showArea('条件与要求', 'volunteer_activity-activity_ability')
//    ], '标题')], '', 'ecampus.twxt2.volunteer_activity@find&id=' + q.id, '', '详情');
