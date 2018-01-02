using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyj.acs.Entity
{
    public partial class data_filter
    {
        [Key]
        [StringLength(100)]
        public string data_filter_id { get; set; }

        [Required]
        [StringLength(100)]
        public string role_id { get; set; }

        [Required]
        [StringLength(100)]
        public string report_id { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        [Required]
        [StringLength(50)]
        public string filter_script_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? expire_time { get; set; }

        public int? seq { get; set; }

        public virtual filter_script filter_script { get; set; }

        public virtual role role { get; set; }
    }
}
