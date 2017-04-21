namespace Qx.Wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SystemSetup
    {
        [Required]
        [StringLength(500)]
        public string WECHAT_HOST { get; set; }

        [Key]
        [StringLength(500)]
        public string APP_ID { get; set; }

        [StringLength(500)]
        public string APP_SECRET { get; set; }
    }
}
