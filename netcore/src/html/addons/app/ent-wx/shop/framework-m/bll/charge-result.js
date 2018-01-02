
ready(function () {
    var num = $.q("num");
    $("charge_num").html(num);
    $.msg("恭喜成功充值" + num + "元");
    $("#submit").click(function () {
        confirmPay($("#num").val());
    });
    $("#back").click(function () {
        $.go(g_wallet_wx);
    });
})