function cancel() {
    history.go(-1);
}
//调用微信JS api 支付
function jsApiCall() {
    WeixinJSBridge.invoke(
        'getBrandWCPayRequest',
        g_jsonParam,//josn串
        function (res) {
            WeixinJSBridge.log(res.err_msg);
            //支付成功或失败前台判断
            if (res.err_msg == 'get_brand_wcpay_request:ok') {
                alert('恭喜您，支付成功!');
                if (g_return_url.indexOf("?") === -1) {
                   g_return_url += "?num=" + g_num;
                   } else {
                    g_return_url += "&num=" + g_num;

                }
                window.location.replace(g_return_url);

            } else {
                alert('支付失败,请点击[立刻支付]重试！');//+res.err_msg
                //history.go(-1);
                //这里一直返回getBrandWCPayRequest提示fail_invalid appid
            }
            // alert(res.err_code + res.err_desc + res.err_msg);
        }
    );
}

function callpay() {
    if (typeof WeixinJSBridge == "undefined") {
        if (document.addEventListener) {
            document.addEventListener('WeixinJSBridgeReady', jsApiCall, false);
        }
        else if (document.attachEvent) {
            document.attachEvent('WeixinJSBridgeReady', jsApiCall);
            document.attachEvent('onWeixinJSBridgeReady', jsApiCall);
        }
    }
    else {
        jsApiCall();
    }
}