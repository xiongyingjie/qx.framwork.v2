render(function () {
    subSetTitle("添加时间段");
    return [
   group([
hide ( 'sub_activity_time-sub_activity_time_id', '#id'),
hide ( 'sub_activity_time-base_activity_id', q.id),
hide ( 'sub_activity_time-base_state', '1'),
time('开始时间', 'sub_activity_time-begin_time', '', '4', '请选择结束时间'),
time('结束时间', 'sub_activity_time-end_time', '', '4', '请选择报名开始时间'),
input('余票', 'sub_activity_time-price', '', '4', { min: 1, max: 50 }),
input('时间段加价', 'sub_activity_time-remain', '', '4', { min: 1, max: 50 })

   ], '添加时间段')]
}, 'wx.sports.sub_activity_time@add', '');

