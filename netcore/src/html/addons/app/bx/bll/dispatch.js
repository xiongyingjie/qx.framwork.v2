$.bindPage("wx.bx.device_record@list".eq("state", -1).
    jn("employ.user_id", "device_record.request_man").
    jn("device.device_id", "device_record.device_id").
    jn("hitch_type.hitch_type_id", "device_record.hitch_type_id"), [
    "tab1", function() {
        /*
<div class="card facebook-card">
                    <div class="card-header">
                        <div class="facebook-date">报修人：{employ-name}</div>
                    </div>
                   
                   
                    <div class="card-content">
                        <table>
                            <tr>
                                <th>报修编号</th>
                                <td>{device_record-device_record_id}</td>

                            </tr>
                            <tr>
                                <th>设备名称</th>
                                <td>{device-name}</td>
                            </tr>
                            <tr>
                               <th>报修点</th>
            				<td id="addrname_{index}"></td>
                            </tr>
                            <tr>
                                <th>故障类型</th>
                                <td>{hitch_type-name}</td>
                            </tr>
                      
                            <tr>
                                <th>报修时间</th>
                                <td>{device_record-req_time}</td>
                            </tr>
                        </table>
                      
                    </div>
                    <div class="card-footer">未处理<span style="color:rgb(68,146,235);"><a href="dispatchdetail.html?id={device_record_id}">派工</a></span></div>
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
]);

$.bindPage("wx.bx.device_record@list".in("state", [1,2,3,4,5]).
    jn("employ.user_id", "device_record.request_man").
    jn("device.device_id", "device_record.device_id").
    jn("address.address_id", "device.address_id").
    jn("hitch_type.hitch_type_id", "device_record.hitch_type_id"), [
    "tab2", function() {
        /*
<div class="card facebook-card">
                    <div class="card-header">
                        <div class="facebook-date">报修人：{employ-name}</div>
                        <div class="facebook-date"> 当前负责人：<span id="charge_man_{index}"> {charge_man}</span></div>
                    </div>

                    <div class="card-content">
                        <table>
                            <tr>
                                <th>报修编号</th>
                                <td>{device_record-device_record_id}</td>

                            </tr>
                            <tr>
                                <th>设备名称</th>
                                <td>{device-name}</td>
                            </tr>
                             <tr>
                               <th>报修点</th>
            				<td id="addr2name_{index}"></td>
                            </tr>
                            <tr>
                                <th>故障类型</th>
                                <td>{hitch_type-name}</td>
                            </tr>

                            <tr>
                                <th>报修时间</th>
                                <td>{device_record-req_time}</td>
                            </tr>
                        </table>

                    </div>
                    <div class="card-footer">已派工 <span style="color:rgb(68,146,235);"></span><span>待回访</span></div>
                </div>
              */
    }, function (data) {
        $.each(data, function (i, o) {
            o.index = i + 1;
            var addr_id = o.address_id;
            var char_man = o.charge_man;
            ("/Json/Bx/GetUserInfo?userid=" + char_man).query(function (data) {
                $("#charge_man_"+o.index).text(data);
            });
            ("/Json/Bx/GetAddrDetail?addrid=" + addr_id).query(function (data) {
                $("#addr2name_" + o.index).text(data);
            });
        });
        return data;
    }
]);

