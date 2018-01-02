namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class TextMsgs
    {
        [Key]
        [StringLength(500)]
        public string MsgId { get; set; }

        [StringLength(500)]
        public string ToUserName { get; set; }

        [StringLength(500)]
        public string FromUserName { get; set; }

        [StringLength(50)]
        public string CreateTime { get; set; }

        [StringLength(500)]
        public string MsgType { get; set; }

        [StringLength(500)]
        public string Content { get; set; }
    }
}
