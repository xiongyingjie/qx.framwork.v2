//$.bindPage("wx.ent.xmyxy.app_contact_person@list&search.eq:uid=_uid", [], function (data) {
//    var old = data["_db_index_cmd_wx.ent.xmyxy.app_contact_person-list"];
//    if (old.length === 1) {
//        //$.go("index.html");
//    }
//    return old[0];
//});

function nextStep(destUrl) {
    if ($.notEmpty_m("app_contact_person-phone", "绑定的手机号不能为空")) {
        var phone = $.val_m("app_contact_person-phone");
        $.submitPage("/Json/Contact/BindPhone?phone=" + phone, function (data, code, msg, url) {

            if (code === 1) {
                $.alert(msg + ",3s后进入通讯录");
                $.go("index.html", 3);
            } else {
                $.alert(msg);
            }
           

         
        });
    }
    
}