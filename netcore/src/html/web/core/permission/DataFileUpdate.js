﻿render(function(){
var cfg=[];
cfg.push(
    group([
hide('data_filter-data_filter_id', '#id'),
showinput('角色ID', 'data_filter-role_id', q.role_id, '4'),
select('过滤脚本', 'data_filter-filter_script_id', 'qx.permmision.v2.filter_script@items&name=name', '3', '4',false, { min: 1, max: 50 }),
time('失效日期', 'data_filter-expire_time', '', '4', '请选择失效日期'),
input('报表ID', 'data_filter-report_id', '', '4'),
input('优先级', 'data_filter-seq', '1', '4', { int: true }),
input('备注', 'data_filter-note', '', '4')
],'标题'));
return cfg;
},'qx.permmision.v2.data_filter@update&id='+q.id,'qx.permmision.v2.data_filter@find&id='+q.id,'编辑');