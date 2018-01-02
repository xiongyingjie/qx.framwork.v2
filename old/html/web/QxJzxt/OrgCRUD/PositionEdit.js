render([
    group([
        hide('position_id',q.id),
      input('类型名称', 'name'),
      select("职位类型", "position_type_id", "/QxJzxt/OrgCRUD/PositionTypesSelect", "position_type_id", 4),
      input('备注', 'note','',2),
      area('描述', 'descripe')
    ],
    "编辑职位",
    1
     )],
"/QxJzxt/OrgCRUD/PositionEdit",
"/QxJzxt/OrgCRUD/PositionFind",
"*");