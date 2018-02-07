render([
    group([
showInput('报修记录编号', 'device_record-device_record_id', '', '4'),
showInput('设备编号', 'device_record-device_id', '', '4'),
showInput('设备名称', 'device_record-name', '', '4'),
showInput('报修人', 'device_record-request_man', '', '4'),
showTime('报修时间', 'device_record-req_time', '', '4'),
//showInput('0：待确认-1已确认1已派工2维修完成3已安排回访4已回访5结单', 'device_record-state', '((0))', '4'),
showInput('故障描述', 'device_record-remark', '', '4')

    ], '标题')], '', 'wx.bx.device_record@find&id=' + q.id.jn("device.device_id", "device_record.device_id").jn("employ.user_id", "request_man"), '', '详情');