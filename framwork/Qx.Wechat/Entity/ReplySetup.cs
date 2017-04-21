namespace Qx.Wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReplySetup
    {
        [StringLength(500)]
        public string ReplySetupId { get; set; }

        [Required]
        [StringLength(500)]
        public string KeyWord { get; set; }

        [Required]
        [StringLength(500)]
        public string ReplyMsgId { get; set; }

        [Required]
        [StringLength(50)]
        public string ReplyTypeId { get; set; }

        public virtual ReplyMsg ReplyMsg { get; set; }
    }
}
