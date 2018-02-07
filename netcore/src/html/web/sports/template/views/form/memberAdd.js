render([
    group([
input('用户id', 'user_info-user_id', '', '4', {min:1,max:50}),
input('姓名', 'user_info-nickname', '', '4', {min:1,max:50}),
input('手机号', 'user_info-phone', '', '4', {mobile:true}),
input('性别', 'user_info-sex', '', '4', {min:1,max:50}),
input('年龄', 'user_info-age', '', '4', {min:1,max:50}),
input('职业', 'user_info-occupation', '', '4', {min:1,max:50}),
input('身高', 'user_info-height', '', '4', {float:true}),
input('体重', 'user_info-weight', '', '4', {float:true}),
input('个性签名', 'user_info-per_signature', '', '4', {min:1,max:50}),
input('证件号', 'user_info-certificate_no', '', '4', {idno:true}),
input('审核状态', 'user_info-state', '', '4', {int:true}),
input('证件类型', 'user_info-certificate_type_id', '', '4', {int:true}),
time('认证提交时间', 'user_info-certificate_commit_time', '', '4', '请选择认证提交时间'),
time('认证通过时间', 'user_info-certificate_pass_time', '', '4', '请选择认证通过时间'),
time('认证过期时间', 'user_info-certificate_expire_time', '', '4', '请选择认证过期时间'),
file('证件正面', 'user_info-certificate_photo_front'),
file('证件反面', 'user_info-certificate_type_behind')
],'标题')],'wx.sports.user_info@add','','添加');