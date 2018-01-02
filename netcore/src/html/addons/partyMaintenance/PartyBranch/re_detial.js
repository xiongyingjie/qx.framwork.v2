render(function () {
    return [
        //审查基本信息
		panel([
             hide('cultivation_object_info-uid'),
			showinput("年级", "cultivation_object_info-Grade", '', '3'),//社区表现分为校方填入
            showinput("班级", "cultivation_object_info-Class", '', '3'),//社区表现分为校方填入
            showinput("姓名", "cultivation_object_info-name", '', '3'),//社区表现分为校方填入
		], "审查基本信息", 1, Color.blue),


        panel([
            showfile("入党申请书", "cultivation_object_info-join_application", '', '3'),
            showfile("个人自传", "cultivation_object_info-alutobiography", '', '3'),
            showfile("入党志愿书", "cultivation_object_info-join_party_volunte", '', '3'),
            showfile("转正申请", "cultivation_object_info-formal_application", '', '3'),
        ], "审核文件资料", 1, Color.blue),


	   panel([
			html('<div id="thought"></div>')
	   ], "思想汇报&nbsp;&nbsp;", 1, Color.green, ""),




	   panel([
			html('<div id="point"></div>')
	   ], "绩点&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Stu/pointAdd'>添加</a>)", 1, Color.green, ""),



       panel([
			html('<div id="position"></div>')
       ], "职务&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Stu/positionAdd'>添加</a>)", 1, Color.red, ""),
       panel([
			html('<div id="connector"></div>')
       ], "培养联系人", 1, Color.green, ""),

		panel([
			html('<div id="prize"></div>')
		], "获奖情况&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Stu/prizeAdd'>添加</a>)", 1, Color.red, ""),

		panel([
			html('<div id="practice"></div>')
		], "社会实践&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Stu/practiceAdd'>添加</a>)", 1, Color.green, ""),


		panel([
			html('<div id="service"></div>')
		], "志愿服务&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Stu/practiceAdd'>添加</a>)", 1, Color.green, "", 1),

		panel([
			html('<div id="activity"></div>')
		], "参加活动", 2)
    ];

},
 '', 'ecampus.join_party.cultivation_object_info@list'
   //  .jn('point_table.UserId')
  //  .jn('get_prize.UserId', '')
 //   .jn('social_practice.UserId')
 //   .jn('volunteer_service.UserId', '')
 //   .jn('join_activity.UserId', '')
  //  .biger('cultivation_connector.EndTime', '_now')
   //.less('cultivation_connector.BeginTime', '_now')
    .eq('UserId', q.id), '');

function refresh(arg1) {
    renderTable([
        {
            id: "point",
            head: ['学年', '绩点'],
            store: "ecampus.join_party.cultivation_object_info@list".
                jn("point_table.UserId").
                eq('point_table.UserId', '_uid'),
            row: function (o, i, data) {
                return [
                    o.grade, o.grade_point,
                    [{ text: "下载证明材料", url: "ecampus.join_party.point_table@download&id=" + o.point_table_id + "&file=point_attachmebt" },
                     { text: "删除", url: "ecampus.join_party.point_table@delete&id=" + o.point_table_id }]];

            }
        },     //绩点

        {
            id: "position",
            head: ['职位', '材料上传时间'],
            store: "ecampus.join_party.cultivation_object_info@list".
                    jn("hold_position.UserId").
                    eq('hold_position.UserId', '_uid'),
            row: function (o, i, data) {
                return [o.describe, o.upload_time,
        [{ text: "下载证明材料", url: "ecampus.join_party.hold_position@download&id=" + o.hold_position_id + "&file=attachment" },
            { text: "删除", url: "ecampus.join_party.hold_position@delete&id=" + o.hold_position_id }
        ]]
            }
        },  //职位

        {
            id: "connector",
            head: ['联系人', '电话', '开始时间', '结束时间'],
            store: "ecampus.join_party.cultivation_object_info@list".
                 jn("cultivation_connector.UserId").
                  eq('cultivation_connector.UserId', '_uid'),
            row: function (o, i, data) {

                return [o.Name, o.Phone, o.BeginTime, o.EndTime]
            }
        },//联系人
        ///------------------------------------------------------思想汇报
           {
               id: "thought",
               head: ['标题', '提交人状态', '提交时间', '审核状态'],
               store: "ecampus.join_party.thought_report@list"
                   .jn('cultivation_state.cultivation_object_stateId', 'thought_report.StateID')
                   .jn('Requst_table.UserId', 'thought_report.UserId')
                   .le('thought_report.StateID', '[Requst_table.cultivation_object_stateId]')
                    .eq('thought_report.UserId', q.id),
               row: function (o, i, data) {
                   return [
                       o.Describe, o.name, o.UploadTime, o.is_read == "1" ? "已读" : "未读",
                       [{ text: "查看思想汇报", url: "ecampus.join_party.thought_report@download&id=" + o.thought_report_id + "&file=Attachment" },
                        { text: "删除", url: "ecampus.join_party.thought_report@delete&id=" + o.thought_report_id }]];

               }
           },
         //--------------------------------------------------------
		 {
		     id: "prize",
		     head: ['获奖', '材料上传时间'],
		     store: "ecampus.join_party.cultivation_object_info@list".
                     jn("get_prize.UserId").
                     eq('get_prize.UserId', '_uid'),
		     row: function (o, i, data) {
		         return [o.describe, o.upload_time,
                   [{ text: "下载证明材料", url: "ecampus.join_party.get_prize@download&id=" + o.get_prize_id + "&file=attachment" },
                       { text: "删除", url: "ecampus.join_party.get_prize@delete&id=" + o.get_prize_id }
                   ]]
		     }
		 },//获奖

	    {
	        id: "practice",
	        head: ['实践项目', '材料上传时间', '操作'],
	        store: "ecampus.join_party.cultivation_object_info@list".
			      jn("social_practice.UserId").
			      eq('social_practice.UserId', '_uid'),
	        row: function (o, i, data) {
	            return [o.describe, o.upload_time,
				 [{ text: "下载证明材料", url: "ecampus.join_party.social_practice@download&id=" + o.social_practice_id + "&file=attachment" },
                  { text: "删除", url: "ecampus.join_party.social_practice@delete&id=" + o.social_practice_id }
				 ]]
	        }
	    },//社会实践

		    {
		        id: "service",
		        head: ['实践项目', '材料上传时间', '操作'],
		        store: "ecampus.join_party.cultivation_object_info@list".
                      jn("social_practice.UserId").
                      eq('social_practice.UserId', '_uid'),
		        row: function (o, i, data) {
		            return [o.describe, o.upload_time,
                     [{ text: "下载证明材料", url: "ecampus.join_party.social_practice@download&id=" + o.social_practice_id + "&file=attachment" },
                      { text: "删除", url: "ecampus.join_party.social_practice@delete&id=" + o.social_practice_id }
                     ]]
		        }
		    }//志愿活动

    ]);

}
function formReady() {
    //设置弹窗大小
    InitPopup({
        width: 500,
        height: 400,
        center: true
    }, ".qx-operate");

    //刷新页面
    refresh(q.id);






}