render(function() {
	subSetTitle("");
	return [
		group([
			hide('thought_report-Id', ''),
			showInput('工号', 'thought_report-UserId', '', '4'),
			showInput('标题', 'thought_report-Describe', '', '4'),
			showTime('上传时间', 'thought_report-UploadTime', '', '4'),
			showFile('思想汇报附件', 'thought_report-Attachment')
		],  "申请详情")
	]; 
}, '', 'ecampus.join_party.thought_report@find&id=' + q.id,'','');