render([
    group([
    hide('knowledge_type_id'),
    input('类型名称', 'name'),
    input('备注', 'note')
    ], "编辑类型")], '*', '/Json/Knowledge/TypeFind', '编辑类型');