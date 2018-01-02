namespace qx.wechat.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logs
    {
        [Key]
        [StringLength(500)]
        public string LogId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? Time { get; set; }

        [Column(TypeName = "text")]
        public string Contents { get; set; }

        public int? HasError { get; set; }
    }
}
