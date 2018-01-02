using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace xyj.acs.Entity
{
    public partial class orgnization_position
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public orgnization_position()
        {
            user_position = new HashSet<user_position>();
        }

        [Key]
        [StringLength(100)]
        public string orgnization_position_id { get; set; }

        [Required]
        [StringLength(50)]
        public string orgnization_id { get; set; }

        [Required]
        [StringLength(50)]
        public string position_id { get; set; }

        public virtual orgnization orgnization { get; set; }

        public virtual position position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_position> user_position { get; set; }
    }
}
