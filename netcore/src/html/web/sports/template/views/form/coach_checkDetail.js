render([
    group([
hide('coacher-coacher_id', ''),
showInput('姓名', 'coacher-name', '', '4'),
showInput('手机号', 'user_info-phone', '', '4'),
showInput('证件号码', 'coacher-certificate_no', '', '4'),
hide( 'coacher-province', ''),
hide('coacher-city', ''),
hide( 'coacher-area', ''),
showInput('服务地址范围', 'coacher-adress', '', '4'),
showInput('价格', 'coacher-price', '', '4'),
hide( 'coacher-group_buy_price', ''),
showInput('职业项目', 'coacher-occupation_project_id', '', '4'),
hide( 'coacher-teach_project', ''),
hide( 'coacher-teach_yard', ''),
showSelect("是否上门服务", "coacher-is_todoor", [{ value: "0", text: "否" }, { value: "1", text: "是" }], "", 4),

showSelect("审核状态", "coacher-audit_status", [{ value: "0", text: "未通过" }, { value: "1", text: "通过" }, { value: "2", text: "未通过" }], "", 4),
showArea('个人简介', 'coacher-profile'),
showArea('资历', 'coacher-seniority')
    ], '')], '', 'wx.sports.coacher@find|user_info@find&id='+q.id, '审核私教');