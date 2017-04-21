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


    public class VoiceMsgRepository : BaseRepository, IRepository<VoiceMsg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.VoiceMsgs.Select(a => new SelectListItem() { Text = a.MsgId.ToString(), Value = a.MsgId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(VoiceMsg model)
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

        public bool Update(VoiceMsg model, string note = "")
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

        public VoiceMsg Find(object id)
        {
            return Db.VoiceMsgs.NoTrackingFind(a=>a.MsgId == (string) id);
        }

        public List<VoiceMsg> All()
        {
            return Db.VoiceMsgs.NoTrackingToList();
        }

        public List<VoiceMsg> All(Func<VoiceMsg, bool> filter)
        {
            return Db.VoiceMsgs.NoTrackingWhere(filter);
        }
    }
}
