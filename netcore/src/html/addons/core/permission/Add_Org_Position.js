render([
    group([
hide('orgnization_position-orgnization_position_id','#id'),
hide('orgnization_position-orgnization_id', q.orgid),
select('职位', 'orgnization_position-position_id', 'qx.permmision.v2.position@items&name=name', 'RBXS5YA7RZH')
    ], '标题')], 'qx.permmision.v2.orgnization_position@add', '', '添加');