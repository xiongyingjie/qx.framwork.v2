var record_id = $.q("id");
var req_man = "";
//var record_id = "10001";
$.bindPage("wx.bx.device_record@list"
    .jn("employ.user_id", "request_man")
    .jn("device.device_id", "device_record.device_id")
    .jn("hitch_type.hitch_type_id", "device_record.hitch_type_id")
    .eq("device_record_id", record_id), [], ''
    , function () {
        var userid = req_man = $(".request_man").text();
        ("/Json/Bx/GetUserInfo?userid=" + userid).query(function (data) {
            $(".request_man").text(data);
        });
        //debugger
        var addr_id = $(".device-address_id").text();
        ("/Json/Bx/GetAddrDetail?addrid=" + addr_id).query(function (data) {
            $(".device-address_id").text(data);
        });
    });
hide([
["device_record-arrange_time", "#now"],
["device_record-state", 1]
]);
function subrecord() {
    var repaire_man = $("#choose-weixiupeople").attr("data-values");
    $(".request_man").val(req_man);
    hide([
    ["device_record-repair_man", repaire_man]
    ]);
    $.submitPage("wx.bx.device_record@update&id=" + record_id, function () {
        $.msg("派工成功，三秒后返回首页");
        $.go("index.html", 3);
    });
}


initWeuiSelect('weixiupeople', 'wx.bx.employ@list'.eq("type", 2), '', function (data) { return data["name"] }, function (data) { return data["user_id"] });
//"Json/BxGetNameByUserid".query()通过用户id获取用户信息