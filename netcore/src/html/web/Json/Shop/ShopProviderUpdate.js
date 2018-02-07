render(function(){
var cfg=[];
cfg.push(
    group([
input('供应商编号', 'shop_provider-shop_provider_id', '', '4', {min:1,max:50}),
input('供应商', 'shop_provider-name', '', '4', {min:1,max:50}),
input('供应商地址', 'shop_provider-adress', '', '4', {min:1,max:50}),
input('联系电话', 'shop_provider-phone', '', '4', {min:1,max:50}),
input('备注', 'shop_provider-note', '', '4', {min:1,max:50})
],'标题'));
return cfg;
},'wx.ent.xmyxy.shop_provider@update&id='+q.id,'wx.ent.xmyxy.shop_provider@find&id='+q.id,'编辑');