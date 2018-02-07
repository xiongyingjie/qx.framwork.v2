using System.ComponentModel.DataAnnotations;

namespace xyj.acs.Entity
{
    public partial class user_group_relation
    {
        [Key]
        [StringLength(150)]
        public string user_group_relation_id { get; set; }

        [Required]
        [StringLength(100)]
        public string user_id { get; set; }

        [StringLength(100)]
        public string nick_name { get; set; }

        [Required]
        [StringLength(100)]
        public string user_group_id { get; set; }

        [StringLength(100)]
        public string create_user_id { get; set; }

        [StringLength(100)]
        public string create_user_name { get; set; }

        [StringLength(100)]
        public string create_date { get; set; }

        public virtual permission_user permission_user { get; set; }

        public virtual user_group user_group { get; set; }
    }
}
