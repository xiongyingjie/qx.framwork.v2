render([
     group([
         hide('position_type_id',q.id ),
         hide('father_id', q.father_id),
         input('职位类型名称', 'name')],
        "编辑职位类型",
        1)],
        "/QxJzxt/OrgCRUD/PositionTypeEdit",
        "/QxJzxt/OrgCRUD/PositionTypeFind",
        "*");