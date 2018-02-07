render([
    group([
        input("岗位编号", "position_no", "例如：01（2个数字）", "2", "请输入岗位类别", "^[0-9]*$"),
        input("岗位名称", "position_name", "例如：餐饮部", "2", "请输入岗位名称")
    ], "添加岗位类别", 1)
], true);