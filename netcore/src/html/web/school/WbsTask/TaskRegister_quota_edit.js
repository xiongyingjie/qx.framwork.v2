render([
    input("定额任务名称", "task_name",4),
    input("相对占比", "proportion", 4),
    pageheader("请输入百分数", "如50即是50%"),
    input("工作内容", "content", 4),
    time("开始时间", "time_begin"),
    time("结束时间", "time_end"),
    select("是否为叶子节点", "point_choose", "[{\"text\":\"是\",\"value\":\"1\"},{\"text\":\"否\",\"value\":\"2\"}]"),
    input("任务顺序", "number", 4),
    button("保存", 6, Color.green, function () { }),
    button("返回", 6, function () { })
])