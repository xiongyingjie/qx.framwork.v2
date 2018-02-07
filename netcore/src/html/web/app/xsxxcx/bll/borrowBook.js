
$.bindPage(
	"wx.ent.xmyxy.T_TS_JY@list".eq("SFRZH", "_uid").ls("YHRQ", "_now"),
[
	"contain", function() {
		/*
	<div class="card-header">
                    <div class="facebook-name">书名：{TSMC} <span></span></div>
                    <div class="facebook-date">借书日期：{JSRQ} <span> </span></div>
                    <div class="facebook-date">应还日期：{YHRQ}</div>
                </div>
				 <div class="card-footer" style="color:#F00">&nbsp;<span>超期</span></div>
    */
	}
]);


$.bindPage(

  "wx.ent.xmyxy.T_TS_JY@list".eq("SFRZH", "_uid").bg("YHRQ","_now"),

   ["contain2", function () {
    /*
	<div class="card-header">
                    <div class="facebook-name">书名：{TSMC} <span></span></div>
                    <div class="facebook-date">借书日期：{JSRQ} <span> </span></div>
                    <div class="facebook-date">应还日期：{YHRQ}</div>
                </div>
				 <div class="card-footer" >&nbsp;<span>未到期</span></div>
    */
}])