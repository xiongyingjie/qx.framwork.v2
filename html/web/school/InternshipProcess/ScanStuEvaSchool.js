render([
    select("年级下拉框", "grade_choose",
        "[{\"text\":\"2013\",\"value\":\"1\"},{\"text\":\"2014\",\"value\":\"2\"},{\"text\":\"2015\",\"value\":\"3\"}]",
        "请添加年级", 4),
    select("专业下拉框", "major_choose",
        "[{\"text\":\"旅游管理\",\"value\":\"1\"},{\"text\":\"酒店管理\",\"value\":\"2\"},{\"text\":\"财务管理\",\"value\":\"3\"}]",
        "请添加专业", 4),
    select("班级下拉框", "class_choose",
        "[{\"text\":\"酒店管理境外生班\",\"value\":\"1\"},{\"text\":\"酒店管理境内生班\",\"value\":\"2\"},{\"text\":\"酒店管理国外生班\",\"value\":\"3\"}]",
        "请添加岗班级", 4),
    button("查询", 6, Color.red, function () { }),

])