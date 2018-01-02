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

    public class MsgSendRecordRepository : BaseRepository, IRepository<msg_send_record>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.msg_send_record.Select(a => new SelectListItem() { Text = a.MsgSendRecordID, Value = a.MsgSendRecordID }).ToList();
            return dest.Format(value);
        }

        public string Add(msg_send_record model)
        {
            if (Find(model.MsgSendRecordID) == null)
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

        public bool Update(msg_send_record model, string note = "")
        {
            if (Find(model.MsgSendRecordID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public msg_send_record Find(object id)
        {
            return Db.msg_send_record.NoTrackingFind(a=>a.MsgSendRecordID == (string) id);
        }

        public List<msg_send_record> All()
        {
            return Db.msg_send_record.NoTrackingToList();
        }

        public List<msg_send_record> All(Func<msg_send_record, bool> filter)
        {
            return Db.msg_send_record.NoTrackingWhere(filter);
        }
    }
}
