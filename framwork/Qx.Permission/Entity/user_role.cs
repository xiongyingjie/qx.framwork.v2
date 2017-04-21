namespace Qx.Permission.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_role
    {
        [Key]
        [StringLength(50)]
        public string UserRoleID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleID { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        public DateTime? ExpireTime { get; set; }

        public virtual permission_user permission_user { get; set; }

        public virtual role role { get; set; }
    }
}
