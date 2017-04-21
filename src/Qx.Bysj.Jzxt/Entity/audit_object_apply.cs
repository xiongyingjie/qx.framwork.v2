namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class audit_object_apply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public audit_object_apply()
        {
            audit_object_apply_extend = new HashSet<audit_object_apply_extend>();
        }

        [Key]
        [StringLength(50)]
        public string ApplyID { get; set; }

        [StringLength(50)]
        public string AuditObjectID { get; set; }

        public int? AwardTypeID { get; set; }

        public int? time { get; set; }

        public virtual audit_object audit_object { get; set; }

        public virtual award_type award_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<audit_object_apply_extend> audit_object_apply_extend { get; set; }
    }
}
