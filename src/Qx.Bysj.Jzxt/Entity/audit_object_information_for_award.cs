namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class audit_object_information_for_award
    {
        [StringLength(50)]
        public string ID { get; set; }

        public int? AwardTypeID { get; set; }

        public int? InformationID { get; set; }

        [StringLength(50)]
        public string Desription { get; set; }

        public int? Sequence { get; set; }

        public virtual audit_object_information_type audit_object_information_type { get; set; }

        public virtual award_type award_type { get; set; }
    }
}
