﻿render([
    group([
        select("省份选择", "province_sel",
            "[{\"text\":\"福建省\",\"value\":\"1\"},{\"text\":\"浙江省\",\"value\":\"2\"},{\"text\":\"湖北省\",\"value\":\"3\"}]", "请输入省份", "2"),
        select("请根据城市选择", "city_sel",
            "[{\"text\":\"北京市\",\"value\":\"1\"},{\"text\":\"厦门市\",\"value\":\"2\"},{\"text\":\"福州市\",\"value\":\"3\"}]", "请输入城市", "2"),
        input("县区编号", "county_no", "110101", "2", "请输入县区编号", "^[0-9]*$"),
        input("县区名称", "county_name", "东城区", "2", "请输入城市名称")
    ], "修改县区", 1)
], true);