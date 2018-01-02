render([
    group([
        input("职称编号", "proposition_no", "例如：0001（4个数字）", "2", "请输入职称编号", "^[0-9]*$"),
        input("职称名称", "proposition_name", "例如：教授", "2", "请输入职称名称")
    ], "添加职称", 1)
], true);