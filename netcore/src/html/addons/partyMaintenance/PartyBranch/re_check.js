//tab页面：审核分为驳回（不同意，Requst_table：state=，记录删除cultivation_object_info表格中填写的材料）
//同意（Requst_table：state=，1通过），
//重填（Requst_table：state=2，审核不通过，cultivation_object_info表记录不删除），
render(function () {
    return [
        group([
             tab([
        {
            title: "审查对象基本信息：",
            content: [
            showinput("学号", "Requst_table-UserId", '', '3'),//社区表现分为校方填入
            showinput("姓名", "cultivation_object_info-name", '', '3'),//社区表现分为校方填入
            showinput("申请转入状态", "cultivation_state-name", '', '3'),//社区表现分为校方填入
//--------------------------------Party_member党员表
            hide('Party_member-Party_member_ID'),

hide('Party_member-UserId'),
hide('Party_member-name'),
hide('Party_member-sex'),
hideTime('Party_member-birthday'),
hide('Party_member-nation'),
hide('Party_member-come_where'),
hide('Party_member-phone'),
hide('Party_member-party_Id'),
hideTime('Party_member-table_time'),
hide('Party_member-identity_sign'),
hideTime('Party_member-member_time'),
hideTime('Party_member-premember_time'),
hide('Party_member-leave'),
//---------------------------Requst_table申请表
hide('Requst_table-Requst_id'),
hideTime('Requst_table-sub_time'),
hide('Requst_table-state'),
hide('Requst_table-intro_file'),
hide('Requst_table-cultivation_object_stateId'),

//---------------------------cultivation_object_info信息表
hide('cultivation_object_info-UserId'),
hide('cultivation_object_info-Class'),
hide('cultivation_object_info-Grade'),
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
hide('cultivation_object_info-qq'),
hide('cultivation_object_info-weixin'),
hide('cultivation_object_info-join_application'),
hide('cultivation_object_info-public_opinion'),
hide('cultivation_object_info-politics_careful'),
hide('cultivation_object_info-community_representation_attach'),
hide('cultivation_object_info-move_in_state')
            ]
        },
             ], 1),
           tab([
        {
            title: "审核说明：",
            content: [
                area("请在此处填写审核的备注说明", "Requst_table-attachment"),
                select('请选择转入支部', 'Requst_table-join_party_Id', 'ecampus.join_party.party@items&name=name', '')
            ]
        },
           ], 1),
           button("重新填写", '1:5', Color.green, function () {
            
               $("#Requst_table-state").val("2");//审核不通过

               submitForm("ecampus.join_party.Requst_table@update-" + q.id);
           }),


           button("同意转入", '1:5', Color.blue, function () {
               var sta = $("#Requst_table-cultivation_object_stateId").val();
               var st = $("#Requst_table-UserId").val();
               if (sta == 5) {
                   
                   $("#Party_member-Party_member_ID").val("#id");;
                   $("#Party_member-UserId").val($("#cultivation_object_info-UserId").val());
                   $("#Party_member-name").val($("#cultivation_object_info-name").val());
                   $("#Party_member-sex").val($("#cultivation_object_info-sex").val());//审核通过
                   $("#Party_member-birthday").val($("#cultivation_object_info-birthday").val());
                   $("#Party_member-nation").val($("#cultivation_object_info-natiion").val());
                   $("#Party_member-come_where").val(2);
                   $("#Party_member-phone").val($("#cultivation_object_info-phone").val());
                   $("#Party_member-party_Id").val($("#Requst_table-join_party_Id").val());
                   $("#Party_member-table_time").val("#now");
                   $("#Party_member-member_time").val($("#cultivation_object_info-formal_time").val());
                   $("#Party_member-leave").val(0);//审核通过

                   $("#cultivation_object_info-move_in_state").val(1);//审核通过
                   $("#cultivation_object_info-party_Id").val($("#Requst_table-join_party_Id").val());

                   $("#Requst_table-state").val(1);//审核通过

                   submitForm("ecampus.join_party.cultivation_object_info@update-" + st + "|Party_member@add" + "|Requst_table@update-" + q.id);
               } else {
                   $("#cultivation_object_info-move_in_state").val(1);//审核通过
                   $("#cultivation_object_info-party_Id").val($("#Requst_table-join_party_Id").val());

                   $("#Requst_table-state").val(1);//审核通过

                   submitForm("ecampus.join_party.cultivation_object_info@update-" + st + "|Requst_table@update-" + q.id);

               }
            
           }),
           button("驳回", '1:5', Color.red, function () {
               $("#Requst_table-state").val(2);//审核不通过
               var st = $("#Requst_table-UserId").val();

               submitForm("ecampus.join_party.Requst_table@update-" + q.id + "|cultivation_object_info@delete&UserId=" + st);
           }),
        ], "审核", 1)
    ];
}, 'ecampus.join_party.Requst_table@update-' + q.id, 'ecampus.join_party.Requst_table@list'
   .jn('cultivation_object_info.UserId', 'Requst_table.UserId')
   .jn('cultivation_state.cultivation_object_stateId', 'Requst_table.cultivation_object_stateId')
    .eq('Requst_id', q.id), '');



