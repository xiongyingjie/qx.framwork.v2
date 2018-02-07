render([
    group([
    hide("materialtypeattrid",q.id),
    hide("materialattrid"),
    hide("materialtypeid"),
    //hide("typename"),
    showinput("材料类型", "typename", "", 2),
    showinput("属性名", "attrname", "", 2),
    showinput("属性类型", "infodatatype", "", 2),
    input("次序", "sequence", "", 2)
    ], "编辑材料类型属性", 1)],
  "/QxJzxt/CRUD/EditMTA",
  "/QxJzxt/CRUD/FindMTA",
"*");