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


    public class ReplyMusicMsgRepository : BaseRepository, IRepository<ReplyMusicMsg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ReplyMusicMsgs.Select(a => new SelectListItem() { Text = a.MusicURL.ToString(), Value = a.ReplyMsgId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(ReplyMusicMsg model)
        {
            model.ReplyMsgId = Pk;
            if (Find(model.ReplyMsgId) == null)
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

        public bool Update(ReplyMusicMsg model, string note = "")
        {
            if (Find(model.ReplyMsgId) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public ReplyMusicMsg Find(object id)
        {
            return Db.ReplyMusicMsgs.NoTrackingFind(a=>a.ReplyMsgId == (string) id);
        }

        public List<ReplyMusicMsg> All()
        {
            return Db.ReplyMusicMsgs.NoTrackingToList();
        }

        public List<ReplyMusicMsg> All(Func<ReplyMusicMsg, bool> filter)
        {
            return Db.ReplyMusicMsgs.NoTrackingWhere(filter);
        }
    }
}
