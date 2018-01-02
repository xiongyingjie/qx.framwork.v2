render(function(){
var cfg=[];
cfg.push(
    group([
input('商品编号', 'shop_goods-goods_id', '', '4', {min:1,max:50}),
input('商品名称', 'shop_goods-name','','4'),
input('商品价格', 'shop_goods-price', '', '4', { float: true }),
input('供应商', 'shop_goods-shop_provider_id', '', '4', { min: 1, max: 50 }),
file('产品图片', 'shop_goods-photo')
],'标题'));
return cfg;
},'wx.ent.xmyxy.shop_goods@update&id='+q.id,'wx.ent.xmyxy.shop_goods@find&id='+q.id,'编辑');