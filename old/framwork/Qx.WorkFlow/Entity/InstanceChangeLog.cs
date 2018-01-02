namespace Qx.WorkFlow.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InstanceChangeLog")]
    public partial class InstanceChangeLog
    {
        [StringLength(200)]
        public string InstanceChangeLogID { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkFlowInstanceID { get; set; }

        [StringLength(50)]
        public string FromNodeID { get; set; }

        [StringLength(50)]
        public string ToNodeID { get; set; }

        [StringLength(50)]
        public string Operator { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ChangeTime { get; set; }

        [StringLength(500)]
        public string Reason { get; set; }

        [Column(TypeName = "text")]
        public string Note { get; set; }

        [StringLength(50)]
        public string InstanceChangeLogTypeID { get; set; }

        public virtual Node Node { get; set; }

        public virtual InstanceChangeLogType InstanceChangeLogType { get; set; }
    }
}
