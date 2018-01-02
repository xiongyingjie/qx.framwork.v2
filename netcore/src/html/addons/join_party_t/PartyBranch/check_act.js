
render([
    group([
showInput('工号', 'cultivation_object_info-UserId', '', '4'),
hide('cultivation_object_info-Class', ''),
hide('cultivation_object_info-Grade', ''),
showInput('姓名', 'cultivation_object_info-name', '', '4'),
showInput('性别', 'cultivation_object_info-sex', '', '4'),
showInput('民族', 'cultivation_object_info-natiion', '', '4'),
showTime('出生年月', 'cultivation_object_info-birthday', '', '4'),
showInput('电话', 'cultivation_object_info-phone', '', '4'),
showInput('学历', 'cultivation_object_info-qualification', '', '4'),
showInput('qq号', 'cultivation_object_info-qq', '', '4'),
showInput('微信号', 'cultivation_object_info-weixin', '', '4'),
showTime('递交入党申请书时间', 'cultivation_object_info-join_application_time', '', '4'),


showFile('入党申请书', 'cultivation_object_info-join_application'),


hide('cultivation_object_info-league_branch_Id',''),
hideTime('cultivation_object_info-be_activist_time', '#now'),
hideTime('cultivation_object_info-graduation_time', ''),
hide('cultivation_object_info-point', ''),
hide( 'cultivation_object_info-rank', ''),
hide('cultivation_object_info-community_representation', ''),
hideTime( 'cultivation_object_info-development_object_time', ''),
hideTime('cultivation_object_info-join_party_time', ''),
hide( 'cultivation_object_info-party_Id', ''),
hideTime('cultivation_object_info-party_committee_eaxm_time', ''),
hideTime( 'cultivation_object_info-join_train_class_time', ''),
hide( 'cultivation_object_info-join_party_volunte',''),
hideTime('cultivation_object_info-sub_time_of_vlolunte', ''),
hideTime('cultivation_object_info-sub_formal_application_Time', ''),
hide('cultivation_object_info-formal_application'),
hideTime('cultivation_object_info-formal_time', ''),
hide('cultivation_object_info-cultivation_object_stateId', ''),
hide( 'cultivation_object_info-alutobiography'),
hideTime('cultivation_object_info-swear_time', ''),
hide( 'cultivation_object_info-unit_id'),

button("确定为积极分子", '6:0', Color.green, function () {
    $("#cultivation_object_info-cultivation_object_stateId").val('2');
    submitForm("ecampus.join_party.cultivation_object_info@update&id="+q.id);
}),
button("继续培养", '6:0', Color.green, function () {
    $("#cultivation_object_info-cultivation_object_stateId").val('1');
    submitForm("ecampus.join_party.cultivation_object_info@update&id="+q.id);
})
],'')],'','ecampus.join_party.cultivation_object_info@find&id='+q.id,'','审批积极分子');

