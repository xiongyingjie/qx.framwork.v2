render([
    group([
showInput('用户ID', 'BBS_DiaryReply-UserID', '', '4'),
showInput('日志Id', 'BBS_DiaryReply-DiaryID', '', '4'),
showInput('回复id', 'BBS_DiaryReply-DiaryReplyID', '', '4'),
showTime('回复时间', 'BBS_DiaryReply-Time', '', '4'),
showEditor('内容', 'BBS_DiaryReply-Contents')
],'日志回复详情')],'','SCSXXT_DEV.BBS_DiaryReply@find&id='+q.id,'','详情');