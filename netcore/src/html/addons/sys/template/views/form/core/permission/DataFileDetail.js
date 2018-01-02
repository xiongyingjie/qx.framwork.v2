render([
    group([
showInput('过滤ID', 'data_filter-data_filter_id', '', '4'),
showInput('角色ID', 'data_filter-role_id', '', '4'),
showInput('报表ID', 'data_filter-report_id', '', '4'),
showInput('备注', 'data_filter-note', '', '4'),
showInput('过滤脚本', 'data_filter-filter_script_id', '', '4'),
showTime('失效日期', 'data_filter-expire_time', '', '4'),
showInput('优先级', 'data_filter-seq', '', '4')
],'标题')],'','qx.permmision.v2.data_filter@find&id='+q.id,'','详情');