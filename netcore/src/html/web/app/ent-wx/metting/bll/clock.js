var fq = 300;
refresh();

setInterval(function () {
    if (fq === 0) {
        fq = 300;
        refresh();
    }
    $("#time").html(fq--);
}, 1000);
//time
function refresh() {
    var body = $("body");
    body.append(new Date() + ":发起请求<br/>");
    $.Ajax({
        url: "/Json/Meeting/Inject",
        success: function (data, code, msg) {
            body.append(msg + "(本次刷新耗时"+(300-fq)+"秒)<hr/>");
        }
    });
}