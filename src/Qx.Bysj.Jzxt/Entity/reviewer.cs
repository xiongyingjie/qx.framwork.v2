namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reviewer")]
    public partial class reviewer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reviewer()
        {
            audit_by_institute = new HashSet<audit_by_institute>();
            audit_object_award = new HashSet<audit_object_award>();
            Jurisdiction_For_Auditdata = new HashSet<Jurisdiction_For_Auditdata>();
            Jurisdiction_For_Award = new HashSet<Jurisdiction_For_Award>();
        }

        [StringLength(50)]
        public string ReviewerID { get; set; }

        public int? UnitID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? ReviewerState { get; set; }

        public int? ReviewTypeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<audit_by_institute> audit_by_institute { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<audit_object_award> audit_object_award { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jurisdiction_For_Auditdata> Jurisdiction_For_Auditdata { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jurisdiction_For_Award> Jurisdiction_For_Award { get; set; }

        public virtual review_type review_type { get; set; }

        public virtual unit unit { get; set; }
    }
}
