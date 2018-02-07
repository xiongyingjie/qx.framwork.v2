render([
    select("企业下拉框", "company_choose",
        "[{\"text\":\"企业酒店\",\"value\":\"1\"},{\"text\":\"企业公司\",\"value\":\"2\"},{\"text\":\"企业住宅\",\"value\":\"3\"}]",
        "请添加企业", 4),
    select("岗位下拉框", "job_choose",
        "[{\"text\":\"采购部\",\"value\":\"1\"},{\"text\":\"策划部\",\"value\":\"2\"},{\"text\":\"公关部\",\"value\":\"3\"}]",
        "请添加岗位", 4),
    button("查询", 6, Color.red, function () { }),

])