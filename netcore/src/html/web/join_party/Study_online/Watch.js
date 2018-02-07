
	render(function(){
var cfg=[];
cfg.push(
    group([
	       showInput('学习资料名称', 'study_material-study_material_Name', '', '4'),

        showEditor('描述', 'study_material-describe'),

        showFile('资料文件', 'study_material-study_material_file','资料一.avi'),

        file('学习报告', 'study_mission_accepted-study_report'),

        hide('study_material_type-study_material_type_id', ''),

        hide('study_mission_accepted-study_mission_accept_id',$.Random),

        hide('学习任务发布编号', 'study_mission_accepted-study_mission_id', '', '4'),

        hide('study_mission_accepted-UserID', ''),

        hide('study_material-study_material_id', ''),

        hide('study_material-type', '#id1'),

        hide('study_mission-study_mission_id', ''),

        hide('study_mission-study_material_id', ''),

       button("提交", '6:0', Color.red, function () {
    $("#study_mission_accepted-study_mission_id").val('4');
    submitForm("ecampus.join_party.study_mission_accepted@add");
})


],'查看任务'));
return cfg;
},'ecampus.join_party.study_mission_accepted@update&id=' + q.id,'ecampus.join_party.study_material@find&id=' + q.id,'详情');