
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
time('入团时间', 'league-joinleague_time', '', '4', '请选择入团时间'),
hide('immigrationapply-immigrationapply_id'),
hide('immigrationapply-league_member_id'),
hide('immigrationapply-immigrate_to_organization'),
hideTime('immigrationapply-apply_time'),
hideTime('league-immigrationapply_time','#now'),
hide('immigrationapply-apply_state'),   
hide('league-league_brand_id'),
//time('迁入时间', 'immigrationapply-immigration_time', '', '4', '请选择迁入时间'),
showInput('来源单位', 'immigrationapply-immigrate_from_organization', '', '4', { min: 1, max: 50 }),
showArea('来源单位意见', 'immigrationapply-emigrationapply_opinion', '', '1', { min: 1, max: 50 }),
showInput('迁入单位', 'league_branch-name', '', '4'),
showArea('迁入原因', 'immigrationapply-immigration_reason', '', '1', { min: 1, max: 50 }),
showfile('档案', 'league-record_file')
    ], '申请迁入'), button("通过", '1:5', Color.green, function () {
        var id2 = $('#league-league_member_id').val();
        $('#immigrationapply-league_member_id').val();
        $('#immigrationapply-apply_state').val(1);
        $('#immigrationapply-immigration_time').val('#now');
        $('#immigrationapply-immigration_operatore').val('#uid');
        $('#league-league_brand_id').val($('#immigrationapply-immigrate_to_organization').val());
        submitForm("ecampus.twxt2.league@update-" + id2 + "|immigrationapply@update-" + q.id);
    }),
button("不通过", '6:0', Color.green, function () {
    $('#league-league_member_id').val();
    $('#immigrationapply-league_member_id').val();
    $('#immigrationapply-apply_state').val(-1);
    $('#immigrationapply-immigration_operatore').val('#uid');
    submitForm("ecampus.twxt2.immigrationapply@update&id=" + q.id);
}),
], '', 'ecampus.twxt2.immigrationapply@list'
       .jn('league.league_member_id', 'league_member_id')
    .jn('league_branch.league_branch_id', 'immigrate_to_organization')
.eq('immigrationapply_id', q.id), '申请迁入审核');
