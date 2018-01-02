namespace Qx.Msg.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class msg_send_record
    {
        [Key]
        [StringLength(100)]
        public string MsgSendRecordID { get; set; }

        [Required]
        [StringLength(50)]
        public string MsgID { get; set; }

        [StringLength(50)]
        public string ReceiverID { get; set; }

        public DateTime? SendTime { get; set; }

        public DateTime? ReadTime { get; set; }

        [StringLength(50)]
        public string OutStateID { get; set; }

        [StringLength(50)]
        public string InStateID { get; set; }

        public virtual in_state in_state { get; set; }

        public virtual msg msg { get; set; }

        public virtual out_state out_state { get; set; }

        public virtual msg_user msg_user { get; set; }
    }
}
