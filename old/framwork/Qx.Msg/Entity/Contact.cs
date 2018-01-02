namespace Qx.Msg.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("contact")]
    public partial class contact
    {
        [StringLength(100)]
        public string ContactID { get; set; }

        [Required]
        [StringLength(50)]
        public string OwnerID { get; set; }

        [Required]
        [StringLength(50)]
        public string MembersID { get; set; }

        public virtual msg_user msg_user { get; set; }
    }
}
