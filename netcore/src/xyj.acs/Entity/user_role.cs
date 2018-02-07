using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyj.acs.Entity
{
    public partial class user_role
    {
        [Key]
        [StringLength(150)]
        public string user_role_id { get; set; }

        [Required]
        [StringLength(100)]
        public string user_id { get; set; }

        [Required]
        [StringLength(100)]
        public string role_id { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? expire_time { get; set; }

        public virtual permission_user permission_user { get; set; }

        public virtual role role { get; set; }
    }
}
