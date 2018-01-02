render([
    group([
showInput('回复ID', 'BBS_ReplyPost-ReplyPostID', '', '4'),
showInput('帖子Id', 'BBS_ReplyPost-PostID', '', '4'),
showInput('发帖者Id', 'BBS_ReplyPost-UserID', '', '4'),
showInput('父级回复Id', 'BBS_ReplyPost-ParentReplyID', '', '4'),
showTime('回复时间', 'BBS_ReplyPost-Time', '', '4'),
showInput('回复内容', 'BBS_ReplyPost-Contents', '', '4'),
showEditor('回复文件', 'BBS_ReplyPost-Files')
],'回复详情')],'','SCSXXT_DEV.BBS_ReplyPost@find&id='+q.id,'','详情');