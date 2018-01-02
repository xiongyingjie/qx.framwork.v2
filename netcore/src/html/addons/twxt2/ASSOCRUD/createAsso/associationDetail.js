render([
    group([
showInput('社团id', 'association-association_id', '', '4'),
showInput('社团申请id', 'association-association_apply_id', '', '4'),
showInput('社团名', 'association-name', '', '4'),
showInput('创建人', 'association-creator', '', '4'),
showTime('创建时间', 'association-createTime', '', '4'),
showInput('审核状态', 'association-status', '', '4'),
showInput('相关文件', 'association-related_file', '', '4'),
showArea('描述', 'association-describe')
],'标题')],'','ecampus.twxt2.association@find&id='+q.id,'','详情');