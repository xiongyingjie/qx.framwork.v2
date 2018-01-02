render([
    group([
showInput('工号', 'cultivation_object_info-UserId', '', '4'),
hide('cultivation_object_info-Grade', ''),
hide('cultivation_object_info-Class', ''),
showInput('姓名', 'cultivation_object_info-name', '', '4'),
showInput('性别', 'cultivation_object_info-sex', '', '4'),
showInput('民族', 'cultivation_object_info-natiion', '', '4'),
showTime('出生年月', 'cultivation_object_info-birthday', '', '4'),
showInput('电话', 'cultivation_object_info-phone', '', '4'),
showInput('学历', 'cultivation_object_info-qualification', '', '4'),
showTime('递交入党申请书时间', 'cultivation_object_info-join_application_time', '', '4'),
hide('cultivation_object_info-league_branch_Id', ''),
showTime('确定为积极分子时间', 'cultivation_object_info-be_activist_time', '', '4'),
showTime('党校结业时间', 'cultivation_object_info-graduation_time', '', '4'),
hide( 'cultivation_object_info-point', ''),
hide('cultivation_object_info-rank', ''),
showInput('qq号', 'cultivation_object_info-qq', '', '4'),
showInput('微信号', 'cultivation_object_info-weixin', '', '4'),
showFile('入党申请书', 'cultivation_object_info-join_application')
],'标题')],'','ecampus.join_party.cultivation_object_info@find&id='+q.id,'','详情');