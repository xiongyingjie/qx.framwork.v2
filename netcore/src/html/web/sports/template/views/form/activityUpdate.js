
render([
    group([
hide('base_activity-base_activity_id'),
select("活动类型", "base_activity-activity_type_id", "/sports/Admin/Getactivity_type", "请选择活动类型", 4),
input('活动名称', 'base_activity-name', '', '4', { min: 1, max: 50 }),
hide('base_activity-province', '默认'),
hide('base_activity-city', '默认'),
hide('base_activity-area', '默认'),
input('活动地址', 'base_activity-address', '', '4', { min: 1, max: 50 }),
input('参考价', 'base_activity-price', '', '4', {float:true}),


hide('base_activity-group_number', '0'),
select("报名方式", "base_activity-sign_mode", [{ value: "个人", text: "个人" }, { value: "团体", text: "团体" }], "个人", 4),

hide('base_activity-join_limit','0'),
input('浏览量', 'activity-browser', '', '4', { int: true }),
input('收藏数', 'activity-collection', '', '4', { int: true }),
input('主办单位', 'base_activity-host_unit', '', '4', { min: 1, max: 50 }),
input('承办单位', 'activity-organizer', '', '4'),
input('备注', 'activity-note', '', '4'),
hide('base_activity-is_enable','1'),
hide('base_activity-describe'),
time('活动开始时间', 'base_activity-begin_time', '', '4', '请选择活动开始时间'),
time('活动结束时间', 'base_activity-end_time', '', '4', '请选择活动结束时间'),
time('报名开始时间', 'base_activity-sign_begin_time', '', '4', '请选择报名开始时间'),
time('报名结束时间', 'base_activity-sign_end_time', '', '4', '请选择报名结束时间'),
file('活动图片', 'base_activity-photos'),
editor('活动介绍', 'base_activity-detail'),


hide('activity-activity_id'),
hide('activity-remain_number'),
hide('activity-total_number')

    ], '添加活动')], 'wx.sports.base_activity@update|activity@update&id=' + q.id, 'wx.sports.base_activity@find|activity@find&id=' + q.id, '活动信息');

