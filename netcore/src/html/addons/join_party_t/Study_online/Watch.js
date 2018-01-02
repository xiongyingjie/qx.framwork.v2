render([
    group([
showinput('学习资料名称', 'study_material-study_material_Name', '', 4),
showSelect("类型名称","'study_material_type-type_name",[{text:"文本",value:"0"},{text:"图片",value:"1"}, {text:"音频",value:"2"}, {text:"视频",value:"3"},{text:"地址",value:"4"}, {text:"网址",value:"5"}],"",4,0),
showinput('描述', 'study_material_type-describe', '', 4),
hide('study_material_type-study_material_type_id'),
hide('study_material-study_material_id'),
hide('study_material-describe'),
showFile('文件下载','study_material-study_material_file','',4)
],'任务详情')],'ecampus.join_party.study_material@find&id='+q.id,'','查看');
