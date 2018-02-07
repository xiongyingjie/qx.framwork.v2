render([
    group([
hide('asso_post-post_id', '',),
showInput('岗位名', 'asso_post-name', '', '4'),
showEditor('岗位描述', 'asso_post-post_description'),
hide('asso_post-position_id', '')
],'标题')],'','ecampus.twxt2.asso_post@find&id='+q.id,'','详情');