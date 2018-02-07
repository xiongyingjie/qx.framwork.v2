
render(
     function() {
        return   [
                group([
                    hides(['knowledge_id', 'create_time', 'modify_time']),
                    input('标题', 'title'),
                    select('类型', 'knowledge_type_id', '/Json/Knowledge/TypeItems', model.knowledge_type_id),
                    input('所有者', 'owner'),
                    input('最后修改人', 'last_modifyer'),
                    editor('介绍信息', 'introduce')
                ], "编辑知识"), 
                group([showfile("文件", "files")],"知识文件")
            ];
        }
    , '*', '/Json/Knowledge/Find', '编辑知识');