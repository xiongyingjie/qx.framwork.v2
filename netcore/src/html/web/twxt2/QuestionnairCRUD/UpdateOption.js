render([
    group([
hide('options-optionID'),
hide('options-questionID'),
input('序号', 'options-sequence', '', '4', { int: true }),
input('内容', 'options-option_content', '', '4', { min: 1, max: 50 }),
file('相关图片', 'options-op_url')
    ], '添加选项')], 'ecampus.twxt2.options@update&id=' + q.id, 'ecampus.twxt2.options@find&id=' + q.id, '添加');