render([
    group([
       // hide("exp_reports_id", model.exp_reports_id),
hide('active-active_id', '#id'),
hide('active-activity_apply_id','NULL'),
hide( 'active-association_id', q.uid),
input('活动名', 'active-activity_name', '', '4', {min:1,max:50}),
input('活动描述', 'active-describe', '', '4', {min:1,max:50}),
time('开始时间', 'active-statrtime', '', '4', '请选择开始时间'),
time('结束时间', 'active-endtime', '', '4', '请选择结束时间'),
input('活动地点', 'active-address', '', '4', {min:1,max:50}),
file('相关文件', 'active-related_file'),
hide( 'active-active_type',1),
hide( 'active-status', 1)
    ], '标题')], 'ecampus.twxt2.active@add', '', '添加');