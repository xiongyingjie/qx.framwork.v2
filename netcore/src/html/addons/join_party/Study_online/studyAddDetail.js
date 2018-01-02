render([
    group([
showInput('学习资料名称', 'study_material-study_material_Name', '', '4'),
showInput('类型名称', 'study_material_type-type_name', '', '4'),
showInput('描述', 'study_material_type-describe', '', '4'),
showInput('学习资料类型编号', 'study_material_type-study_material_type_id', '', '4'),
showInput('学习资料编号', 'study_material-study_material_id', '', '4'),
showEditor('描述', 'study_material-describe'),
showFile('#', 'study_material-study_material_file')
],'标题')],'','ecampus.join_party.study_material@find|study_material_type@find&id='+q.id,'','详情');