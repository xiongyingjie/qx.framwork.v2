render([
     group([showinput('考号', 'demo_english_grade_id'),
input('用户id', 'open_id', '', '4', '请输入用户id', ''),
input('姓名', 'stu_name', '', '4', '请输入姓名', ''),
hide('school', '厦门医学院'),
select('考试类型', 'type', [
{
    text: "CET-4", value: "CET-4"
},
{
    text: "CET-6", value: "CET-6"
}]),
input('听力', 'listen', '', '4', '请输入听力分数', ''),
input('阅读', 'reading', '', '4', '请输入阅读分数', ''),
input('写作', 'write', '', '4', '请输入写作分数', ''),
hide('_note', 'note'),
input('批次', 'year', '2017年6月', '4', '请输入批次', '')], "编辑"+q.id+"的CET成绩信息")
    
],'*',"/WxApp/CETAdmin/FindCET");