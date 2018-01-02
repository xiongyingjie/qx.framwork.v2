
$.bindPage("/open/balance",[],function(data) {
    data.Balance = data.Balance / 100.0;
    return data;
});

function withdraw() {
    $.msg("暂不支持")
}
