render([
    tab([
     {
         title: "添加记录",
         content: [
             select("高校", "entSchool", "[{\"text\":\"1\",\"value\":\"1\"},{\"text\":\"2\",\"value\":\"2\"}]", "请选择学校", 1),
             select("岗位名称", "positionName", "[{\"text\":\"1\",\"value\":\"1\"},{\"text\":\"2\",\"value\":\"2\"}]", "请选择批次", 1),
             area("岗位描述", "positionDesc", "", 4, "", 120),
             input("招生数量", "positionNum", "", 1, "请输入招生数量"),
             date("发布日期", "positionStartDate", "2010-2-11", 4, ""),
             date("截止日期", "positionEndDate", "2010-2-11", 4, ""),
             button("保存", 1, Color.blue, function () { })
         ]
     }
    ], 1)

]);