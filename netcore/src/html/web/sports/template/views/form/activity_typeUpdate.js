render(function(){
var cfg=[];
cfg.push(
    group([
hide('activity_type-activity_type_id'),
hide('activity_type-father_type_id'),
input('类型名称', 'activity_type-name', '', '4', {min:1,max:50}),
hide('activity_type-seq'),
hide('activity_type-show_in_homepage'),
hide('activity_type-show_in_menu'),
hide('activity_type-is_release'),
area('类型描述', 'activity_type-note'),
hide('activity_type-img')
],'标题'));
return cfg;
},'wx.sports.activity_type@update&id='+q.id,'wx.sports.activity_type@find&id='+q.id,'编辑');