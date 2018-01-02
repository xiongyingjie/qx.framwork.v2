namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class reply_template_msg
    {
        [Key]
        [StringLength(500)]
        public string ReplyMsgId { get; set; }

        [StringLength(50)]
        public string TemplateId { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public virtual ReplyMsgs ReplyMsgs { get; set; }
    }
}
