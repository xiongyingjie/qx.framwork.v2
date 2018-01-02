namespace Qx.Msg.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class crew_limite_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public crew_limite_type()
        {
            msg_group = new HashSet<msg_group>();
        }

        [Key]
        [StringLength(50)]
        public string CrewLimiteTypeID { get; set; }

        public int? CrewLimite { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<msg_group> msg_group { get; set; }
    }
}
