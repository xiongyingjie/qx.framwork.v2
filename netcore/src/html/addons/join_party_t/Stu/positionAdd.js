render([
    group([

             input("职务", "hold_position-describe", '请输入职务', 4),
		    file("上传职务证明附件", "hold_position-attachment",4,  "/UserFile/join_party/hold_position_file/"),
            hideTime( 'hold_position-begin_time', ''),
            hideTime( 'hold_position-end_time', ''),
hide('hold_position-hold_position_id', '#id'),
hide('hold_position-UserId', '#uid'),
hide('hold_position-upload_time', '#now')

],'上传职务情况及材料')],'ecampus.join_party.hold_position@add','','添加');
