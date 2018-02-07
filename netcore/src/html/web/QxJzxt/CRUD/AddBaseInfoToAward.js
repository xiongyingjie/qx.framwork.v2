render([
     group([
    hide('awardtypeid', q.awardtypeid),
    select('基本信息项', 'baseinfoid', '/QxJzxt/CRUD/BaseInfoSelect'),
    input('次序', 'sequence', '', '4',  '^[0-9]*$','请输入数字')],
    "为奖项类型添加基本信息项",
    1)],
    "/QxJzxt/CRUD/AddBaseInfoToAward",
    "",
    "为奖项类型添加基本信息项",
    "*");