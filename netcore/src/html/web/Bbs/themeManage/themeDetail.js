render([
    group([
hide( 'BBS_Theme-ThemeID', ''),
showInput('主题名字', 'BBS_Theme-ThemeName', '', '4'),
showInput('版块ID', 'BBS_Theme-ColumnID', '', '4'),
showArea('主题说明', 'BBS_Theme-ThemeExplain', '', '2')
],'主题详情')],'','SCSXXT_DEV.BBS_Theme@find&id='+q.id,'','详情');