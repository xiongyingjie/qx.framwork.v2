render([
    group([
        hide('id', q.id),
        hide('unit_id', q.unit_id),
        showinput("当前奖项", "oldAwardName", "oldAwardName", 4),
        select('调整奖项', 'batchinstanceid', "/QxJzxt/CRUD/instanceSelect?id=" + q.id + "&unit_id=" + q.unit_id, "", '4', '请选择要调整的奖项')],
        "调整奖项",
        1)],
        "/QxJzxt/CRUD/adjustAward",
        "/QxJzxt/CRUD/CollegeChangeAward");