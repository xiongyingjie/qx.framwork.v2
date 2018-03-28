namespace xyj.tool.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("role")]
    public partial class role
    {
        [Key]
        [StringLength(100)]
        public string role_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string role_type { get; set; }

        [StringLength(50)]
        public string sub_system { get; set; }

        public int? is_default { get; set; }
    }
}
