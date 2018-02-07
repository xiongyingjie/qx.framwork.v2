ready(function () {
    $.Ajax({
        url: "/Json/Contact/Find",
        data: { id: $.q("id") },
        success: function (data) {
            var obj = [

              // { label: "性别", input: data.sex },
               { label: "电话", input: data.phone },
               { label: "部门", input: data.org },
               { label: "上级部门", input: data.father_org },
                { label: "工号", input: data.user_id },
                  { label: "邮箱", input: data.email }

               //{ label: "上级", input: data.father_org },
               //{ label: "办公地点", input: data.work_place }
            ];
            var html = "";

            for (var i = 0; i < obj.length; i++) {
                var item = obj[i];
                html +=
                 '<li>' +
                      '<div class="item-content">' +
                       ' <div class="item-media"><i class="icon icon-form-name"></i></div>' +
                       ' <div class="item-inner">' +
                        '  <div class="item-title label labeldetail">' + item.label + '</div>' +
                         ' <div class="item-input item-inputdetail">' +
                                 item.input +
                          '</div>' +
                       ' </div>' +
                     ' </div>' +
                   ' </li>';
            }
            html = '<div class="list-block deletemargin">' +
                         ' <ul>' + html +
                       ' </ul>' +
                       ' </div>';
            $("#list-block").html(html);
            var html2 = "";

            html2 = '<div class="detailtop">' +
                            ' <div class="left">' +
                                '<a href="index.html" class="back link"> <i class="icon icon-back color-white"></i></a>' +
                            ' </div>' +

                           '<div class="content-block deletemargin color-white" style="text-align: center;" >' +
                                '<div class="col-100 acolor ">' +
                                        '<img src="img/tel.png" class="detailimgsize">' +
                                            '<h3 >' + data.name + '</h3>' +
                                            //'<p>' + data.postion + '</p></a>' +
                                '</div>' +
                              ' </div> ' +

                          ' <div class="content-block2 deletemargin detailtopbottom color-white">' +
                                    '<div class="row">' +
                                     ' <div class="col-50 acolor" style="border-right: 1px solid #FFFFFF;"><a href="tel:' + obj[0].input + '"><img src="img/tele.png" class="detailimgsize2"></a></div>' +
                                    '  <div class="col-50 acolor"><a href="sms:' + obj[0].input + '"><img src="img/text.png" class="detailimgsize2"></a></div>' +
                                  '  </div>' +
                                    '<div class="row">' +
                                    '  <div class="col-50 acolor" style="border-right: 1px solid #FFFFFF;">打电话</div>' +
                                   '   <div class="col-50 acolor">发短信</div>' +
                                   ' </div>' +
                           ' </div>' +
                       ' </div>';
            $("#detailtop").html(html2);
        }
    });
});