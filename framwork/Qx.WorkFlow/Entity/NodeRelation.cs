namespace Qx.WorkFlow.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NodeRelation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NodeRelation()
        {
            ConvertConditions = new HashSet<ConvertCondition>();
        }

        [StringLength(50)]
        public string NodeRelationID { get; set; }

        [Required]
        [StringLength(50)]
        public string NodeID { get; set; }

        [StringLength(50)]
        public string ChildID { get; set; }

        [StringLength(50)]
        public string Note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConvertCondition> ConvertConditions { get; set; }

        public virtual Node Node { get; set; }

        public virtual Node Node1 { get; set; }
    }
}
