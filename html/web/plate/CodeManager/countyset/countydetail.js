﻿render([
    group([
        input("省份名称", "province_name", "北京市", "2", "", "^[0-9]*$"),
        input("城市名称", "city_name", "北京市", "2", "", "^[0-9]*$"),
        input("县区编号", "county_no", "110101", "2", "", "^[0-9]*$"),
        input("县区名称", "county_name", "东城区", "2", "请输入城市名称")
    ], "查看详情", 1)
],'','', true);