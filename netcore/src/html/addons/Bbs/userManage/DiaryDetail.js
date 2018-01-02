render([
    group([
showInput('日志ID', 'BBS_Diary-DiaryID', '', '4'),
showInput('用户ID', 'BBS_Diary-UserID', '', '4'),
showInput('状态', 'BBS_C_DiaryState-StateName', '', '4'),
showTime('发布时间', 'BBS_Diary-Time', '', '4'),
showInput('标题', 'BBS_Diary-DiaryTitle', '', '4'),
showEditor('内容', 'BBS_Diary-Contents'),
//showInput('状态', 'BBS_Diary-StateID', '', '4'),
    ], '帖子详情')], '', 'SCSXXT_DEV.BBS_Diary@list'
       .jn('BBS_C_DiaryState.StateID', 'StateID')
.eq('BBS_Diary.DiaryID', q.id), '', '详情');