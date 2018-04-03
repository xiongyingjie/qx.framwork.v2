render(function(model){
var cfg=[];
cfg.push(
    group([
input('客户编码', 'customer-customer_id', '', '4', {min:1,max:50}),
input('客户名称', 'customer-name', '', '4', {min:1,max:50}),
select('发票类型编号', 'customer-tickect_type_id', 'erp.invoicing.tickect_type@items&name=name', '', '4'),
input('区域', 'customer-area', '', '4', {min:1,max:50}),
input('联系人', 'customer-contactor', '', '4', {min:1,max:50}),
input('电话', 'customer-phone', '', '4', {mobile:true}),
input('地址', 'customer-address', '', '4', {min:1,max:50}),
select('客户分类', 'customer-customer_type_id', 'erp.invoicing.customer_type@items&name=name', '', '4'),
input('拼音码', 'customer-pinyin', '', '4', {min:1,max:50}),
input('结帐方式', 'customer-checkout_method', '', '4', {min:1,max:50}),
input('结帐周期', 'customer-checkout_period', '', '4', {min:1,max:50}),
input('价格级别', 'customer-price_level', '', '4', {min:1,max:50}),
input('邮编', 'customer-zip_code', '', '4'),
input('电子邮件地址', 'customer-email', '', '4'),
input('传真', 'customer-fax', '', '4'),
input('开户行', 'customer-bank', '', '4'),
input('帐号', 'customer-bank_no', '', '4'),
input('税务登记号', 'customer-tax_no', '', '4'),
input('每月结帐日', 'customer-checkout_day', '', '4'),
input('押账批次', 'customer-charge_account_batch', '', '4'),
input('信誉额度', 'customer-credit_limit', '', '4'),
input('业务员', 'customer-salesman', '', '4'),
input('停止往来', 'customer-stop_intercourse', '', '4'),
input('备注1', 'customer-note1', '', '4'),
input('备注2', 'customer-note2', '', '4'),
input('锁', 'customer-is_lock', '', '4'),
input('状态', 'customer-status', '', '4')
],'标题'));
return cfg;
},'','erp.invoicing.customer@find&id='+q.id,'详情');