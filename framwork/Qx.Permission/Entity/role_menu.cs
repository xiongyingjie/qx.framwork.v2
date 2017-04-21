namespace Qx.Permission.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class role_menu
    {
        [Key]
        [StringLength(120)]
        public string RoleMenuID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleID { get; set; }

        [Required]
        [StringLength(100)]
        public string MenuID { get; set; }

        [StringLength(10)]
        public string Note { get; set; }

        public int IncludeChildren { get; set; }

        public DateTimeOffset? ExpireTime { get; set; }

        public virtual menu menu { get; set; }

        public virtual role role { get; set; }
    }
}
