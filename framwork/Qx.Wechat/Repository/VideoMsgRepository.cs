using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;
using Qx.Wechat.Entity;
using Qx.Wechat.Services;

namespace Qx.Wechat.Repository
{


    public class VideoMsgRepository : BaseRepository, IRepository<VideoMsg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.VideoMsgs.Select(a => new SelectListItem() { Text = a.MsgId.ToString(), Value = a.MsgId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(VideoMsg model)
        {
            model.MsgId = Pk;
            if (Find(model.MsgId) == null)
            {
                return Db.SaveAdd(model) ? Pk.ToString() : null;
            }
            else
            {
                return "";
            }
        }

        public bool Delete(object id)
        {
            return Db.SaveDelete(Find(id));
        }

        public bool Update(VideoMsg model, string note = "")
        {
            if (Find(model.MsgId) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public VideoMsg Find(object id)
        {
            return Db.VideoMsgs.NoTrackingFind(a=>a.MsgId == (string) id);
        }

        public List<VideoMsg> All()
        {
            return Db.VideoMsgs.NoTrackingToList();
        }

        public List<VideoMsg> All(Func<VideoMsg, bool> filter)
        {
            return Db.VideoMsgs.NoTrackingWhere(filter);
        }
    }
}
