namespace xyj.tool.Entity
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
        [StringLength(100)]
        public string role_id { get; set; }

        [Required]
        [StringLength(100)]
        public string menu_id { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        public int include_children { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? expire_time { get; set; }

        public virtual menu menu { get; set; }
    }
}
