render([
    group([
input('仓库名称', 'org_storage-name', '', '4', { min: 1, max: 50 }),
input('仓库地址', 'org_storage-address', '', '4', { min: 1, max: 50 }),
input('仓库容量', 'org_storage-capacity', '', '4', { min: 1, max: 50 }),
input('联系人', 'org_storage-contactor', '', '4', { min: 1, max: 50 }),
input('邮箱', 'org_storage-email', '', '4', { min: 1, max: 50 }),
input('电话', 'org_storage-phone', '', '4', '^((13[0-9])|(14[5|7])|(15([0-3]|[5-9]))|(18[0,5-9]))\\d{8}$', { min: 1, max: 50 }),
input('备注', 'org_storage-note', '', '4'),

hide('org_storage-org_id', "book"),
hide('org_storage-org_storage_id', "#id"),   

    ], '仓库管理')], 'erp.invoicing.org_storage@add', '', '添加仓库');