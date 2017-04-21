namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class audit_object
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public audit_object()
        {
            audit_by_institute = new HashSet<audit_by_institute>();
            audit_object_apply = new HashSet<audit_object_apply>();
            audit_object_award = new HashSet<audit_object_award>();
            data_list_Value = new HashSet<data_list_Value>();
        }

        [Key]
        [StringLength(50)]
        public string AuditObjectID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string StudentNumber { get; set; }

        [StringLength(50)]
        public string PoliticalLandscape { get; set; }

        [StringLength(50)]
        public string Score { get; set; }

        [StringLength(50)]
        public string CommunityScore { get; set; }

        public int? UnitID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<audit_by_institute> audit_by_institute { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<audit_object_apply> audit_object_apply { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<audit_object_award> audit_object_award { get; set; }

        public virtual unit unit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_list_Value> data_list_Value { get; set; }
    }
}
