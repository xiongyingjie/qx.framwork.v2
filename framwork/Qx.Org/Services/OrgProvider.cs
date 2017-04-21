using System;
using System.Collections.Generic;
using System.Linq;
using Qx.Org.Entity;
using Qx.Org.Interfaces;
using Qx.Org.Repository;
using Qx.Tools.CommonExtendMethods;
using Qx.Tools.Interfaces;

namespace Qx.Org.Services
{
    public class OrgProvider : BaseRepository,IOrgProvider
    {
        private IRepository<L_Org_Pos> _l_Org_Pos;
        private OrgServices _orgServices;

        public OrgProvider()
        {
            _l_Org_Pos = new L_Org_PosRepository();
            _orgServices = new OrgServices();
        }

        public string GetUnitIdByPositionId(string O_P_ID)
        {
            var orgPosition = _l_Org_Pos.Find(O_P_ID);
            if (orgPosition == null)
            {
                throw new Exception("未找到这个公司岗位O_P_ID=>" + O_P_ID);
            }
            else
            {
                return orgPosition.O_ID;
            }
        }
        public List<string> FastCarIDs(string OrgID)
        {
            return _orgServices.FastCarIDs(OrgID);
        }
        public string GetOrgName(string OrgID)
        {
            return _orgServices.GetOrgName(OrgID);
        }
        public List<Orgnization> FindOrgs(string FatherID)
        {
            return _orgServices.FindOrgs(FatherID);
        }
        public string FindFatherID(string O_ID)
        {
            return _orgServices.FindFatherID(O_ID);
        }
        public bool OrgRegist(string O_ID, string TypeID, string Name, string Descripe, string FatherID)
        {
           return  _orgServices.OrgRegist(O_ID, TypeID, Name, Descripe, FatherID);
        }
        public bool OrgAcc(string AccID, string OrgID,string AccTypeID)
        {
            OrgAccount orgacc = new OrgAccount()
            {
                AccountID = AccID,
                OA_ID = DateTime.Now.Random().ToString(),
                O_ID = OrgID,
                AccTypeID=AccTypeID
            };
            return _orgServices.OrgAcc(orgacc);
        }
        public List<OrgAccount> OrgAccounts(string OrgID)
        {
            return _orgServices.OrgAccounts(OrgID);
        }
        public string GetOrgAccountID(string OrgID, string AccountTypeID)
        {
            return _orgServices.GetOrgAccountID(OrgID, AccountTypeID);
        }
        public string GetProvince(string OrgID)
        {
            return Db.Orgnizations.Find(OrgID).Province;
        }
        public string GetCity(string OrgID)
        {
            return Db.Orgnizations.Find(OrgID).City;
        }
        public string GetArea(string OrgID)
        {
            return Db.Orgnizations.Find(OrgID).Area;
        }
        public string GetTypeName(string OrgID)
        {
                return Db.OrgTypes.Find(OrgID).TypeName;
        }
        public List<List<string>> ProfitTableSetting()
        {
            return _orgServices.ProfitTableSetting();
        }
        public List<List<string>> ORGProfitSetting()
        {
            return _orgServices.ORGProfitSetting();
        }
        public List<string> FindOrgIDsByTypeID(string TypeID)
        {
            List<string> OrgIDs = new List<string>();
            var Orgs = Db.Orgnizations.Where(a => a.TypeID == TypeID);
            foreach(var org in Orgs)
            {
                OrgIDs.Add(org.O_ID);
            }
            return OrgIDs;
        }
        public List<List<string>> GetOrgAsset(string orgid)
        {
            var asset = Db.OrgAssets.Where(a=>a.O_ID==orgid).GroupBy(a=>a.TypeID).Select(b=>new List<string>()
                {
                     b.Key.ToString(),
                     b.Where(a=>a.TypeID==b.Key).FirstOrDefault().Name,
                     b.Sum(a=>a.Price).ToString(),
                }).ToList();
            return asset;
        }
        public List<List<string>> GetOrgAssetDetail(string orgid, int TypeID)
        {
            var asset = Db.OrgAssets.Where(a => a.O_ID == orgid && a.TypeID == TypeID).Select(b => new List<string>()
                {
                    b.Name,
                    b.Price.ToString()
                }).ToList();
            return asset;
        }
        public string GetPositionName(string Lopid)
        {
            return Db.L_Org_Pos.Find(Lopid).Position.Name;
        }
        public List<Orgnization> SearchOrg( string TypeID = "",string Province="", string City="", string Area="", string Name="")
        {
            return Db.Orgnizations.Where(a =>a.TypeID==TypeID&& a.Province.Contains(Province)).Where(a=> a.City.Contains(City) && a.Area.Contains(Area) && a.Name.Contains(Name)).ToList();
        }
    }
}
