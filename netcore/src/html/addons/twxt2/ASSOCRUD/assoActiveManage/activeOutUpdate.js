render(function(){
var cfg=[];
cfg.push(
    group([
hide('active_apply-activity_apply_id', 'q.active_apply-activity_apply_id'),
hide('active_apply-status'),
hide('active-active_id', 'q.active-active_id'),
hide('active-activity_apply_id', 'q.active-activity_apply_id'),
hide('active-association_id', 'q.active-association_id'),
hide( 'active_apply-auditor', ''),
input('活动名', 'active-activity_name', '', '4', {min:1,max:50}),
input('活动描述', 'active-describe', '', '4', {min:1,max:50}),
input('活动地点', 'active-address', '', '4', { min: 1, max: 50 }),
showinput('审核意见', 'active_apply-audit_opinion', '', '4', { min: 1, max: 50 }),
showTime('审核时间', 'active_apply-audit_time', '', '4', '请选择审核时间'),
showTime('申请时间', 'active_apply-apply_time', '#now', '4', '请选择申请时间'),
time('开始时间', 'active-statrtime', '', '4', '请选择开始时间'),
time('结束时间', 'active-endtime', '', '4', '请选择结束时间'),
file('相关文件', 'active-related_file','1'),
hide('active-active_type', 'q.active-active_type'),
hide('active-status', 'q.active-status'),
button("提交", '1:4', Color.green, function () {
    $("#active_apply-status").val(1);
    $("#active-status").val(1);
    //$.alert(    $("#association-status").val())
    submitForm("ecampus.twxt2.active@update-" + q.id1 + "|active_apply@update-" + q.id2);
}),

],'标题'));
return cfg;
}, '', 'ecampus.twxt2.active@list'.jn('active_apply.activity_apply_id', 'activity_apply_id').eq('active_id', q.id1), '编辑');