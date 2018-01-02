render(function(){
var cfg=[];
cfg.push(
    group([
input('学习资料名称', 'study_material-study_material_Name', '', '4', {min:1,max:20}),


select("类型名称","study_material-type","ecampus.join_party.study_material_type@items&name=type_name","",4),

editor('描述', 'study_material-describe', '', 1,250),


showFile('资料', 'study_material-study_material_file'),
hide('study_material_type-study_material_type_id'),
hide('study_material-study_material_id'),   
hide("study_material_type-type_name"),
hide('study_material_type-describe')
],'资料编辑界面'));
return cfg;
},'ecampus.join_party.study_material@update&id='+q.id,
'ecampus.join_party.study_material@find|study_material_type@find&id='+q.id,'编辑');