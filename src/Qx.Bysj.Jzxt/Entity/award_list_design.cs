namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class award_list_design
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public award_list_design()
        {
            review_rule = new HashSet<review_rule>();
        }

        [Key]
        [StringLength(50)]
        public string ListID { get; set; }

        public int? AwardTypeID { get; set; }

        [StringLength(50)]
        public string ListName { get; set; }

        public int? Sequence { get; set; }

        public int? IsPrimaryKey { get; set; }

        [StringLength(50)]
        public string DefaultValue { get; set; }

        public int? state { get; set; }

        public virtual award_type award_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<review_rule> review_rule { get; set; }
    }
}
