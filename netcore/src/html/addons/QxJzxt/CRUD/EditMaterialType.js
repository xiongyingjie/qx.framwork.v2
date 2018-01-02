render([
    group([
   hide("materialtypeid"),
    input("材料类型名称", "typename", "", 2),
     area("材料类型描述", "description", "请输入描述", 1, "", 120)], "编辑材料类型", 1
     )],
"/QxJzxt/CRUD/UpdateMaterialType",
"/QxJzxt/CRUD/FindMaterialType",
"*");