render([
    input("资源标题", "resources_name", 4),
    input("资源发布者", "resources_editor", 4),
    date("日期输入", "date_input", "日期", 4),
    select("发布栏目", "release_div", "[{\"text\":\"A栏目\",\"value\":\"1\"},{\"text\":\"B栏目\",\"value\":\"2\"}]", 4),
    pageheader("添加文件", "选择需要添加的文件"),
    button("添加文件", 4, function () { }),
    pageheader("创建确认", "请点击以下按钮"),
    button("创建", 4, Color.red, function () { }),
])

