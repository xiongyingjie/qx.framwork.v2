using Qx.Msg.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Msg.ViewModels.InState
{
    public class InState_M
    {
        public in_state ToModel()
        {
            return new in_state()
            {
                InStateID = InStateID,
                StateName = StateName
            };
        }
        public static InState_M ToViewmodel(in_state instate)
        {
            return new InState_M()
            {
                InStateID = instate.InStateID,
                StateName = instate.StateName
            };
        }

        [Display(Name = "收件信息类型ID")]
        [StringLength(50)]
        public string InStateID { get; set; }

        [Display(Name = "收件信息类型名称")]
        [StringLength(50)]
        public string StateName { get; set; }
    }
}