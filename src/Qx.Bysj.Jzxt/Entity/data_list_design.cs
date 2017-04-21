namespace Qx.Bysj.Jzxt.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class data_list_design
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public data_list_design()
        {
            data_list_option = new HashSet<data_list_option>();
            data_list_Value = new HashSet<data_list_Value>();
        }

        [Key]
        [StringLength(50)]
        public string ListID { get; set; }

        public int? DataTypeID { get; set; }

        [StringLength(50)]
        public string ListName { get; set; }

        public int? ListTypeID { get; set; }

        public int? Sequence { get; set; }

        public int? IsPrimaryKey { get; set; }

        [StringLength(50)]
        public string DefaultValue { get; set; }

        public int? state { get; set; }

        public virtual data_list_type data_list_type { get; set; }

        public virtual data_type data_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_list_option> data_list_option { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_list_Value> data_list_Value { get; set; }
    }
}
