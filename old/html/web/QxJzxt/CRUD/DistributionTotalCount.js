render([
     group([
    hide('awardlevelid', q.awardlevelid),
    hide('awardinstanceleveid', q.awardinstanceleveid),
    hide('awardid', q.awardid),
    input('总名额', 'total_count', '', '4', '^[0-9]*$', '请输入数字')],
    "修改总名额",
    1)],
    "/QxJzxt/CRUD/DistributionTotalCount",
    "/QxJzxt/CRUD/FindBatchAwardInstance",
    "修改总名额",
    "*");