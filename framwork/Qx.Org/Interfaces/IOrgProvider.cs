using System.Collections.Generic;
using Qx.Org.Entity;

namespace Qx.Org.Interfaces
{
   public interface IOrgProvider
    {
        string GetUnitIdByPositionId(string O_P_ID);
        List<string> FastCarIDs(string OrgID);
        string GetOrgName(string OrgID);
        List<Entity.Orgnization> FindOrgs(string FatherID);
        string FindFatherID(string O_ID);
        bool OrgRegist(string O_ID, string TypeID, string Name, string Descripe, string FatherID);
        bool OrgAcc(string AccID, string OrgID, string AccTypeID);
        List<OrgAccount> OrgAccounts(string OrgID);
        string GetOrgAccountID(string OrgID, string AccountTypeID);
        string GetProvince(string OrgID);
        string GetCity(string OrgID);
        string GetArea(string OrgID);
        string GetTypeName(string OrgID);
        List<List<string>> ProfitTableSetting();
        List<List<string>> ORGProfitSetting();
        List<string> FindOrgIDsByTypeID(string TypeID);
        List<List<string>> GetOrgAsset(string orgid);
        List<List<string>> GetOrgAssetDetail(string orgid, int TypeID);
        string GetPositionName(string Lopid);
        List<Orgnization> SearchOrg(string TypeID,string Province, string City, string Area, string Name);
    }
}
