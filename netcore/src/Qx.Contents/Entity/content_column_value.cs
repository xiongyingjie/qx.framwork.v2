namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class content_column_value
    {
        [Key]
        [StringLength(50)]
        public string ccv_id { get; set; }

        [Required]
        [StringLength(50)]
        public string ccd_id { get; set; }

        [StringLength(150)]
        public string column_value { get; set; }

        [StringLength(50)]
        public string relation_key_value { get; set; }

        public virtual content_column_design content_column_design { get; set; }
    }
}
