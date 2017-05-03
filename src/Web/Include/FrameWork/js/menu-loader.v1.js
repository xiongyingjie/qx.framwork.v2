//菜单模块
function queryMenu(url, params) {
    if (url.indexOf("http") > -1) {
        console.log("remote requesting to" + url);
        params = "dist_url=" + url;
        url = "/sb/grap";
    } else {
        params = "";
        console.log("local requesting to " + url);
    }
    $.ajax({
        url: url,
        type: "GET",
        data: params,
        // context: document.body,
        success: function (result) {
            //console.log("queryMenu result" + result)
            $("#qx-page-wrapper").html(result);
        },
        error: function () {
            alert('fail');
        }
    });
}