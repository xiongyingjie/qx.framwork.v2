render([
    group([
    hide("instancebaseinfoid"),
     hide("awardlevelid"),
       hide("baseInfoid"),
        input("次序", "sequence", "请输入次序", 4, "^[0-9]*$", "请输入数字")
    ],
     "编辑次序",
     1
     )],
"/QxJzxt/CRUD/EditAwardInstanceBaseInfo",
"/QxJzxt/CRUD/FindAwardInstanceBaseInfo",
"*");