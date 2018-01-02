
render(function () {
    var cfg = [];
    cfg.push(
        group([
 showInput('用户ID', 'BBS_Users-UserID', '', '4'),
showInput('用户说明', 'BBS_Users-UserPoint', '', '4'),
showTime('注册时间', 'BBS_Users-RegisterDate', '', '4'),
showTime('最后登陆时间', 'BBS_Users-LastLogin', '', '4'),
showTime('最近活动时间', 'BBS_Users-RecentActivite', '', '4'),
select('用户等级', 'BBS_Users-UserGradeID', 'SCSXXT_DEV.BBS_C_UserGrade@items&UserGradeID=UserGradeID'),
hide('BBS_Users-UserStateID', q.UserStateID),
hide('BBS_Users-HeadImg', q.HeadImg ),
hide('BBS_Users-userSex', q.userSex),
hide('BBS_Users-userQQ', q.userQQ),
hide( 'BBS_Users-userBirthday',q.userBirthday),
hide('BBS_Users-userTel', q.userTel),
hide('BBS_Users-userAddress', q.userAddress),
hide('BBS_Users-userExperience', q.userExperience)
        ], '管理等级'));
    return cfg;
}, 'SCSXXT_DEV.BBS_Users@update&id=' + q.id, 'SCSXXT_DEV.BBS_Users@find&id=' + q.id, '编辑');