namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class audit_object_award
    {
        [Key]
        [StringLength(50)]
        public string GetAwardID { get; set; }

        [Required]
        [StringLength(50)]
        public string AuditObjectID { get; set; }

        public int AwardTypeID { get; set; }

        public int? GetAwardTime { get; set; }

        [StringLength(50)]
        public string bonus { get; set; }

        public int? AwardGrantState { get; set; }

        [StringLength(50)]
        public string ReviewerID { get; set; }

        public int? State { get; set; }

        public virtual audit_object audit_object { get; set; }

        public virtual award_type award_type { get; set; }

        public virtual reviewer reviewer { get; set; }
    }
}
