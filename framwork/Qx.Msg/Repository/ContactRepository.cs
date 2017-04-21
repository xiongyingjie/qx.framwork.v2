using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Qx.Msg.Entity;
using Qx.Msg.Services;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.Msg.Repository
{


    public class ContactRepository : BaseRepository, IRepository<contact>
    {
        public List<SelectListItem> ToSelectItems(string value="")
        {
            var dest = Db.contact.Select(a => new SelectListItem() { Text = a.ContactID, Value = a.ContactID }).ToList();
            return dest.Format(value);
        }

        public string Add(contact model)
        {
            //model.ContactID = Pk;
            if (Find(model.ContactID) == null)
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

        public bool Update(contact model, string note = "")
        {
            if (Find(model.ContactID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public contact Find(object id)
        {
            return Db.contact.NoTrackingFind(a=>a.ContactID == (string)id);
        }

        public List<contact> All()
        {
            return Db.contact.NoTrackingToList();
        }

        public List<contact> All(Func<contact, bool> filter)
        {
            return Db.contact.NoTrackingWhere(filter);
        }
    }
}
