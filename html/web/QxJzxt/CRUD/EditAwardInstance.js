render([
     group([
         hide('instanceid'),
         hide('awardtypeid'),
         input('奖项名称', 'instancename'),
         time("开始时间", "starttime", "starttime", 4),
         time("结束时间", "endtime", "endtime", 4),
         input('奖金', 'bonus')],
        "编辑奖项",
        1)], 
        "*",
        "/QxJzxt/CRUD/FindAwardInstance",
        "编辑奖项",
        "*");