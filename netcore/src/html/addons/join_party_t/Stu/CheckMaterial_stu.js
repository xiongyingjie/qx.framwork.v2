render(function () {
    return [
		group([
			showinput("工号", "cultivation_object_info-UserId", '', '1'),
			showinput("姓名", "cultivation_object_info-name", '', '1'),
			//showinput("所在支部", "Party_branch-name", '', '1'), //教师提交是所选支部
            showinput("wechat", "cultivation_object_info-weixin", '', '1'),
			showinput("QQ", "cultivation_object_info-qq", '', '1'),
			showinput("手机号", "cultivation_object_info-phone", '', '1'),
            //-----------------------------------------------------------
           showfile('下载入党申请书附件', 'cultivation_object_info-join_application')
		], "查看入党申请材料", 1)
    ];

},
 '', 'ecampus.join_party.cultivation_object_info@find&id='+'_uid', '');

	// 'ecampus.join_party.cultivation_object_info@list'
   // .jn('league_branch.unit_id', 'cultivation_object_info.league_branch_Id')
   // .jn('Party_branch.unit_id', 'league_branch.unit_id')
   // .eq('cultivation_object_info.UserId', '_uid')
