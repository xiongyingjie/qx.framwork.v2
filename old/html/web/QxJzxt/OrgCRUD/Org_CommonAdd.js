render([
    group([
        hide('father_id', q.father_id),
         //input('父级名称', 'fatherOrgName'),
         input('组织名称', 'name'),
         select("组织类型", "orgnization_type_id", "/QxJzxt/OrgCRUD/OrgnizationTypeSelect", "", 4),
         select("组织级别", "organization_level_id", "/QxJzxt/OrgCRUD/OrganizationLevelSelect", "", 4),
         input('备注', 'note'),
        area('描述', 'descripe')],
        "编辑组织机构",
        1)],
        "/QxJzxt/OrgCRUD/Org_CommonAdd ",
        "",
        "*");