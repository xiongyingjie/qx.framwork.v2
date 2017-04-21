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


    public class ImageMsgRepository : BaseRepository, IRepository<ImageMsg>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.ImageMsgs.Select(a => new SelectListItem() { Text = a.MsgId.ToString(), Value = a.PicUrl }).ToList();
            return dest.Format(value);
        }

        public string Add(ImageMsg model)
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

        public bool Update(ImageMsg model, string note = "")
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

        public ImageMsg Find(object id)
        {
            return Db.ImageMsgs.NoTrackingFind(a=>a.MsgId == (string) id);
        }

        public List<ImageMsg> All()
        {
            return Db.ImageMsgs.NoTrackingToList();
        }

        public List<ImageMsg> All(Func<ImageMsg, bool> filter)
        {
            return Db.ImageMsgs.NoTrackingWhere(filter);
        }
    }
}
