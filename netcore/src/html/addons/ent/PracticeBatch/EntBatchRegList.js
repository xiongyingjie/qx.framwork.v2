render([
    tab([
     {
         title: "添加记录",
         content: [
             select("学校", "entSchool", "[{\"text\":\"1\",\"value\":\"1\"},{\"text\":\"2\",\"value\":\"2\"}]", "请选择学校", 1),
             select("批次编号", "bachNo", "[{\"text\":\"1\",\"value\":\"1\"},{\"text\":\"2\",\"value\":\"2\"}]", "请选择批次", 1),
             button("保存", 1, Color.blue, function () { })
         ]
     }
    ], 1)

]);