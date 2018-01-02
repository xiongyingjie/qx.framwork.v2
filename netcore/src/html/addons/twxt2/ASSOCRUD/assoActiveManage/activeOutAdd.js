var  rid=Math.ceil(Math.random()*1000000);
render(function () {
    return [
        group([
    hide('active_apply-activity_apply_id', rid),
    hide('active_apply-status', 1),
    hide('active_apply-audit_opinion', ''),
    hide('active_apply-auditor', ''),
    hide('active_apply-audit_time', ''),
    hide ( 'active_apply-apply_time', '#now'),
    hide('active-active_id', '#id'),
    hide('active-activity_apply_id',rid),
    hide('active-association_id', q.uid),
    input('活动名', 'active-activity_name', '', '4', { min: 1, max: 50 }),
    input('活动描述', 'active-describe', '', '4', { min: 1, max: 50 }),
    time('开始时间', 'active-statrtime', '', '4', '请选择开始时间'),
    time('结束时间', 'active-endtime', '', '4', '请选择结束时间'),
    input('活动地点', 'active-address', '', '4', { min: 1, max: 50 }),
    file('相关文件', 'active-related_file'),
    hide('active-active_type', 2),
    hide('active-status', 1)
        ], '标题')]
},'ecampus.twxt2.active_apply@add|active@add','','添加');
