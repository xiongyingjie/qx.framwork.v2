namespace Qx.Wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NewsMsgItem
    {
        [StringLength(500)]
        public string NewsMsgItemId { get; set; }

        [StringLength(500)]
        public string ReplyMsgId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(50)]
        public string PicUrl { get; set; }

        [StringLength(50)]
        public string Url { get; set; }

        public virtual ReplyNewsMsg ReplyNewsMsg { get; set; }
    }
}
