//render([
//     group([
//    hide('awardid', q.awardid),
//    hide('levelnum', q.levelnum),
//    input('等级名称', 'awardlevelname', '', '4', '', '奖项等级'),
//    input('总名额数', 'total_count', '', '4', '^[0-9]*$', '请输入数字'),
//    input('奖金', 'bonus', '', '4', '^[0-9]*$', '请输入数字')],
//    "为奖项添加等级",
//    1)],
//    "/QxJzxt/CRUD/AddAwardInstanceFromBatch",
//    "",
//    "为奖项添加等级");



render(
    function () {
        var cfg = [];
        var groupcontain = [];
        groupcontain.push(hide("awardid", q.awardid));
        groupcontain.push(hide("levelnum", q.levelnum));
        for (var i = 0; i < q.levelnum; i++) {
            groupcontain.push(input('等级名称', 'awardlevelname_' + i, '', '3', '', '奖项等级'));
            groupcontain.push(input('总名额数', 'total_count_' + i, '', '3', '^[0-9]*$', '请输入数字'));
            groupcontain.push(input('奖金', 'bonus_' + i, '', '3', '^[0-9]*$', '请输入数字'));
        }
        cfg.push(group(groupcontain, "为奖项添加等级"));
        return cfg;
    },
  "/QxJzxt/CRUD/AddAwardInstanceFromBatch",
    "",
    "为奖项添加等级");
