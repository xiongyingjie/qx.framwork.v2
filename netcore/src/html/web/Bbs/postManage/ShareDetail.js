render([
    group([
showInput('分享Id', 'BBS_Share-ShareID', '', '4'),
showInput('用户ID', 'BBS_Share-UserID', '', '4'),
showInput('帖子ID', 'BBS_Share-PostID', '', '4'),
showInput('分享状态', 'BBS_C_Share-StatusName', '', '4'),
showTime('分享时间', 'BBS_Share-Time', '', '4')
    ], '分享详情')], '', 'SCSXXT_DEV.BBS_Share@list'
       .jn('BBS_C_Share.StatusID', 'StatusID')
.eq('BBS_Share.ShareID', q.id), '', '详情');