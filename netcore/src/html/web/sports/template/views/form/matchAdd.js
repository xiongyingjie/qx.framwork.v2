render([
    group([
        hide('base_activity-base_activity_id'),
select("赛事类型", "base_activity-activity_type_id", "/sports/Admin/Getmatch_type", "请选择赛事类型", 4),
input('赛事名称', 'base_activity-name', '', '4', { min: 1, max: 50 }),
hide('base_activity-province', '默认'),
hide('base_activity-city', '默认'),
hide('base_activity-area', '默认'),
input('赛事地址', 'base_activity-address', '', '4', { min: 1, max: 50 }),
input('参考价', 'base_activity-price', '', '4', { float: true }),


hide('base_activity-group_number', '0'),
select("报名方式", "base_activity-sign_mode", [{ value: "个人", text: "个人" }, { value: "团体", text: "团体" }], "个人", 4),


input('每人限报项数', 'base_activity-join_limit', '0', '4', { int: true }),
input('浏览量', 'match-browser', '', '4', { int: true }),
input('收藏数', 'match-collection', '', '4', { int: true }),
input('主办单位', 'base_activity-host_unit', '', '4', { min: 1, max: 50 }),

input('备注', 'match-note', '', '4'),
hide('base_activity-is_enable', '1'),
hide('base_activity-describe'),

input('比赛规模', 'match-match_size', '', '4'),
input('承办单位', 'match-organizer', '', '4'),
input('协办单位', 'match-co_organizer', '', '4'),
input('赞助商', 'match-sponsor', '', '4'),
time('赛事开始时间', 'base_activity-begin_time', '', '4', '请选择赛事开始时间'),
time('赛事结束时间', 'base_activity-end_time', '', '4', '请选择赛事结束时间'),
time('报名开始时间', 'base_activity-sign_begin_time', '', '4', '请选择报名开始时间'),
time('报名结束时间', 'base_activity-sign_end_time', '', '4', '请选择报名结束时间'),
file('赛事图片', 'base_activity-photos'),
editor('赛事介绍', 'base_activity-detail'),
hide('match-match_id')


    ], '赛事信息')], 'wx.sports.base_activity@add|match@add', '', '添加');

function formReady() {
    var id = $.random();
    $.set("base_activity-base_activity_id", 201, id);
    $.set("match-match_id", 201, id)
}