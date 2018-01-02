render([
    group([
        input("省份名称", "ProvinceID", "北京市", "1.5", "请输入省份名称"),
        input("城市编号", "CityID", "110100", "1.5", "请输入城市编号", "^[0-9]*$"),
        input("城市名称", "CityName", "北京市", "1.5", "请输入城市名称")
    ], "查看详情", 1)
], '', '/plate/CodeManager/EditCity');