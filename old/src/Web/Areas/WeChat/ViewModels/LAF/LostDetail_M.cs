using Qx.Wechat.LostAndFound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels.LostAndFound
{
    public class LostDetail_M
    {
        public static LostDetail_M ToViewModel(LostThingNotice LostDetail, string UserID)
        {
            return new LostDetail_M()
            {
                LostDetail= LostDetail,
                UserID= UserID
            };
        }

        public LostThingNotice LostDetail { get; set; }

        public string UserID { get; set; }
    }
}