//预备党员申请--提交材料:文件上传有问题
render(function () {
    return [
		group([//入党联系人，入党志愿书上传
            //-----------------------------------------------------------
			file('上传转正申请', 'cultivation_object_info-formal_application', 1, "/UserFile/join_party/formal_application_file/"),

            //-------------------------查出cultivation_object_info表中所有的数据-----------------------------------------
            hide('cultivation_object_info-UserId'),
hide('cultivation_object_info-Class'),
hide('cultivation_object_info-Grade'),
hide('cultivation_object_info-name'),
hide('cultivation_object_info-sex'),
hide('cultivation_object_info-natiion'),
hideTime('cultivation_object_info-birthday'),
hide('cultivation_object_info-phone'),
hide('cultivation_object_info-qualification'),
hideTime('cultivation_object_info-join_application_time'),
hide('cultivation_object_info-league_branch_Id'),
hideTime('cultivation_object_info-be_activist_time'),
hideTime('cultivation_object_info-graduation_time'),
hide('cultivation_object_info-point'),
hide('cultivation_object_info-rank'),
hide('cultivation_object_info-community_representation'),
hideTime('cultivation_object_info-development_object_time'),
hideTime('cultivation_object_info-join_party_time'),
hide('cultivation_object_info-party_Id'),
hideTime('cultivation_object_info-party_committee_eaxm_time'),
hideTime('cultivation_object_info-join_train_class_time'),
hideTime('cultivation_object_info-sub_time_of_vlolunte'),
hideTime('cultivation_object_info-sub_formal_application_Time','#now'),
hide('cultivation_object_info-join_party_volunte'),
hideTime('cultivation_object_info-formal_time'),
hide('cultivation_object_info-cultivation_object_stateId'),
hide('cultivation_object_info-alutobiography'),
hideTime('cultivation_object_info-swear_time'),
hide('cultivation_object_info-qq'),
hide('cultivation_object_info-weixin'),
hide('cultivation_object_info-join_application'),
hide('cultivation_object_info-community_representation_attach'),
hide('cultivation_object_info-unit_id'),
button("提交材料", '1:5', Color.green, function () {
  
    $("#cultivation_object_info-sub_formal_application_Time").val("#now");
    submitForm("ecampus.join_party.cultivation_object_info@update-_uid");
})

		], "提交正式党员申请材料", 1)
    ];

},
 '',
'ecampus.join_party.cultivation_object_info@list'
.eq('cultivation_object_info.UserId', '_uid'), '');
