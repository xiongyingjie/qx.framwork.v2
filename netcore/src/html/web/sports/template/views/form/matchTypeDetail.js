render([
    group([
showInput('类型id', 'activity_type-activity_type_id', '', '4'),
showInput('父类型', 'activity_type-father_type_id', '', '4'),
showInput('类型名称', 'activity_type-name', '', '4'),
showInput('类型排序', 'activity_type-seq', '', '4'),
showInput('首页显示', 'activity_type-show_in_homepage', '', '4'),
showInput('显示在顶部菜单', 'activity_type-show_in_menu', '', '4'),
showInput('是否发布', 'activity_type-is_release', '', '4'),
showArea('类型描述', 'activity_type-note'),
showFile('类型图标', 'activity_type-img')
],'标题')],'','wx.sports.activity_type@find&id='+q.id,'','详情');