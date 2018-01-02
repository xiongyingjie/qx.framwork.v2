


render([
    group([
hide( 'party_talk_record-party_talk_record_id','#id'),
showInput('学号', 'party_talk_record-UserId', q.id, '4', {min:1,max:50}),
editor('谈话内容', 'party_talk_record-contents'),
input('谈话人', 'party_talk_record-talker', '', '4', {min:1,max:50}),
time('谈话时间', 'party_talk_record-record_time', '', '4', '请选择谈话时间'),
input('谈话地点', 'party_talk_record-place', '', '4', {min:1,max:50}),
hide( 'party_talk_record-cultivation_object_stateId', '3')
],'标题')],'ecampus.join_party.party_talk_record@add','','添加');