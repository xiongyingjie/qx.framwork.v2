render([
    group([
hide('BBS_Theme-ThemeID', '#id'),
select('版块名字', 'BBS_Theme-ColumnID', 'SCSXXT_DEV.BBS_Columns@items&ColumnName=ColumnName'),
input('主题名字', 'BBS_Theme-ThemeName', '', '4', {min:1,max:20}),
area('主题说明', 'BBS_Theme-ThemeExplain', '', '2', {min:1,max:50})
],'主题添加')],'SCSXXT_DEV.BBS_Theme@add','','添加');