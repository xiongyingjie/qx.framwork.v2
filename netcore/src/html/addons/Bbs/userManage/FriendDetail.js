render([
    group([
showInput('朋友ID', 'BBS_Friend-FriendID', '', '4'),
showInput('我', 'BBS_Friend-UserIDA', '', '4'),
showInput('我的好友', 'BBS_Friend-UserIDB', '', '4'),
showInput('状态ID', 'BBS_Friend-StatusID', '', '4'),
showTime('时间', 'BBS_Friend-Time', '', '4')
],'好友详情')],'','SCSXXT_DEV.BBS_Friend@find&id='+q.id,'','详情');