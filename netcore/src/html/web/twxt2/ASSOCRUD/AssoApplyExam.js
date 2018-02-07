render(function(){
var cfg=[];
cfg.push(
    group([
showInput('申请人', 'permission_user-nick_name', '', '4', { min: 1, max: 50 }),
hide( 'association_apply-uid', ''),
showTime('申请时间', 'association_apply-apply_time', '', '4'),
showInput('社团名', 'association-name', '', '4', {min:1,max:50}),
file('相关文件', 'association-related_file','1',false),
showArea('描述','association-describe'),
area('审核意见', 'association_apply-audit_suggestion'),
hide( 'association-association_id'),
hide('association_apply-association_apply_id'),
hide('association-uid', ''),
hideTime('association-createTime', '#now'),
hide('association-status', ''),
hide('association_apply-association_id'),
hide('association_apply-status', ''),
hide('association_apply-auditor', '#uid'),
hideTime('association_apply-audit_time', '#now'),
button("通过", '1:4', Color.green, function () {
    $("#association-status").val(-1);
    $("#association_apply-status").val(-1);
    var association_id = $("#association-association_id").val();
    var name = $("#association-name").val();
    //$.alert(    $("#association-status").val())
   // submitForm("/twxt2/AssoCRUD/AddtoOrg?association_id=" + association_id + "&name=" + name,function(data,code) {
        
        submitForm("ecampus.twxt2.association@update-" + q.id2 + "|association_apply@update-" + q.id1);
    //});
    
}),
button("不通过", '1:0', Color.green, function () {
    $("#association-status").val(1);
    $("#association_apply-status").val(-2);
    //$.alert(    $("#association-status").val())
    submitForm("ecampus.twxt2.association@update-" + q.id2 + "|association_apply@update-" + q.id1);
}),
button("驳回重填", '1:0', Color.green, function () {
    $("#association-status").val(2);
    $("#association_apply-status").val(-3);
    //$.alert(    $("#association-status").val())
    submitForm("ecampus.twxt2.association@update-" + q.id2 + "|association_apply@update-" + q.id1);
})
],'社团申请审核'));
return cfg;
}, '', 'ecampus.twxt2.association@list&search.join:association_apply.association_id=association_id&search.join:permission_user.user_id=association_apply.uid&search.equal:association_id=' + q.id2, '审核');


function formReady() {
    $(".fileinput-button").hide();
}