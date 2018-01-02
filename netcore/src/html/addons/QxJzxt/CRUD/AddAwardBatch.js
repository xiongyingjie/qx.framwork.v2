render([
    group([
         hide('IsCurrentAward', '0'),
        input('奖项名称', 'awardname', '', '3', '', '请输入奖项名称'),
         select("奖项类型", "awardtypeid", "/QxJzxt/CRUD/AwardTypeSelect",'', 3),
         input('奖项级数', 'levelnum', '', '3', '^[0-9]*$', '请输入数字'),
         file("评奖文件", "awardfile", 3, "/UserFiles/Test/",""),
         time("开始时间", "starttime", "", 3), 
         time("结束时间", "endtime", "", 3),
        area('奖项描述', 'description')],
        "添加奖项",
        1
        )],
        "/QxJzxt/CRUD/AddAwardBatch",
        "",
        '添加奖项');