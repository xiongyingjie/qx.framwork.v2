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


    public class ContactRepository : BaseRepository, IRepository<Contact>
    {
        public List<SelectListItem> ToSelectItems(string value="")
        {
            var dest = Db.Contacts.Select(a => new SelectListItem() { Text = a.ContactID, Value = a.ContactID }).ToList();
            return dest.Format(value);
        }

        public string Add(Contact model)
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

        public bool Update(Contact model, string note = "")
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

        public Contact Find(object id)
        {
            return Db.Contacts.NoTrackingFind(a=>a.ContactID == (string)id);
        }

        public List<Contact> All()
        {
            return Db.Contacts.NoTrackingToList();
        }

        public List<Contact> All(Func<Contact, bool> filter)
        {
            return Db.Contacts.NoTrackingWhere(filter);
        }
    }
}
