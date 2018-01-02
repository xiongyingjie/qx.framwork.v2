//测试
render(function(){
var cfg=[];
cfg.push(
    group([
editor('描述', 'study_material_type-describe', '请输入相关描述', 1,350),

],'资料编辑界面'));
return cfg;
},'ecampus.join_party.study_material@update|study_material_type@update&id='+q.id,'ecampus.join_party.study_material@find|study_material_type@find&id='+q.id,'编辑');