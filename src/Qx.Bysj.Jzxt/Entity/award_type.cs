namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public award_type()
        {
            allocation_for_award = new HashSet<allocation_for_award>();
            audit_by_institute = new HashSet<audit_by_institute>();
            audit_object_apply = new HashSet<audit_object_apply>();
            audit_object_award = new HashSet<audit_object_award>();
            audit_object_information_for_award = new HashSet<audit_object_information_for_award>();
            award_list_design = new HashSet<award_list_design>();
            data_use_history = new HashSet<data_use_history>();
            Jurisdiction_For_Award = new HashSet<Jurisdiction_For_Award>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AwardTypeID { get; set; }

        [StringLength(50)]
        public string AwardName { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? Bonus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<allocation_for_award> allocation_for_award { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<audit_by_institute> audit_by_institute { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<audit_object_apply> audit_object_apply { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<audit_object_award> audit_object_award { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<audit_object_information_for_award> audit_object_information_for_award { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<award_list_design> award_list_design { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_use_history> data_use_history { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Jurisdiction_For_Award> Jurisdiction_For_Award { get; set; }
    }
}
