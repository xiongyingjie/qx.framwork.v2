render([
    group([
hide('sub_activity_time-sub_activity_time_id','#id'),
hide('sub_activity_time-base_activity_id',q.id),

hideTime('sub_activity_time-end_time'),


input('项目名称', 'sub_activity_time-name', '', '4', { min: 1, max: 50 }),
select("开放报名", "sub_activity_time-state", [{ value: "1", text: "是" }, { value: "0", text: "否" }], "", 4),
input('价格', 'sub_activity_time-price', '', '4', {float:true}),
input('余量', 'sub_activity_time-remain', '', '4', {int:true}),

input('备注', 'sub_activity_time-note', '', '4'),

time('开始时间', 'sub_activity_time-begin_time', '', '4', '请选择开始时间')
    ], '项目信息')], 'wx.sports.sub_activity_time@add', '', '项目信息');