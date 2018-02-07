render([
    group([
input('正式成员id', 'volunteer_member-vid', '', '4', {min:1,max:50}),
input('成员申请id', 'volunteer_member-member_apply_id', '', '4', {min:1,max:50}),
input('活动id', 'volunteer_member-activity_id', '', '4', {min:1,max:50}),
file('志愿服务总结文件', 'volunteer_member-volunteer_file'),
area('得分情况', 'volunteer_member-score')
],'标题')],'ecampus.twxt2.volunteer_member@add','','添加');