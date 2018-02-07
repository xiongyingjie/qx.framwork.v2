//var record_id = $.q("id");
var record_id = "10001";
$.bindPage("wx.bx.tb_RepairRecords@list".jn("tb_ReqRecords.number", "req_number").eq("req_number", record_id), [
    "checkdetail", function() {
        /*
 <div  class="weui-tab__bd-item weui-tab__bd-item--active">
                    <div class="weui-cells deletemargin">
                        <div class="weui-cell">
                            <div class="weui-cell__hd">
                                <img src="images/flex.png">
                            </div>
                            <div class="weui-cell__bd">
                                <table>
                                    <tr>
                                        <th>设备名称</th>
                                        <td>{tb_ReqRecords-device_class}</td>
                                    </tr>
                                    <tr>
                                        <th>设备编号</th>
                                        <td>{tb_ReqRecords-device_id}</td>
                                    </tr>
                                    <tr>
                                        <th>报修地点</th>
                                        <td>{tb_ReqRecords-first_addr}/{tb_ReqRecords-second_addr}</td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                     </div>
                    <div class="card facebook-card">
                        <div class="card-footer">报修信息 <span>{tb_ReqRecords-number}</span></div>
                        <div class="weui-cells deletemargin">
                            <div class="weui-cell">
                                <div class="weui-cell__bd">
                                    <p>报修人</p>
                                </div>
                                <div class="weui-cell__ft">{tb_ReqRecords-request_man}</div>
                            </div>
                            <div class="weui-cell">
                                <div class="weui-cell__bd">
                                    <p>故障语音</p>
                                </div>
                                <div class="weui-cell__ft">暂无语音</div>
                            </div>
                            <div class="weui-cell">
                                <div class="weui-cell__bd">
                                    <p>故障类型</p>
                                </div>
                                <div class="weui-cell__ft">{tb_ReqRecords-details}</div>

                            </div>
                            <div class="weui-cell">
                                <div class="weui-cell__bd">
                                    <p>故障语音</p>
                                </div>
                                <div class="weui-cell__ft">暂无语音</div>
                            </div>
                           
                            <div class="weui-cell">
                                
                                <div class="weui-cell__bd">
                                    <textarea class="weui-textarea" placeholder="{tb_ReqRecords-remark}" rows="3" id="i"></textarea>
                                  
                                </div>

                            </div>
                            <div class="weui-cell">
                                <div class="weui-cell__hd">
                                   {tb_RepairRecords-photo}
                                </div>
                             
                            </div>
                         </div>
                      
                    </div>
                    <div class="card facebook-card">
                        <div class="card-footer">派工信息 <span>{tb_ReqRecords-finish_time}</span></div>
                        <div class="weui-cells deletemargin">
                            <div class="weui-cell">
                                <div class="weui-cell__bd">
                                    <p>派工人</p>
                                </div>
                                <div class="weui-cell__ft">{tb_RepairRecords-task_man}</div>
                            </div>
                            <div class="weui-cell">

                                <div class="weui-cell__bd">
                                    <textarea class="weui-textarea" placeholder="故障备注" rows="3" id="i"></textarea>

                                </div>

                            </div>
                        </div>

                    </div>
                    <div class="card facebook-card">
                        <div class="card-footer">维修信息 <span>{tb_RepairRecords-repair_time}</span></div>
                        <div class="weui-cells deletemargin">
                            <div class="weui-cell">
                                <div class="weui-cell__bd">
                                    <p>维修负责人</p>
                                </div>
                                <div class="weui-cell__ft">{tb_RepairRecords-repair_man}</div>
                            </div>
                            <div class="weui-cell">
                                <div class="weui-cell__bd">
                                    <p>设备维修状态</p>
                                </div>
                                <div class="weui-cell__ft">{state_name}</div>
                            </div>
                            <div class="weui-cell">
                                <div class="weui-cell__bd">
                                    <p>维修详情</p>
                                </div>
                                <div class="weui-cell__ft">
                                    {tb_ReqRecords-remark}   
                                    </div>
                            </div>
                            <div class="weui-cell">
                                <div class="weui-cell__bd">
                                    <p>更换部件</p>
                                </div>
                                <div class="weui-cell__ft">未更换部件</div>
                            </div>
                            <div class="weui-cell">
                                <div class="weui-cell__hd">
                                    未上传附件
                                </div>
                            </div>
                        </div>

                    </div>
               
                    <div class="placeholder return">
                        返回
                    </div>
             </div>
    
*/
    }, function (data) {
        $.each(data, function (i,o) {
                switch (o.state) {
                case "0":
                    o.state_name = "维修未完成";
                    break;
                case "1":
                    o.state_name = "维修完成";
                    break;
                default:
                }
            });
        }
]
);




