render([
    group([hide( 'demo_dayoff_id', q.id),hide( 'unit_id', q.id),
input('账号', 'uid'),
input('请假天数', 'day'),
time('提交时间', 'submit_time'),
input('请假理由', 'reason')], "请假信息"),
group([area('班主任审批意见', 'teacher_comment')], "班主任审核"),
group([area('学院审核意见', 'depart_comment'),
    radio("是否同意请假", "DepartmentChecked", [
        { text: '同意', value: '1' },
        { text: '拒绝', value: '0' }
], 1, 3)], "学院审核")
],

'*', "/Demo/GetDayOffInfo");