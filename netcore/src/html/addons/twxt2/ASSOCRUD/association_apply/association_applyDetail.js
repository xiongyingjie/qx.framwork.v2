render([
    group([
showInput('社团申请id', 'association_apply-association_apply_id', '', '4'),
showInput('社团id', 'association_apply-association_id', '', '4'),
showInput('1是团委审核2草稿-1审核通过-2审核不通过-3重填', 'association_apply-status', '', '4'),
showInput('申请人', 'association_apply-applicant', '', '4'),
showInput('审核人', 'association_apply-auditor', '', '4'),
showInput('审核意见', 'association_apply-audit_suggestion', '', '4'),
showTime('审核时间', 'association_apply-audit_time', '', '4'),
showInput('社团id', 'association-association_id', '', '4'),
showInput('社团申请id', 'association-association_apply_id', '', '4'),
showInput('社团名', 'association-name', '', '4'),
showInput('相关文件', 'association-related_file', '', '4'),
showInput('创建人', 'association-creator', '', '4'),
showTime('创建时间', 'association-createTime', '', '4'),
showInput('状态（1申请中，-1已批准100开放中200关闭）', 'association-status', '', '4'),
showArea('描述', 'association-describe')
],'标题')],'','ecampus.twxt2.association_apply@find|association@find&id='+q.id,'','详情');