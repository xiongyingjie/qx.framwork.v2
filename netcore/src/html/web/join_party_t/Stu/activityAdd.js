render([
    group([
	  input("参加活动", "join_activity-describe", '',2), 
			file("上传参加活动附件", "join_activity-attachment", 2, "/UserFile/join_party/join_activity_file/"),
			hide('join_activity-join_activity_id', '#id'),
hide('join_activity-UserId', '#uid'),
hide('join_activity-upload_time', '#now')
],'上传职务情况及材料')],'ecampus.join_party.join_activity@add','','添加');
