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


    public class LinkMsgRepository : BaseRepository, IRepository<LinkMsg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.LinkMsgs.Select(a => new SelectListItem() { Text = a.MsgId.ToString(), Value = a.Url }).ToList();
            return dest.Format(value);
        }

        public string Add(LinkMsg model)
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

        public bool Update(LinkMsg model, string note = "")
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

        public LinkMsg Find(object id)
        {
            return Db.LinkMsgs.NoTrackingFind(a=>a.MsgId == (string) id);
        }

        public List<LinkMsg> All()
        {
            return Db.LinkMsgs.NoTrackingToList();
        }

        public List<LinkMsg> All(Func<LinkMsg, bool> filter)
        {
            return Db.LinkMsgs.NoTrackingWhere(filter);
        }
    }
}
