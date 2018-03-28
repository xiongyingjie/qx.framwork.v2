render([
    group([
hide('orgnization_position-orgnization_position_id','#id'),
hide('orgnization_position-orgnization_id', q.orgid),
select('职位', 'orgnization_position-position_id', 'sys.core.position@items&name=name', 'RBXS5YA7RZH')
    ], '标题')], 'sys.core.orgnization_position@add', '', '添加');