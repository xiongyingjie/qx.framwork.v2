render([
    group([
hide('position-position_id'),
input('岗位名称', 'position-name', '', '4', { min: 1, max: 100 }),
select('岗位类型', 'position-position_type_id', 'sys.core.position_type@items&name=name', '1'),
input('备注', 'position-note', ''),
input('描述', 'position-descripe', '')
    ], '标题')], 'sys.core.position@update&id=' + q.id, 'sys.core.position@find&id=' + q.id, '添加');