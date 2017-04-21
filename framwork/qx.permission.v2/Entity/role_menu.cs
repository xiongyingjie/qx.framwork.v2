namespace qx.permmision.v2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class role_menu
    {
        [Key]
        [StringLength(120)]
        public string role_menu_id { get; set; }

        [Required]
        [StringLength(20)]
        public string role_id { get; set; }

        [Required]
        [StringLength(100)]
        public string menu_id { get; set; }

        [StringLength(10)]
        public string note { get; set; }

        public int include_children { get; set; }

        public DateTimeOffset? expire_time { get; set; }

        public virtual menu menu { get; set; }

        public virtual role role { get; set; }
    }
}
