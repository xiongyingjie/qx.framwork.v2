using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyj.acs.Entity
{
    public partial class permission_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public permission_user()
        {
            user_group_relation = new HashSet<user_group_relation>();
            user_orgnization = new HashSet<user_orgnization>();
            user_position = new HashSet<user_position>();
            user_role = new HashSet<user_role>();
        }

        [Key]
        [StringLength(100)]
        public string user_id { get; set; }

        [StringLength(100)]
        public string nick_name { get; set; }

        [Required]
        [StringLength(100)]
        public string user_pwd { get; set; }

        [Column(TypeName = "text")]
        public string email { get; set; }

        [Column(TypeName = "text")]
        public string phone { get; set; }

        [Required]
        [StringLength(50)]
        public string user_type_id { get; set; }
        [Required]
        [StringLength(300)]
        public string sub_system_reg_id { get; set; }

        [Column(TypeName = "text")]
        public string note { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? register_date { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? last_login_date { get; set; }

        public virtual user_type user_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_group_relation> user_group_relation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_orgnization> user_orgnization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_position> user_position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_role> user_role { get; set; }
    }
}
