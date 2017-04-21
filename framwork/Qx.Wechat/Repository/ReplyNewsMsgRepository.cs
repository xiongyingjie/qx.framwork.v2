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
    public class ReplyNewsMsgRepository : BaseRepository, IRepository<ReplyNewsMsg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ReplyNewsMsgs.Select(a => new SelectListItem() { Text = a.ReplyMsgId.ToString(), Value = a.ReplyMsgId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(ReplyNewsMsg model)
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

        public bool Update(ReplyNewsMsg model, string note = "")
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

        public ReplyNewsMsg Find(object id)
        {
            return Db.ReplyNewsMsgs.NoTrackingFind(a=>a.ReplyMsgId == (string) id);
        }

        public List<ReplyNewsMsg> All()
        {
            return Db.ReplyNewsMsgs.NoTrackingToList();
        }

        public List<ReplyNewsMsg> All(Func<ReplyNewsMsg, bool> filter)
        {
            return Db.ReplyNewsMsgs.NoTrackingWhere(filter);
        }
    }
}
