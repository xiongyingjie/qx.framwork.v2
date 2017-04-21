using Qx.Bysj.Jzxt.Interfaces;

namespace Qx.Bysj.Jzxt.Services
{
    public class JzxtService : BaseRepository, IJzxtService
    {
        //public List<SelectListItem> GetContactName(string OwnerID)
        //{
        //    var Contacts = Db.Contacts.Where(a => a.OwnerID == OwnerID).ToList();
        //    var Users = Db.Users;
        //    List<SelectListItem> ContactName = new List<SelectListItem>();
        //    foreach (var Contact in Contacts)
        //    {
                
        //        ContactName.Add(new SelectListItem()
        //        {
                   
        //            Text = Users.Find(Contact.MembersID).UserName,
        //            Value = Contact.MembersID,
        //        });
        //    }
        //    return ContactName;
        //}
        
    }
}
