render([
    group([
input('标题', 'title'),
select('类型', 'knowledge_type_id', '/Json/Knowledge/TypeItems'),
input('所有者', 'owner'),
input('最后修改人', 'last_modifyer'),
editor('介绍信息', 'introduce','在这里编写知识介绍')], "知识信息"),
group([file("知识文件", "files", "/userfile/entwx/knowledge")], "知识文件")], '*', '', '添加知识');