using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qx.Wechat.Services;
using Qx.Tools.Interfaces;
using Qx.Wechat.Entity;
using System.Web.Mvc;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Wechat.Repository
{
    public class ReplyMsgRepository : BaseRepository, IRepository<ReplyMsg>
    {
        public string Add(ReplyMsg model)
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

        public List<ReplyMsg> All()
        {
            return Db.ReplyMsgs.NoTrackingToList();
        }

        public List<ReplyMsg> All(Func<ReplyMsg, bool> filter)
        {
            return Db.ReplyMsgs.NoTrackingWhere(filter);
        }

        public bool Delete(object id)
        {
            return Db.SaveAdd(Find(id));
        }

        public ReplyMsg Find(object id)
        {
            return Db.ReplyMsgs.NoTrackingFind(a => a.ReplyMsgId == (string)id);
        }

        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ReplyMsgs.Select(a => new SelectListItem() { Text = a.ReplyMsgId.ToString(), Value = a.ReplyMsgId.ToString() }).ToList();
            return dest.Format(value);
        }

        public bool Update(ReplyMsg model, string note = "")
        {
            if (Find(model.ReplyMsgId) != null)
            {
                return Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }
    }
}
