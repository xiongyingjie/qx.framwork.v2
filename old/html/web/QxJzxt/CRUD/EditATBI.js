render([
    group([
    hide("awardtypebaseinfoid"),
     hide("baseinfoid"),
       hide("awardtypeid"),
        input("次序", "sequence", "请输入次序", 4, "^[0-9]*$","请输入数字")
    ],
     "编辑次序",
     1
     )],
"/QxJzxt/CRUD/EditATBI",
"/QxJzxt/CRUD/FindATBI",
"*");