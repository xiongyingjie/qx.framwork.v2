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


    public class ReplyTextMsgRepository : BaseRepository, IRepository<ReplyTextMsg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ReplyTextMsgs.Select(a => new SelectListItem() { Text = a.Content, Value = a.ReplyMsgId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(ReplyTextMsg model)
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

        public bool Update(ReplyTextMsg model, string note = "")
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

        public ReplyTextMsg Find(object id)
        {
            return Db.ReplyTextMsgs.NoTrackingFind(a=>a.ReplyMsgId == (string) id);
        }

        public List<ReplyTextMsg> All()
        {
            return Db.ReplyTextMsgs.NoTrackingToList();
        }

        public List<ReplyTextMsg> All(Func<ReplyTextMsg, bool> filter)
        {
            return Db.ReplyTextMsgs.NoTrackingWhere(filter);
        }
    }
}
