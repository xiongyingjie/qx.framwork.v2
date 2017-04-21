namespace Qx.Permission.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class role_button_forbid
    {
        [Key]
        [StringLength(80)]
        public string RoleButtonForbidID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleID { get; set; }

        [Required]
        [StringLength(60)]
        public string ButtonID { get; set; }

        public DateTimeOffset? ExpireTime { get; set; }

        [StringLength(10)]
        public string Note { get; set; }

        public virtual button button { get; set; }

        public virtual role role { get; set; }
    }
}
