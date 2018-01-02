render([
    group([
        input("省市编号", "ProvinceID", "例如：110000（6个数字）", "2", "请输入省市编号", "^[0-9]*$"),
        input("省市名称", "ProvinceName", "例如：福建省", "2", "请输入省市名称")
    ], "添加省份", 1)
], '/plate/CodeManager/AddProvince', '', true);
