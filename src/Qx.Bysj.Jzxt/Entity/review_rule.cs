namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class review_rule
    {
        [Key]
        [StringLength(50)]
        public string RuleID { get; set; }

        [Required]
        [StringLength(50)]
        public string ListID { get; set; }

        [Required]
        [StringLength(50)]
        public string OperateID { get; set; }

        [Required]
        [StringLength(50)]
        public string ConstraintValue { get; set; }

        public int Sequence { get; set; }

        public virtual award_list_design award_list_design { get; set; }

        public virtual operation operation { get; set; }
    }
}
