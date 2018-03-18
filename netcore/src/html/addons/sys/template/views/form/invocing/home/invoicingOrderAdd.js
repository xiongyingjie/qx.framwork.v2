render([
    group([

        hide("invoicing_order-invoicing_order_id","#id"),
//input('订单编号', 'invoicing_order-invoicing_order_id', '', '4', {min:1,max:100}),
input('操作人', 'invoicing_order-creator', '小陈', '4', {min:1,max:50}),
time('操作时间', 'invoicing_order-create_time', '', '4', '请选择操作时间'),
        input('审核人', 'invoicing_order-checkor', '小陈', '4', {min:1,max:50}),
time('审核时间', 'invoicing_order-check_time', '', '4', '请选择审核人'),
input('业务员', 'invoicing_order-bllor', '张三', '4', {min:1,max:50}),
input('经办人', 'invoicing_order-excutor', '李四', '4', { min: 1, max: 50 }),

hide("invoicing_order-invoicing_order_type_id", "0"),
//input('订单类型', 'invoicing_order-invoicing_order_type_id', '0', '4', { min: 1, max: 50 }),

        hide("invoicing_order-invoicing_order_state_id", "0"),

//input('订单状态编号', 'invoicing_order-invoicing_order_state_id', '', '4', {min:1,max:50}),
        hideTime('invoicing_order-total_pay_time'),
        //time('结账时间', 'invoicing_order-total_pay_time', '', '4', '请选择结账时间'),
        hideTime('invoicing_order-finish_time'),
//time('完成时间', 'invoicing_order-finish_time', '', '4', '请选择完成时间'),
        hide('invoicing_order-total_reduced_price', '0'),
        //input('优惠金额', 'invoicing_order-total_reduced_price', '0', '4', { float: true }),

        hide('invoicing_order-total_pay_price', '0'),
        hide('invoicing_order-total_payed_price', '0'),
//input('应支付总额', 'invoicing_order-total_pay_price', '0', '4', {float:true}),
//input('已支付总额', 'invoicing_order-total_payed_price', '0', '4', { float: true }),

        
area('备注', 'invoicing_order-note')
    ], '进货单详情')], 'erp.invoicing.invoicing_order@add', '','创建进货单');