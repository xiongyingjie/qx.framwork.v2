var device_id = $.q("id");
$.bindPage("wx.bx.device@list".jn("device_type.device_type_id", "device.device_type_id")
    .eq("device.device_id", device_id),'','', function() {
        var addr_id = $(".device-address_id").val();
        ("/Json/Bx/GetAddrDetail?addrid=" + addr_id).query(function(data) {
            $(".device-address_id").val(data);
        });
    });
$.bindPage("wx.bx.employ@list".eq("employ.user_id", "_uid"));
hide([
    ["device_record-device_record_id", "#id"],
    ["device_record-req_time", "#now"],
    ["device_record-state", 0],
    ["device_record-request_man", "#uid"]
]);
function subrecord() {
    $.submitPage("wx.bx.device_record@add", function () {
        $.msg("报修成功，三秒后返回首页");$.go("index.html",3)}, function (data) {
        return data;
    });
}


