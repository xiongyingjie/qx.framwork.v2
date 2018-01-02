var id = $.q("id");
var num;
var schId = $.random();
$.bindPage([
    'wx.ent.xmyxy.T_YDM_STUDENT_COURESE@list',
    'wx.ent.xmyxy.T_YDM_SIGN_STATUS@list'.ob('SIGN_STATUS_ID','+'),
    'wx.ent.xmyxy.T_YDM_COURSE@find&id=' + id,
    'wx.ent.xmyxy.T_YDM_COURSE_SCHEDULE@list'.eq('COURSE_ID', id)
], [
    'contain', function() {
        /*
      <div class="card-footer">
            	{STUDENT_NAME}<span>{STUDENT_ID}</span>
            	<span>
            	<select id="stu_{STUDENT_ID}" class="weui-select optionhtml" name="select" onchange="submitDm('{STUDENT_ID}')">
			     </select>
               </span>
            </div> 
    */
    }
], function(data) {
    data.num=num = data["_db_index_cmd_wx.ent.xmyxy.T_YDM_COURSE_SCHEDULE-list"].length + 1;
}, function(data) {
    var html = "";
    $.each(data["_db_index_cmd_wx.ent.xmyxy.T_YDM_SIGN_STATUS-list"], function(i, o) {
        html += "  <option " + (o.SIGN_STATUS_ID==0?'selected=selected':'') + " value=" + o.SIGN_STATUS_ID + ">" + o.SIGN_NAME + "</option>";
    });
    $(".optionhtml").html(html);
  
});


function submitDm(stuId) {
    var signId = schId + '_' + stuId;
    hide([
    ['T_YDM_COURSE_SCHEDULE-SCHEDULE_ID', schId]
    , ['T_YDM_COURSE_SCHEDULE-COURSE_ID',id ]
    , ['T_YDM_COURSE_SCHEDULE-LESSON_SEQ', num]
    , ['T_YDM_COURSE_SCHEDULE-LESSON_TIME', '#now']
    ]);
    hide([
        ['T_YDM_SIGN-SIGN_ID',signId ]
        , ['T_YDM_SIGN-SCHEDULE_ID', schId]
        , ['T_YDM_SIGN-STUDENT_ID', stuId]
        , ['T_YDM_SIGN-SIGN_STATUS', $.val("stu_" + stuId, 204)]
    ]);
    $.submitPage('wx.ent.xmyxy.T_YDM_COURSE_SCHEDULE@update-' + schId + '|T_YDM_SIGN@update-' + signId, function() {$.msg("已保存")});
}