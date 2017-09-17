render([
    tab([
     {
         title: "添加记录",
         content: [
             input("企业编号", "entNo", "", 1, "请输入企业编号"),
             input("企业名称", "entName", "", 1, "请输入企业名称"),
             input("企业地址", "entAddress", "", 1, "请输入企业地址"),
             select("企业类型代码", "entType", "[{\"text\":\"1\",\"value\":\"1\"},{\"text\":\"2\",\"value\":\"2\"}]", "请输入企业类型代码", 1),
             select("企业级别", "entRank", "[{\"text\":\"1\",\"value\":\"1\"},{\"text\":\"2\",\"value\":\"2\"}]", "请输入企业级别", 1),
             input("邮箱", "entEmail", "", 1, "请输入邮箱"),
             input("联系方式", "entPhone", "", 1, "请输入联系方式"),
             input("企业视频", "entVideo", "", 1, "请填写优酷视频引用地址"),
             editor("企业简介", "entIntroduce", "今天我很开心", 1, 350)
         ]
     }
    ], 1)

]);



