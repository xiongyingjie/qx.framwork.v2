initWeuiSelect("user-name", "app.cst.student@items&name=name", "_db_index_cmd_app.cst.student-items", function(d) {
    return d["Text"];
}, function(d) {
    return d["Value"];
});
var form_card_state;
$("[name='card_state']").click(function (o) {
    var othis = $(o.target);
    form_card_state = othis.attr("id");

});
function submit() {
    if (!$.hasValue(form_card_state)) {
        $.alert("必须选择您的医保卡情况");
        return;
    }
    if ($.notEmpty_m("user-name", "必须选择姓名")) {
       // debugger
        $.submitPage("app.cst.medicare_card@add",
            function (data, code) {
                $.alert("提交成功，感谢您的配合");
            },
        function (data) {
            data["medicare_card-stu_no"] = $.val_m("user-name");
            data["medicare_card-card_state"] = form_card_state;
            return data;
        });

    }
}