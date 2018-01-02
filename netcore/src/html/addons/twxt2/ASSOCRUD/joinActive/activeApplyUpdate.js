render(function () {
    var cfg = [];
    cfg.push(
        group([
    showInput('活动名', 'active-activity_name', '', '4', { min: 1, max: 50 }),
    showInput('活动描述', 'active-describe', '', '4', { min: 1, max: 50 }),
    showTime('开始时间', 'active-statrtime', '', '4', '请选择开始时间'),
    showTime('结束时间', 'active-endtime', '', '4', '请选择结束时间'),
    showTime('申请时间', 'active_apply-apply_time', '', '4', '请选择申请时间'),
    showInput('活动地点', 'active-address', '', '4', { min: 1, max: 50 }),
    time('审核时间', 'active_apply-audit_time', '', '4', '请选择审核时间'),
     input('审核人', 'active_apply-auditor', '', '4', { min: 1, max: 20 }),
     area('审核意见', 'active_apply-audit_opinion', '', '1','200', { min: 1, max: 50 }),
    showfile('相关文件', 'active-related_file','1'),
    hide('active_apply-activity_apply_id', 'q.active_apply-activity_apply_id'),
    hide('active_apply-status'),
    hide('active-active_id', 'q.active-active_id'),
    hide('active-activity_apply_id', 'q.active-activity_apply_id'),
    hide('active-association_id', 'q.active-association_id'),
    hide('active-active_type', 'q.active-active_type'),
    hide('active-status', 'q.active-status')
   
       //button("拒绝", '1:5', Color.green, function () {
       //    $("#active_apply-status").val(-3);
       //    $("#active-status").val(1);
       //    //$.alert(    $("#association-status").val())
       //    submitForm("ecampus.twxt2.active@update-" + q.id1 + "|active_apply@update-" + q.id2);
       //}),
        ], '活动审核'));
    cfg.push( button("审核通过", '1:5', Color.green, function () {
        $("#active_apply-status").val(-2);
        $("#active-status").val(1);
        //$.alert(    $("#association-status").val())
        submitForm("ecampus.twxt2.active@update-" + q.id1 + "|active_apply@update-" + q.id2);
    }),
      button("重新填写", '6:0', Color.orange, function () {
          $("#active_apply-status").val(-1);
          $("#active-status").val(1);
          //$.alert(    $("#association-status").val())
          submitForm("ecampus.twxt2.active@update-" + q.id1 + "|active_apply@update-" + q.id2);
      }))
    return cfg;
}, '', 'ecampus.twxt2.active@list'.jn('active_apply.activity_apply_id', 'activity_apply_id').eq('active_id', q.id1), '活动审核');

function formReady() {
    
}