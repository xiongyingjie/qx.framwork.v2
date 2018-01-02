//	<i class="icon iconfont icon-shanchu txt-color-red mg-l-10 fr wy-dele wy-dele"></i>
$.bindPage(["wx.ent.xmyxy.shop_cartitem@list"
    .jn("shop_batch_goods.batch_good_id")
    .jn("shop_batch.batch_id","shop_batch_goods.batch_id")
    .jn("shop_goods.goods_id","shop_batch_goods.goods_id")
    .eq("uid", "_uid")
],
    ["list", function () {
        /*
                    <div id="container-{shop_batch_goods-batch_good_id}">
                    	<div class="weui-panel__hd"><span>{shop_batch-name}</span>
					<a href="javascript:;" class="wy-dele"></a>
				</div>
				<div class="weui-panel__bd mg-b-10">
					<div class="weui-media-box_appmsg pd-10">
						<div class="weui-media-box__hd">
							<a ><img class="weui-media-box__thumb" src="{shop_goods-photo}" alt=""></a>
						</div>
						<div class="weui-media-box__bd">
							<h1 class="weui-media-box__desc"><a  class="ord-pro-link">{shop_goods-name}</a></h1>
							<div class="clear mg-t-10">
								<div class="wy-pro-pri fl">¥<em class="num font-15">{shop_batch_goods-price}</em></div>
							
								<div class="pro-amount fr">
									<div class="Spinner Spinner-{shop_batch_goods-goods_id}"></div>
								</div>
							</div>
						</div>
					</div>
				</div>
                    </div>
			<script>
          $(".Spinner-{shop_batch_goods-goods_id}").Spinner({
    value: {shop_cartitem-num},
    id:'{shop_batch_goods-batch_good_id}',
    name:'{shop_cartitem-shop_cartitem_id}',
    len: 3,
    min: 0,
    max: 999
});

$('#Increase-{shop_batch_goods-batch_good_id}').click(function () {
    var id=$(this).attr("id").replace("Increase-","");
    "/Json/Shop/AddCart".
      submit({ id: id },
      function (data, code, msg) { 
          if(code==1){
              totalPrice();
          }else{
              $.msg(msg);
              var numObj= $("#Amount-{shop_batch_goods-batch_good_id}");
              numObj.val(Number(numObj.val())-1)
          }  
      });
           
});
$('#Decrease-{shop_batch_goods-batch_good_id}').click(function () {
    var id=$(this).attr("gid").replace("Decrease-","");
     var goods_id=$(this).attr("id").replace("Decrease-","");
    var numObj= $("#Amount-{shop_batch_goods-batch_good_id}");
    //debugger
    if (numObj.val() <= 0) {
        $.confirm("您确定要把此商品从购物车删除吗?", function() {
            "/Json/Shop/ReduceCart".
                submit({ id: id },
                    function(data, code, msg) {
                        if (code == 1) {
                      //  debugger
                            $("#container-"+goods_id).remove();
                              $.msg("已删除");
                            totalPrice();
                        } else {
                            $.msg(msg);
                        }
                    });
        },function(){
           numObj.val(numObj.val()==1?1:Number(numObj.val())+1)
        });
    }
    else{
        "/Json/Shop/ReduceCart".
                    submit({ id: id },
                    function (data, code, msg) {   
                        if(code==1){
                            totalPrice();  
                        } else{
                            $.msg(msg);
                            numObj.val(numObj.val()==1?1:Number(numObj.val())+1)
                        }  
                    });
    }  
});                              
$("#Amount-{shop_batch_goods-batch_good_id}").
    bind("input propertychange", function () {
        totalPrice();
    }
);
       
        </script>
                 
        */
    }, function (data) {
       // debugger
        $.each(data, function (i, o) {
            o["shop_goods-photo"] = $.hasValue(o["shop_goods-photo"]) ? $.url(o["shop_goods-photo"]) : "img/product.png";
        });
        return  data;
    }],
    "", function () {
        totalPrice();
});






function totalPrice() {
    var items = $('.weui-content .weui-panel__bd');
    var length = items.length;
    var price = 0;
    var amount = 0;
    for (var i = 0; i < length; i++) {
        price += parseFloat(items.eq(i).find('em').text()) * parseFloat(items.eq(i).find('.Amount').val());
        amount += parseInt(items.eq(i).find('.Amount').val());
    }
    $('.weui-tabbar .weui-tabbar__item').find('#zong1').text(price.toFixed(2));
    $('.weui-tabbar .promotion-foot-menu-label').find('#amount').text(amount);
    if (price.toFixed(2) > 1000) {
        $('#btn').removeClass('weui-btn weui-btn_warn').addClass('weui-btn weui-btn_disabled weui-btn_warn');
        $('.weui-tabbar .weui-tabbar__item').find('#limitprice').text('(超过上限：￥1000)');
    }
    else {
        $('#btn').addClass('weui-btn weui-btn_warn').removeClass('weui-btn weui-btn_disabled weui-btn_warn');
        $('.weui-tabbar .weui-tabbar__item').find('#limitprice').text('(上限：￥1000)');
    }
    //	计算总价
}

function buy(url) {
    "/Json/Shop/Buy".submit({}, function(data, code, msg) {

        if (code == 1) {
            $.go(url);
        } else {
            $.alert(msg);
        }
    });
}






