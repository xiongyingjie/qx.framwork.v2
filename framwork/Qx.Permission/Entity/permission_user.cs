namespace Qx.Permission.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class permission_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public permission_user()
        {
            user_role = new HashSet<user_role>();
        }

        [Key]
        [StringLength(100)]
        public string UserID { get; set; }

        [StringLength(100)]
        public string NickName { get; set; }

        [Required]
        [StringLength(100)]
        public string UserPwd { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string UserTypeId { get; set; }

        [Column(TypeName = "text")]
        public string Note { get; set; }

        public DateTime? RegisterDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_role> user_role { get; set; }

        public virtual user_type user_type { get; set; }
    }
}
