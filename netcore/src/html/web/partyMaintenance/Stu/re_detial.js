render(function () {
    return [
		panel([
             hide('cultivation_object_info-uid'),
			showinput("社区表现分", "cultivation_object_info-community_representation", '', '3'),//社区表现分为校方填入
			showTime("党校结业时间", "cultivation_object_info-graduation_time", '', '3'),//校方填写登记结业时间
		], "查看发展对象申请材料", 1, Color.blue),




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
			html('<div id="service"></div>')
        ], "上传自传&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Stu/practiceAdd'>添加</a>)", 1, Color.green, "", 1),

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
    .eq('UserId', '_uid'), '');

function refresh() {
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
    refresh();



    //		"ecampus.join_party.cultivation_object_info@list".jn("volunteer_service.UserId").eq('volunteer_service.UserId', '_uid')
    //.query(
    //function(data) {//请求数据
    //if (!$.isArray(data))
    // {
    //	data = [data];
    //}
    //		var head=['活动','材料上传时间'];
    //	    var body=[];   //处理数据（用数组把查出来的数据去加入）
    //		$.each(data, function(i,o) {
    //			body.push([o.describe, o.upload_time]);
    //		});
    //		//塞入table
    //		$("#service").html(table(body, head).html);
    //	});	 //志愿活动


    //			"ecampus.join_party.cultivation_object_info@list".jn("join_activity.UserId").eq('join_activity.UserId', '_uid')
    //.query(
    //function(data) {//请求数据
    //if (!$.isArray(data))
    // {
    //	data = [data];
    //}
    //		var head=['活动','材料上传时间'];
    //	    var body=[];   //处理数据（用数组把查出来的数据去加入）
    //		$.each(data, function(i,o) {
    //			body.push([o.describe, o.upload_time]);
    //		});
    //		//塞入table
    //		$("#activity").html(table(body, head).html);
    //	});	 //参加活动
}