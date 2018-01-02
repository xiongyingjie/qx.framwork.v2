namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class SystemSetups
    {
        [Key]
        [StringLength(500)]
        public string APP_ID { get; set; }

        [Required]
        [StringLength(500)]
        public string WECHAT_HOST { get; set; }

        [StringLength(500)]
        public string APP_SECRET { get; set; }
    }
}
