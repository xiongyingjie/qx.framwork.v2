render([
    group([
input('学习资料名称', 'study_material-study_material_Name', '', '4', {min:1,max:20}),
select('类型名称', 'study_material-type', 'ecampus.join_party.study_material_type@items&name=type_name', '请选择类型', '4'),

editor('描述', 'study_material-describe', '请输入相关描述', 1,350),
file('资料', 'study_material-study_material_file'),

hide('study_material-study_material_id','#id'),

],'资料定义界面')],'ecampus.join_party.study_material@add','','定义资料');

