function Init(obj2) {
    if (obj2 == undefined) {
        obj2 =
          { title: "雅鲁漂流—大奇山2日团队游.pdf", owner: "系统管理员", last_modifyer: "系统管理员", modify_time: "2015-09-19 19:43:22", introduce: "哈哈哈" };

    }
    // $.log(obj2.introduce);
    var html2 = "";
    html2 = '<div class="detailtop">' +
        '<div class="title">' +
        '<a href="index.html?id=' + obj2.knowledge_type_id + '" class="back link"> <i class="icon icon-back color-black"></i></a>' + obj2.title + '</div>' +
        '<div class=" media-list">' +
        '<a href="#"class="acolor">' +
        '<div class="content-block">' +
        '<div class="row no-gutter">' +
        '<div class="col-20"><div class="item-media"><img src="img/tel.png" class="Inboximgsize"></div></div>' +
        '<div class="col-80">' +
        '<div class="row no-gutter">' +
        '<div class="item-tit">' + obj2.owner + '<img src="img/read.png"  class="readimg">(<span>0</span>)</div></div>' +
        '<div class="row">' +
        '<div class="item-text"><span>最后修改:' + obj2.last_modifyer + '</span><span>' + $.parsedate(obj2.modify_time) + '</span></div>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '</a>' +
        '</div>' +
        '<div class="interdoce">' + $.htmlDecode(obj2.introduce) +
        '</div>';
    var files = obj2.files.split(';');


    if (files.length > 0 && files[0] != "") {
        html2 +=
            '<div class="content-block-title">附件下载</div>';

        for (var u = 0; u < files.length; u++) {
            html2 += '<div class="list-block ">' +
                '<ul>' +
                '<li class="item-content" style="background-color:#ffffff;">' +
                '<div class="item-inner">' +
                '<div class="item-title">' + $.getFileName(files[u]) + '</div>' +
                '<div class="item-after"><span style="font-size:10px;padding:9px 2px;"> </span><a href="' + $.url(files[u]) + '"><img src="img/download.png" class="downimg"></a></div>' +
                '</div>' +
                '</li>' +
                '</ul>' +
                '</div>';
        }

        html2 += '</div>';
    }

    $("#detailtop").html(html2);
}
head.ready(function () {
    var tid = $.q("tid");

    $.Ajax({
        url: "/Json/Knowledge/Find",
        data: { id: $.q("id") },
        success: function (obj2, code, msg, url) {
            Init(obj2);

        }
    });


})