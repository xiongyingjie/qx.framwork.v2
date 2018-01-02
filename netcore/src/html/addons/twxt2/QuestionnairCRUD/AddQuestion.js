render([
    group([
hide('question-questionID','#id'),
hide('question-questionnaireID',q.id),
input('序号', 'question-sequence', '', '4', { int: true }),
input('问题内容', 'question-question_content', '', '4', { min: 1, max: 50 }),
select('题型', 'question-type', [{ text: "单选", value: "1" }, { text: "多选", value: "0" }, { text: "自定义回答", value: "2" }], '2'),
file('相关图片','question-url')
    ], '标题')], 'ecampus.twxt2.question@add', '', '添加');