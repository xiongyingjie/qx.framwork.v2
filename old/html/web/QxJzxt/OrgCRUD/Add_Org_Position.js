render([
     group([
         hide('orgnization_id', q.orgid),
         select("职位", "position_id", "/QxJzxt/OrgCRUD/PositionSelect", "", 4)
     ],
        "组织机构对应的职位",
        1)],
        "/QxJzxt/OrgCRUD/Add_Org_Position",
        "",
        "*");