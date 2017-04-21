namespace Qx.Wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Token
    {
        [StringLength(500)]
        public string TokenId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExpireTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? GetTime { get; set; }
    }
}
