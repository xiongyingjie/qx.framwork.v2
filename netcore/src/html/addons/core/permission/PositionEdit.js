render([
    group([
hide('position-position_id'),
input('岗位名称', 'position-name', '', '4', { min: 1, max: 100 }),
select('岗位类型', 'position-position_type_id', 'qx.permmision.v2.position_type@items&name=name', '1'),
input('备注', 'position-note', ''),
input('描述', 'position-descripe', '')
    ], '标题')], 'qx.permmision.v2.position@update&id=' + q.id, 'qx.permmision.v2.position@find&id=' + q.id, '添加');