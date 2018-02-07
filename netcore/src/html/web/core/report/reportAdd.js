render([
    group([
input('报表ID', 'report_data-ReportID', '', '4', {min:1,max:199}),
input('报表名称', 'report_data-ReportName', '', '4', {min:1,max:199}),
input('标题集合', 'report_data-HeadFields', '', '4', {min:1,max:199}),
input('每页条数', 'report_data-RecordsPerPage', '', '4', {int:true}),
input('预制参数', 'report_data-ParaNames', '', '4', {min:1,max:199}),
input('要显示的列集合', 'report_data-ColunmToShow', '', '4', {min:1,max:199}),
area('脚本', 'report_data-SqlStr'),
area('操作列', 'report_data-OperateColum'),
editor('日志', 'report_data-ReportLog')
],'标题')],'qx.system.report_data@add','','添加');