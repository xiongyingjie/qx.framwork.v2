render([
    tab([
     {
         title: "添加评分项",
         content: [
             input("评分项名称", "gradeName", "", 1, "请输入评分项名称"),
             input("所占比例（请输入整数,如70%输入70）", "Radio", "", 1, "请输入所占比例"),
             input("排序", "sort", "", 1, "请输入排序"),
             button("保存", 1, Color.blue, function () { })
         ]
     }
    ], 1)

]);