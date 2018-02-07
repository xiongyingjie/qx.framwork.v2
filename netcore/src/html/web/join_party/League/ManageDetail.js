render([
    group([
    showInput('学号', 'cultivation_object_info-UserId', '', '4'),
    showInput('姓名', 'cultivation_object_info-name', '', '4'),
    showInput('团支部ID', 'cultivation_object_info-league_branch_Id', '', '4'),
    showInput('年级', 'cultivation_object_info-Grade', '', '4'),
    showInput('性别', 'cultivation_object_info-sex', '', '4'),
    showInput('班级', 'cultivation_object_info-Class', '', '4'),
    showInput('民族', 'cultivation_object_info-natiion', '', '4'),
    showInput('联系方式', 'cultivation_object_info-phone', '', '4'),
    showTime('递交入党申请书时间', 'cultivation_object_info-join_application_time', '', '4'),
    showFile('入党申请书附件', 'join_application')
    ], '管理界面')], '', 'ecampus.join_party.cultivation_object_info@find&id=' + q.id, '', '详情');

    