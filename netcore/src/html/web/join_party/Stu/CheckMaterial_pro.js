//预备党员--查看材料：文件上传失败
//数据库没有群众意见
render(function () {
    return [
		group([//转正申请提交时间，转正申请，群众意见
            //-----------------------------------------------------------
			showinput("转正申请提交时间", "cultivation_object_info-sub_formal_application_Time", '', '1'),
            showfile("下载转正申请附件", "cultivation_object_info-formal_application")
		], "查看正式党员申请材料", 1)
    ];

},
 '', 'ecampus.join_party.cultivation_object_info@list'.eq('UserId', '_uid'), '');
