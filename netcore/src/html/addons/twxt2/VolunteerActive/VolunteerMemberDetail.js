render([
    group([
hide( 'volunteer_member-vid', ''),
hide( 'volunteer_member-member_apply_id', ''),
hide( 'volunteer_member-activity_id', ''),
showFile('志愿服务总结文件', 'volunteer_member-volunteer_file'),
showArea('得分情况', 'volunteer_member-score')
],'标题')],'','ecampus.twxt2.volunteer_member@find&id='+q.id,'','详情');