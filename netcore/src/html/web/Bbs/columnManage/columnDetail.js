render([
    group([
showInput('版块ID', 'BBS_Columns-ColumnID', '', '4'),
showInput('版块', 'BBS_Columns-ColumnName', '', '4'),
showInput('专栏', 'BBS_Forum-ColumnName', '', '4'),
showInput('父级版块ID', 'BBS_Columns-FatherColumnID', '', '4'),
showInput('版块照片', 'BBS_Columns-ColumnImg', '', '4'),
showArea('专栏解释', 'BBS_Columns-ColumnExplain', '', '2')
    ], '版块详情')], '', 'SCSXXT_DEV.BBS_Columns@list'
       .jn('BBS_Forum.ForumID', 'ForumID')
.eq('BBS_Columns.ColumnID', q.id), '', '详情');