render([
    tab([
     {
         title: "设置评分比重",
         content: [
             select("选择高校", "reviewItemSchool", "[{\"text\":\"1\",\"value\":\"1\"},{\"text\":\"2\",\"value\":\"2\"}]", "请选择学校", 1),
             input("学校比重", "schoolRadio", "", 1, "请输入学校比重"),
             input("企业比重", "entRadio", "", 1, "请输入企业比重"),
             button("保存", 1, Color.blue, function () { })
         ]
     }
    ], 1)

]);