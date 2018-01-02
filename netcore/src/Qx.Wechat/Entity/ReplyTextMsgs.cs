namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class ReplyTextMsgs
    {
        [Key]
        [StringLength(500)]
        public string ReplyMsgId { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        public virtual ReplyMsgs ReplyMsgs { get; set; }
    }
}
