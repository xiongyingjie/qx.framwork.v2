namespace Qx.Msg.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class timer_msg
    {
        [Key]
        [StringLength(50)]
        public string TimerMsgID { get; set; }

        [StringLength(50)]
        public string MsgID { get; set; }

        public DateTime? SetSendTime { get; set; }

        public DateTime? RealSendTime { get; set; }

        public virtual msg msg { get; set; }
    }
}
