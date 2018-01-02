namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class column_tempelate
    {
        [Key]
        public Guid column_tempelate_id { get; set; }

        [StringLength(500)]
        public string column_tempelate_name { get; set; }

        [Column(TypeName = "text")]
        public string column_tempelate_html { get; set; }
    }
}
