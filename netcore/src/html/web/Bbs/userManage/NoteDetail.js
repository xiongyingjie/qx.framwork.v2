render([
    group([
showInput('用户ID', 'BBS_Note-UserID', '', '4'),
showInput('消息ID', 'BBS_Note-NoteID', '', '4'),
showInput('回复用户ID', 'BBS_Note-ReceiverUserID', '', '4'),
showTime('消息时间', 'BBS_Note-NoteTime', '', '4'),
showArea('消息内容', 'BBS_Note-NoteContent', '', '2'),
],'消息详情')],'','SCSXXT_DEV.BBS_Note@find&id='+q.id,'','详情');