render([
    group([
        input("岗位编号", "position_no", "1", "2", "请输入岗位类别", "^[0-9]*$"),
        input("岗位名称", "position_name", "餐饮部", "2", "请输入岗位名称")
    ], "修改岗位类别", 1)
], true);