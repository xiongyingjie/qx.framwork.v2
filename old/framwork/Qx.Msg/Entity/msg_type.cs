namespace Qx.Msg.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class msg_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public msg_type()
        {
            msg = new HashSet<msg>();
        }

        [Key]
        [StringLength(50)]
        public string MsgTypeID { get; set; }

        [StringLength(50)]
        public string TypeName { get; set; }

        [StringLength(50)]
        public string TypeDescription { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<msg> msg { get; set; }
    }
}
