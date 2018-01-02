render([
    group([
input('按钮ID', 'button-button_id',$.random()),
input('菜单ID', 'button-menu_id', '', '4', {min:1,max:100}),
input('按钮名称', 'button-name', '', '4'),
input('备注', 'button-note', '', '4'),
input('按钮值', 'button-value', '0', '4', {min:1,max:40})
],'标题')],'qx.permmision.v2.button@add','','添加');