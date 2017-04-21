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


    public class ShortVideoMsgRepository : BaseRepository, IRepository<ShortVideoMsg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ShortVideoMsgs.Select(a => new SelectListItem() { Text = a.MsgId.ToString(), Value = a.MsgId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(ShortVideoMsg model)
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

        public bool Update(ShortVideoMsg model, string note = "")
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

        public ShortVideoMsg Find(object id)
        {
            return Db.ShortVideoMsgs.NoTrackingFind(a=>a.MsgId == (string) id);
        }

        public List<ShortVideoMsg> All()
        {
            return Db.ShortVideoMsgs.NoTrackingToList();
        }

        public List<ShortVideoMsg> All(Func<ShortVideoMsg, bool> filter)
        {
            return Db.ShortVideoMsgs.NoTrackingWhere(filter);
        }
    }
}
