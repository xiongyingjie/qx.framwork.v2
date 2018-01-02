render([
    tab([
     {
         title: "添加员工",
         content: [
             input("员工号", "empNo", "", 1, "请输入员工号"),
             input("员工姓名", "empName", "", 1, "请输入员工姓名"),
             input("联系电话", "empPhone", "", 1, "请输入联系电话"),
             input("QQ", "entQQ", "", 1, "请输入QQ"),
             input("邮箱", "entEmail", "", 1, "请输入邮箱"),
             input("家庭住址", "entAddress", "", 1, "请输入家庭住址"),
             select("员工类型", "entType", "[{\"text\":\"1\",\"value\":\"1\"},{\"text\":\"2\",\"value\":\"2\"}]", "请输入员工类型", 1),
             button("保存", 1, Color.blue, function () { })
         ]
     }
    ], 1)

]);