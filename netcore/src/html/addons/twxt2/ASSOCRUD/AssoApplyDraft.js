
render([
    group([
hide('association-association_id', ''),
input('社团名', 'association-name', '', '4', { min: 1, max: 50 }),
file('相关文件', 'association-related_file'),
hide('association-uid', ''),
hideTime('association-createTime', ''),
hide('association-status', ''),
area('描述', 'association-describe'),
hide('association_apply-association_apply_id', ''),
hide('association_apply-association_id', ''),
hide('association_apply-status', ''),
hide('association_apply-auditor', ''),
hide('association_apply-audit_suggestion', ''),
hide('association_apply-uid', '#uid'),
hideTime('association_apply-audit_time'),
hideTime('association_apply-apply_time', '#now'),
button("提交申请", '1:5', Color.green, function () {
    $("#association-status").val(1);
    $("#association_apply-status").val(1);
    //$.alert(    $("#association-status").val())
    submitForm("ecampus.twxt2.association@update-" + q.id2+"|association_apply@update-" + q.id1 );
}),
button("保存草稿", '6:0', Color.orange, function () {
    $("#association-status").val(2);
    $("#association_apply-status").val(2);
    submitForm("ecampus.twxt2.association@update-" + q.id2 + "|association_apply@update-" + q.id1);
})

    ], '标题')], '', 'ecampus.twxt2.association@list&search.join:association_apply.association_id=association_id&search.equal:association_id=' + q.id2, '添加');