using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Msg.ViewModels.MyGroups
{
    public class GroupAdd_M
    {
        public msg_group ToModel()
        {
            return new msg_group()
            {
                GroupID = GroupID,
                OwnerID= OwnerID,
                GroupName = GroupName,
                CreatTime= CreatTime,
                CrewLimiteTypeID= CrewLimiteTypeID,
                Remarks= Remarks
            };
        }
        public static GroupAdd_M ToViewModel(List<SelectListItem>CrewLimiteselectItems,string ownerID)
        {
            return new GroupAdd_M()
            {                             
                CreatTime = DateTime.Now,
                OwnerID=ownerID,
                CrewLimiteselectItems = CrewLimiteselectItems
            };
        }
        public static GroupAdd_M ToViewModel(List<SelectListItem> CrewLimiteselectItems, string ownerID, msg_group group)
        {
            return new GroupAdd_M()
            {

                GroupID = group. GroupID,
                OwnerID = group.OwnerID,
                GroupName = group.GroupName,
                CreatTime = DateTime.Now,
                CrewLimiteTypeID = group.CrewLimiteTypeID,
                Remarks = group.Remarks,
                CrewLimiteselectItems = CrewLimiteselectItems

            };
        }

        [StringLength(50)]
        public string GroupID { get; set; }

        [Required]
        [StringLength(50)]
        public string OwnerID { get; set; }

        [Display(Name = "组名称")]
        [StringLength(50)]
        public string GroupName { get; set; }

        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime2")]
        public DateTime CreatTime { get; set; }

        [Display(Name = "人数上限")]
        [StringLength(50)]
        public string CrewLimiteTypeID { get; set; }

        [Display(Name = "说明")]
        [StringLength(50)]
        public string Remarks { get; set; }
        public List<SelectListItem> CrewLimiteselectItems { get; set; }

    }
}