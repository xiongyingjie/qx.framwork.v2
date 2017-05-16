namespace qx.permmision.v2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_position
    {
        [Key]
        [StringLength(150)]
        public string user_position_id { get; set; }

        [Required]
        [StringLength(100)]
        public string orgnization_position_id { get; set; }

        [Required]
        [StringLength(100)]
        public string user_id { get; set; }

        public virtual orgnization_position orgnization_position { get; set; }

        public virtual permission_user permission_user { get; set; }
    }
}
