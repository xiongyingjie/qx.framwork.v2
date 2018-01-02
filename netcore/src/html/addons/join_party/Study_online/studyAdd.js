render([
    group([
hide( 'study_mission-study_mission_id',$.random),
input('任务名称', 'study_mission-study_mission_name', '', '4'),
time('开始时间', 'study_mission-begin_time', '', '4', '请选择开始时间'),
time('结束时间', 'study_mission-end_time', '', '4', '请选择结束时间'),
hide('study_material-study_material_id'),
select('学习资料编号', 'study_mission-study_material_id', 'ecampus.join_party.study_material@items&name=study_material_id', '4'),
select('学习资料名称', 'study_material-study_material_name', 'ecampus.join_party.study_material@items&name=study_material_name', '4'),
select('学习对象', 'study_mission-study_object', 'ecampus.join_party.study_mission@items&name=study_object', '4'),
showRadio('任务开关', 'study_mission-is_enable',  [{ text: '开启', value: '0' }] ,4,0,0),
], '标题')], 'ecampus.join_party.study_mission@add', '', '添加');




