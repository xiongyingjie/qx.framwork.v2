render(function(model){
var cfg=[];
cfg.push(
    group([
input('仓库编码', 'org_storage-org_storage_id', '', '4', {min:1,max:50}),
input('仓库名称', 'org_storage-name', '', '4', {min:1,max:50}),
input('联系人', 'org_storage-contactor', '', '4'),
input('电话', 'org_storage-phone', '', '4'),
input('地址', 'org_storage-address', '', '4'),
input('邮箱', 'org_storage-email', '', '4'),
input('容量', 'org_storage-capacity', '', '4'),
input('备注', 'org_storage-note', '', '4'),
hide('org_storage-org_id')
],'标题'));
return cfg;
},'erp.invoicing.org_storage@update&id='+q.id,'erp.invoicing.org_storage@find&id='+q.id,'编辑');