render([
    group([
        input("省市编号", "ProvinceID", "", "2", "请输入省市编号", "^[0-9]*$"),
        input("省市名称", "ProvinceName", "", "2", "请输入省市名称")
    ], "查看详情", 1)
],'', '/plate/CodeManager/FindProvince');