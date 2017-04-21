namespace Qx.Wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ImageMsg
    {
        [Key]
        [StringLength(500)]
        public string MsgId { get; set; }

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

        [StringLength(500)]
        public string PicUrl { get; set; }

        [StringLength(500)]
        public string MediaId { get; set; }
    }
}
