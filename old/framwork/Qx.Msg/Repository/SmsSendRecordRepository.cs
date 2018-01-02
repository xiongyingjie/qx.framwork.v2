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

    public class SmsSendRecordRepository : BaseRepository, IRepository<sms_send_record>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.sms_send_record.Select(a => new SelectListItem() { Text = a.RequestId, Value = a.RequestId }).ToList();
            return dest.Format(value);
        }

        public string Add(sms_send_record model)
        {
            model.RequestId = Pk;
            if (Find(model.RequestId) == null)
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

        public bool Update(sms_send_record model, string note = "")
        {
            if (Find(model.RequestId) != null)
            {
                return Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public sms_send_record Find(object id)
        {
            return Db.sms_send_record.NoTrackingFind(a => a.RequestId == (string)id);
        }

        public List<sms_send_record> All()
        {
            return Db.sms_send_record.NoTrackingToList();
        }

        public List<sms_send_record> All(Func<sms_send_record, bool> filter)
        {
            return Db.sms_send_record.NoTrackingWhere(filter);
        }
    }
}
