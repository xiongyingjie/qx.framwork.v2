namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class page_control_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public page_control_type()
        {
            content_column_design = new HashSet<content_column_design>();
        }

        [Key]
        [StringLength(50)]
        public string pct_id { get; set; }

        [StringLength(50)]
        public string pct_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<content_column_design> content_column_design { get; set; }
    }
}
