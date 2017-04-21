using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Qx.Tools.Interfaces;
using System.Linq;
using Qx.Tools.CommonExtendMethods;
using Qx.Msg.Entity;
using Qx.Msg.Services;

namespace Qx.Msg.Repository
{

    public class MsgCollectionRepository : BaseRepository, IRepository<msg_collection>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.msg_collection.Select(a => new SelectListItem() { Text = a.MsgCollectionID, Value = a.MsgCollectionID }).ToList();
            return dest.Format(value);
        }

        public string Add(msg_collection model)
        {
            //model.MsgCollectionID = Pk;
            if (Find(model.MsgCollectionID) == null)
            {
                return Db.SaveAdd(model) ? Pk : null;
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

        public bool Update(msg_collection model, string note = "")
        {
            if (Find(model.MsgCollectionID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public msg_collection Find(object id)
        {
            return Db.msg_collection.NoTrackingFind(a=>a.MsgCollectionID == (string) id);
        }

        public List<msg_collection> All()
        {
            return Db.msg_collection.NoTrackingToList();
        }

        public List<msg_collection> All(Func<msg_collection, bool> filter)
        {
            return Db.msg_collection.NoTrackingWhere(filter);
        }
    }
}
