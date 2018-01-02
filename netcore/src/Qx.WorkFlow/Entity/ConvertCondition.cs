namespace Qx.WorkFlow.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("ConvertCondition")]
    public partial class ConvertCondition
    {
        [StringLength(50)]
        public string ConvertConditionID { get; set; }

        [Required]
        [StringLength(50)]
        public string NodeRelationID { get; set; }

        [StringLength(50)]
        public string ConditionNote { get; set; }

        [StringLength(50)]
        public string Property { get; set; }

        [StringLength(50)]
        public string Operator { get; set; }

        [StringLength(50)]
        public string PropertyValue { get; set; }

        public virtual NodeRelation NodeRelation { get; set; }
    }
}
