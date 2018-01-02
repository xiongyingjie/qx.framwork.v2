using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyj.acs.Entity
{
    public partial class role_button_forbid
    {
        [Key]
        [StringLength(80)]
        public string role_Button_forbid_id { get; set; }

        [Required]
        [StringLength(100)]
        public string role_id { get; set; }

        [Required]
        [StringLength(60)]
        public string button_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? expire_time { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        public virtual button button { get; set; }

        public virtual role role { get; set; }
    }
}
