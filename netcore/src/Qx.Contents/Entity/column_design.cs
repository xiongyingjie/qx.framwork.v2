namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class column_design
    {
        [Key]
        [StringLength(50)]
        public string column_design_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public int show_count { get; set; }

        [Required]
        [StringLength(20)]
        public string unit_id { get; set; }

        [StringLength(50)]
        public string update_type_id { get; set; }

        [Column(TypeName = "text")]
        public string html_template { get; set; }

        [StringLength(500)]
        public string html_template_params { get; set; }

        [StringLength(50)]
        public string library_id { get; set; }
    }
}
