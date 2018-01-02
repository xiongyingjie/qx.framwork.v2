render([
    select("企业下拉框", "company_choose",
        "[{\"text\":\"企业酒店\",\"value\":\"1\"},{\"text\":\"企业公司\",\"value\":\"2\"},{\"text\":\"企业住宅\",\"value\":\"3\"}]",
        "请选择企业酒店", 4),
    select("岗位下拉框", "job_choose",
        "[{\"text\":\"班级不存在\",\"value\":\"1\"},{\"text\":\"酒店管理一班\",\"value\":\"2\"},{\"text\":\"酒店管理二班\",\"value\":\"3\"}]",
        "请选择岗位", 4),
    button("查询", 4, Color.red, function () { }),

])