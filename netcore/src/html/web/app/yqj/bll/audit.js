
$.bindPage(
	"wx.ent.xmyxy.T_YQJ_XSQJXXB@list".eq("STATUS_ID","1").
    jn("T_YQJ_XSJBXX.XH","T_YQJ_XSQJXXB.XH").
	jn("T_YQJ_QJLXB.LXDM","T_YQJ_XSQJXXB.LXDM").
	jn("T_YQJ_STATUS.STATUS_ID","T_YQJ_XSQJXXB.STATUS_ID").
	ls("T_YQJ_XSQJXXB.TS","3")

, [	"tab1", function() {
		/*
		 <div class="card facebook-card" style="margin-top: 12px;">
               <div class="card-header">
                   
                  <div class="facebook-name"><span>{T_YQJ_XSQJXXB-XH}</span><span>{T_YQJ_XSJBXX-XM}</span> <span>{LXMC}</span> </div>
                  
                </div>
                <div class="card-footer"><span><a>同意</a></span><span><a>查看</a></span></div>
               </div>
    */
	}]);               


//("/Json/Bx/GetUserInfo?userid=" + request_man).query(function (data) {
 //           $(".request_man").val(data);
 //       });

