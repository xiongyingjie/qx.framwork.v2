render([
     input("定额任务ID", "task_id", "请输入id", 4, "请输入0-9的数字", "^[0-9]*$"),
     input("员工ID", "employee_id", "请输入id", 4, "请输入0-9的数字", "^[0-9]*$"),
     input("相对占比", "percentage", "请输入id", 4, "请输入0-9的数字", "^[0-9]*$"),
     pageheader("请输入百分数", "如50即是50%"),
     input("分配说明", "说明",4),
     select("是否已完成", "finish_or not", "[{\"text\":\"是\",\"value\":\"1\"},{\"text\":\"否\",\"value\":\"2\"}]", 4),
     time("完成时间", "finish_time", 4),
     editor("证明材料", "note", "2017年07月17日", 1, 350)
     //editor("个人总结","note","今天我很开心",1,350)
])