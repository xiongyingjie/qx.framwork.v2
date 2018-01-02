//检查绑定信息
"wx.ent.xmyxy.bind_user_student@list".eq("user_id", "_uid").query(function(data) {
    if (data.length > 0) {
        $.go(g_homepage);
    } 
});


function bind() {
    $.submitPage("wx.ent.xmyxy.bind_user_student@update",
        function() {
            $.msg("绑定成功,3秒后进入首页");
            $.go(g_homepage,3);
        },
        function (data) { 
            var stuId = data["bind_user_student-stu_id"];
            if (!$.hasValue(stuId)) {
                $.alert("要绑定的账号不能为空");
                return false;//终止提交
            }
            data["bind_user_student-bind_user_student_id"] = $.user_id() + "-" + stuId;
            data["bind_user_student-user_id"] = "#uid";
            data["bind_user_student-bind_time"] = "#now";
            data["bind_user_student-state"] = "0";
            return data;
        });
}