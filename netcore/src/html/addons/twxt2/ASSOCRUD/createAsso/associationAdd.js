render([
    group([
input('社团id', 'association-association_id', '', '4', {min:1,max:50}),
input('社团申请id', 'association-association_apply_id', '', '4', {min:1,max:50}),
input('社团名', 'association-name', '', '4', {min:1,max:50}),
input('创建人', 'association-creator', '', '4', {min:1,max:50}),
time('创建时间', 'association-createTime', '', '4', '请选择创建时间'),
input('审核状态', 'association-status', '', '4', {int:true}),
input('相关文件', 'association-related_file', '', '4', {min:1,max:200}),
area('描述', 'association-describe')
],'标题')],'ecampus.twxt2.association@add','','添加');