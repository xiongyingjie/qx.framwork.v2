render([
    group([
    hide("awardlevelid", q.id),
    select('基本信息项', 'baseInfoid', '/QxJzxt/CRUD/BaseInfoSelect'),
    input("次序", "sequence", "请输入次序", 4,"^[0-9]*$","请输入数字")
    ],
     "添加基本信息项",
     1
     )],
    "/QxJzxt/CRUD/AddAwardInstanceBaseInfo",
    "",
    "添加基本信息项",
    "*");