render([
     group([
         hide('organization_level_id',q.id),
         input('级别名称', 'name'),
        area('备注', 'note')],
        "编辑组织机构级别",
        1)],
        "/QxJzxt/OrgCRUD/EditOrgLevel",
        "/QxJzxt/OrgCRUD/FindOrgLevel",
        "编辑");