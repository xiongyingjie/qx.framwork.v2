render([
    group([
    input("属性名称", "attrname", "", 2),
    select("属性类型", "infodatatype", "/QxJzxt/CRUD/MaterialAttrsSelect", "", 2),
    ],
    "添加材料属性",
    1)],
"/QxJzxt/CRUD/AddMaterialAttrs",
"",
"*");