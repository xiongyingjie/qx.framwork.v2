render([
     group([
    hide('awardlevelid', q.awardlevelid),
    select('奖项', 'awardid', '/QxJzxt/CRUD/AwardBatchSelect'),
    input('总名额', 'total_count', '', '4', '^[0-9]*$','请输入数字')],
    "添加奖项到批次",
    1)],
    "/QxJzxt/CRUD/AddAwardInstanceToBatch",
    "",
    "添加奖项到批次",
    "*");