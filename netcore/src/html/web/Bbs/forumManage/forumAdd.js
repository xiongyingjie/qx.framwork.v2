render([
    group([
hide('BBS_Forum-ForumID', '#id'),
input('专栏名字', 'BBS_Forum-ForumName', '', '4', { min: 1, max: 20 }),
area('专栏说明', 'BBS_Forum-ForumExplain')
],'添加专栏')],'SCSXXT_DEV.BBS_Forum@add','','添加');