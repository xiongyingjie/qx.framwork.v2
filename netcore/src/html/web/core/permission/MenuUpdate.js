render(function(){
var cfg=[];
cfg.push(
    group([
hide('menu-note', ''),
hide('menu-controller'),
hide('menu-action'),
hide('menu-area'),
showinput('父亲ID', 'menu-farther_id', '', '4'),
input('菜单ID', 'menu-menu_id', '', '4', { min: 1, max: 100 }),
input('菜单名称', 'menu-name', '', '4', { min: 1, max: 100 }),
input('URL地址', 'menu-url', '', '4', { min: 1, max: 199 }),
input('级数', 'menu-depth', '', '4', { int: true }),
input('顺序', 'menu-sequence', '', '4', { int: true }),
input('所属子系统', 'menu-sub_system', '-', '4', { min: 1, max: 50 }),
select('状态', 'menu-status', [{ text: "可用", value: "1" }, { text: "不可用", value: "0" }]),
input('图标', 'menu-image_class', '', '4'),
input('激活图标', 'menu-active_li', '', '4')
],'标题'));
return cfg;
},'qx.permmision.v2.menu@update&id='+q.id,'qx.permmision.v2.menu@find&id='+q.id,'编辑');