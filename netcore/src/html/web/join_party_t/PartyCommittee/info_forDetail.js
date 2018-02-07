

render([
    group([
showInput('工号', 'cultivation_object_info-UserId', '', '4'),
hide('cultivation_object_info-Class', ''),
hide('cultivation_object_info-Grade', ''),
showInput('姓名', 'cultivation_object_info-name', '', '4'),
showInput('性别', 'cultivation_object_info-sex', '', '4'),
showInput('民族', 'cultivation_object_info-natiion', '', '4'),

showInput('电话', 'cultivation_object_info-phone', '', '4'),
showInput('学历', 'cultivation_object_info-qualification', '', '4'),
showInput('党支部ID', 'cultivation_object_info-party_Id', '', '4'),
showTime('出生年月', 'cultivation_object_info-birthday', '', '4'),
showTime('递交入党申请书时间', 'cultivation_object_info-join_application_time', '', '4'),
showTime('确定为积极分子时间', 'cultivation_object_info-be_activist_time', '', '4'),
showTime('党校结业时间', 'cultivation_object_info-graduation_time', '', '4'),
showTime('确定为发展对象时间', 'cultivation_object_info-development_object_time', '', '4'),
showTime('入党时间', 'cultivation_object_info-join_party_time', '', '4'),
showTime('党委审批时间', 'cultivation_object_info-party_committee_eaxm_time', '', '4'),
showTime('预备党员培训时间', 'cultivation_object_info-join_train_class_time', '', '4'),
showTime('提交入党志愿书时间', 'cultivation_object_info-sub_time_of_vlolunte', '', '4'),
showTime('提交转正申请书时间', 'cultivation_object_info-sub_formal_application_Time', '', '4'),
showTime('转正时间', 'cultivation_object_info-formal_time', '', '4'),

showFile('个人自传附件', 'cultivation_object_info-alutobiography','','2'),
showFile('入党申请书', 'cultivation_object_info-join_application','','2'),
showFile('入党志愿书附件', 'cultivation_object_info-join_party_volunte','','2'),
showFile('转正申请附件', 'cultivation_object_info-formal_application','','2'),


hide('cultivation_object_info-cultivation_object_stateId', ''),
hide('cultivation_object_info-point', ''),
hide('cultivation_object_info-rank', ''),
hide('cultivation_object_info-community_representation', ''),
hide('cultivation_object_info-league_branch_Id', ''),
hide('cultivation_object_info-qq', ''),
hide('cultivation_object_info-weixin', '')

],'党员基本信息')],'','ecampus.join_party.cultivation_object_info@find&id='+q.id,'','详情');

