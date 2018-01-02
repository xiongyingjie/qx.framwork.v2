Init();
function Init() {
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

$.bindPage("/Json/Announcement/Index", ["content_news_list", function () {
    /*
    <li>
                                    <a href="detail.html?id={PK_ID} " class="acolor">
                                         
                                          <div class=" item-content">
                                             
                                              <div class="item-inner">
                                                 
                                                    <div class="item-title ">
                                                     
                                                       <div class="telefontcolor1" ><span>[{LB}]</span><span>{TITLE}</span></div> 
                                                          <div class="telefontcolor2">
                                                        <span>
                                                          作者: {DEPART_NAME} ( {FIRST_NAME} ) 
                                                        </span><span>
                                                            发布日期:  {PUBLISH_DATE}
                                                        </span>
                                                      
                                                    </div>
                                                </div> 
                                                 
                                            </div> 
                                             
                                        </div>
                                    </a> 
                                     
                                </li>
    */
}, function (data) {
    return data["_Json_Announcement_Index"];
    //[{ "kajdfldfg-title": "通过公告测试", "kajdfldfg-lb": "报告专栏", "kajdfldfg-first_name": "系统管理员", "kajdfldfg-depart_name": "教务处", "kajdfldfg-date": "2014-06-10" },
    //                                    { "kajdfldfg-title": "第六周会议，活动安排", "kajdfldfg-lb": "报告专栏", "kajdfldfg-first_name": "章一莎", "kajdfldfg-depart_name": "办公室", "kajdfldfg-date": "2016-06-10" },
    //                                    { "kajdfldfg-title": "关于举办厦门医学院第十八届田径运动会的通知", "kajdfldfg-lb": "报告专栏", "kajdfldfg-first_name": "章一莎", "kajdfldfg-depart_name": "办公室", "kajdfldfg-date": "2015-06-10" }];
}]);
//$.Ajax({
//    url: "/Json/Announcement/Index",
//    success: function (data) {
//        $.log(data);
//    }
//});
/*

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
});*/