render([
group([
showInput('志愿活动名称', 'volunteer_activity-activity_name', '', '3'),
showInput('志愿活动地点', 'volunteer_activity-activity_place', '', '3'),
showTime('志愿活动时间', 'volunteer_activity-activity_time', '', '3'),
showArea('志愿活动简介', 'volunteer_activity-activity_express'),
showFile('活动文件', 'volunteer_activity-activity_file'),
showArea('条件与要求', 'volunteer_activity-activity_ability')
], '标题')], '', 'ecampus.twxt2.volunteer_activity@find&id=' + q.id, '', '详情');

