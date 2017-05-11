namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class content_table_design
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public content_table_design()
        {
            content_column_design = new HashSet<content_column_design>();
            content_table_query = new HashSet<content_table_query>();
        }

        [Key]
        [StringLength(50)]
        public string ctd_id { get; set; }

        [StringLength(50)]
        public string ct_id { get; set; }

        [StringLength(50)]
        public string table_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<content_column_design> content_column_design { get; set; }

        public virtual content_type content_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<content_table_query> content_table_query { get; set; }
    }
}
