render([
    group([
      input('类型名称', 'name'),
       select("职位类型", "position_type_id", "/QxJzxt/OrgCRUD/PositionTypesSelect", "", 4),
      input('备注', 'note','',2),
      area('描述', 'descripe')
    ],
    "添加职位",
    1
     )],
"/QxJzxt/OrgCRUD/PositionAdd",
"",
"*");