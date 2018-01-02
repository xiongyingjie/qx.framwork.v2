waitCheck();
function waitCheck() {
    $("#bt-finished").removeClass("weui-bar__item--on");
    $("#bt-waitCheck").addClass("weui-bar__item--on");
   
  
    refresh(1);
}
function finished() {
    $("#bt-waitCheck").removeClass("weui-bar__item--on");
    $("#bt-finished").addClass("weui-bar__item--on");

    refresh(2);
}
function refresh(state) {
    $("#tab").html("");

    $.bindPage(["wx.ent.xmyxy.shop_order_detail@list"
     .jn("shop_order.order_id")
     .jn("shop_batch_goods.batch_good_id")
     .jn("shop_batch.batch_id", "shop_batch_goods.batch_id")
     .jn("shop_goods.goods_id", "shop_batch_goods.goods_id")
     .eq("shop_batch.is_current", "1")
     .eq("shop_order.uid", "_uid")
      .eq("shop_order.state", state)
     .ob("shop_batch_goods.seq")
    ],
     ["tab", [
         function () {
             /*
                                  <div class="weui-media-box_appmsg ord-pro-list">
                                         <div class="weui-media-box__hd">
                                             <a href="pro_info.html"><img class="weui-media-box__thumb" src="{shop_goods-photo}" alt=""></a>
                                         </div>
                                         <div class="weui-media-box__bd">
                                             <h1 class="weui-media-box__desc"><a  class="ord-pro-link">{shop_goods-name}</a></h1>
                                             
                                             <div class="clear mg-t-10">
                                                 <div class="wy-pro-pri fl">¥<em class="num font-15">{shop_batch_goods-price}</em></div>
                                                 <div class="pro-amount fr"><span class="font-13">数量×<em class="name">{shop_order_detail-num}</em></span></div>
                                             </div>
                                         </div>
                                     </div>
                      
             */
         }, function () {
             /*
                          <div id="order-{shop_order-order_id}" class="weui-panel weui-panel_access">
                                 <div class="weui-panel__hd"><span>节日：{shop_batch-name} (订单号:{shop_order-order_id})</span><i onclick="deleteOrder('{shop_order-order_id}')" class="icon iconfont icon-shanchu fr"></i></div>
                                 <div class="weui-media-box__bd  pd-10">
                                 {sub-tpl}
                                 </div>
                                 <div class="ord-statistics">
                                     <span>共<em class="num">{totalNum}</em>件商品，</span>
                                     <span class="wy-pro-pri">总金额：¥<em class="num font-15">{totalPrice}</em></span>
                                 </div>
                             </div>
                      
             */
         }, function (data) {
             data[0].totalPrice = 0;
             data[0].totalNum = 0;
             for (var i = 0; i < data.length; i++) {
                 data[0].totalPrice += Number(data[i]["shop_order_detail-price"]) * Number(data[i]["shop_order_detail-num"]);
                 data[0].totalNum += Number(data[i]["shop_order_detail-num"]);
             }
             return data[0];
         }]
     ],function(data) {
         $.each(data, function (i, o) {
             o["shop_goods-photo"] = $.hasValue(o["shop_goods-photo"]) ? $.url(o["shop_goods-photo"]) : "img/product.png";
         });
         return data;
    });
}

function deleteOrder(id) {
    $.confirm("删除后不可撤销,确认删除订单吗？", function() {
        ("/Json/Shop/CancelBuy?id=" + id).submit({ id: id },
            function (data, code, msg) {
            $.alert(msg);
            if (code == 1) {
                $("#order-" + id).remove();
            }
        });
    });


}