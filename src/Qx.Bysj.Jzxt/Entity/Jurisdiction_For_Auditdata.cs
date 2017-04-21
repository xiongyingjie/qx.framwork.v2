namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Jurisdiction_For_Auditdata
    {
        [Key]
        [StringLength(50)]
        public string AuditDataJurisdicitionID { get; set; }

        public int? DataTypeID { get; set; }

        [StringLength(50)]
        public string ReviewerID { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public virtual data_type data_type { get; set; }

        public virtual reviewer reviewer { get; set; }
    }
}
