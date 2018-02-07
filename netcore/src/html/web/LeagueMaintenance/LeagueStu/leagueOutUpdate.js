render(function(){
var cfg=[];
cfg.push(
    group([
showInput('学号', 'league-league_member_id', '', '4'),
showInput('姓名', 'league-name', '', '4'),
showInput('性别', 'league-sex', '', '4'),
showInput('民族', 'league-nation', '', '4'),
showInput('籍贯', 'league-birthplace', '', '4'),
showInput('年级', 'league-grade', '', '4'),
showInput('专业', 'league-professional', '', '4'),
showInput('班级', 'league-league_organization', '', '4'),
time('入团时间', 'league-joinleague_time', '', '4', '请选择入团时间'),
hide( 'emigrationapply-emigrationapply_id', q.id),
hide( 'emigrationapply-league_member_id', '#uid'),
hide('emigrationapply-apply_time', '#now'),
hide( 'emigrationapply-apply_state', '1'),
input('当前单位', 'emigrationapply-current_organization', '', '4', {min:1,max:50}),
input('迁出到单位', 'emigrationapply-emigrate_to_organization', '', '4', {min:1,max:50}),
area('迁出原因', 'emigrationapply-emigration_reason', '', '1', { min: 1, max: 50 }),
file('档案', 'league-record_file'),
button("提交申请", '1:2', Color.green, function () {
     $('#emigrationapply-apply_state').val(0);
    submitForm("ecampus.twxt2.league@update-_uid|emigrationapply@update");
}),
],'标题'));
return cfg;
}, '', 'ecampus.twxt2.emigrationapply@list'
       .jn('league.league_member_id', 'league_member_id')
.eq('emigrationapply.emigrationapply_id', q.id), '编辑');