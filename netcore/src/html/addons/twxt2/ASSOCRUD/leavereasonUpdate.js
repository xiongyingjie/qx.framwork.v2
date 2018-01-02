render(function(){
var cfg=[];
cfg.push(
    group([
hide('association_member-asso_member_id', ''),
hide('association_member-association_id', ''),
hide('association_member-student_id', ''),
hide('association_member-department_id', ''),
hideTime('association_member-enroll_time', ''),
hide('association_member-auditor', ''),
hide('association_member-status', ''),
hide('association_member-merit', ''),
hide('association_member-prefer', ''),
hide('association_member-phone', ''),
hide('association_member-email', ''),
hide('association_member-relatedfile'),
hide('association_member-sex', ''),
hideTime('association_member-apply_time', ''),
area('退团理由', 'association_member-leave_reason'),
button("提交申请", '1:5', Color.green, function () {
    $("#association_member-status").val(3);
    submitForm("ecampus.twxt2.association_member@update&id="+q.id);
})
],'退出社团'));
return cfg;
},'','ecampus.twxt2.association_member@find&id='+q.id,'编辑');