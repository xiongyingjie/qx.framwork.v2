$.bindPage("wx.ent.xmyxy.app_contact_person@list&search.eq:uid=_uid", [], function (data) {
    var old = data["_db_index_cmd_wx.ent.xmyxy.app_contact_person-list"];
    if (old.length === 0) {
        $(".list-block.deletemargin").html("编辑信息前需绑定手机,<a href='binding_phone.html'>点击</a>绑定手机号");
        $.confirm("编辑信息前需绑定手机,是否现在绑定手机?", function () {
            $.go("binding_phone.html");
        });
    }
    return old[0];
});



function submit() {
    $.submitPage("/Json/Contact/UpdateInfo?name=" + $.val_m("app_contact_person-name") + "&phone=" + $.val_m("app_contact_person-phone"), function () {
        $.alert("保存成功");
    });
   ;
}