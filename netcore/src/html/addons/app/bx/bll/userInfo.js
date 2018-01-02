
$.bindPage("/Open/UserInfo", [], function (data) {
    $("#lb_units").html($.toObject(data.units).name);
    return data;
});
//待修记录
$.bindPage("wx.bx.device_record@list"
    .jn("device.device_id", "device_record.device_id")
    .jn("hitch_type.hitch_type_id", "device_record.hitch_type_id")
    .eq("device_record.repair_man", "_uid")
    .eq("device_record.state", 1), [
    "tab1", function () {
        /*
<div class="card facebook-card">
        <div class="card-header">
                          <div class="facebook-date">报修人：<span id="request_man1_{index}"> {request_man}</span></div>
                        <div class="facebook-date"> 当前负责人：<span id="charge_man1_{index}"> {charge_man}</span></div>
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
                    <td id="addr1name_{index}"></td>
                </tr>
                <tr>
                    <th>故障类型</th>
                    <td>{hitch_type-name}</td>
                </tr>

                <tr>
                    <th>报修时间</th>
                    <td>{device_record-req_time}</td>
                                            <th>派工时间</th>
                    <td>{device_record-arrange_time}</td>
                </tr>
            </table>
        </div>
        <div class="card-footer"><span></span><span><a href="repairdetail.html?id={device_record-device_record_id}">填写维修记录</a></span></div>
    </div>
  */
    },function (data) {
    $.each(data, function (i, o) {
        o.index = i + 1;
        var addr_id = o.address_id;
        var request_man = o.request_man;
        var charge_man = o.charge_man;
        ("/Json/Bx/GetUserInfo?userid=" + request_man).query(function (data) {
            $("#request_man1_" + o.index).text(data);
        }); ("/Json/Bx/GetUserInfo?userid=" + charge_man).query(function (data) {
            $("#charge_man1_" + o.index).text(data);
        });
        ("/Json/Bx/GetAddrDetail?addrid=" + addr_id).query(function (data) {
            $("#addr1name_" + o.index).text(data);
        });
    });
    return data;
}
]);
//已修记录
$.bindPage("wx.bx.device_record@list"
    .jn("device.device_id", "device_record.device_id")
    .jn("hitch_type.hitch_type_id", "device_record.hitch_type_id")
    .in("device_record.state", [2, 3, 4,5])
    .eq("device_record.repair_man", "_uid"), [
    "tab2", function () {
        /*

<div class="card facebook-card">
        <div class="card-header">
                        <div class="facebook-date">报修人：<span id="request_man2_{index}"> {request_man}</span></div>
                        <div class="facebook-date"> 当前负责人：<span id="charge_man2_{index}"> {charge_man}</span></div>
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
                     <th>派工时间</th>
                    <td>{device_record-arrange_time}</td>
                </tr>
            </table>
        </div>
        <div class="card-footer"><span></span><span><a href="repairdetailed.html?id={device_record-device_record_id}">查看记录</a></span></div>
    </div>
  */
    }, function (data) {
        $.each(data, function (i, o) {
            o.index = i + 1;
            var addr_id = o.address_id;
            var request_man = o.request_man;
            var charge_man = o.charge_man;
            ("/Json/Bx/GetUserInfo?userid=" + request_man).query(function (data) {
                $("#request_man2_" + o.index).text(data);
            }); ("/Json/Bx/GetUserInfo?userid=" + charge_man).query(function (data) {
                $("#charge_man2_" + o.index).text(data);
            });
            ("/Json/Bx/GetAddrDetail?addrid=" + addr_id).query(function (data) {
                $("#addr2name_" + o.index).text(data);
            });
        });
        return data;
    }
    ]);
//待回访记录
$.bindPage("wx.bx.device_record@list"
    .jn("device.device_id", "device_record.device_id")
    .jn("hitch_type.hitch_type_id", "device_record.hitch_type_id")
    .eq("device_record.state", 3)
    .eq("device_record.revisit_man", "_uid"), ["tab3", function() {
        /*
 
 <div class="card facebook-card">
         <div class="card-header">
                        <div class="facebook-date">报修人：<span id="request_man3_{index}"> {request_man}</span></div>
                        <div class="facebook-date"> 维修人：<span id="repair_man3_{index}">  {repair_man}</span></div>
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
                     <td id="addr3name_{index}"></td>
                 </tr>
                 <tr>
                     <th>故障类型</th>
                     <td>{hitch_type-name}</td>
                 </tr>
 
                 <tr>
                     <th>报修时间</th>
                     <td>{device_record-req_time}</td>
                                             <th>派工时间</th>
                     <td>{device_record-arrange_time}</td>
                 </tr>
             </table>
         </div>
         <div class="card-footer"><span></span><span><a href="reexamrecord.html?id={device_record-device_record_id}">填写回访记录</a></span></div>
     </div>
   */
    }, function (data) {
        $.each(data, function (i, o) {
            o.index = i + 1;
            var addr_id = o.address_id;
            var request_man = o.request_man;
            var repair_man = o.repair_man;
            ("/Json/Bx/GetUserInfo?userid=" + request_man).query(function (data) {
                $("#request_man3_" + o.index).text(data);
            }); ("/Json/Bx/GetUserInfo?userid=" + repair_man).query(function (data) {
                $("#repair_man3_" + o.index).text(data);
            });
            ("/Json/Bx/GetAddrDetail?addrid=" + addr_id).query(function (data) {
                $("#addr3name_" + o.index).text(data);
            });
        });
        return data;
    }
    ]);
//已回访记录
$.bindPage("wx.bx.device_record@list"
    .jn("device.device_id", "device_record.device_id")
    .jn("hitch_type.hitch_type_id", "device_record.hitch_type_id")
    .in("device_record.state", [ 4,5])
    .eq("device_record.revisit_man", "_uid"), ["tab4", function() {
        /*

<div class="card facebook-card">
<div class="card-header">
                        <div class="facebook-date">报修人：<span id="request_man4_{index}"> {request_man}</span></div>
                        <div class="facebook-date"> 维修人：<span id="repair_man4_{index}">  {repair_man}</span></div>
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
           <td id="addr4name_{index}"></td>
        </tr>
        <tr>
            <th>故障类型</th>
            <td>{hitch_type-name}</td>
        </tr>
          <tr>
            <th>维修详情</th>
            <td>{repair_note}</td>
        </tr>
    </table>
</div>
<div class="card-footer"><span></span><span><a href="reexamrecorddetail.html?id={device_record-device_record_id}">查看记录</a></span></div>
</div>
*/
    }, function (data) {
        $.each(data, function (i, o) {
            o.index = i + 1;
            var addr_id = o.address_id;
            var request_man = o.request_man;
            var repair_man = o.repair_man;
            ("/Json/Bx/GetUserInfo?userid=" + request_man).query(function (data) {
                $("#request_man4_" + o.index).text(data);
            }); ("/Json/Bx/GetUserInfo?userid=" + repair_man).query(function (data) {
                $("#repair_man4_" + o.index).text(data);
            });
            ("/Json/Bx/GetAddrDetail?addrid=" + addr_id).query(function (data) {
                $("#addr4name_" + o.index).text(data);
            });
        });
        return data;
    }
    ]);
("wx.bx.employ@list".jn("employ_type.type_id", "employ.type").eq("user_id", $.user_id())).query(function (data) {
    if (data.length == 0) {
        $.alert("请联系管理员进行身份认证");
        return;
    }
    $("#emmployee_type").text(data[0]["employ_type-name"]);
});