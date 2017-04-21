using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.Group
{
    public class Group_M
    {
        public msg_group ToModel()
        {
            return new msg_group()
            {
                GroupID = GroupID,
                OwnerID = OwnerID,
                GroupName = GroupName,
                CreatTime= CreatTime,
                CrewLimiteTypeID= CrewLimiteTypeID,
                Remarks= Remarks
            }; 
        }
        public static Group_M ToViewModel(msg_group msggroup)
        {
            return new Group_M()
            {
                GroupID = msggroup.GroupID,
                OwnerID = msggroup.OwnerID,
                GroupName = msggroup.GroupName,
                CreatTime = msggroup.CreatTime??DateTime.Now,
                CrewLimiteTypeID = msggroup.CrewLimiteTypeID,
                Remarks = msggroup.Remarks

            };
        }
        [Display(Name = "群组ID")]
        [StringLength(50)]
        public string GroupID { get; set; }

        [Display(Name = "所属者ID")]
        [StringLength(50)]
        public string OwnerID { get; set; }

        [Display(Name = "群组名称")]
        [StringLength(50)]
        public string GroupName { get; set; }

        [Display(Name = "创建时间")]
        [Column(TypeName = "datetime2")]
        public DateTime CreatTime { get; set; }

        [Display(Name = "群组上限ID")]
        [StringLength(50)]
        public string CrewLimiteTypeID { get; set; }


        [Display(Name = "备注")]
        [StringLength(50)]
        public string Remarks { get; set; }
        
    }
}