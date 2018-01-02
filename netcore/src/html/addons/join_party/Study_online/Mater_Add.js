//有问题
render(function() {
	return [
		panel([
input('任务名称', 'study_mission-study_mission_name', '', '4', {min:1,max:50}),
time('开始时间', 'study_mission-begin_time', '', '4', '请选择开始时间'),
time('结束时间', 'study_mission-end_time', '', '4', '请选择结束时间'),


hide('study_mission-study_mission_id','#id'),

hide('study_mission-study_material_id',''), // 资料

hide('study_mission-study_object'),  //对象
button("提交", '1:5', Color.green, function () {
         submitForm("ecampus.join_party.study_mission@add");
            })
		] ,"添加任务", 1,Color.blue),
 panel([
			html('<div id="ORG"></div>')
	   ], "接收任务组织&nbsp;&nbsp;(<a class='qx-operate' data-url='*fjoin_party/Study_online/Mater_PRG_Add'>添加组织</a>)", 1, Color.red, "")
	]
})


function formReady() {
	//设置弹窗大小
	InitPopup({
		width: 500,
		height: 400,
		center: true
	}, ".qx-operate");

	//刷新页面
	refresh();
}

function refresh() {
		renderTable([
			{
				id: "ORG",
				head: ['组织机构ID'],
				store: "ecampus.join_party.study_mission@list".
					jn("study_mission_appoint_ORG.study_mission_release_id").
					eq('study_mission_appoint_ORG.study_mission_release_id', 'study_mission.study_mission_id'),
				row: function(o, i, data) {
					return [
						o.org_id,
						[
							{ text: "下载证明材料", url: "ecampus.join_party.point_table@download&id=" + o.point_table_id + "&file=point_attachmebt" },
							{ text: "删除", url: "ecampus.join_party.point_table@delete&id=" + o.point_table_id }
						]
					];

				}
			}
		]);
	};
		
	


