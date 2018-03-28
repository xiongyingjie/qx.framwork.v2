render(function(model){
var cfg=[];
cfg.push(
    group([
input('品牌编号', 'brand-brand_id', '', '4', {min:1,max:50}),
input('品牌名称', 'brand-name', '', '4', {min:1,max:50}),
hide('brand-sequence'),
hide('brand-url'),
hide('brand-logo'),
hide('brand-descripe'),
hide('brand-note')
],'标题'));
return cfg;
},'','erp.invoicing.brand@find&id='+q.id,'详情');