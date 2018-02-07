
$.bindPage(
	["wx.ent.xmyxy.T_YQJ_QJLXB@items&name=LXMC",
	"wx.ent.xmyxy.T_YQJ_JCB@items&name=JCMC"],
[],function(data) {
		var items1 = data["_db_index_cmd_wx.ent.xmyxy.T_YQJ_JCB-items"];//节数
		$.fillSelect("T_YQJ_XSQJXXB_KSJCDM", items1);
		$.fillSelect("T_YQJ_XSQJXXB_JSJCDM", items1);
		$.fillSelect("T_YQJ_XSQJXXB_LXDM", data["_db_index_cmd_wx.ent.xmyxy.T_YQJ_QJLXB-items"]);
		return data;
	}
);          
function subrecord() {
	$.submitPage("wx.ent.xmyxy.T_YQJ_XSQJXXB@add",function(data,code) {
		$.msg("提交成功");
		//$.go(-1, 3);
	},function(data) {
		data["WID"] = $.random();
		return data;
	});
}     
