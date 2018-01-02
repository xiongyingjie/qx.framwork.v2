var random1 = $.random();
var random2 = $.random();

render([
    group([
hide('association-association_id', random1),
input('社团名', 'association-name', '', '4', { min: 1, max: 50 }),
file('相关文件', 'association-related_file'),
hide('association-status', '1'),
hide('association-uid'),
area('描述', 'association-describe'),
hide('association_apply-association_apply_id', random2),
hide('association_apply-association_id', random1),
hide('association_apply-status', '1'),
hide('association_apply-uid', '#uid'),
hideTime('association_apply-apply_time', '#now'),
button("提交申请", '1:5', Color.green, function () {
    submitForm("ecampus.twxt2.association@add|association_apply@add");
}),
button("保存草稿", '6:0', Color.orange, function () {
    $("#association-status").val('2');
    $("#association_apply-status").val('2');
    submitForm("ecampus.twxt2.association@add|association_apply@add");
})

    ], '申请社团')], '', '', '申请');