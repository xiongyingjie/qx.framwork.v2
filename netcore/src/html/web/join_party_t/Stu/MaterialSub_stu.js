
render([
    group([
        showInput('工号', 'teacher_info-uid', '', '1'),//来源于表teacher_info-uid，提交的时候存到cultivation_object_info.stu_Id
		showInput('姓名', 'teacher_info-name', '', '1'),//来源于表teacher_info.name

	   select("意向培养支部","cultivation_object_info-unit_id", 'ecampus.join_party.Party_branch@items&name=name','',4,0),


	//	showinput("所在团支部", "league_branch-Name", '', '1'),//来源表league_branch.Name，teacher_info.unit_id=league_branch.unit_id
        //列表隐藏值
          hide('cultivation_object_info-UserId', ''),
          hide('cultivation_object_info-name', ''),
          hide('cultivation_object_info-league_branch_Id', ''),
          hide('cultivation_object_info-Class', ''),
          hide('teacher_info-unit_id', ''),
     
          hide('cultivation_object_info-party_Id', ''),  //赋值默认团支部所在的党支部的id

          hide('cultivation_object_info-Grade', ''),
          hide('cultivation_object_info-sex', ''),
          hide('cultivation_object_info-natiion', ''),
          hide('cultivation_object_info-phone', ''),
          hide('cultivation_object_info-qualification', ''),
          hideTime('cultivation_object_info-birthday', ''),
		  //hide('cultivation_object_info-unit_id', ''),



        hide('teacher_info-sex', ''),//来源于表teacher_info.sex
        hide('teacher_info-natiion', ''),//来源于表teacher_info.natiion
        hideTime('teacher_info-birthday', ''),//来源于表teacher_info-birthday
        hide('teacher_info-phone', ''),//来源于表teacher_info-phone
        hide('teacher_info-qualification', ''),//来源于表teacher_info-qualification
       
       
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
            $("#cultivation_object_info-UserId").val($("#teacher_info-uid").val());
            $("#cultivation_object_info-name").val($("#teacher_info-name").val());
            $("#cultivation_object_info-league_branch_Id").val($("#cultivation_object_info-unit_id").val());
			
			   
            $("#cultivation_object_info-sex").val($("#teacher_info-sex").val());//$为引用id=teacher_info-sex对象
            $("#cultivation_object_info-natiion").val($("#teacher_info-natiion").val());
            $("#cultivation_object_info-birthday").val($("#teacher_info-birthday").val());
            $("#cultivation_object_info-phone").val($("#teacher_info-phone").val());
            $("#cultivation_object_info-qualification").val($("#teacher_info-qualification").val());

           //$("#cultivation_object_info-join_application_time").val($("#cultivation_object_info-join_application_time").val());
            $("#cultivation_object_info-cultivation_object_stateId").val("1");
			 $("#cultivation_object_info-unit_id").val("#Party_branch-unit_id");
            //$.alert($("#cultivation_object_info-UserId").val());
            submitForm("ecampus.join_party.cultivation_object_info@add");
        })
    ], '提交入党申请材料')],
 '', 'ecampus.join_party.teacher_info@find&id='+ '_uid'
    , '');