﻿render([
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
showTime('迁入申请时间', 'immigrationapply-apply_time', '', '4'),
showTime('迁入时间', 'immigrationapply-immigration_time', '', '4'),
showInput('迁入单位', 'immigrationapply-immigrate_to_organization', '', '4'),
showInput('来源单位', 'immigrationapply-immigrate_from_organization', '', '2'),
showInput('迁入操作人', 'immigrationapply-immigration_operator', '', '2'),
showArea('迁入原因', 'immigrationapply-immigration_reason', '', '1'),
showFile('档案', 'league-record_file'),
    ], '标题')], '', 'ecampus.twxt2.immigrationapply@list'
       .jn('league.league_member_id', 'league_member_id')
.eq('immigrationapply.immigrationapply_id', q.id), '', '详情');