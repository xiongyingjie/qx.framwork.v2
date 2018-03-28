render(function(){
var cfg=[];
cfg.push(
    group([
input('按钮ID', 'button-button_id', '', '4', {min:1,max:60}),
input('菜单ID', 'button-menu_id', '', '4', {min:1,max:100}),
input('按钮名称', 'button-name', '', '4', {min:1,max:40}),
input('备注', 'button-note', '', '4', {min:1,max:100}),
input('按钮值', 'button-value', '', '4', {min:1,max:40})
],'标题'));
return cfg;
},'sys.core.button@update&id='+q.id,'sys.core.button@find&id='+q.id,'编辑');