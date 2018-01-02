
render([
     group([
    hide('materialattrid',q.materialattrid),
    select('材料类型', 'materialtypeid', '/QxJzxt/CRUD/MaterialTypeSelect'),
    input("次序", "sequence","" , 4, "^[0-9]*$", "请输入数字"),
     hide('attrtypeid'),
     hide('isprimarykey'),
     hide('defaultvalue')],
    "添加属性到材料类型",
    1)],
   "/QxJzxt/CRUD/AddAttrsToMaterialType", "", "添加");