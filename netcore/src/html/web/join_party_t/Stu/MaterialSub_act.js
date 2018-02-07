
render(function () {
    return [
		group([
			input("绩点", "point_table-grade_point", '', 4),
			 select("选择学年", "point_table-grade", 
			       [{ text: '大一学年', value: '大一学年' },
                   { text: '大二学年', value: '大二学年' },
                   { text: '大三学年', value: '大三学年' },
                   { text: '大四学年', value: '大四学年' }], "", 3),
            file('绩点证明材料', 'point_table-point_attachmebt',3, "/UserFile/join_party/point_file/"),
            //此处再添加一个下拉框选择学年
            //-----------------------------------------------------------
			area("职务", "hold_position-describe", '请输入职务', 4),
		    file("上传职务证明附件", "hold_position-attachment",4,  "/UserFile/join_party/hold_position_file/"),//职务表
            hideTime( 'hold_position-begin_time', ''),
            hideTime( 'hold_position-end_time', ''),
            input('社区表现分', 'cultivation_object_info-community_representation', '', 4), 
			file("上传社区表现分证明附件", "cultivation_object_info-community_representation_attach", 2, "/UserFile/join_party/community_file/"),
			file("上传自传", "cultivation_object_info-alutobiography", 1, "/UserFile/join_party/alutobiography_file/"),
         
			input("获奖名称", "get_prize-prize_name", '', 3),
			 area("获奖描述", "get_prize-describe", '', 3),
			 file("上传获奖情况附件", "get_prize-attachment", 3, "/UserFile/join_party/get_prize_file/"),
			area("社会实践", "social_practice-describe", '', 2),
			 file("上传社会实践附件", "social_practice-attachment", 2, "/UserFile/join_party/social_practice_file/"),
			area("志愿活动", "volunteer_service-describe", '',2),
			 file("上传志愿活动附件", "volunteer_service-attachment", 2, "/UserFile/join_party/volunteer_service_file/"),
            area("参加活动", "join_activity-describe", '',2), 
			file("上传参加活动附件", "join_activity-attachment", 2, "/UserFile/join_party/join_activity_file/"),
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
hideTime('cultivation_object_info-development_object_time'),
hideTime('cultivation_object_info-join_party_time'),
hide('cultivation_object_info-party_Id'),
hideTime('cultivation_object_info-party_committee_eaxm_time'),
hideTime('cultivation_object_info-join_train_class_time'),
hide('cultivation_object_info-join_party_volunte'),
hideTime('cultivation_object_info-sub_time_of_vlolunte'),
hideTime('cultivation_object_info-sub_formal_application_Time'),
hide('cultivation_object_info-formal_application'),
hideTime('cultivation_object_info-formal_time'),
hide('cultivation_object_info-cultivation_object_stateId'),
hideTime('cultivation_object_info-swear_time'),
hide('cultivation_object_info-qq'),
hide('cultivation_object_info-weixin'),
hide('cultivation_object_info-join_application'),
//---------------------------查出point_table表中的列-----------------------------
hide('point_table-point_table_id', '#id'),
hide('point_table-UserId','#uid'),
//---------------------------查出hold_position表中的列-----------------------------
hide('hold_position-hold_position_id', '#id'),
hide('hold_position-UserId', '#uid'),
hide('hold_position-upload_time', '#now'),
//---------------------------查出get_prize表中的列-----------------------------
hide('get_prize-get_prize_id', '#id'),
hide('get_prize-UserId', '#uid'),
hide('get_prize-upload_time', '#now'),
//---------------------------查出social_practice表中的列-----------------------------
hide('social_practice-social_practice_id', '#id'),
hide('social_practice-UserId', '#uid'),
hide('social_practice-upload_time', '#now'),
//---------------------------查出volunteer_service表中的列-----------------------------
hide('volunteer_service-volunteer_service_Id', '#id'),
hide('volunteer_service-UserId', '#uid'),
hide('volunteer_service-upload_time', '#now'),
//---------------------------查出join_activity表中的列-----------------------------
hide('join_activity-join_activity_id', '#id'),
hide('join_activity-UserId', '#uid'),
hide('join_activity-upload_time', '#now'),

 button("提交材料", '1:5', Color.green, function () {
     submitForm("ecampus.join_party.cultivation_object_info@update-_uid|point_table@add|hold_position@add|get_prize@add|social_practice@add|volunteer_service@add|join_activity@add");
 })

		], "提交发展对象申请材料", 1)
    ];

}, '','ecampus.join_party.cultivation_object_info@list'
.eq('cultivation_object_info.UserId', '_uid'), '');



