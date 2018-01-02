using Qx.Wechat.LostAndFound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.WeChat.ViewModels.LostAndFound
{
    public class LostList_M
    {
        public static LostThingNotice_M ToViewModel(List<LostThingNotice> lostlist, string UserID)
        {
            return new LostThingNotice_M()
            {
                _Lostlist = lostlist,
                _UserID = UserID
            };
        }
        public List<LostThingNotice> _Lostlist { get; set; }
        public string _UserID { get; set; }
    }
}