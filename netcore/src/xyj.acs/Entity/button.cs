using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyj.acs.Entity
{
    [Table("button")]
    public partial class button
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public button()
        {
            role_button_forbid = new HashSet<role_button_forbid>();
        }

        [Key]
        [StringLength(60)]
        public string button_id { get; set; }

        [Required]
        [StringLength(100)]
        public string menu_id { get; set; }

        [StringLength(40)]
        public string name { get; set; }

        [StringLength(100)]
        public string note { get; set; }

        [Required]
        [StringLength(40)]
        public string value { get; set; }

        public virtual menu menu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<role_button_forbid> role_button_forbid { get; set; }
    }
}
