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
        public string CTQ_ID { get; set; }

        [StringLength(50)]
        public string CTD_ID { get; set; }

        [StringLength(50)]
        public string SqlQuery { get; set; }

        public virtual content_table_design content_table_design { get; set; }
    }
}
