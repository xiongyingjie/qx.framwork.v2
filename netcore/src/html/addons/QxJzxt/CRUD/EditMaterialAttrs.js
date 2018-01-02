render([
    group([
    hide("materialattrid"),
    input("属性名称", "attrname", "", 2),
    select("属性类型", "infodatatype", "/QxJzxt/CRUD/MaterialAttrsSelect",'', 2),
    ], "编辑材料属性", 1)],
"/QxJzxt/CRUD/EditMaterialAttrs",
"/QxJzxt/CRUD/FindMaterialAttrs",
"*");