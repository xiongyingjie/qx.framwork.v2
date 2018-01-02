using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyj.acs.Entity
{
    [Table("position")]
    public partial class position
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public position()
        {
            orgnization_position = new HashSet<orgnization_position>();
        }

        [Key]
        [StringLength(50)]
        public string position_id { get; set; }

        [Required]
        [StringLength(50)]
        public string position_type_id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string descripe { get; set; }

        [Column(TypeName = "text")]
        public string note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orgnization_position> orgnization_position { get; set; }

        public virtual position_type position_type { get; set; }
    }
}
