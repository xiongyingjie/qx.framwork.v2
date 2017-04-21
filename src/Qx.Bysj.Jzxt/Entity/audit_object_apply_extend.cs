namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class audit_object_apply_extend
    {
        [Key]
        [StringLength(50)]
        public string ExtendID { get; set; }

        [StringLength(50)]
        public string ApplyID { get; set; }

        [StringLength(50)]
        public string Information { get; set; }

        public int? InformationTypeID { get; set; }

        [StringLength(50)]
        public string InformationValue { get; set; }

        public virtual apply_information_type apply_information_type { get; set; }

        public virtual audit_object_apply audit_object_apply { get; set; }
    }
}
