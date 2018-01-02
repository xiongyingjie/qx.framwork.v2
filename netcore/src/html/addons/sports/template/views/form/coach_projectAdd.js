render([
    group([
   select('项目类型', 'base_activity-activity_type_id', "/sports/Admin/GetProject_type", '请选择项目类型', '4'),
//input('类型id', 'base_activity-activity_type_id', '', '4', {min:1,max:50}),
input('项目标题', 'base_activity-name', '', '4', { min: 1, max: 50 }),
input('门市价', 'coacher_project-price', '', '4', { float: true }),
input('平台价', 'coacher_project-promot_price', '', '4', { float: true }),

hide('base_activity-is_enable',"1"),
hide('coacher_project-coacher_id','#uid'),
hide('base_activity-base_activity_id'),
hide('base_activity-province'),
hide('base_activity-city'),
hide('base_activity-area'),
hide('base_activity-address'),
hideTime('base_activity-begin_time'),
hide('base_activity-price'),
hideTime('base_activity-end_time'),
hideTime('base_activity-sign_begin_time'),
hideTime('base_activity-sign_end_time'),
hide('base_activity-group_number'),
hide('base_activity-host_unit'),
hide('base_activity-sign_mode'),
hide('base_activity-describe'),
hide('base_activity-join_limit'),
hide('base_activity-detail'),
hide('base_activity-photos'),
hide('coacher_project-coacher_project_id'),

hide('coacher_project-person_limit'),
hide('coacher_project-state')
    ], '私教项目')], 'wx.sports.base_activity@add|coacher_project@add', '', '添加');


function formReady() {
    var id = $.random();
    $.set("base_activity-base_activity_id", 201, id);
    $.set("coacher_project-coacher_project_id", 201, id);
}