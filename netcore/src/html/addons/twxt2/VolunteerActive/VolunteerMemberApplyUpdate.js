render(function(){
var cfg=[];
cfg.push(
    group([
input('志愿服务成员申请id', 'volunteer_member_apply-member_apply_id', '', '4', {min:1,max:50}),
input('学生id', 'volunteer_member_apply-uid', '', '4', {min:1,max:100}),
input('活动id', 'volunteer_member_apply-activity_id', '', '4', {min:1,max:50}),
input('性别', 'volunteer_member_apply-sex', '', '4', {min:1,max:50}),
input('活动能力应答', 'volunteer_member_apply-skill_express', '', '4', {min:1,max:200}),
file('申请文件', 'volunteer_member_apply-apply_file'),
input('申请状态', 'volunteer_member_apply-apply_status', '', '4', {int:true}),
input('手机号码', 'volunteer_member_apply-phone', '', '4', {mobile:true}),
input('姓名', 'volunteer_member_apply-name', '', '4', {min:1,max:50})
],'标题'));
return cfg;
},'ecampus.twxt2.volunteer_member_apply@update&id='+q.id,'ecampus.twxt2.volunteer_member_apply@find&id='+q.id,'编辑');