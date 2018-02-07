
//信息迁入--本页面只是做党员:提交页面时主外键冲突
render([
    group([
        //数据库读取
        //从数据库中的stu_info查出显示学号，姓名，班级
        showInput('学号', 'stu_info-uid', '', '1'),//来源于表stu_info-uid，提交的时候存到cultivation_object_info.stu_Id
		showInput('姓名', 'stu_info-name', '', '1'),//来源于表stu_info.name
		showinput("所在班级", "stu_class-class_name", '', '1'),//来源表league_branch.Name，stu_info.unitid=league_branch.unitid
          input('qq号', 'cultivation_object_info-qq', '', '1'),
        input('微信号', 'cultivation_object_info-weixin', '', '1'),
//---------------------------查出stu_info表中的列----------------
hide('stu_info-class_id'),
hide('stu_info-sex'),
hide('stu_info-natiion'),
hideTime('stu_info-birthday'),
hide('stu_info-phone'),
hide('stu_info-qualification'),
hide('stu_info-unitid'),
//---------------------------查出year_specialty表中的列----------------
hide('year_specialty-specilty_no'),
hide('year_specialty-year_specialty_id'),
hide('year_specialty-grade_no'),

//---------------------------查出league_branch表中的列----------------
hide('league_branch-unitid'),
hide('league_branch-Name'),
hide('league_branch-Party_branch_id'),
//---------------------------查出cultivation_object_info表中的列----------------
hide('cultivation_object_info-UserId'),
hide('cultivation_object_info-Class'),
hide('cultivation_object_info-Grade'),
hide('cultivation_object_info-name'),
hide('cultivation_object_info-sex'),
hide('cultivation_object_info-natiion'),
hideTime('cultivation_object_info-birthday'),
hide('cultivation_object_info-phone'),
hide('cultivation_object_info-qualification'),
hideTime('cultivation_object_info-join_application_time'),
hide('cultivation_object_info-league_branch_Id'),
hideTime('cultivation_object_info-be_activist_time'),
hideTime('cultivation_object_info-graduation_time'),
hide('cultivation_object_info-point'),
hide('cultivation_object_info-rank'),
hide('cultivation_object_info-community_representation'),
hideTime('cultivation_object_info-development_object_time'),
hideTime('cultivation_object_info-join_party_time'),
hide('cultivation_object_info-party_Id'),
hideTime('cultivation_object_info-party_committee_eaxm_time'),
hideTime('cultivation_object_info-join_train_class_time'),
hide('cultivation_object_info-join_party_volunte'),
hideTime('cultivation_object_info-sub_time_of_vlolunte'),
hideTime('cultivation_object_info-sub_formal_application_Time'),
hide('cultivation_object_info-formal_application'),
hideTime('cultivation_object_info-formal_time'),
hide('cultivation_object_info-cultivation_object_stateId'),
hide('cultivation_object_info-alutobiography'),
hideTime('cultivation_object_info-swear_time'),
hide('cultivation_object_info-join_application'),
hide('cultivation_object_info-public_opinion'),
hide('cultivation_object_info-politics_careful'),
hide('cultivation_object_info-community_representation_attach'),
hide('cultivation_object_info-move_in_state'),
//---------------------------提交数据-----------------------------

         button("提交材料", '1:5', Color.green, function () {



             $("#cultivation_object_info-Class").val($("#stu_class-class_name").val());
             $("#cultivation_object_info-Grade").val($("#year_specialty-grade_no").val());
             $("#cultivation_object_info-name").val($("#stu_info-name").val());
             $("#cultivation_object_info-sex").val($("#stu_info-sex").val());
             $("#cultivation_object_info-natiion").val($("#stu_info-natiion").val());
             $("#cultivation_object_info-phone").val($("#stu_info-phone").val());
             $("#cultivation_object_info-qualification").val($("#stu_info-qualification").val());
             $("#cultivation_object_info-league_branch_Id").val($("#league_branch-unitid").val());
             $("#cultivation_object_info-party_Id").val($("#league_branch-Party_branch_id").val());
             $("#cultivation_object_info-UserId").val($("#stu_info-uid").val());
             $("#cultivation_object_info-cultivation_object_stateId").val("4");
             $("#cultivation_object_info-move_in_state").val("0");
             $("#cultivation_object_info-birthday").val($("#stu_info-birthday").val());



             submitForm("ecampus.join_party.cultivation_object_info@add");
         })



    ], '预备党员转入申请')],
 '', 'ecampus.join_party.stu_info@list'
    .jn('league_branch.unitid')
    .jn('stu_class.class_id')
     .jn('year_specialty.year_specialty_id', 'stu_class.year_specialty_id')
     .eq('stu_info.uid', '100188')
    , '');
//'ecampus.join_party.cultivation_object_info@update-' + '_uid'