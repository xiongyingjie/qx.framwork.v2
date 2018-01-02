namespace Qx.WorkFlow.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("WorkFlowInstance")]
    public partial class WorkFlowInstance
    {
        [StringLength(50)]
        public string WorkFlowInstanceID { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkFlowID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateTime { get; set; }

        [StringLength(50)]
        public string CurrentNodeID { get; set; }

        [Column(TypeName = "text")]
        public string Note { get; set; }

        [StringLength(50)]
        public string InstancePeople { get; set; }

        [StringLength(50)]
        public string UnitID { get; set; }

        public virtual Node Node { get; set; }

        public virtual WorkFlow WorkFlow { get; set; }
    }
}
