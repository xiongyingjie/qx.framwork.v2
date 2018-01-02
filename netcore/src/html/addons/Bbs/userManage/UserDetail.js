render([
    group([
        showInput('用户ID', 'BBS_Users-UserID', '', '4'),
        showInput('用户昵称', 'BBS_Users-UserPoint', '', '4'),
        showInput('用户等级', 'BBS_C_UserGrade-UserGradeName', '', '4'),
        showInput('用户状态', 'BBS_C_UserState-StateName', '', '4'),
        showInput('头像', 'BBS_Users-HeadImg', '', '4'),
showInput('用户性别', 'BBS_Users-userSex', '', '4'),
showInput('用户ｑｑ', 'BBS_Users-userQQ', '', '4'),
showInput('用户生日', 'BBS_Users-userBirthday', '', '4'),
showInput('用户电话', 'BBS_Users-userTel', '', '4'),
showInput('用户地址', 'BBS_Users-userAddress', '', '4'),
showArea('用户经历', 'BBS_Users-userExperience', '', '4'),
        hide( 'BBS_C_UserGrade-UserGradeID', ''),
        hide( 'BBS_C_UserState-UserStateID', ''),
        hide( 'BBS_Users-UserGradeID', ''),
        hide( 'BBS_Users-UserStateID', ''),
showTime('注册时间', 'BBS_Users-RegisterDate', '', '4'),
showTime('最后登陆时间', 'BBS_Users-LastLogin', '', '4'),
showTime('最近活动时间', 'BBS_Users-RecentActivite', '', '4')

    ], '用户详情')], '', 'SCSXXT_DEV.BBS_Users@list'
       .jn('BBS_C_UserState.UserStateID', 'UserStateID')
       .jn('BBS_C_UserGrade.UserGradeID', 'UserGradeID')
.eq('BBS_Users.UserID', q.id), '', '详情');