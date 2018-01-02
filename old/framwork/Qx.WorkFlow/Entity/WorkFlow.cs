namespace Qx.WorkFlow.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkFlow")]
    public partial class WorkFlow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkFlow()
        {
            Node1 = new HashSet<Node>();
            WorkFlowInstance = new HashSet<WorkFlowInstance>();
        }

        [StringLength(50)]
        public string WorkFlowID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Creator { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CreateTime { get; set; }

        [StringLength(50)]
        public string StartNodeID { get; set; }

        public int? RollbackTypeID { get; set; }

        public virtual Node Node { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Node> Node1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkFlowInstance> WorkFlowInstance { get; set; }
    }
}
