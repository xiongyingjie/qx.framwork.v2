using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace xyj.acs.Entity
{
    public partial class role_group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public role_group()
        {
            role_group_relation = new HashSet<role_group_relation>();
            user_group_role_group_relation = new HashSet<user_group_role_group_relation>();
        }

        [Key]
        [StringLength(100)]
        public string role_group_id { get; set; }

        [Required]
        [StringLength(100)]
        public string role_group_name { get; set; }

        [StringLength(100)]
        public string father_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<role_group_relation> role_group_relation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_group_role_group_relation> user_group_role_group_relation { get; set; }
    }
}
