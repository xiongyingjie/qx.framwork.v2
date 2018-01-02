render(function () {
    return [
		panel([


		    input("社区表现分", "cultivation_object_info-community_representation", '', '4'),//社区表现分为校方填入
			showTime("党校结业时间", "cultivation_object_info-graduation_time", '', '4'),//校方填写登记结业时间
            file("上传自传", "cultivation_object_info-alutobiography", '', '2'),

hide( 'cultivation_object_info-UserId', ''),
hide( 'cultivation_object_info-name', ''),
hide( 'cultivation_object_info-Grade', ''),
hide( 'cultivation_object_info-Class', ''),
hide( 'cultivation_object_info-sex', ''),
hide('cultivation_object_info-natiion', ''),

hide( 'cultivation_object_info-phone', ''),
hide('cultivation_object_info-qualification', ''),
hide( 'cultivation_object_info-point', ''),
hide( 'cultivation_object_info-rank', ''),

hide( 'cultivation_object_info-birthday', ''),
hide( 'cultivation_object_info-sub_time_of_vlolunte', ''),
hide( 'cultivation_object_info-be_activist_time', ''),


hide( 'cultivation_object_info-development_object_time', ''),
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
hide('cultivation_object_info-unit_id'),
       
			button("提交材料", '1:5', Color.green, function () {
         submitForm("ecampus.join_party.cultivation_object_info@update-_uid");
 })
		] ,"查看发展对象申请材料", 1,Color.blue),



		
	   /*panel([
			html('<div id="point"></div>')
	   ], "绩点&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Stu/pointAdd'>添加</a>)", 1, Color.green, ""),
	   */


       panel([
			html('<div id="position"></div>')
       ], "职务&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Stu/positionAdd'>添加</a>)", 1, Color.red, ""),
       panel([
			html('<div id="connector"></div>')
			],"培养联系人",1,Color.green,""),
					      
		panel([
			html('<div id="prize"></div>')
			],"获奖情况&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Stu/prizeAdd'>添加</a>)",1,Color.red,""),
           
		panel([
			html('<div id="practice"></div>')
			],"社会实践&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Stu/practiceAdd'>添加</a>)",1,Color.green,""),
			

		panel([
			html('<div id="service"></div>')
			],"志愿服务&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Stu/practiceAdd'>添加</a>)",1,Color.red,"",1),
		
		panel([
			html('<div id="activity"></div>')
			],"参加活动&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Stu/activityAdd'>添加</a>)",1,Color.green,"",1)
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
	    head:['学年','绩点'],
        store:"ecampus.join_party.cultivation_object_info@list".
			jn("point_table.UserId").
			eq('point_table.UserId', '_uid'),
		row:function(o,i,data) {
		    return [
		        o.grade, o.grade_point,
                [{ text: "下载证明材料",url: "ecampus.join_party.point_table@download&id=" + o.point_table_id + "&file=point_attachmebt" },
                 {text: "删除", url: "ecampus.join_party.point_table@delete&id=" + o.point_table_id }]];

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
                    {text: "删除", url: "ecampus.join_party.hold_position@delete&id=" + o.hold_position_id }
                ] ] }
        },  //职位

        {
	    id: "connector",
	    head: ['联系人', '电话', '开始时间', '结束时间'],
	    store: "ecampus.join_party.cultivation_object_info@list".
		     jn("cultivation_connector.UserId").
		      eq('cultivation_connector.UserId', '_uid'),
	    row: function (o, i, data) {

	        return [o.Name, o.Phone, o.BeginTime, o.EndTime] }
        },//联系人

		 {
	    id: "prize",
	    head: ['获奖', '材料上传时间'],
	    store: "ecampus.join_party.cultivation_object_info@list".
                jn("get_prize.UserId").
				eq('get_prize.UserId', '_uid'),
	    row: function (o, i, data) {
	        return [o.describe, o.upload_time,
              [{ text: "下载证明材料", url:  "ecampus.join_party.get_prize@download&id=" + o.get_prize_id + "&file=attachment" },
                  { text: "删除", url: "ecampus.join_party.get_prize@delete&id=" + o.get_prize_id }
              ]] }
        },//获奖

	    {
		    id:"practice",
			head:['实践项目','材料上传时间','操作'],
			store:"ecampus.join_party.cultivation_object_info@list".
			      jn("social_practice.UserId").
			      eq('social_practice.UserId', '_uid'),
		    row :function(o, i, data) {
			    return [o.describe, o.upload_time,
				 [{ text: "下载证明材料", url:  "ecampus.join_party.social_practice@download&id=" + o.social_practice_id + "&file=attachment"},
                  { text: "删除", url: "ecampus.join_party.social_practice@delete&id=" + o.social_practice_id }
              ]] }
	    },//社会实践

		    {
		    id:"service",
			head:['实践项目','材料上传时间','操作'],
			store:"ecampus.join_party.cultivation_object_info@list".
			      jn("social_practice.UserId").
			      eq('social_practice.UserId', '_uid'),
		    row :function(o, i, data) {
			    return [o.describe, o.upload_time,
				 [{ text: "下载证明材料", url:  "ecampus.join_party.social_practice@download&id=" + o.social_practice_id + "&file=attachment"},
                  { text: "删除", url: "ecampus.join_party.social_practice@delete&id=" + o.social_practice_id }
              ]] }
	    },//志愿活动

		    {
		    id:"activity",
			head:['活动','材料上传时间'],
			store:"ecampus.join_party.cultivation_object_info@list"
			.jn("join_activity.UserId")
			.eq('join_activity.UserId', '_uid'),
		    row :function(o, i, data) {
			    return [o.describe, o.upload_time,
				 [{ text: "下载证明材料", url:  "ecampus.join_party.join_activity@download&id=" + o.join_activity_id + "&file=attachment"},
                  { text: "删除", url: "ecampus.join_party.join_activity@delete&id=" + o.join_activity_id }
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