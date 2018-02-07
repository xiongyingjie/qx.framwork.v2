render([
    group([
hide('association_member-asso_member_id', ''),
hide('association_member-association_id', ''),
hide('association_member-student_id', ''),
hideTime('association_member-enroll_time', ''),
hide('association_member-auditor', ''),
hide('association_member-status', ''),
hide('association_member-merit', ''),
hide('association_member-prefer', ''),
hide('association_member-phone', ''),
hide('association_member-email', ''),
hide('association_member-relatedfile', ''),
hide('association_member-sex', ''),
hideTime('association_member-apply_time', ''),
hide('association_member-leave_reason', ''),
hide('association_member-department_position', ''),
select('部门', 'association_member-department_id', '/twxt2/AssoCRUD/GetRelationalDepart?department_id='+q.dep, '', '4')

    ], '更换部门')], 'ecampus.twxt2.association_member@update-' + q.id, 'ecampus.twxt2.association_member@find&id=' + q.id, '', '更换部门');
//*d/twxt2/AssoCRUD/ChangeDepart?member_id=' + association_member - asso_member_id + '&selected=' + association_member - department_id

