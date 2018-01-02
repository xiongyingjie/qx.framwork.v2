render([
    group([
     hide("materialtypeid", q.materialtypeid),
     select("奖项类型", "awardtypeid", "/QxJzxt/CRUD/AwardTypeSelect", "", 2)
    ],
    "添加到奖项",
    1
     )],
"/QxJzxt/CRUD/AddMaterialToAward",
"",
"*");