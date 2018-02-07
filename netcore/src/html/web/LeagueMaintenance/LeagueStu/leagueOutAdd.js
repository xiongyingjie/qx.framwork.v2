var random1 = $.random();
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
hide('emigrationapply-emigrationapply_id', '#uid'),
hide('emigrationapply-apply_time', '#now'),
hide('emigrationapply-league_member_id', '#uid'),
hide('emigrationapply-apply_state', 0),
hide('league-league_brand_id'),
showInput('当前单位', 'league_branch-name','','4'),
hide('emigrationapply-current_organization'),
input('迁出到单位', 'emigrationapply-emigrate_to_organization', '', '4', {min:1,max:50}),
area('迁出原因', 'emigrationapply-emigration_reason', '', '1', { min: 1, max: 50 }),
file('档案', 'league-record_file'),
    button("提交申请", '1:2', Color.green, function () {
        $('#emigrationapply-current_organization').val($('#league-league_brand_id').val());
        $('#emigrationapply-emigrationapply_id').val(random1);
       submitForm("ecampus.twxt2.league@update-_uid|emigrationapply@add");   
    })
    ], '标题')], '', 'ecampus.twxt2.league@list'
    .jn('league_branch.league_branch_id', 'league_brand_id')
    .eq('league_member_id', '_uid'), '添加');