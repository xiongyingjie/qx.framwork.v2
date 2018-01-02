namespace Qx.Msg.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class msg_group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public msg_group()
        {
            group_member = new HashSet<group_member>();
        }

        [Key]
        [StringLength(50)]
        public string GroupID { get; set; }

        [Required]
        [StringLength(50)]
        public string OwnerID { get; set; }

        [StringLength(50)]
        public string GroupName { get; set; }

        public DateTime? CreatTime { get; set; }

        [StringLength(50)]
        public string CrewLimiteTypeID { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        public virtual crew_limite_type crew_limite_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<group_member> group_member { get; set; }

        public virtual msg_user msg_user { get; set; }
    }
}
