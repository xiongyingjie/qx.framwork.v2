render([
    group([
hide( 'BBS_Columns-ColumnID', '#id'),
input('版块名字', 'BBS_Columns-ColumnName', '', '4', {min:1,max:20}),
//select('父级版块', 'BBS_Columns-FatherColumnID', 'SCSXXT_DEV.BBS_Columns@items&ColumnName=ColumnName'),
select('专栏名称', 'BBS_Columns-ForumID', 'SCSXXT_DEV.BBS_Forum@items&ForumID=ForumID'),
//input('专栏ID', 'BBS_Columns-ForumID', '', '4', {min:1,max:50}),
input('版块照片', 'BBS_Columns-ColumnImg', '', '4', {min:1,max:50}),
area('专栏解释', 'BBS_Columns-ColumnExplain', '', '4', {min:1,max:200})
],'添加版块')],'SCSXXT_DEV.BBS_Columns@add','','添加');