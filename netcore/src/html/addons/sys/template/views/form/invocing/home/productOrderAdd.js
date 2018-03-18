render([
    group([
        hide("in_store_order_item-in_store_order_item_id","#id"),//入库明细单号 主键
        hide("in_store_order_item-invoicing_order_id",q.id),

//showInput('订单编号', 'in_store_order_item-invoicing_order_id', q.id, '4'),
        select('选择商品', 'in_store_order_item-product_id', 'erp.invoicing.product@items&name=name', '1', '4'),
//input('商品编号', 'in_store_order_item-product_id', '', '4', { min: 1, max: 50 }),
input('单价', 'in_store_order_item-price', '10', '4', { float: true }),
input('数量', 'in_store_order_item-total_num', '1', '4', { int: true }),
input('折扣(0.5为5折)', 'in_store_order_item-discount', '1', '4', { float: true }),
input('优惠金额', 'in_store_order_item-reduced_price', '0', '4', { float: true }),
input('应付总额', 'in_store_order_item-total_pay_price', '10', '4', { float: true }),
        hide('in_store_order_item-dealed_num', '0')
//input('已处理数量', 'in_store_order_item-dealed_num', '0', '4', { int: true })
    ], '商品信息')], 'erp.invoicing.in_store_order_item@add', '', '给订单添加商品');