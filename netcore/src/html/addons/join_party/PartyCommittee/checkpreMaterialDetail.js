render(function () {
    return [
		panel([
		 showInput('学号', 'cultivation_object_info-UserId', '', '4'),
showInput('姓名', 'cultivation_object_info-name', '', '4'),
showInput('年级', 'cultivation_object_info-Grade', '', '4'),
showInput('班级', 'cultivation_object_info-Class', '', '4'),
showInput('性别', 'cultivation_object_info-sex', '', '4'),
showInput('民族', 'cultivation_object_info-natiion', '', '4'),

showInput('电话', 'cultivation_object_info-phone', '', '4'),
showInput('学历', 'cultivation_object_info-qualification', '', '4'),
hide('cultivation_object_info-point', ''),
hide( 'cultivation_object_info-rank', ''),
showInput('社区表现分', 'cultivation_object_info-community_representation', '', '4'),

showTime('出生年月', 'cultivation_object_info-birthday', '', '4'),
showTime('提交入党志愿书时间', 'cultivation_object_info-sub_time_of_vlolunte', '', '4'),
showTime('确定为积极分子时间', 'cultivation_object_info-be_activist_time', '', '4'),
showTime('党校结业时间', 'cultivation_object_info-graduation_time', '', '4'),

showTime('确定为发展对象时间', 'cultivation_object_info-development_object_time', '', '4'),
showFile("自传", "cultivation_object_info-alutobiography", '', '2'),
hide('cultivation_object_info-join_application_time', ''),
hide( 'cultivation_object_info-league_branch_Id', ''),
hide('cultivation_object_info-join_party_time', ''),
hide( 'cultivation_object_info-party_Id', ''),
hide( 'cultivation_object_info-party_committee_eaxm_time', ''),
hide('cultivation_object_info-join_train_class_time', ''),
hide( 'cultivation_object_info-join_party_volunte'),

hide( 'cultivation_object_info-sub_formal_application_Time', ''),
hide( 'cultivation_object_info-formal_application'),
hide( 'cultivation_object_info-formal_time', ''),
hide( 'cultivation_object_info-cultivation_object_stateId', ''),

hide('cultivation_object_info-swear_time', ''),
hide( 'cultivation_object_info-qq', ''),
hide('cultivation_object_info-weixin', ''),
hide('cultivation_object_info-join_application'),
hide('cultivation_object_info-unit_id')
          
			
		
          
			
		] ,"查看发展对象申请材料", 1,Color.blue),
	
	   panel([
			html('<div id="point"></div>')
	   ], "绩点", 1, Color.green, ""),



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
			],"参加活动",1,Color.green,"",1),
	   panel([
           button("确定为预备党员", '6:0', Color.green, function () {
    $("#cultivation_object_info-cultivation_object_stateId").val('4');
    $("#cultivation_object_info-development_object_time").val('#now');
    submitForm("ecampus.join_party.cultivation_object_info@update&id="+q.id);
}),
button("继续培养", '6:0', Color.red, function () {
    $("#cultivation_object_info-cultivation_object_stateId").val('3');
    submitForm("ecampus.join_party.cultivation_object_info@update&id="+q.id);
})
			
		] ,"审核提交", 1,Color.blue)
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