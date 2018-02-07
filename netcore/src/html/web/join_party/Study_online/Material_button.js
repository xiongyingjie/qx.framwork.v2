render(function(){
var cfg=[];
cfg.push(
    group([
hide('study_mission-study_mission_id'),
showInput('任务名称', 'study_mission-study_mission_name', '', '4'),
hide( 'study_mission-begin_time'),
hide( 'study_mission-end_time'),
hide('study_mission-study_material_id', ''),
hide( 'study_mission-study_object'),

radio('任务开关', 'study_mission-is_enable',  [{ text: '关闭', value: '0' }, { text: '开启', value: '1' },] ,4),

],'标题'));
return cfg;
},'ecampus.join_party.study_mission@update&id='+q.id,'ecampus.join_party.study_mission@find&id='+q.id,'编辑');


 