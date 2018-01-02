render([
    group([
    hide("awardlevelid", q.id),
    select('材料类型', 'materialtypeid', '/QxJzxt/CRUD/MaterialTypeSelect')
    ],
     "添加奖项材料",
     1
     )],
    "/QxJzxt/CRUD/AddMaterialToAwardInstance",
    "",
    "添加奖项材料",
    "*");