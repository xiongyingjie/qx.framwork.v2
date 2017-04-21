namespace Qx.Wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReplyNewsMsg
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReplyNewsMsg()
        {
            NewsMsgItems = new HashSet<NewsMsgItem>();
        }

        [Key]
        [StringLength(500)]
        public string ReplyMsgId { get; set; }

        public int ArticleCount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewsMsgItem> NewsMsgItems { get; set; }

        public virtual ReplyMsg ReplyMsg { get; set; }
    }
}
