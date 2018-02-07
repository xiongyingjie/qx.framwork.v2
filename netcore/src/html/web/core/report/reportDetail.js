render([
    group([
showInput('报表ID', 'report_data-ReportID', '', '4'),
showInput('报表名称', 'report_data-ReportName', '', '4'),
showInput('标题集合', 'report_data-HeadFields', '', '4'),
showInput('每页条数', 'report_data-RecordsPerPage', '', '4'),
showInput('预制参数', 'report_data-ParaNames', '', '4'),
showInput('要显示的列集合', 'report_data-ColunmToShow', '', '4'),
showArea('脚本', 'report_data-SqlStr'),
showArea('操作列', 'report_data-OperateColum'),
showEditor('日志', 'report_data-ReportLog')
],'标题')],'','qx.system.report_data@find&id='+q.id,'','详情');