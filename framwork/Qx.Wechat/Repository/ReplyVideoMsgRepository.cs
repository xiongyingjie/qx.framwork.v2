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


    public class ReplyVideoMsgRepository : BaseRepository, IRepository<ReplyVideoMsg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ReplyVideoMsgs.Select(a => new SelectListItem() { Text = a.ReplyMsgId.ToString(), Value = a.ReplyMsgId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(ReplyVideoMsg model)
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

        public bool Update(ReplyVideoMsg model, string note = "")
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

        public ReplyVideoMsg Find(object id)
        {
            return Db.ReplyVideoMsgs.NoTrackingFind(a=>a.ReplyMsgId == (string)id);
        }

        public List<ReplyVideoMsg> All()
        {
            return Db.ReplyVideoMsgs.NoTrackingToList();
        }

        public List<ReplyVideoMsg> All(Func<ReplyVideoMsg, bool> filter)
        {
            return Db.ReplyVideoMsgs.NoTrackingWhere(filter);
        }
    }
}
