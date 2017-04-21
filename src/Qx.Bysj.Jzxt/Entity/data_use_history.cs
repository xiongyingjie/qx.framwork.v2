namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class data_use_history
    {
        [Key]
        [StringLength(50)]
        public string DataUseHistoryID { get; set; }

        [StringLength(50)]
        public string AuditDataID { get; set; }

        public int? AwardTypeID { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        public virtual award_type award_type { get; set; }
    }
}
