render([
    group([
hide('coacher_activity-coacher_activity_id', '#id'),    //生成主键值
hide( 'coacher_activity-comment', ''), //审核意见
hide('coacher_activity-coacher_activity_state_id', '0'),  //审核状态
hide('coacher_activity-province', ''),
hide('coacher_activity-city', ''),
hide('coacher_activity-area', ''),
hide('coacher_activity-begin_time', ''),  //开始时间
hide('coacher_activity-end_time', ''),   // 结束时间
hide('coacher_activity-group_number', ''),  //开团数
hide('coacher_activity-organizer', ''), //承办单位
hide('coacher_activity-remain_number', ''),  //剩余报名数
hide('coacher_activity-total_number', ''),   //报名总名额数
hide('coacher_activity-describe', ''), //描述
hide( 'coacher_activity-pass_time', ''),   //审核时间
hide( 'coacher_activity-coacher_id', '#uid'),   //教练id
hide('coacher_activity-browser', ''),  //浏览量
hide('coacher_activity-collection', ''),  //收藏数

select("活动类型", "coacher_activity-activity_type_id", "/sports/Admin/Getactivity_Type", "请选择活动类型", 4),
input('活动标题', 'coacher_activity-name', '', '4', {min:1,max:50}),
input('地址', 'coacher_activity-address', '', '4', { min: 1, max: 50 }),
input('活动价格', 'coacher_activity-price', '', '4', {float:true}),
input('承办单位', 'coacher_activity-host_unit', '', '4'),
select("报名方式", "coacher_activity-sign_mode", [{ value: "个人", text: "个人" }, { value: "团体", text: "团体" }], "个人", 4),

input('备注', 'coacher_activity-note', '', '4'),
hide('coacher_activity-is_enable', '1'),  //是否启用0为禁用1为启用
time('报名开始时间', 'coacher_activity-sign_begin_time', '', '4', '请选择报名开始时间'),
time('报名结束时间', 'coacher_activity-sign_end_time', '', '4', '请选择报名结束时间'),
file('图片', 'coacher_activity-photos'),
editor('活动介绍', 'coacher_activity-detail'),




],'标题')],'wx.sports.coacher_activity@add','','添加');