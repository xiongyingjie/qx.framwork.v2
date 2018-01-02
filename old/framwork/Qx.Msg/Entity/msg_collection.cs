namespace Qx.Msg.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class msg_collection
    {
        [Key]
        [StringLength(150)]
        public string MsgCollectionID { get; set; }

        [Required]
        [StringLength(50)]
        public string MsgID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserID { get; set; }

        public DateTime? Time { get; set; }

        [StringLength(50)]
        public string ReceiverID { get; set; }

        public virtual msg msg { get; set; }

        public virtual msg_user msg_user { get; set; }
    }
}
