render([
    group([
showInput('用户Id', 'study_mission_accepted-UserID', '',4),
showFile('学习报告', 'study_mission_accepted-study_report','report',4),
hide('study_mission_accepted-study_mission_accept_id', ''),
hide( 'study_mission_accepted-study_mission_release_id', ''),
hide('study_mission_accepted-status', ''),
hide('study_mission_accepted_status-statusID', '')
],'标题')],'','ecampus.join_party.study_mission_accepted@find &id='+q.id,'','详情');