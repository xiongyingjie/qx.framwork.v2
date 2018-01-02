$.bindPage("wx.bx.device_record@list"
    .jn("device.device_id", "device_record.device_id")
    .jn("employ.user_id", "device_record.request_man").in("state", [-1, 1, 2, 3, 4,5]).eq("charge_man", "_uid"), [
    "tab1list", function() {
        /* 
          		<div class="weui-cells">
          			<div class="weui-cell">
            			<div class="weui-cell__hd">
            				<span class="weui-badge" style="margin-left: 5px;">{index}</span>
            			</div>   		
            			<div class="weui-cell__bd"><a href="hitchedDetail.html?id={device_record_id}">
            				<table>
            					<tbody><tr>
            						<th>被检地点</th>
            						<td id="addname_{index}"></td>
            					</tr>
                                <tr>
            						<th>设备名称</th>
            						<td>{device-name}</td>
            					</tr>
            					<tr>
            						<th>报修人员</th>
            						<td>{employ-name}</td>
            					</tr>
                                <tr>
            						<th>报修时间</th>
            						<td>{device_record-req_time}</td>
            					</tr>
            					<tr>
            						<th>巡检确认时间</th>
            						<td>{device_record-confirm_time}</td>
            					</tr>
            				</tbody></table>
                          </a>
            			</div>
                       
        			</div>
	        	</div>

    */
    }, function(data) {
        $.each(data, function (i, o) {
            //debugger
            o.index = i + 1;
            var addr_id = o.address_id;
            ("/Json/Bx/GetAddrDetail?addrid=" + addr_id).query(function (data) {
                $("#addname_"+o.index).text(data);
            });
        });
        return data;
    }
    ]);
$.bindPage("wx.bx.device_record@list"
    .eq("state", 0)
    .jn("device.device_id", "device_record.device_id")
    .jn("employ.user_id", "device_record.request_man"), [
"tab2list", function () {
    /*
        		<div class="weui-cells">
          			<div class="weui-cell">
            			<div class="weui-cell__hd">
            				<span class="weui-badge" style="margin-left: 5px;">{index}</span>
            			</div>
            			<div class="weui-cell__bd"><a href="hitchDetail.html?id={device_record_id}">
            				<table>
            					<tr>
            						<th>被检地点</th>
            						<td id="addrname_{index}"></td>
            					</tr>
                                <tr>
            						<th>设备名称</th>
            						<td>{device-name}</td>
            					</tr>
            					<tr>
            						<th>报修人员</th>
            						<td>{employ-name}</td>
            					</tr>
            					<tr>
            						<th>报修时间</th>
            						<td>{device_record-req_time}</td>
            					</tr>
            				</table></a>
            			</div>
        			</div>
	        	</div>  
    */
}, function (data) {
    $.each(data, function (i, o) {
        o.index = i + 1;
        var addr_id = o.address_id;
        ("/Json/Bx/GetAddrDetail?addrid=" + addr_id).query(function (data) {
            $("#addrname_" + o.index).text(data);
        });
    });
    return data;
}
])