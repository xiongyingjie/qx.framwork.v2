render(function () {
    var cfg = [];
    cfg.push(
        group([
            hide('role_menu-role_menu_id', '#id'),
            showinput('菜单ID', 'role_menu-menu_id', q.menu_id, '4', { min: 1, max: 60 }),
            showinput('角色ID', 'role_menu-role_id', q.role_id, '4', { min: 1, max: 60 }),
            select('是否包含子菜单', 'role_menu-include_children', [{ text: "是", value: "1" }, { text: "否", value: "0" }], '1'),
    time('失效日期', 'role_menu-expire_time', '', '4', { min: 1, max: 100 }),
    input('备注', 'role_menu-note', '', '1')
        ], '分配菜单设置'));
    return cfg;
}, 'qx.permmision.v2.role_menu@add', '', '选择分配菜单');