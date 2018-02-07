render([
    tab([
        {
            title: "企业添加",
            content: [group([
                input("单位编号", "ent_no", "", "2", "填写企业代码"),
                input("单位名称", "ent_name", "", "2", "企业名称"),
                input("单位管理员工号", "ent_manager_no", "", "2", "该员工号账户将负责管理企业"),
                input("单位管理员姓名", "ent_manager_name", "", "2", "必须填"),
                input("单位管理员密码", "ent_manager_psw", "", "2", "必须填"),
                input("确认密码", "ent_repsw", "", "2", "必须和企业管理员密码一致")], "添加企业及其管理员", 1)]
        },
        {
            title: "学校添加",
            content: [group([
                input("单位编号", "sch_no", "", "2", "填写学校代码"),
                input("单位名称", "sch_name", "", "2", "学校名称"),
                input("单位管理员工号", "sch_manager_no", "", "2", "该员工号账户将负责管理学校"),
                input("单位管理员姓名", "sch_manager_name", "", "2", "必须填"),
                input("单位管理员密码", "sch_manager_psw", "", "2", "必须填"),
                input("确认密码", "sch_repsw", "", "2", "必须和学校管理员密码一致")], "添加学校及其管理员", 1)]
        }
    ], 1)
   

], true);