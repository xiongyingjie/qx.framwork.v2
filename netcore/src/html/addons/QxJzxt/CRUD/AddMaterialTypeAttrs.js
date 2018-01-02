render([
    group([
    hide("materialtypeid", q.materialtypeid),
    select("材料属性", "materialattrid", "/QxJzxt/CRUD/MaterialAttrSelect", "", 2),
    input("次序", "sequence", "", 2),
    ], "添加材料类型属性", 1)],
    "/QxJzxt/CRUD/AddMaterialTypeAttrs",
    "",
    "*");