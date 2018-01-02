

render([
    group([
hide('asso_post-post_id','#id'),
hide('asso_post-position_id',q.id),
input('岗位名', 'asso_post-name', '', '4', { min: 1, max: 50 }),
area('岗位描述', 'asso_post-post_description'),
    ], '添加岗位')], 'ecampus.twxt2.asso_post@add', '', '添加');