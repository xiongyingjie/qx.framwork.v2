render([
    input("工作量名称", "input_name", "请输入工作量名称",4),
    input("定额占比", "input_quota_proportion", "请输入定额占比", 4),
    input("定量占比", "input_quantitative_proportion", "请输入定量占比", 4),
    input("机动占比", "input_motor_proportion", "请输入机动占比", 4),
    pageheader("以上操作请输入百分数", "如50即是50%"),
    time("开始时间","time_begin"),
    time("结束时间","time_end"),
    button("保存", 6, Color.green, function () { }),
    button("返回", 6, function () { })
])