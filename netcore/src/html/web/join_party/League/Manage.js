render(function () {
    var cfg = [];
    cfg.push(
        group([
    input('#', 'cultivation_object_info-uid', '', '4', { min: 1, max: 50 }),
    input('学号', 'cultivation_object_info-stu_Id', '', '4', { min: 1, max: 50 }),
    input('#', 'cultivation_object_info-Class', '', '4', { min: 1, max: 50 }),
    input('##_1', 'cultivation_object_info-Grade', '', '4', { min: 1, max: 50 }),
    input('##_1', 'cultivation_object_info-name', '', '4', { min: 1, max: 50 }),
    input('##_1', 'cultivation_object_info-sex', '', '4', { min: 1, max: 20 }),
    input('民族', 'cultivation_object_info-natiion', '', '4', { min: 1, max: 50 }),
    time('##_1', 'cultivation_object_info-birthday', '', '4', '请选择##_1'),
    input('##_1', 'cultivation_object_info-phone', '', '4', { min: 1, max: 50 }),
    input('学历', 'cultivation_object_info-qualification', '', '4', { min: 1, max: 50 }),
    time('递交入党申请书时间', 'cultivation_object_info-join_application_time', '', '4', '请选择递交入党申请书时间'),
    input('团支部ID', 'cultivation_object_info-league_branch_Id', '', '4', { min: 1, max: 50 }),
    time('确定为积极分子时间', 'cultivation_object_info-be_activist_time', '', '4', '请选择确定为积极分子时间'),
    time('党校结业时间', 'cultivation_object_info-graduation_time', '', '4', '请选择党校结业时间'),
    input('绩点', 'cultivation_object_info-point', '', '4', { min: 1, max: 50 }),
    input('排名', 'cultivation_object_info-rank', '', '4', { min: 1, max: 50 }),
    input('社区表现分', 'cultivation_object_info-community_representation', '', '4', { float: true }),
    time('确定为发展对象时间', 'cultivation_object_info-development_object_time', '', '4', '请选择确定为发展对象时间'),
    time('入党时间', 'cultivation_object_info-join_party_time', '', '4', '请选择入党时间'),
    input('党支部ID', 'cultivation_object_info-party_Id', '', '4', { min: 1, max: 50 }),
    time('党委审批时间', 'cultivation_object_info-party_committee_eaxm_time', '', '4', '请选择党委审批时间'),
    time('预备党员培训时间', 'cultivation_object_info-join_train_class_time', '', '4', '请选择预备党员培训时间'),
    file('入党志愿书附件', 'cultivation_object_info-join_party_volunte'),
    time('提交入党志愿书时间', 'cultivation_object_info-sub_time_of_vlolunte', '', '4', '请选择提交入党志愿书时间'),
    time('提交转正申请书时间', 'cultivation_object_info-sub_formal_application_Time', '', '4', '请选择提交转正申请书时间'),
    file('转正申请附件', 'cultivation_object_info-formal_application'),
    time('转正时间', 'cultivation_object_info-formal_time', '', '4', '请选择转正时间'),
    input('培养对象状态ID', 'cultivation_object_info-cultivation_object_stateId', '', '4', { min: 1, max: 50 }),
    file('个人自传附件', 'cultivation_object_info-alutobiography'),
    time('宣誓时间', 'cultivation_object_info-swear_time', '', '4', '请选择宣誓时间'),
    input('qq号', 'cultivation_object_info-qq', '', '4', { min: 1, max: 50 }),
    input('微信号', 'cultivation_object_info-weixin', '', '4', { min: 1, max: 50 })
        ], '标题'));
    return cfg;
}, 'ecampus.join_party.cultivation_object_info@update&id=' + q.id, 'ecampus.join_party.cultivation_object_info@find&id=' + q.id, '编辑');