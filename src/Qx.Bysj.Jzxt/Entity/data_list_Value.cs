namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class data_list_Value
    {
        [Key]
        [StringLength(50)]
        public string ValueID { get; set; }

        [StringLength(50)]
        public string ListID { get; set; }

        [StringLength(50)]
        public string ListValue { get; set; }

        [StringLength(50)]
        public string AuditObjectID { get; set; }

        public virtual audit_object audit_object { get; set; }

        public virtual data_list_design data_list_design { get; set; }
    }
}
