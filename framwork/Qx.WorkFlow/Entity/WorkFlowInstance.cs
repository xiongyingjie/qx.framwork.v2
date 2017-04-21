namespace Qx.WorkFlow.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkFlowInstance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkFlowInstance()
        {
            WorkFlowInstanceLogs = new HashSet<WorkFlowInstanceLog>();
        }

        [StringLength(50)]
        public string WorkFlowInstanceID { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkFlowID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string CurrentNodeID { get; set; }

        [StringLength(50)]
        public string Note { get; set; }

        public virtual Node Node { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkFlowInstanceLog> WorkFlowInstanceLogs { get; set; }

        public virtual WorkFlow WorkFlow { get; set; }
    }
}
