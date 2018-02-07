render([
    group([
    hide("baseinfoid"),
    input("信息项名称", "infoname", "",2,""),
    select("类型", "infodatatype", "/QxJzxt/CRUD/BaseInfoTypeSelect", "infodatatype", 4)]
    , "编辑基本信息项", 1
     )],
"/QxJzxt/CRUD/EditBaseInfo",
"/QxJzxt/CRUD/FindBaseInfo",
"编辑基本信息项",
"*");