namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class ReplySetups
    {
        [Key]
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

        public virtual ReplyMsgs ReplyMsgs { get; set; }
    }
}
