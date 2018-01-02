render([
    group([
showInput('菜单ID', 'menu-menu_id', '', '4'),
showInput('菜单名称', 'menu-name', '', '4'),
showInput('父亲ID', 'menu-farther_id', '', '4'),
showInput('备注', 'menu-note', '', '4'),
showInput('URL地址', 'menu-url', '', '4'),
showInput('深度', 'menu-depth', '', '4'),
showInput('顺序', 'menu-sequence', '', '4'),
showInput('所属子系统', 'menu-sub_system', '', '4'),
showInput('状态', 'menu-status', '', '4'),
showInput('控制器', 'menu-controller', '', '4'),
showInput('动作', 'menu-action', '', '4'),
showInput('区域', 'menu-area', '', '4'),
showInput('图标', 'menu-image_class', '', '4'),
showInput('激活图标', 'menu-active_li', '', '4')
],'标题')],'','qx.permmision.v2.menu@find&id='+q.id,'','详情');