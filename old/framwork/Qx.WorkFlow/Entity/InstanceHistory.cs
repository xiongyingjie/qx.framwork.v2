namespace Qx.WorkFlow.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InstanceHistory")]
    public partial class InstanceHistory
    {
        [Key]
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

        [Required]
        [StringLength(50)]
        public string InstanceHistoryTypeID { get; set; }

        [StringLength(50)]
        public string UnitID { get; set; }

        public virtual InstanceHistoryType InstanceHistoryType { get; set; }
    }
}
