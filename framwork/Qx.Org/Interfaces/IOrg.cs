using System.Collections.Generic;
using Qx.Org.Entity;

namespace Qx.Org.Interfaces
{
    public interface IOrg
    {
        List<Orgnization> FindFather(string orgid);
        List<string> FastCarIDs(string OrgID);
        string GetOrgName(string OrgID);
        List<Orgnization> FindOrgs(string FatherID);
        string FindFatherID(string O_ID);
        bool OrgRegist(string O_ID, string TypeID, string Name, string Descripe, string FatherID);
        bool OrgAcc(OrgAccount orgacc);
        List<OrgAccount> OrgAccounts(string OrgID);
        string GetOrgAccountID(string OrgID, string AccountTypeID);
        List<List<string>> ProfitTableSetting();
        List<List<string>> ORGProfitSetting();
    }
}
