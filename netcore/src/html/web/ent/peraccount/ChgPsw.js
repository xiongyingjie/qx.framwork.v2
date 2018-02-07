render([
    tab([
     {
         title: "修改密码",
         content: [
             input("旧密码", "oldCode", "", 1, "请输入旧密码"),
             input("新密码", "newCode", "", 1, "请输入新密码"),
             input("确认密码", "reCode", "", 1, "请再次输入新密码"),
             button("保存", 1, Color.blue, function () { })
         ]
     }
    ], 1)

]);



