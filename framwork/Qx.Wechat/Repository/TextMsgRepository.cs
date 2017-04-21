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


    public class TextMsgRepository : BaseRepository, IRepository<TextMsg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.TextMsgs.Select(a => new SelectListItem() { Text = a.MsgId.ToString(), Value = a.MsgId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(TextMsg model)
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

        public bool Update(TextMsg model, string note = "")
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

        public TextMsg Find(object id)
        {
            return Db.TextMsgs.NoTrackingFind(a=>a.MsgId == (string) id);
        }

        public List<TextMsg> All()
        {
            return Db.TextMsgs.NoTrackingToList();
        }

        public List<TextMsg> All(Func<TextMsg, bool> filter)
        {
            return Db.TextMsgs.NoTrackingWhere(filter);
        }
    }
}
