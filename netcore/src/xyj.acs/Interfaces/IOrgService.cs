using System.Collections.Generic;
using xyj.acs.Models;
using xyj.core.Interfaces;
using xyj.core.Models.Report;

namespace xyj.acs.Interfaces
{ 
    public interface IOrgService : IAutoInject
    {
        int ImportStaff(List<Staff> staffList, string orgnization_position_id);
        bool FandUserIsExistOrgPosition(string uid, string orgnization_position_id);
        bool FindOrgPositionIsRelationUser(string orgnization_position_id);
        bool FindPositionIsRelationOrg(string orgid, string position_id);
        List<Position> getUserPosition(string uid);
        Orgnization getUnitInfo(string orgnization_id);
        List<Orgnization> getAllSubUnit(string orgnization_id);
        List<Orgnization> getDirectSubUnit(string orgnization_id);
        bool FindPositionTypeIsRelation(string position_type_id);
        bool FindOrgLevelRelation(string organization_level_id);
        bool FindOrgTypeIsRelation(string orgnization_type_id);
        bool findOrgIsRelation(string OrgID);
        string[] SplitAllParams(string AllParams);
        //创建社团并任职
        bool CreateAssociation(string leaderId, string name, string associationId, string descripe);
        //更换社长
        bool UpdateAssociationLeader(string leaderId, string associationId);
        //获取该用户任职的所有组织机构
        List<DropDownListItem> GetOrgItem(string user_id);
        //删除社团
        bool DeleteAssociation(string associationId);
        //通过登入者的ID获取所在组织机构编号----清杰
        List<string> GetOrgID(string user_id);
        //同步任职---清杰
        bool RenZhi(string user_id, string associationId, string position_id);//用户ID，组织机构ID，职位ID
    }
}
