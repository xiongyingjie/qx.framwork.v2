render([
    group([
hide('questionnaire-questionnaireID','#id'),
input('问卷名称', 'questionnaire-questionnaire_name', '', '4', { min: 1, max: 50 }),
time('开始时间', 'questionnaire-begin_time'),
time('结束时间', 'questionnaire-end_time'),
select('调查对象分类', 'questionnaire-survey_objectID', 'ecampus.twxt2.survey_object@items&name=survey_objectName'),
select('状态', 'questionnaire-isrelease', [{ text: '之后发布', value: '0' }, { text: '发布问卷', value: '1' }], '0'),
hide('questionnaire-creator','#uid'),
hide('questionnaire-create_Org', q.unit_id)
    ], '添加问卷')], 'ecampus.twxt2.questionnaire@add', '', '添加');