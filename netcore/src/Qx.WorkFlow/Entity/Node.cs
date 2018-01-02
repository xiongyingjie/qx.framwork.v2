namespace Qx.WorkFlow.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("Node")]
    public partial class Node
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Node()
        {
            InstanceChangeLog = new HashSet<InstanceChangeLog>();
            NodeRelation = new HashSet<NodeRelation>();
            WorkFlowInstance = new HashSet<WorkFlowInstance>();
            WorkFlow = new HashSet<WorkFlow>();
        }

        [StringLength(50)]
        public string NodeID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string WorkFlowID { get; set; }

        [Required]
        [StringLength(50)]
        public string MenuID { get; set; }

        [StringLength(50)]
        public string Domain { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleID { get; set; }

        [StringLength(50)]
        public string Note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InstanceChangeLog> InstanceChangeLog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NodeRelation> NodeRelation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkFlowInstance> WorkFlowInstance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkFlow> WorkFlow { get; set; }

        public virtual WorkFlow WorkFlow1 { get; set; }
    }
}
