render([
    group([
hide('survey_object-survey_objectID', '#id'),
input('对象名称', 'survey_object-survey_objectName', '', '4', { min: 1, max: 50 }),
    ], '添加调查对象')], 'ecampus.twxt2.survey_object@add', '', '添加');