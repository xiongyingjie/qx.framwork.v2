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


    public class ReplyImageMsgRepository : BaseRepository, IRepository<ReplyImageMsg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ReplyImageMsgs.Select(a => new SelectListItem() { Text = a.ReplyMsgId.ToString(), Value = a.ReplyMsgId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(ReplyImageMsg model)
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

        public bool Update(ReplyImageMsg model, string note = "")
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

        public ReplyImageMsg Find(object id)
        {
            return Db.ReplyImageMsgs.NoTrackingFind(a=>a.ReplyMsgId == (string) id);
        }

        public List<ReplyImageMsg> All()
        {
            return Db.ReplyImageMsgs.NoTrackingToList();
        }

        public List<ReplyImageMsg> All(Func<ReplyImageMsg, bool> filter)
        {
            return Db.ReplyImageMsgs.NoTrackingWhere(filter);
        }
    }
}
