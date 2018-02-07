render([
    group([
        input("职称编号", "proposition_no", "0", "2", "请输入职称编号", "^[0-9]*$"),
        input("职称名称", "proposition_name", "默认", "2", "请输入职称名称")
    ], "修改职称", 1)
], true);