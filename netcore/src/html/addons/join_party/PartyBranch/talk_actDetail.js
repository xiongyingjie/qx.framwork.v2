render([
    group([
hide('party_talk_record-party_talk_record_id', ''),
hide( 'party_talk_record-cultivation_object_stateId', ''),
showInput('学号', 'party_talk_record-UserId', '', '4'),

showInput('谈话人', 'party_talk_record-talker', '', '4'),	
showTime('谈话时间', 'party_talk_record-record_time', '', '4'),
showInput('谈话地点', 'party_talk_record-place', '', '4'),
showEditor('谈话内容', 'party_talk_record-contents')

],'谈话记录详情')],'','ecampus.join_party.party_talk_record@find&id='+q.id,'','详情');