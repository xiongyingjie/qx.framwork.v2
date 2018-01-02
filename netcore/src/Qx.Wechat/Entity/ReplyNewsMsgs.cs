namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class ReplyNewsMsgs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ReplyNewsMsgs()
        {
            NewsMsgItems = new HashSet<NewsMsgItems>();
        }

        [Key]
        [StringLength(500)]
        public string ReplyMsgId { get; set; }

        public int ArticleCount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NewsMsgItems> NewsMsgItems { get; set; }

        public virtual ReplyMsgs ReplyMsgs { get; set; }
    }
}
