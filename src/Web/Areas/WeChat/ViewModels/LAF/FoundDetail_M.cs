using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Qx.Wechat.LostAndFound.Models;

namespace Web.Areas.WeChat.ViewModels.LostAndFound
{
    public class FoundDetail_M
    {
        public static FoundDetail_M ToViewModel(FoundThingNotice FoundDetail, string UserID)
        {
            return new FoundDetail_M()
            {
                FoundDetail = FoundDetail,
                UserID = UserID
            };
        }

        public FoundThingNotice FoundDetail { get; set; }


        public string UserID { get; set; }
    }
}