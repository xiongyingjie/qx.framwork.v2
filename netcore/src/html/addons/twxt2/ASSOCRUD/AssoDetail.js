render([
    group([
hide('association-association_id', ''),
showInput('社团名', 'association-name', '', '4'),
showInput('状态', 'asso_status-status_name', '', '4'),
showInput('创建人', 'association-uid', '', '4'),
//showTime('创建时间', 'association-createTime', '', '4'),
showArea('描述', 'association-describe')
//showFile('相关文件', 'association-related_file')
    ], '社团基本信息')], '', 'ecampus.twxt2.association@list'
    .jn('asso_status.status_id', 'status')
    .eq('association_id',q.id), '', '详情');