render([
    group([
        input("印章类型编号", "stamptype_no", "1", "2", "请输入印章类型编号", "^[0-9]*$"),
        input("印章类型名称", "stamptype_name", "财务章", "2", "请输入印章类型名称"),
        select("所属单位选择", "belong_sel",
            "[{\"text\":\"学校端\",\"value\":\"1\"},{\"text\":\"企业端\",\"value\":\"2\"}]", "请输入所属单位", "3"),
    ], "修改印章类型", 1)
], true);