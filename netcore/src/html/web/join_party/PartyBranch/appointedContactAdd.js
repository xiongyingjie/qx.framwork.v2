render([
    group([
hide('cultivation_connector-cultivation_connector_id','#id'),
showInput('学号', 'cultivation_connector-UserId', q.id, '4', {min:1,max:50}),
select('联系人所属支部', 'cultivation_connector-unitid', 'ecampus.join_party.Party_branch@items&name=name', ';', '4'),
input('培养联系人姓名', 'cultivation_connector-Name', '', '4', {min:1,max:50}),
input('电话', 'cultivation_connector-Phone', '', '4', {min:1,max:50}),
input('职务', 'cultivation_connector-Position', '', '4', {min:1,max:50}),
hide( 'cultivation_connector-connector_id', '#uid'),
time('开始时间', 'cultivation_connector-BeginTime', '', '4', '请选择开始时间'),
time('结束时间', 'cultivation_connector-EndTime', '', '4', '请选择结束时间')



],'指派联系人')],'ecampus.join_party.cultivation_connector@add','','');