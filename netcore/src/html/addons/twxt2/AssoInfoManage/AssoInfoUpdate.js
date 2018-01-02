render(function(){
var cfg=[];
cfg.push(
    group([
input('社团名', 'association-name', '', '3', { min: 1, max: 50 }),
time('创建时间', 'association-createTime', '', '3', '请选择创建时间'),
input('用户名', 'permission_user-nick_name', '', '3', { min: 1, max: 100 }),
area('描述', 'association-describe'),
file('相关文件', 'association-related_file'),
hide('association-association_id', '', '4', {min:1,max:50}),
//time('创建时间', 'association-createTime', '', '4', '请选择创建时间'),
//input('用户名', 'permission_user-nick_name', '', '4', {min:1,max:100}),
hide('association-uid', '',{min:1,max:50}),
hide( 'association-status', '',{int:true}),
hide('permission_user-user_id'),
hide('permission_user-user_pwd', '', {min:1,max:100}),
hide('permission_user-email'),
hide( 'permission_user-phone'),
hide( 'permission_user-user_type_id', '',  {min:1,max:50}),
hide('permission_user-note'),
hideTime('permission_user-register_date', '','请选择注册时间'),
hideTime('permission_user-last_login_date', '','请选择最近登入时间')
],'标题'));
return cfg;
}, function () {
   // $.log(q.id);
    $.log('ecampus.twxt2.association@update-' + q.id + '|permission_user@update-' + $('#permission_user-user_id').val());
    return 'ecampus.twxt2.association@update-' + q.id + '|permission_user@update-' + $('#permission_user-user_id').val();
},
'ecampus.twxt2.association@list'
.jn('permission_user.user_id', 'uid')
.eq('association_id', q.id), '编辑');

