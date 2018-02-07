render([
    group([
showInput('学号', 'league-league_member_id', '', '4', { min: 1, max: 50 }),
showInput('姓名', 'league-name', '', '4', { min: 1, max: 50 }),
showInput('性别', 'league-sex', '', '4', { min: 1, max: 50 }),
showInput('民族', 'league-nation', '', '4', { min: 1, max: 50 }),
showInput('籍贯', 'league-birthplace', '', '4', { min: 1, max: 50 }),
showInput('年级', 'league-grade', '', '4', { min: 1, max: 50 }),
showInput('专业', 'league-professional', '', '4', { min: 1, max: 50 }),
showInput('班级', 'league-league_organization', '', '4', { min: 1, max: 20 }),
time('入团时间', 'league-joinleague_time', '', '4', '请选择出团时间'),
hide('emigrationapply-emigrationapply_id', q.emigrationapply_id),
hide('emigrationapply-league_member_id', q.league_member_id),
hideTime('emigrationapply-apply_time', q.apply_time),
hide('emigrationapply-apply_state', q.apply_state),
//time('迁出时间', 'emigrationapply-emigration_time', '', '4', '请选择迁出时间'),
showInput("当前单位", "emigrationapply-current_organization", "", 3),
showInput('迁出到单位', 'emigrationapply-emigrate_to_organization', '', '4', { min: 1, max: 50 }),
showArea('迁出原因', 'emigrationapply-emigration_reason', '', '1', { min: 1, max: 50 }),
//input("操作人",'emigrationapply-emigration_operator',''),
showfile('档案', 'league-record_file'),
area('迁出意见', 'emigrationapply-emigrationapply_opinion', '', '1', { min: 1, max: 50 }),
button("通过", '1:5', Color.green, function () {
    var id2=$('#league-league_member_id').val();
    $('#emigrationapply-league_member_id').val();
    $('#emigrationapply-apply_state').val(1);
    $('#emigrationapply-emigration_time').val('#now');
    $('#emigrationapply-emigration_operatore').val('#uid');
    submitForm("ecampus.twxt2.league@update-" + id2 + "|emigrationapply@update-" + q.id);
}),
button("不通过", '6:0', Color.green, function () {
    $('#league-league_member_id').val();
    $('#emigrationapply-league_member_id').val();
    $('#emigrationapply-apply_state').val(-1);
    $('#emigrationapply-apply_state').val();
    $('#emigrationapply-emigration_operatore').val('#uid');
    submitForm("ecampus.twxt2.emigrationapply@update&id=" + q.id);
}),
    ], '申请迁出')], '', 'ecampus.twxt2.emigrationapply@list'
       .jn('league.league_member_id', 'league_member_id')
.eq('emigrationapply.emigrationapply_id', q.id), '申请迁出审核');