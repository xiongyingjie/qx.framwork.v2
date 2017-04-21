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
    public class NewsMsgItemRepository : BaseRepository, IRepository<NewsMsgItem>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.NewsMsgItems.Select(a => new SelectListItem() { Text = a.PicUrl, Value = a.ReplyMsgId.ToString() }).ToList();
            return dest.Format(value);
        }

        public string Add(NewsMsgItem model)
        {
            model.NewsMsgItemId = Pk;
            if (Find(model.NewsMsgItemId) == null)
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

        public bool Update(NewsMsgItem model, string note = "")
        {
            if (Find(model.NewsMsgItemId) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public NewsMsgItem Find(object id)
        {
            return Db.NewsMsgItems.NoTrackingFind(a=>a.NewsMsgItemId == (string) id);
        }

        public List<NewsMsgItem> All()
        {
            return Db.NewsMsgItems.NoTrackingToList();
        }

        public List<NewsMsgItem> All(Func<NewsMsgItem, bool> filter)
        {
            return Db.NewsMsgItems.NoTrackingWhere(filter);
        }
    }
}
