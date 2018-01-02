render([
    group([
hide( 'association-association_id', ''),
showInput('社团名', 'association-name', '', '4'),
showInput('社团创建人', 'permission_user-nick_name', '', '3'),
hide('association-uid', ''),
showTime('创建时间', 'association-createTime', '', '4'),
select('状态', 'association-status', [{ text: "开放", value: "100" }, { text: "关闭", value: "200" }], '', 4),
file('相关文件', 'association-related_file'),
area('描述', 'association-describe'),
button("保存", '1:5', Color.green, function () {
    var data = $('#association-association_id')
    submitForm("ecampus.twxt2.association@update-"+data);
})
    ], '社团信息管理')], '', 'ecampus.twxt2.association@list'
.jn('permission_user.user_id', 'uid')
.eq('association_id', '752d465b-dc3a-e4f9-a7fd-87ef67ec19f1')
    , '', '社团信息');