function Init(obj) {
    if (obj == undefined) {
        obj = [
                 { knowledge_id: "1", title: "产品演示考核评分表之完整版2012V1.0", owner: "杨文元", create_time: "2015-09-18 17:43:22", modify_time: "2015-09-19 19:43:22" },
        ];
    }

    var html = "";
    for (var i = 0; i < obj.length; i++) {
        var item = obj[i];
        $.log($.parsedate(item.modify_time))
        html +=
         ' <li><a href="detail.html?id=' + item.knowledge_id + '" class="acolor">' +
                 ' <div class="item-link item-content">' +
                   ' <div class="item-inner">' +
                   '   <div class="item-title ">' +
                    '  <div class="telefontcolor1">' + item.title + '</div>' +
                    '<div class="telefontcolor2"><span>创建时间: ' +
                    $.parsedate(item.modify_time) + '</span><span>修改时间: ' +
                    $.parsedate(item.create_time) + '</span><span>所有者: ' + item.owner + '</span></div></div>' +
                   ' </div>' +
                '  </div></a>' +
               ' </li>';
    }
    html = '<div class="list-block list-block-search searchbar-found deletemargin" >' +
        ' <ul id="content_news_list">' + html +
        ' </ul>' +
        ' </div>';
    $("#list-block").html(html);



    var $allLi = $("#content_news_list").children();
    $("#c11").keyup(function () {
        var searchText = $(this).val(); //获取输入的搜索内容 
        if (searchText == "") {
            $("#content_news_list").html($allLi).clone();
        } else {
            $("#content_news_list").html($allLi).clone();
            var $searchLi = ""; //预备对象，用于存储匹配出的li  

            if (searchText != "") {

                //获取所有匹配的li  
                $searchLi = $("#content_news_list").find('a:contains(' + searchText + ')').parent();

            }

            //将获取的元素追加到列表中  
            $("#content_news_list").html($searchLi).clone();

            //判断搜索内容是否有效，若无效，输出not find  
            if ($searchLi.length <= 0) {
                $("#content_news_list").html(
                    ' <li>' +
                    '   <div style=" text-align: center; line-height: 50px;">' +
                    ' not found</div>' +
                    ' </li>');
            }
        }
    });
}


ready(function () {
    //Init();
    var tid = $.q("id");
    $.Ajax({
        url: "/Json/Knowledge/All",
        data: { id: tid },
        success: function (obj, code, msg, url) {
            var title = "";
            if (tid == "1") {
                title = "岗位知识";
            } else if (tid == "2") {
                title = "制度知识";
            } else if (tid == "3") {
                title = "培训课件";
            } else {
                title = "全部";
            }
            $("#title").text(title);
            Init(obj);
        }
    });
});