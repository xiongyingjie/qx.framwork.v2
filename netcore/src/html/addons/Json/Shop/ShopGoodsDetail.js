render([
    group([
showInput('商品编号', 'shop_goods-goods_id', '', '4'),
showInput('商品名称', 'shop_goods-name','','4'),
showInput('商品价格', 'shop_goods-price', '', '4'),
showInput('供应商', 'shop_goods-shop_provider_id', '', '4'),
showFile('产品图片', 'shop_goods-photo')
],'标题')],'','wx.ent.xmyxy.shop_goods@find&id='+q.id,'','详情');