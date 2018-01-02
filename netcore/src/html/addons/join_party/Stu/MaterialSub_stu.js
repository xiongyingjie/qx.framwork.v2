
//入党申请--材料申请,申请时间不对，入党申请书文件上传不成功
render([
    group([
        //数据库读取
        //cultivation_object_info表中仅仅含有学号，id
        //列表显示值cultivation_object_info,stu_class,stu_info,league_branch
        showInput('学号', 'stu_info-uid', '', '1'),//来源于表stu_info-uid，提交的时候存到cultivation_object_info.stu_Id
		showInput('姓名', 'stu_info-name', '', '1'),//来源于表stu_info.name
		showinput("所在团支部", "league_branch-Name", '', '1'),//来源表league_branch.Name，stu_info.unit_id=league_branch.unit_id
        //列表隐藏值
          hide('cultivation_object_info-UserId', ''),
          hide('cultivation_object_info-name', ''),
          hide('cultivation_object_info-league_branch_Id', ''),
          hide('cultivation_object_info-Class', ''),
          hide('stu_info-unit_id', ''),
          hide('league_branch-Party_branch_id', ''),
          hide('cultivation_object_info-party_Id', ''),  //赋值默认团支部所在的党支部的id

          hide('cultivation_object_info-Grade', ''),
          hide('cultivation_object_info-sex', ''),
          hide('cultivation_object_info-natiion', ''),
          hide('cultivation_object_info-phone', ''),
          hide('cultivation_object_info-qualification', ''),
          hideTime('cultivation_object_info-birthday', ''),
		




      
        hide('stu_class-class_name', ''),//来源于表stu_class.class_name，stu_class.class_id=stu_info.class_id
        hide('year_specialty-grade_no', ''),//来源于表year_specialty.grade_no,stu_class.year_specialty_id=year_specialty.year_specialty_id
        hide('stu_info-sex', ''),//来源于表stu_info.sex
        hide('stu_info-natiion', ''),//来源于表stu_info.natiion
        hideTime('stu_info-birthday', ''),//来源于表stu_info-birthday
        hide('stu_info-phone', ''),//来源于表stu_info-phone
        hide('stu_info-qualification', ''),//来源于表stu_info-qualification
        hide('league_branch-unit_id', ''),//来源于表league_branch-unit_id，存到cultivation_object_info-league_branch_Id
       
        //用户填写，提交至表cultivation_object_info
        input('qq号', 'cultivation_object_info-qq', '', '1'),
        input('微信号', 'cultivation_object_info-weixin', '', '1'),
         file('提交入党申请书附件', 'cultivation_object_info-join_application', 1, "/UserFile/join_party/join_application_file/"),

        //其他隐藏
        hideTime('cultivation_object_info-join_application_time', '#now'),//以当前用户提交时间为准
        hideTime('cultivation_object_info-be_activist_time', ''),//以当前用户提交时间为准
        hideTime('cultivation_object_info-graduation_time', ''),//以当前用户提交时间为准
       
        hide('cultivation_object_info-community_representation', ''),
        hideTime( 'cultivation_object_info-development_object_time', ''),//以当前用户提交时间为准
        hideTime('cultivation_object_info-join_party_time', ''),
        hideTime('cultivation_object_info-party_committee_eaxm_time', ''),
        hideTime('cultivation_object_info-join_train_class_time', ''),
        hideTime('cultivation_object_info-sub_time_of_vlolunte', ''),
        hideTime('cultivation_object_info-sub_formal_application_Time', ''),
       // hideFile('转正申请附件', 'cultivation_object_info-formal_application'),
        hideTime('cultivation_object_info-formal_time', ''),
        hide('cultivation_object_info-cultivation_object_stateId', '0'),
        //hideFile('个人自传附件', 'cultivation_object_info-alutobiography'),
        hideTime('cultivation_object_info-swear_time', ''),
        button("提交材料", '1:5', Color.green, function () {
            $("#cultivation_object_info-UserId").val($("#stu_info-uid").val());
            $("#cultivation_object_info-name").val($("#stu_info-name").val());
            $("#cultivation_object_info-league_branch_Id").val($("#stu_info-unit_id").val());
            $("#cultivation_object_info-Class").val($("#stu_class-class_name").val());
            $("#cultivation_object_info-Grade").val($("#year_specialty-grade_no").val());
            $("#cultivation_object_info-sex").val($("#stu_info-sex").val());//$为引用id=stu_info-sex对象
            $("#cultivation_object_info-natiion").val($("#stu_info-natiion").val());
            $("#cultivation_object_info-birthday").val($("#stu_info-birthday").val());
            $("#cultivation_object_info-phone").val($("#stu_info-phone").val());
            $("#cultivation_object_info-qualification").val($("#stu_info-qualification").val());
            $("#cultivation_object_info-party_Id").val($("#league_branch-Party_branch_id").val());
            $("#cultivation_object_info-cultivation_object_stateId").val("0");
			 $("#cultivation_object_info-unit_id").val("Root.1c0.5c9.6b8");
            //$.alert($("#cultivation_object_info-UserId").val());
            submitForm("ecampus.join_party.cultivation_object_info@add");
        })


    ], '提交入党申请材料')],
 '', 'ecampus.join_party.stu_info@list'
    .jn('league_branch.unit_id')
	.jn('Party_branch.unit_id','league_branch.Party_branch_id')
     .jn('stu_class.class_id')
     .jn('year_specialty.year_specialty_id', 'stu_class.year_specialty_id')
     .eq('uid', '_uid')
    , '');
//'ecampus.join_party.cultivation_object_info@update-' + '_uid'