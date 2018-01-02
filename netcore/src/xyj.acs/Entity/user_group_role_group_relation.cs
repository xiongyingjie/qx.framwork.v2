using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyj.acs.Entity
{
    public partial class user_group_role_group_relation
    {
        [Key]
        [StringLength(100)]
        public string user_group_role_group_relation_id { get; set; }

        [Required]
        [StringLength(100)]
        public string user_group_id { get; set; }

        [Required]
        [StringLength(100)]
        public string role_group_id { get; set; }

        [StringLength(100)]
        public string create_date { get; set; }

        [Column(TypeName = "text")]
        public string note { get; set; }

        public virtual role_group role_group { get; set; }

        public virtual user_group user_group { get; set; }
    }
}
