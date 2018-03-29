namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class ReplyImageMsgs
    {
        [Key]
        [StringLength(500)]
        public string ReplyMsgId { get; set; }

        [Required]
        [StringLength(500)]
        public string MediaId { get; set; }

        public virtual ReplyMsgs ReplyMsgs { get; set; }
    }
}