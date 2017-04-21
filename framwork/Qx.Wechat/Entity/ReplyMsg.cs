namespace Qx.Wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReplyMsg
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReplyMsg()
        {
            ReplySetups = new HashSet<ReplySetup>();
        }

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

        public virtual ReplyImageMsg ReplyImageMsg { get; set; }

        public virtual ReplyMusicMsg ReplyMusicMsg { get; set; }

        public virtual ReplyNewsMsg ReplyNewsMsg { get; set; }

        public virtual ReplyTextMsg ReplyTextMsg { get; set; }

        public virtual ReplyVideoMsg ReplyVideoMsg { get; set; }

        public virtual ReplyVoiceMsg ReplyVoiceMsg { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReplySetup> ReplySetups { get; set; }
    }
}
