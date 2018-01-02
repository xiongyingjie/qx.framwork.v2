render(function () {
    var cfg = [];
    cfg.push(
        group([
            showInput('学号', 'cultivation_object_info-UserId', '', '4'),
            showInput('姓名', 'cultivation_object_info-name', '', '4'),
            showInput('班级', 'cultivation_object_info-Class', '', '4'),
            showTime('递交入党申请书时间', 'cultivation_object_info-join_application_time', '', '4'),
            showInput('性别', 'cultivation_object_info-sex', '', '4'),
            showInput('民族', 'cultivation_object_info-natiion', '', '4'),
            showInput('年级', 'cultivation_object_info-Grade', '', '4'),
            hideTime('cultivation_object_info-birthday', ''),
            showInput('电话', 'cultivation_object_info-phone', '', '4'),
            hide('cultivation_object_info-qualification', ''),
            hide('cultivation_object_info-league_branch_Id', ''),
            hideTime('cultivation_object_info-be_activist_time', ''),
            hideTime('cultivation_object_info-graduation_time', ''),
            hide('cultivation_object_info-point', ''),
            hide('cultivation_object_info-rank', ''),
            hide('cultivation_object_info-community_representation', ''),
            hideTime('cultivation_object_info-development_object_time', ''),
            hideTime('cultivation_object_info-join_party_time', ''),
            hide('cultivation_object_info-party_Id', ''),
            hideTime('cultivation_object_info-party_committee_eaxm_time', ''),
            hideTime('cultivation_object_info-join_train_class_time', ''),
            hide('cultivation_object_info-join_party_volunte', ''),
            hideTime('cultivation_object_info-sub_time_of_vlolunte', ''),
            hideTime('cultivation_object_info-sub_formal_application_Time', ''),
            hide('cultivation_object_info-formal_application', ''),
            hideTime('cultivation_object_info-formal_time', ''),
            hide('cultivation_object_info-cultivation_object_stateId', ''),
            hide('cultivation_object_info-alutobiography', ''),
            hideTime('cultivation_object_info-swear_time', ''),
            hide('cultivation_object_info-qq', ''),
            hide('cultivation_object_info-weixin', ''),
            hide('cultivation_object_info-join_application', ''),
			 hide('cultivation_object_info-unit_id', ''),
            //状态（下拉框）[cultivation_state]
         //   select('下拉', 'test_dropdown', 'ecampus.join_party.cultivation_state@items&name=name', "", "4"),
            button('推优', '6:0', Color.green, function () {
                $('#cultivation_object_info-cultivation_object_stateId').val(1);
                submitForm('ecampus.join_party.cultivation_object_info@update&id=' + q.id);
            })
        ], '推优管理'));
    return cfg;
}, '', 'ecampus.join_party.cultivation_object_info@list'
.jn('cultivation_state.cultivation_object_stateId', 'cultivation_object_stateId')
.eq('UserId', q.id), '推优管理');