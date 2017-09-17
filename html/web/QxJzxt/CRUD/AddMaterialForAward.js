render([
    group([
     hide("awardtypeid", q.awardtypeid),
     select("材料类型", "materialtypeid", "/QxJzxt/CRUD/MaterialTypeSelect", "", 2)
    ],
    "添加到奖项",
    1
     )],
"/QxJzxt/CRUD/AddMaterialForAward",
"",
"*");