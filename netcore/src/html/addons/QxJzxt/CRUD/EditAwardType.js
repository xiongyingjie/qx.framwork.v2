render([
    group([
    hide("awardtypeid"),
    input("奖项名称", "awardname", "", 4),
    area("奖项描述", "description", "请输入描述", 1, "", 120)],
    "编辑奖项类型",
    1
     )],
"/QxJzxt/CRUD/UpdateAwardType",
"/QxJzxt/CRUD/FindAwardType",
"*");