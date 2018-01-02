using System.ComponentModel.DataAnnotations;

namespace xyj.acs.Entity
{
    public partial class user_group_role_relation
    {
        [Key]
        [StringLength(100)]
        public string user_group_role_relation_id { get; set; }

        [Required]
        [StringLength(100)]
        public string user_group_id { get; set; }

        [Required]
        [StringLength(100)]
        public string role_id { get; set; }

        [StringLength(50)]
        public string note { get; set; }

        [StringLength(100)]
        public string create_date { get; set; }

        public virtual role role { get; set; }

        public virtual user_group user_group { get; set; }
    }
}
