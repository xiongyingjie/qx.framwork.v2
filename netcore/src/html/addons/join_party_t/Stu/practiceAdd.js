render([
    group([
	input("社会实践", "social_practice-describe", '', 4),
	file("上传社会实践附件", "social_practice-attachment", 2, "/UserFile/join_party/social_practice_file/"),
	hide('social_practice-social_practice_id', '#id'),
hide('social_practice-UserId', '#uid'),
hide('social_practice-upload_time', '#now')
],'社会实践及材料')],'ecampus.join_party.social_practice@add','','添加');

