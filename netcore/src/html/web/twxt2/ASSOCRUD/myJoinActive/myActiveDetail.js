render(function () {
    return [
        group([
    hide('active-active_id', ''),
    hide( 'active-activity_apply_id', ''),
    hide('active-association_id', ''),
    showInput('活动名', 'active-activity_name', '', '4'),
    showInput('活动描述', 'active-describe', '', '4'),
    showTime('开始时间', 'active-statrtime', '', '4'),
    showTime('结束时间', 'active-endtime', '', '4'),
    showInput('活动地点', 'active-address', '', '4'),
    showFile('相关文件', 'active-related_file'),
    hide('active-active_type', ''),
    hide('active-status', '')
        ], '标题')]
}, '', 'ecampus.twxt2.active@find&id=' + q.id, '', '详情');