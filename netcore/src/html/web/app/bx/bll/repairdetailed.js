var number = $.q("id");
$.bindPage("wx.bx.device_record@list"
    .jn("device.device_id", "device_record.device_id")
    .jn("hitch_type.hitch_type_id", "device_record.hitch_type_id")
    .eq("device_record_id", number), [], ''
    , function () {
        //debugger
        var addr_id = $(".device-address_id").val();
        ("/Json/Bx/GetAddrDetail?addrid=" + addr_id).query(function (data) {
            $(".device-address_id").val(data);
        });
    });


function uprecord() {
    hide([
["device_record-repaire_time", "#now"],
["device_record-state", 2]]);
    $.submitPage("wx.bx.device_record@update&id=" + number, function () {
        $.msg("报修成功，三秒后返回首页");
        $.go("index.html", 3);
    });
}