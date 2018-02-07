render([
    group([
        input("类别编号", "category_no", "1", "2", "请输入类别编号", "^[0-9]*$"),
        input("类别名称", "category_name", "酒店", "2", "请输入类别名称")
    ], "修改企业类别", 1)
], true);