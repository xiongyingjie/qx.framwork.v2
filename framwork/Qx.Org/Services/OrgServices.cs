using System.Collections.Generic;
using System.Linq;
using Qx.Org.Entity;
using Qx.Org.Interfaces;
using Qx.Tools.CommonExtendMethods;

namespace Qx.Org.Services
{
    public class OrgServices: BaseRepository,IOrg
    {


        public List<Orgnization> FindFather(string orgid)
        {
            var father = Db.Orgnizations.FirstOrDefault(a => a.O_ID == orgid);
            List<Orgnization> fathers = new List<Orgnization>();
            while (father != null)
            {
                if (father.O_ID == "0")
                    break;
                fathers.Add(father);
                father = Db.Orgnizations.Find(father.FatherID);
            }
            fathers.Reverse();
            return fathers;
        }
        public List<string> FastCarIDs(string OrgID)
        {
            return Db.Orgnizations.Where(a => a.FatherID == OrgID).Select(b=>b.O_ID).ToList();
        }
        public string GetOrgName(string OrgID)
        {
            return Db.Orgnizations.Find(OrgID).Name;
        }
        public List<Orgnization> FindOrgs(string FatherID)
        {
            return Db.Orgnizations.Where(a => a.FatherID == FatherID).ToList();
        }
        public string FindFatherID(string O_ID)
        {
            return Db.Orgnizations.Find(O_ID).FatherID;
        }
        public bool OrgRegist(string O_ID,string TypeID,string Name,string Descripe,string FatherID)
        {
            Orgnization org = new Orgnization()
            {
                O_ID = O_ID,
                TypeID = TypeID,
                Name = Name,
                Descripe = Descripe,
                FatherID = FatherID
            };
            Db.Orgnizations.Add(org);
            return Db.Saved();
        }
        public bool OrgAcc(OrgAccount orgacc)
        {
            Db.R_Accounts.Add(new R_Accounts() { AccountID = orgacc.AccountID });
             Db.OrgAccounts.Add(orgacc);
            return Db.Saved();
        }
        public List<OrgAccount> OrgAccounts(string OrgID)
        {
            return Db.OrgAccounts.Where(a => a.O_ID == OrgID).ToList();
        }
        public string GetOrgAccountID(string OrgID, string AccountTypeID)
        {
            return Db.OrgAccounts.Where(a => a.O_ID == OrgID && a.AccTypeID == AccountTypeID).FirstOrDefault().AccountID;
        }

        public List<List<string>>ProfitTableSetting()
        {
            return Db.Orgnizations.Where(a => a.TypeID == "4" || a.TypeID == "5").ToList().Select(b =>new List<string>()
            {
                b.O_ID,
                b.TypeID,
                b.FatherID
            }).ToList();
        }

        public List<List<string>> ORGProfitSetting()
        {
            return Db.Orgnizations.Where(a => a.TypeID == "1" || a.TypeID == "2" || a.TypeID == "3" || a.TypeID == "4" || a.TypeID == "5").ToList().Select(b => new List<string>()
            {
                b.O_ID,
                b.TypeID,
                b.FatherID
            }).ToList();
        }


    }
}
