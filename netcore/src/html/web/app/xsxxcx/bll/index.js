
var time = new Date();
$.bindPage([
	"wx.ent.xmyxy.T_ZH_REC_CONSUME@list".eq("CUSTOMERID", "_uid")
	.ob("OPDT", "+"),
	"wx.ent.xmyxy.T_TS_JY@list".eq("SFRZH", "_uid").ls("YHRQ","_now"),
    "wx.ent.xmyxy.T_JW_CJGL_XSCJXX@list".eq("XH", "_uid"),
    "wx.ent.xmyxy.bind_user_student@list".eq("user_id", "_uid")
], [
    ], function (data) {
    var balance = data["_db_index_cmd_wx.ent.xmyxy.T_ZH_REC_CONSUME-list"];
    var scoreList = data["_db_index_cmd_wx.ent.xmyxy.T_JW_CJGL_XSCJXX-list"];
    var stuInfo = data["_db_index_cmd_wx.ent.xmyxy.bind_user_student-list"];
    data.num = balance.length > 0 ? balance[0].ODDFARE:"0";
    data.scroe = scoreList.length > 0 ? scoreList[0].JD : "0";
    var date = 0;
	$.each(data["_db_index_cmd_wx.ent.xmyxy.T_TS_JY-list"], function(i, o) {
	    date ++;
	});
	
   // data.num = data["_db_index_cmd_wx.ent.xmyxy.T_ZH_REC_CONSUME-list"][0].ODDFARE;

    data.bookCount = date;
    data.stuNo = stuInfo[0].stu_id;
     
    return data;
});






