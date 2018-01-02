render([
    group([
input('ID', 'role_button_forbid-role_Button_forbid_id', $.random()),
showInput('角色ID', 'role_button_forbid-role_id', q.role_id),
showInput('按钮ID', 'role_button_forbid-button_id', q.button_id, '4'),
time('失效日期', 'role_button_forbid-expire_time', ''),
input('备注', 'role_button_forbid-note', '0')
    ], '标题')], 'qx.permmision.v2.role_button_forbid@add', '', '添加');