namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class content_column_design
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public content_column_design()
        {
            content_column_value = new HashSet<content_column_value>();
        }

        [Key]
        [StringLength(50)]
        public string ccd_id { get; set; }

        [StringLength(50)]
        public string ctd_id { get; set; }

        [StringLength(20)]
        public string dt_id { get; set; }

        [StringLength(50)]
        public string pct_id { get; set; }

        [StringLength(50)]
        public string column_name { get; set; }

        [StringLength(50)]
        public string seq { get; set; }

        [StringLength(50)]
        public string is_pk { get; set; }

        [StringLength(50)]
        public string def_value { get; set; }

        public virtual content_column_ui_design content_column_ui_design { get; set; }

        public virtual content_table_design content_table_design { get; set; }

        public virtual data_type data_type { get; set; }

        public virtual page_control_type page_control_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<content_column_value> content_column_value { get; set; }
    }
}
