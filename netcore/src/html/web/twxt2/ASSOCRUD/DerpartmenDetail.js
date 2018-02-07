render(function () {
    var cfg = [];
    cfg.push(
        group([
    showInput('部门名', 'asso_depart-department_name', '', '4', { min: 1, max: 50 }),
    showTime('创建时间', 'asso_depart-create_time', '', '4'),
    showEditor('部门描述', 'asso_depart-describe','','1'),
    hide('asso_depart-department_id', '#uid'),
    hide('asso_depart-association_id', '')
        ], '部门详情'));
    return cfg;
}, '', 'ecampus.twxt2.asso_depart@find&id=' + q.id, '部门详情');