render(function () {
    return [
        group([
    hide('active_apply-activity_apply_id', "q.id"),
    hide( 'active_apply-status', ''),
    hide('active_apply-audit_time', 'q.active_apply-audit_time'),
    hide('active-active_id', "q.active-active_id"),
    hide('active-activity_apply_id', "q.active-activity_apply_id"),
    hide('active-association_id', "active-association_id"),
    showInput('活动名', 'active-activity_name', '', '4'),
    showInput('活动描述', 'active-describe', '', '4'),
    showTime('申请时间', 'active_apply-apply_time', '', '4'),
    showTime('开始时间', 'active-statrtime', '', '4'),
    showTime('结束时间', 'active-endtime', '', '4'),
    showInput('活动地点', 'active-address', '', '4'),
    showFile('相关文件', 'active-related_file'),
    showInput('审核人', 'active_apply-auditor', '', '4'),
    showArea('审核意见', 'active_apply-audit_opinion', ''),
    hide('active-active_type', 'q.active-active_type'),
    hide('active-status', 'q.active-status')
        ], '标题')]
}, '', 'ecampus.twxt2.active@list'.jn('active_apply.activity_apply_id', 'activity_apply_id').eq('active_id',q.id ), '详情')
