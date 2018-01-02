render([
    input("学校ID", "school_id","请输入学校ID", 4),
    input("批次名称","number_name", "请输入批次名称", 4),
    input("起止日期", "time_begin-end", "请输入开始、结束日期", 4),
    select("是否当前批次","number_choose", "[{\"text\":\"是\",\"value\":\"1\"},{\"text\":\"否\",\"value\":\"2\"}]", 4),
    select("是否生效","work_or not", "[{\"text\":\"是\",\"value\":\"1\"},{\"text\":\"否\",\"value\":\"2\"}]", 4),
    button("创建",4, Color.red, function () { }),
])

