namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class ReplyVideoMsgs
    {
        [Key]
        [StringLength(500)]
        public string ReplyMsgId { get; set; }

        [Required]
        [StringLength(500)]
        public string MediaId { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public virtual ReplyMsgs ReplyMsgs { get; set; }
    }
}
