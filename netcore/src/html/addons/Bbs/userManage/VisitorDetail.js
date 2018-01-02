render([
    group([
showInput('访问ID', 'BBS_Visitor-VisitorID', '', '4'),
showInput('访问者ID', 'BBS_Visitor-UserIDA', '', '4'),
showInput('被访问者ID', 'BBS_Visitor-UserID', '', '4'),
showTime('访问时间', 'BBS_Visitor-Time', '', '4'),

],'访客详情')],'','SCSXXT_DEV.BBS_Visitor@find&id='+q.id,'','详情');