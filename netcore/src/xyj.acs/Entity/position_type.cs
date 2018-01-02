using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace xyj.acs.Entity
{
    public partial class position_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public position_type()
        {
            position = new HashSet<position>();
        }

        [Key]
        [StringLength(50)]
        public string position_type_id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string father_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<position> position { get; set; }
    }
}
