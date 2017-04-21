namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class data_list_option
    {
        [Key]
        [StringLength(50)]
        public string LlistOptionID { get; set; }

        [StringLength(50)]
        public string ListID { get; set; }

        [StringLength(50)]
        public string OptionValue { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public int? Sequence { get; set; }

        public virtual data_list_design data_list_design { get; set; }
    }
}
