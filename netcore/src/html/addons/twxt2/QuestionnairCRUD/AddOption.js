render([
    group([
hide('options-optionID','#id'),
hide('options-questionID',q.id),
input('序号', 'options-sequence', '', '4', { int: true }),
input('内容', 'options-option_content', '', '4', { min: 1, max: 50 }),
file('相关图片', 'options-op_url')
    ], '添加选项')], 'ecampus.twxt2.options@add', '', '添加');