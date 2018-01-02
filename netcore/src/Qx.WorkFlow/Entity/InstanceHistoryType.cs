namespace Qx.WorkFlow.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("InstanceHistoryType")]
    public partial class InstanceHistoryType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InstanceHistoryType()
        {
            InstanceHistory = new HashSet<InstanceHistory>();
        }

        [StringLength(50)]
        public string InstanceHistoryTypeID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstanceHistory> InstanceHistory { get; set; }
    }
}
