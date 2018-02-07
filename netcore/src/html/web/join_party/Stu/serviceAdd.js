render([
    group([
	input("志愿服务", "volunteer_service-describe", '', 4),
	file("上传志愿服务附件", "volunteer_service-attachment", 2, "/UserFile/join_party/social_practice_file/"),
	hide('volunteer_service-volunteer_service_Id', '#id'),
hide('volunteer_service-UserId', '#uid'),
hide('volunteer_service-upload_time', '#now')
],'志愿服务及材料')],'ecampus.join_party.volunteer_service@add','','添加');

