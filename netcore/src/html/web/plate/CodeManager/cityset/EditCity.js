render([
    group([
        select("省份选择", "ProvinceID",
            "[{\"text\":\"福建省\",\"value\":\"1\"},{\"text\":\"浙江省\",\"value\":\"2\"},{\"text\":\"湖北省\",\"value\":\"3\"}]", "请输入省份", "3"),
        input("城市编号", "CityID", "例如：110200（6个数字）", "3", "请输入城市编号", "^[0-9]*$"),
        input("城市名称", "CityName", "例如：泉州市", "3", "请输入城市名称")
    ], "修改城市", 1)
], '*', '/plate/CodeManager/EditCity', true);