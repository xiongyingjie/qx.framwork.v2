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


    public class ReplyVoiceMsgRepository : BaseRepository, IRepository<ReplyVoiceMsg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ReplyVoiceMsgs.Select(a => new SelectListItem() { Text = a.ReplyMsgId.ToString(), Value = a.ReplyMsgId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(ReplyVoiceMsg model)
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

        public bool Update(ReplyVoiceMsg model, string note = "")
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

        public ReplyVoiceMsg Find(object id)
        {
            return Db.ReplyVoiceMsgs.NoTrackingFind(a=>a.ReplyMsgId == (string) id);
        }

        public List<ReplyVoiceMsg> All()
        {
            return Db.ReplyVoiceMsgs.NoTrackingToList();
        }

        public List<ReplyVoiceMsg> All(Func<ReplyVoiceMsg, bool> filter)
        {
            return Db.ReplyVoiceMsgs.NoTrackingWhere(filter);
        }
    }
}
