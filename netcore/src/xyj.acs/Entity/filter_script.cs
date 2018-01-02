using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyj.acs.Entity
{
    public partial class filter_script
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public filter_script()
        {
            data_filter = new HashSet<data_filter>();
        }

        [Key]
        [StringLength(50)]
        public string filter_script_id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(100)]
        public string script { get; set; }

        [StringLength(50)]
        public string note { get; set; }

        public int? link_count { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? create_time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_filter> data_filter { get; set; }
    }
}
