namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class content_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public content_type()
        {
            content_table_design = new HashSet<content_table_design>();
        }

        [Key]
        [StringLength(50)]
        public string ct_id { get; set; }

        [StringLength(50)]
        public string type_name { get; set; }

        [StringLength(50)]
        public string father_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<content_table_design> content_table_design { get; set; }
    }
}
