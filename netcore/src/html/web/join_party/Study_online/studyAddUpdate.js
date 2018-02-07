render(function(){
var cfg=[];
cfg.push(
    group([
input('学习资料名称', 'study_material-study_material_Name', '', '4', {min:1,max:20}),
input('类型名称', 'study_material_type-type_name', '', '4', {min:1,max:50}),
input('描述', 'study_material_type-describe', '', '4', {min:1,max:50}),
hide('study_material_type-study_material_type_id'),
hide('study_material-study_material_id'),
hide('study_material-describe'),
hide('study_material-study_material_file')
],'标题'));
return cfg;
},'ecampus.join_party.study_material@update|study_material_type@update&id='+q.id,'ecampus.join_party.study_material@find|study_material_type@find&id='+q.id,'编辑');