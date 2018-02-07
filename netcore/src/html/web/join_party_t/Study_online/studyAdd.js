//添不进去
render([
	group([
select('学习资料名称', 'study_material-study_material_Name', 'ecampus.join_party.study_material@items&name=study_material_Name', '', '4'),
select("类型名称","study_material_type-type_name", 'ecampus.join_party.study_material_type@items&name=type_name','',4,0),
showInput('描述', 'study_material-study_material-describe', '',4),
hide('study_material_type-study_material_type_id'),
hide('study_material-study_material_id','#id'),
hide('study_material_type-describe'),
hide('study_material-study_material_file')
],'标题')],'ecampus.join_party.study_material@add','ecampus.join_party.study_material@Detail&id='+study_material_id,'添加');
function formReady() {
	$.bindSelect('study_material-study_material_Name', 'study_material_type-type_name', 'ecampus.join_party.study_material_type@items&name=type_name', true);
	//联动下拉框写接口
}


