render([
    group([
hide('#', 'cultivation_object_info-uid', '', '4'),
showInput('学号', 'cultivation_object_info-stu_Id', '', '4'),
showInput('姓名', 'cultivation_object_info-name', '', '4'),
showInput('班级', 'cultivation_object_info-Class', '', '4'),
showTime('递交入党申请书时间', 'cultivation_object_info-join_application_time', '', '4'),
showInput('性别', 'cultivation_object_info-sex', '', '4'),
showInput('民族', 'cultivation_object_info-natiion', '', '4'),
showInput('年级', 'cultivation_object_info-Grade', '', '4'),
showInput('绩点', 'cultivation_object_info-point', '', '4'),
showInput('联系电话', 'cultivation_object_info-phone', '', '4'),
time('确定为积极分子时间', 'cultivation_object_info-be_activist_time', '', '4')
    ], '推优管理')], '', 'ecampus.join_party.cultivation_object_info@find&id=' + q.id, 'ecampus.join_party.cultivation_object_info@Update&id', '推优');