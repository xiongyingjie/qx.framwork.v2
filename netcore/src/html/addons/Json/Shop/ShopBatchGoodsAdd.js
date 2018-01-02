render([
    group([
//showInput('商品号', 'shop_batch_goods-batch_good_id', '#id', '4', { min: 1, max: 50 }),
hide('shop_batch_goods-batch_good_id', '#id'),
showInput('批次编号', 'shop_batch_goods-batch_id', q.id, '4', {min:1,max:50}),
//input('商品编号', 'shop_batch_goods-goods_id', '', '4', { min: 1, max: 50 }),
showInput('商品编号', 'shop_batch_goods-goods_id', q.sid, '4', { min: 1, max: 50 }),
input('价格', 'shop_batch_goods-price', '', '4', {float:true}),
input('排序', 'shop_batch_goods-seq', '', '4', {int:true}),
input('库存', 'shop_batch_goods-remain', '', '4', {int:true})
],'标题')],'wx.ent.xmyxy.shop_batch_goods@add','','添加');