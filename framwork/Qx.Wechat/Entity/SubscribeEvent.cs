namespace Qx.Wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SubscribeEvent
    {
        [Key]
        [StringLength(500)]
        public string EventId { get; set; }

        [StringLength(500)]
        public string ToUserName { get; set; }

        [StringLength(500)]
        public string FromUserName { get; set; }

        [StringLength(50)]
        public string CreateTime { get; set; }

        [StringLength(500)]
        public string MsgType { get; set; }

        [StringLength(500)]
        public string Event { get; set; }

        [StringLength(500)]
        public string EventKey { get; set; }

        [StringLength(500)]
        public string Ticket { get; set; }
    }
}
