render(function(model){
var cfg=[];
cfg.push(
    group([
input('货商编码', 'provider-provider_id', '', '4', {min:1,max:50}),
input('货商名称', 'provider-name', '', '4'),
input('联系人', 'provider-contactor', '', '4'),
input('电话', 'provider-phone', '', '4'),
select('发票类型编号', 'provider-tickect_type_id', 'erp.invoicing.tickect_type@items&name=name', '', '4'),
input('区域', 'provider-area', '', '4'),
input('传真', 'provider-fax', '', '4'),
input('地址', 'provider-address', '', '4'),
input('邮编', 'provider-zip_code', '', '4'),
select('货商分类', 'provider-provider_type_id', 'erp.invoicing.provider_type@items&name=name', '', '4'),
input('拼音码', 'provider-pinyin', '', '4'),
input('电子邮件地址', 'provider-email', '', '4'),
input('开户行', 'provider-bank', '', '4'),
input('帐号', 'provider-bank_no', '', '4'),
input('税务登记号', 'provider-tax_no', '', '4'),
input('结帐方式', 'provider-checkout_method', '', '4'),
input('结帐周期', 'provider-checkout_period', '', '4'),
input('每月结帐日期', 'provider-checkout_day', '', '4'),
input('押账批次', 'provider-charge_account_batch', '', '4'),
input('信誉额度', 'provider-credit_limit', '', '4'),
input('业务员', 'provider-salesman', '', '4'),
input('价格级别', 'provider-price_level', '', '4'),
input('停止往来', 'provider-stop_intercourse', '', '4'),
input('备注1', 'provider-note1', '', '4'),
input('备注2', 'provider-note2', '', '4'),
input('锁', 'provider-is_lock', '', '4'),
input('状态', 'provider-status', '', '4')
],'标题'));
return cfg;
},'erp.invoicing.provider@update&id='+q.id,'erp.invoicing.provider@find&id='+q.id,'编辑');