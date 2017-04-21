using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.GroupType
{
    public class GroupTypeAdd_M
    {
        public crew_limite_type ToModel()
        {
            return new crew_limite_type()
            {
                CrewLimiteTypeID = CrewLimiteTypeID,
                CrewLimite = CrewLimite
            };
        }
        public static GroupTypeAdd_M ToViewModel(crew_limite_type crewlimitetype)
        {
            return new  GroupTypeAdd_M()
                {
               CrewLimiteTypeID= crewlimitetype.CrewLimiteTypeID,
                CrewLimite= crewlimitetype.CrewLimite.Value
            };
        }
        [Display(Name = "通讯组类型ID")]
        [StringLength(50)]
        public string CrewLimiteTypeID { get; set; }

        [Display(Name = "人数上限")]
        public int  CrewLimite { get; set; }
    }
}