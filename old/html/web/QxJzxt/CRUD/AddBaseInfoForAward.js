render([
     group([
    hide('baseinfoid', q.baseinfoid),
    select('奖项类型', 'awardtypeid', '/QxJzxt/CRUD/AwardTypeSelect'),
    input('次序', 'sequence', '', '4', '^[0-9]*$','请输入数字')],
    "添加基本信息项到奖项类型",
    1)],
    "/QxJzxt/CRUD/AddBaseInfoForAward",
    "",
    "添加基本信息项到奖项类型",
    "*");