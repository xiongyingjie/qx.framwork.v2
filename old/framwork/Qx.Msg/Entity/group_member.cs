namespace Qx.Msg.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class group_member
    {
        [Key]
        [StringLength(50)]
        public string GroupMemberID { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupID { get; set; }

        [Required]
        [StringLength(50)]
        public string MembersID { get; set; }

        public virtual msg_group msg_group { get; set; }

        public virtual msg_user msg_user { get; set; }
    }
}
