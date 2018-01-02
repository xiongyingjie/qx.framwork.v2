render([
    group([
input('类型id', 'activity_type-activity_type_id', '', '4', {min:1,max:50}),
input('父类型', 'activity_type-father_type_id', '', '4', {min:1,max:50}),
input('类型名称', 'activity_type-name', '', '4', {min:1,max:50}),
input('类型排序', 'activity_type-seq', '', '4', {int:true}),
input('首页显示', 'activity_type-show_in_homepage', '', '4', {int:true}),
input('显示在顶部菜单', 'activity_type-show_in_menu', '', '4', {int:true}),
input('是否发布', 'activity_type-is_release', '', '4', {int:true}),
area('类型描述', 'activity_type-note'),
file('类型图标', 'activity_type-img')
],'标题')],'wx.sports.activity_type@add','','添加');