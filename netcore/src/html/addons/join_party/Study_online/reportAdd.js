render([
    group([
input('用户Id', 'study_mission_accepted-UserID', '', '4', {min:1,max:50}),
input('状态', 'study_mission_accepted-status', '', '4', {min:1,max:10}),
input('学习报告', 'study_mission_accepted-study_report', '', '4', {min:1,max:200}),
hide('study_mission_accepted-study_mission_accept_id'),
hide('study_mission_accepted-study_mission_release_id')
],'标题')],'ecampus.join_party.study_mission_accepted@add','','添加');