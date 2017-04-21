using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.OutState
{
    public class OutState_M
    {
        public out_state ToModel()
        {
            return new out_state()
            {
                OutStateID=OutStateID,
                StateName=StateName
            };
        }
        public static OutState_M ToViewModel(out_state outstate)
        {
            return new OutState_M()
            {
                OutStateID = outstate.OutStateID,
                StateName = outstate.StateName
            };
        }
        [Display(Name = "状态ID")]
        [StringLength(50)]
        public string OutStateID { get; set; }

        [Display(Name = "状态")]
        [StringLength(50)]
        public string StateName { get; set; }
    }
}