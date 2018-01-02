namespace qx.permmision.v2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class organization_relation
    {
        [Key]
        [StringLength(100)]
        public string organization_relation_id { get; set; }

        [Required]
        [StringLength(50)]
        public string orgnization_id { get; set; }

        [Required]
        [StringLength(50)]
        public string other_orgnization_id { get; set; }

        public virtual orgnization orgnization { get; set; }

        public virtual orgnization orgnization1 { get; set; }
    }
}
