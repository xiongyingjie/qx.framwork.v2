using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Msg.ViewModels.GroupMembers
{
    public class GroupMembers_M
    {
        public group_member ToModel()
        {
            return new group_member()
            {
                GroupMemberID = GroupMemberID,
                GroupID= GroupID,
                MembersID= MembersID
            };
        }
        public static GroupMembers_M ToViewModel(group_member groupmember)
        {
            return new GroupMembers_M()
            {
                GroupMemberID = groupmember.GroupMemberID,
                GroupID = groupmember.GroupID,
                MembersID = groupmember.MembersID
            };
        }
        [Display(Name = "通讯组成员表ID")]
        [StringLength(50)]
        public string GroupMemberID { get; set; }

        
        [Display(Name = "通讯组ID")]
        [StringLength(50)]
        public string GroupID { get; set; }

        [Display(Name = "好友")]
        [StringLength(50)]
        public string MembersID { get; set; }
    }
}