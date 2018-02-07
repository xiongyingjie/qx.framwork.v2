render([
    tab([
     {
         title: "选择学校/批次/岗位:",
         content: [
             select("学校", "reviewItemSchool", "[{\"text\":\"1\",\"value\":\"1\"},{\"text\":\"2\",\"value\":\"2\"}]", "请选择学校", 1),
             select("批次", "reviewItemRank", "[{\"text\":\"1\",\"value\":\"1\"},{\"text\":\"2\",\"value\":\"2\"}]", "请选择批次", 1),
             select("岗位", "reviewItemPosition", "[{\"text\":\"1\",\"value\":\"1\"},{\"text\":\"2\",\"value\":\"2\"}]", "请选择批次", 1),
             button("查询", 1, Color.blue, function () { })
         ]
     }
    ], 1)

]);