namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MenuEvents
    {
        [Key]
        [StringLength(500)]
        public string EventId { get; set; }

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

        [Required]
        [StringLength(500)]
        public string Event { get; set; }

        [Required]
        [StringLength(500)]
        public string EventKey { get; set; }
    }
}
