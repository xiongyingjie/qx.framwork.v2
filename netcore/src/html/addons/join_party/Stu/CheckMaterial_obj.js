﻿//发展对象--查看材料
render(function () {
    return [
		group([//培养联系人，入党志愿书提交时间，入党志愿书下载
            //-----------------------------------------------------------
			showinput("入党联系人", "cultivation_connector-Name", '', '1'),
            showinput("入党志愿书提交时间", "cultivation_object_info-sub_time_of_vlolunte", '', '1'),
			showfile("入党志愿书附件下载", "cultivation_object_info-join_party_volunte"),
		], "查看预备党员申请材料", 1)
    ];

},
 '', 'ecampus.join_party.cultivation_object_info@list'.jn('cultivation_connector.UserId', '').eq('UserId', '_uid'), '');
