render(function(){
var cfg=[];
cfg.push(
    group([
hide('asso_post-post_id', ''),
input('岗位名', 'asso_post-name', '', '4', {min:1,max:20}),
editor('岗位描述', 'asso_post-post_description'),
hide('asso_post-position_id', '')
],'标题'));
return cfg;
},'ecampus.twxt2.asso_post@update&id='+q.id,'ecampus.twxt2.asso_post@find&id='+q.id,'编辑');