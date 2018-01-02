head.ready(function () {

    $.Ajax({
        url: "/Json/Contact/GetPeople",
        success: function (obj, code, msg, url) {
            var html = "";
            for (var i = 0; i < obj.length; i++) {
                var item = obj[i];
                html +=
                    ' <li><a href="detail.html?id=' + obj[i].user_id + '" class="acolor">' +
                    ' <div class="item-content">' +
                    ' <div class="item-media"><img src="img/tel.png" class="Inboximgsize"></div>' +
                    ' <div class="item-inner">' +
                    '   <div class="item-title label">' +
                    '  <span class="telefontcolor1">' + item.name + '</span><br/><span class="telefontcolor2">' + item.father_org + '</span></div>' +
                    '  <div class="item-input">' +
                    '     <span class="telefontcolor3">' + '</span><br/><span class="telefontcolor2">' + item.org + '</span>' +
                    '<div style="display:none">' + item.phone + '</div>' +
                    '  </div>' +
                    ' </div>' +
                    '  </div></a>' +
                    ' </li>' +
                    ' <li>';
            }
            html = '<div class="list-block list-block-search searchbar-found deletemargin" >' +
                ' <ul id="content_news_list">' + html +
                ' </ul>' +
                ' </div>';
            $("#list-block").html(html);
            $(function () {
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
            });


        }
    });


});