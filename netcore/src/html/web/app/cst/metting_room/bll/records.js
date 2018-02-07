
init();
function init(key) {
    $.bindPage('app.cst.metting_order@list'
        .jn('metting_room.metting_room_id', 'metting_order.metting_room_id')
        .jn('metting_order_state.metting_order_state_id', 'metting_order.metting_order_state_id')
        .jn('metting_order_time_span.metting_order_time_span_id', 'metting_order.metting_order_time_span_id')
        .lk('metting_order.name', key)
        .eq('metting_order.uid', '_uid'),
        [
            "list", function() {
                /*
        	<div  class="card facebook-card" >
                 <div class="card-header">
                  <div class="facebook-avatar"><img src="http://lorempixel.com/68/68/people/1/" width="34" height="34"></div>
                  <div class="facebook-name">{metting_room-name}</div>
                  <div class="facebook-date">
                  会议名称： <span style="color:orange">{metting_order-name}</span> &nbsp;
                  预计到会人数：<span style="color:orange"> {metting_order-person_num}</span>
                  </div>
                </div>
                <div class="card-content">
                   
                </div>
                <div class="card-footer">
                预约时间: &nbsp;{metting_order-time}  {metting_order_time_span-name}<span style="color:orange">{metting_order_state-name}</span></div>
              </div> 
        </div>
      
        */
            }
        ]);
}
$("#ip_name").keyup(function(o) {
   init($(o.target).val());
})