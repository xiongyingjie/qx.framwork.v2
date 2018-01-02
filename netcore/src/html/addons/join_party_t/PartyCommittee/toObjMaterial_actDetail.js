render(function () {
    return [
		panel([
             hide('cultivation_object_info-UserId',q.id),
			input("社区表现分", "cultivation_object_info-community_representation", '', '4'),//社区表现分为校方填入
	
	        
			showTime("党校结业时间", "cultivation_object_info-graduation_time", '', '4'),//校方填写登记结业时间
			showFile("转正申请附件", "cultivation_object_info-formal_application", '', '1'),
            showFile("自传", "cultivation_object_info-alutobiography", '', '1')
			
		] ,"查看发展对象申请材料", 1,Color.blue),



		
	   /*panel([
			html('<div id="point"></div>')
	   ], "绩点", 1, Color.green, ""),
	   */


       panel([
			html('<div id="position"></div>')
       ], "职务", 1, Color.red, ""),
       panel([
			html('<div id="connector"></div>')
			],"培养联系人",1,Color.green,""),
					      
		panel([
			html('<div id="prize"></div>')
			],"获奖情况",1,Color.red,""),
           
		panel([
			html('<div id="practice"></div>')
			],"社会实践",1,Color.green,""),
			

		panel([
			html('<div id="service"></div>')
			],"志愿服务",1,Color.red,"",1),
		
		panel([
			html('<div id="activity"></div>')
			],"参加活动",1,Color.green,"",1)
    ];

},
 '', 'ecampus.join_party.cultivation_object_info@list'
    .eq('UserId',q.id), '');

function refresh() {
    renderTable([
        {
	    id: "point",
	    head:['学年','绩点'],
        store:"ecampus.join_party.cultivation_object_info@list".
			jn("point_table.UserId").
			eq('point_table.UserId', q.id),
		row:function(o,i,data) {
		    return [
		        o.grade, o.grade_point,
                [{ text: "下载证明材料",url: "ecampus.join_party.point_table@download&id=" + o.point_table_id + "&file=point_attachmebt" }
                 ]];

			}
        },     //绩点

        {
	    id: "position",
	    head: ['职位', '材料上传时间'],
	    store: "ecampus.join_party.cultivation_object_info@list".
		        jn("hold_position.UserId").
		        eq('hold_position.UserId',q.id),
	    row:    function (o, i, data) {
	                    return [o.describe, o.upload_time,
                [{ text: "下载证明材料", url: "ecampus.join_party.hold_position@download&id=" + o.hold_position_id + "&file=attachment" }
                ] ] }
        },  //职位

        {
	    id: "connector",
	    head: ['联系人', '电话', '开始时间', '结束时间'],
	    store: "ecampus.join_party.cultivation_object_info@list".
		     jn("cultivation_connector.UserId").
		      eq('cultivation_connector.UserId', q.id),
	    row: function (o, i, data) {

	        return [o.Name, o.Phone, o.BeginTime, o.EndTime] }
        },//联系人

		 {
	    id: "prize",
	    head: ['获奖', '材料上传时间'],
	    store: "ecampus.join_party.cultivation_object_info@list".
                jn("get_prize.UserId").
				eq('get_prize.UserId',q.id),
	    row: function (o, i, data) {
	        return [o.describe, o.upload_time,
              [{ text: "下载证明材料", url:  "ecampus.join_party.get_prize@download&id=" + o.get_prize_id + "&file=attachment" }
              ]] }
        },//获奖

	    {
		    id:"practice",
			head:['实践项目','材料上传时间','操作'],
			store:"ecampus.join_party.cultivation_object_info@list".
			      jn("social_practice.UserId").
			      eq('social_practice.UserId', q.id),
		    row :function(o, i, data) {
			    return [o.describe, o.upload_time,
				 [{ text: "下载证明材料", url:  "ecampus.join_party.social_practice@download&id=" + o.social_practice_id + "&file=attachment"}
              ]] }
	    },//社会实践

		    {
		    id:"service",
			head:['实践项目','材料上传时间','操作'],
			store:"ecampus.join_party.cultivation_object_info@list".
			      jn("social_practice.UserId").
			      eq('social_practice.UserId', q.id),
		    row :function(o, i, data) {
			    return [o.describe, o.upload_time,
				 [{ text: "下载证明材料", url:  "ecampus.join_party.social_practice@download&id=" + o.social_practice_id + "&file=attachment"}
              ]] }
	    },//志愿活动

		    {
		    id:"activity",
			head:['活动','材料上传时间'],
			store:"ecampus.join_party.cultivation_object_info@list"
			.jn("join_activity.UserId")
			.eq('join_activity.UserId',q.id),
		    row :function(o, i, data) {
			    return [o.describe, o.upload_time,
				 [{ text: "下载证明材料", url:  "ecampus.join_party.join_activity@download&id=" + o.join_activity_id + "&file=attachment"}
              ]] }
	    }//参加活动

    ]);

}
function formReady() {
    //设置弹窗大小
	    InitPopup({
	        width: 500,
	        height: 400,
            center:true
	    }, ".qx-operate");

	    //刷新页面
	    refresh();
}