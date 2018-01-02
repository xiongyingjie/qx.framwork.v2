render([
    group([
        input("省市编号", "ProvinceID", "", "2", "请输入省市编号", "^[0-9]*$"),
        input("省市名称", "ProvinceName", "", "2", "请输入省市名称")
    ], "修改省份", 1)
], '/plate/CodeManager/UpdateProvince', '/plate/CodeManager/FindProvince', true);