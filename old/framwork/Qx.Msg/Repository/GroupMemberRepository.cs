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


    public class GroupMemberRepository : BaseRepository, IRepository<group_member>
    {
        public List<SelectListItem> ToSelectItems(string value = "")
        {
            var dest = Db.group_member.Select(a => new SelectListItem() { Text = a.GroupMemberID, Value = a.GroupMemberID }).ToList();
            return dest.Format(value);
        }

        public string Add(group_member model)
        {
            if (Find(model.GroupMemberID) == null)
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

        public bool Update(group_member model, string note = "")
        {
            if (Find(model.GroupMemberID) != null)
            {
              return  Db.SaveModified(model);
            }
            else
            {
                return false;
            }
        }

        public group_member Find(object id)
        {
            return Db.group_member.NoTrackingFind(a=>a.GroupMemberID == (string)id);
        }

        public List<group_member> All()
        {
            return Db.group_member.NoTrackingToList();
        }

        public List<group_member> All(Func<group_member, bool> filter)
        {
            return Db.group_member.NoTrackingWhere(filter);
        }
    }
}
