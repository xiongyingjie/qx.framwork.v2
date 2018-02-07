render([
    group([
showInput('贴子编号', 'BBS_Post-PostID', '', '4'),
showInput('标题', 'BBS_Post-PostTitle', '', '4'),
showInput('主题', 'BBS_Theme-ThemeName', '', '4'),
showInput('状态', 'BBS_C_PostState-StateName', '', '4'),
showInput('类型', 'BBS_C_PostTypet-PostTypeName', '', '4'),
showInput('发帖者Id', 'BBS_Post-UserID', '', '4'),
showInput('是否置顶', 'BBS_Post-IsTop', '', '4'),
showInput('是否精品', 'BBS_Post-IsCream', '', '4'),
showTime('发贴时间', 'BBS_Post-PostTime', '', '4'),
showInput('点击次数', 'BBS_Post-PClickCount', '', '4'),
showInput('回复编号', 'BBS_Post-BestReplyID', '', '4'),
showInput('帖子文件', 'BBS_Post-Files'),
showEditor('贴子内容', 'BBS_Post-PostContent'),
//showFile('帖子文件', 'BBS_Post-Files'),
    ], '帖子详情')], '', 'SCSXXT_DEV.BBS_Post@list'
       .jn('BBS_Theme.ThemeID', 'ThemeID')
       .jn('BBS_C_PostState.StateID', 'StateID')
        .jn('BBS_C_PostType.PostTypeID', 'PostTypeID')
.eq('BBS_Post.PostID', q.id), '', '详情');