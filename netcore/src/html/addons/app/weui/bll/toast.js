$(document).on("click", "#show-toast", function () {
    $.toast("操作成功", function () {
        console.log('close');
    });
})
    .on("click", "#show-toast-cancel", function () {
        $.toast("取消操作", "cancel", function (toast) {
            console.log(toast);
        });
    })
    .on("click", "#show-toast-forbidden", function () {
        $.toast("禁止操作", "forbidden");
    })
    .on("click", "#show-toast-text", function () {
        $.toast("纯文本", "text");
    })
    .on("click", "#show-loading", function () {
        $.showLoading();

        setTimeout(function () {
            $.hideLoading();
        }, 3000)
    });