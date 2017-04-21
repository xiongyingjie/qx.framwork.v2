namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Jurisdiction_For_Award
    {
        [Key]
        [StringLength(50)]
        public string JrisditionForAwardID { get; set; }

        [Required]
        [StringLength(50)]
        public string ReviewerID { get; set; }

        public int? AwardTypeID { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public virtual award_type award_type { get; set; }

        public virtual reviewer reviewer { get; set; }
    }
}
