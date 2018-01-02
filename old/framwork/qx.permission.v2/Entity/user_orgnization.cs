namespace qx.permmision.v2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_orgnization
    {
        [Key]
        [StringLength(50)]
        public string user_orgnization_id { get; set; }

        [Required]
        [StringLength(50)]
        public string orgnization_id { get; set; }

        [Required]
        [StringLength(100)]
        public string user_id { get; set; }

        public virtual orgnization orgnization { get; set; }

        public virtual permission_user permission_user { get; set; }
    }
}
