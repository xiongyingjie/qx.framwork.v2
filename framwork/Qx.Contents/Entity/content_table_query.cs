namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class content_table_query
    {
        [Key]
        [StringLength(50)]
        public string ctq_id { get; set; }

        [StringLength(50)]
        public string ctd_id { get; set; }

        [StringLength(50)]
        public string sql_query { get; set; }

        public virtual content_table_design content_table_design { get; set; }
    }
}
