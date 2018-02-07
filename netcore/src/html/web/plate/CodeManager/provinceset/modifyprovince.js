render([
    group([
        input("省市编号", "province_no", "", "2", "请输入省市编号", "^[0-9]*$"),
        input("省市名称", "province_name", "", "2", "请输入省市名称")
    ], "修改省份", 1)
], true);