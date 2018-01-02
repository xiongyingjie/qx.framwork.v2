render(function() {
	subSetTitle("");
	return [
		group([
			hide('cultivation_object_info-uid', ''),
			showInput('学号', 'cultivation_object_info-UserId', '', '4'),
			showInput('年级', 'cultivation_object_info-Grade', '', '4'),
			showInput('班级', 'cultivation_object_info-Class', '', '4'),
			showInput('姓名', 'cultivation_object_info-name', '', '4'),
			showInput('性别', 'cultivation_object_info-sex', '', '4'),
			showInput('民族', 'cultivation_object_info-natiion', '', '4'),
			showTime('出生年月', 'cultivation_object_info-birthday', '', '4'),
			showInput('电话', 'cultivation_object_info-phone', '', '4'),
			showInput('学历', 'cultivation_object_info-qualification', '', '4'),
			showInput('qq号', 'cultivation_object_info-qq', '', '4'),
			showInput('微信号', 'cultivation_object_info-weixin', '', '4'),
			showTime('递交入党申请书时间', 'cultivation_object_info-join_application_time', '', '4'),
			showFile('入党申请书', 'cultivation_object_info-join_application')
			
		],  "申请详情")
	]; 
}, '', 'ecampus.join_party.cultivation_object_info@find&id=' + q.id,'','');

        