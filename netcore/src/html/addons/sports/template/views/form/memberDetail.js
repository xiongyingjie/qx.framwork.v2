render([
     group([
hide('user_info-user_id', ''),
showInput('姓名', 'user_info-nickname', '', '4', { min: 1, max: 50 }),
showInput('手机号', 'user_info-phone', '', '4', { mobile: true }),
showInput('证件号', 'user_info-certificate_no', '', '4', { idno: true }),
showInput('性别', 'user_info-sex', '', '4', { min: 1, max: 50 }),
showInput('年龄', 'user_info-age', '', '4', { min: 1, max: 50 }),
showInput('职业', 'user_info-occupation', '', '4', { min: 1, max: 50 }),
showInput('身高', 'user_info-height', '', '4', { float: true }),
showInput('体重', 'user_info-weight', '', '4', { float: true }),
showInput('个性签名', 'user_info-per_signature', '', '4', { min: 1, max: 50 }),

hide('user_info-state', ''),
hide('user_info-certificate_type_id', ''),
hideTime('user_info-certificate_commit_time', ''),
hideTime('user_info-certificate_pass_time', ''),
hideTime('user_info-certificate_expire_time', ''),
hide('user_info-certificate_photo_front', ''),
hide('user_info-certificate_type_behind', '')
     ], '会员信息')], '', 'wx.sports.user_info@find&id=' + q.id, '', '详情');