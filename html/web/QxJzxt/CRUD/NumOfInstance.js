render([
     group([
         hide('awardtypeid', q.awardtypeid),
         input('奖项等级数', 'awardinstancenum','','2', '^[0-9]*$', '请输入数字')],
        "创建奖项",
        1)],
        "/QxJzxt/CRUD/PreAddAwardInstance",
        "",
        "*");