
goodsList();

function goodsList(key) {
    if ($.hasValue(key)) {
        
    }
    $.bindPage(["wx.ent.xmyxy.shop_batch_goods@list"
    .jn("shop_goods.goods_id")
    .jn("shop_batch.batch_id")
    .eq("shop_batch.is_current", "1") + ($.hasValue(key) ? "".lk("shop_goods.name", key) : "")
    .ob("seq")
    ],
    ["list", function () {
        /*
                      <div class="pro-items">
                    <div class="weui-media-box weui-media-box_appmsg">
                        <a class="weui-media-box__hd"><img class="weui-media-box__thumb" src="{shop_goods-photo}" alt=""></a>
                        <div class="weui-media-box__bd">
                            <h1 class="weui-media-box__desc">{shop_goods-name}</h1>
                            <div class="wy-pro-pri">¥<em class="num font-15">{shop_batch_goods-price}</em>
                            </div>
                            <ul class="weui-media-box__info prolist-ul weui-flex">
                                <li class="weui-media-box__info__meta weui-flex__item">库存<em class="num">{shop_batch_goods-remain}</em>件</li>
                                <li onclick="addCart('{shop_batch_goods-batch_good_id}')" class="weui-media-box__info__meta"><i class="icon iconfont icon-gouwuche txt-color-red"></i></li>
                            </ul>
                        </div>
                    </div>
                </div>
                 
        */
    }, function (data) {
        $.each(data, function (i, o) {
            o["shop_goods-photo"] = $.hasValue(o["shop_goods-photo"]) ? $.url(o["shop_goods-photo"]) : "img/product.png";
        });
        return data;
    }]);
}

$("#ip_key").keyup(function() {
    goodsList($(this).val());
});


function goToCart(url) {
    $.go(url );
}
function addCart(id) {
    "/Json/Shop/AddCart".
        submit({ id: id },
        function (data, code, msg) {
        $.msg(msg);
    });
}
//function addCart(id) {
//    var url = "";
//    var info = $.q("info") + "";//x1:10;x2:5;x3:10
//    //debugger
//    if (info.indexOf(id)>-1) {
//        //加数量
//        var arr = info.split(';');
//        for (var i = 0; i < arr.length; i++) {
//            var item = arr[i];//原始串
//            if (item.indexOf(id) > -1) {
//                var number = Number(item.split(':')[1]) + 1;
//                url = $.getfullurl().replace(item, id + ":" + number);
//                break;
//            }
//        }
//    } else {
//        if ($.hasValue(info))
//        {//新加商品
//            url = $.getfullurl() + ";" + id + ":1";
//        }else
//        {//第一从点击购物车
//            url = $.getfullurl() + "?info=" + id + ":1";
//        }  
//    }
//    $.go(url);
//}


//查询商品列表
//"wx.ent.xmyxy.shop_batch_goods@list"
//    .jn("shop_goods.goods_id")
//    .jn("shop_batch.batch_id")
//    .eq("shop_batch.is_current", "1")
//    .ob("seq")
//    .excute(function(item) {
//        $.log(item);
//    });
////查询订单列表
//"wx.ent.xmyxy.shop_order@list"
//    .excute(function (item) {
//           $.log(item);
//    });
////提交订单
//"/Json/Shop/Buy".submit({ info: "x1:10;x2:5;x3:10" },
//    function(data,code,msg) {
//        $.log(msg);
//    });
////取消订单
//"/Json/Shop/CancelBuy".submit({ id: "RCZECXH5SRK" },
//    function (data, code, msg) {
//        $.log(msg);
//    });

