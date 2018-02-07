var number = $.q("id");
$.bindPage("wx.bx.device_record@list"
    .jn("device.device_id", "device_record.device_id")
    .jn("hitch_type.hitch_type_id", "device_record.hitch_type_id")
    .eq("device_record_id", number), []);


function uprecord() {
    hide([
["device_record-repair_time", "#now"],
["device_record-state", 2]]);
    $.submitPage("wx.bx.device_record@update&id=" + number, function () {
        $.msg("报修成功，三秒后返回首页");
        $.go("index.html", 3);
    });
}