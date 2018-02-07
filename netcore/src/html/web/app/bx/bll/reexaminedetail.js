var record_id = $.q("id");
var req_man = "";
var repair_man = "";
$.bindPage("wx.bx.device_record@list"
    .jn("device.device_id", "device_record.device_id")
    .jn("hitch_type.hitch_type_id", "device_record.hitch_type_id")
    .eq("device_record_id", record_id), [], ''
    , function () {
        //debugger
        repair_man = $(".repair_man").text();
        req_man = $(".request_man").text();
        ("/Json/Bx/GetUserInfo?userid=" + req_man).query(function (data) {
            $(".request_man").text(data);
        });
        ("/Json/Bx/GetUserInfo?userid=" + repair_man).query(function (data) {
            $(".repair_man").text(data);
        });
        var addr_id = $(".device-address_id").text();
        ("/Json/Bx/GetAddrDetail?addrid=" + addr_id).query(function (data) {
            $(".device-address_id").text(data);
        });
    });
function subrecord() {
    var revisit_man = $("#choose-weixiupeople").attr("data-values");
    hide([
    ["device_record-revisit_man", revisit_man],
     ["device_record-state", 3]
    ]);
    $.submitPage("wx.bx.device_record@update&id=" + record_id, function () {
        $.msg("安排回访员成功，三秒后返回首页");
        $.go("index.html", 3);
    });
}


initWeuiSelect('weixiupeople', 'wx.bx.employ@list'.eq("type", 3), '', function (data) { return data["name"] }, function (data) { return data["user_id"] });
//"Json/BxGetNameByUserid".query()通过用户id获取用户信息