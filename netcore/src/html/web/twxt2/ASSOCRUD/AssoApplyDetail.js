render([
    group([
hide( 'association-association_id', ''),
showInput('社团名', 'association-name', '', '4'),
hide('association_apply-association_apply_id', ''),
showInput('申请状态', 'asso_apply_status-status_name', '', '4'),
showInput('申请人', 'permission_user-nick_name', '', '4'),
//showInput('审核人', 'association_apply-auditor', '', '4'),
showInput('审核意见', 'association_apply-audit_suggestion', '', '4'),
showTime('审核时间', 'association_apply-audit_time', '', '4'),
showTime('申请时间', 'association_apply-apply_time', '', '4'),
showFile('相关文件', 'association-related_file'),
showArea('描述', 'association-describe')
    ], '社团申请详情')], '', 'ecampus.twxt2.association@list'
    .jn('association_apply.association_id', 'association_id')
    .jn('asso_apply_status.status_id', 'association_apply.status')
    .jn('permission_user.user_id', 'association_apply.uid')
    .eq('association_id', q.id2), '', '详情');

