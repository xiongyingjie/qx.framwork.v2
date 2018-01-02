render([
    group([
input('学习任务指派编号', 'study_mission_appoint_ORG-study_mission_appoint_id', '', '4', {min:1,max:50}),
input('学习任务发布编号', 'study_mission_appoint_ORG-study_mission_release_id', '', '4', {min:1,max:50}),
input('组织机构ID', 'study_mission_appoint_ORG-org_id', '', '4', {min:1,max:50})
],'标题')],'ecampus.join_party.study_mission_appoint_ORG@add','','添加');