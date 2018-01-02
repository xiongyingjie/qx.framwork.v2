render([
     group([
         hide('orgnization_type_id'),
         input('类型名称', 'name'),
        area('备注', 'note')],
        "编辑组织机构类型",
        1)],
        "/QxJzxt/OrgCRUD/EditOrgType",
        "/QxJzxt/OrgCRUD/FindOrgType",
        "*");