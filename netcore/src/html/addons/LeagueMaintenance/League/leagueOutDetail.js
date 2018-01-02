render([
    group([
showInput('学号', 'league-league_member_id', '', '4'),
showInput('姓名', 'league-name', '', '4'),
showInput('性别', 'league-sex', '', '4'),
showInput('民族', 'league-nation', '', '4'),
showInput('籍贯', 'league-birthplace', '', '4'),
showInput('年级', 'league-grade', '', '4'),
showInput('专业', 'league-professional', '', '4'),
showInput('班级', 'league-league_organization', '', '4'),
showTime('入团时间', 'league-joinleague_time', '', '4'),
showTime('迁出申请时间', 'emigrationapply-apply_time', '', '4'),
showInput('当前单位', 'emigrationapply-current_organization', '', '4'),
showInput('迁出到单位', 'emigrationapply-emigrate_to_organization', '', '4'),
showArea('迁出原因', 'emigrationapply-emigration_reason', '', '1'),
showFile('档案', 'league-record_file'),
    ], '标题')], '', 'ecampus.twxt2.emigrationapply@list'
       .jn('league.league_member_id', 'league_member_id')
.eq('emigrationapply.emigrationapply_id', q.id), '', '详情');