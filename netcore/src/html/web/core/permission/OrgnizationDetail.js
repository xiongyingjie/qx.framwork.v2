render([
    group([
showInput('机构id', 'orgnization-orgnization_id', '', '4'),
showInput('上级', 'orgnization-father_id', '', '4'),
showInput('名称', 'orgnization-name', '', '4'),
showInput('类型', 'orgnization-orgnization_type_id', '', '4'),
showInput('子系统', 'orgnization-sub_system', '', '4'),
showInput('机构级别id', 'orgnization-organization_level_id', '', '4'),
showArea('备注', 'orgnization-note'),
showEditor('描述', 'orgnization-descripe')
],'标题')],'','qx.permmision.v2.orgnization@find&id='+q.id,'','详情');