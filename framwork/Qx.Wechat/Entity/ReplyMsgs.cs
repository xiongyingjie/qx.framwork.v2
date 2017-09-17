namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReplyMsgs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReplyMsgs()
        {
            ReplySetups = new HashSet<ReplySetups>();
        }

        [Key]
        [StringLength(500)]
        public string ReplyMsgId { get; set; }

        [Required]
        [StringLength(500)]
        public string ToUserName { get; set; }

        [Required]
        [StringLength(500)]
        public string FromUserName { get; set; }

        [Required]
        [StringLength(50)]
        public string CreateTime { get; set; }

        [Required]
        [StringLength(500)]
        public string MsgType { get; set; }

        public virtual reply_template_msg reply_template_msg { get; set; }

        public virtual ReplyImageMsgs ReplyImageMsgs { get; set; }

        public virtual ReplyMusicMsgs ReplyMusicMsgs { get; set; }

        public virtual ReplyNewsMsgs ReplyNewsMsgs { get; set; }

        public virtual ReplyTextMsgs ReplyTextMsgs { get; set; }

        public virtual ReplyVideoMsgs ReplyVideoMsgs { get; set; }

        public virtual ReplyVoiceMsgs ReplyVoiceMsgs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReplySetups> ReplySetups { get; set; }
    }
}
