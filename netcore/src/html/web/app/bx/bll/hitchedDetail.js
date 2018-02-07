
var ReqNum = $.q("id");
$.bindPage("wx.bx.device_record@list"
    .eq("device_record_id", ReqNum)
    .jn("device.device_id", "device_record.device_id")
    .jn("device_type.device_type_id", "device.device_type_id"), [], ''
    , function () {
        //debugger
        var userid = $(".request_man").val();
        ("/Json/Bx/GetUserInfo?userid=" + userid).query(function (data) {
            $(".request_man").val(data);
        });
        var addr_id = $(".device-address_id").val();
        ("/Json/Bx/GetAddrDetail?addrid=" + addr_id).query(function (data) {
            $(".device-address_id").val(data);
        });
    });
hide([
    ["device_record-device_record_id"],
    ["device_record-req_time"],
    ["device_record-confirm_time", "#now"],
    ["device_record-state", -1],
    ["device_record-charge_man", "#uid"]

]);
function uprecord() {
    var hitch_style = $("#choose-weixiupeople").attr("data-values");
    hide([
    ["device_record-hitch_type_id", hitch_style]
    ]);
    $.submitPage("wx.bx.device_record@update&id=" + ReqNum, function () {
        $.msg("提交成功，三秒后返回首页");
        $.go("index.html", 3);
    });
}


