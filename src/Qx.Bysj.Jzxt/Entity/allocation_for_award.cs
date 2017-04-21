namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class allocation_for_award
    {
        [Key]
        [StringLength(50)]
        public string AwardAllocationID { get; set; }

        public int AwardTypeID { get; set; }

        public int UnitID { get; set; }

        public int? Count { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public virtual award_type award_type { get; set; }

        public virtual unit unit { get; set; }
    }
}
