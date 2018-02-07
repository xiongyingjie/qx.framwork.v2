
render(function () {
    var cfg=[
            group([
                hide('demo_dayoff_id', q.id), hide('unit_id', q.id),
                input('账号', 'uid'),
                input('请假天数', 'day'),
                time('提交时间', 'submit_time'),
                input('请假理由', 'reason')
            ], "请假信息"),
            
            group([
                area('老师审批意见', 'teacher_comment', '', '1'),
                radio("是否同意请假", "TeacherChecked", [
                    { text: '同意', value: '1' },
                    { text: '拒绝', value: '0' }
                ], 1, 3)
            ], "班主任审核")
    ];
   
     return cfg;
    },

'*', "/Demo/GetDayOffInfo");

