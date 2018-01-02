using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Qx.Account.Entity
{
    public partial class account_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public account_type()
        {
            account = new HashSet<account>();
        }

        [Key]
        [StringLength(20)]
        public string AccTypeID { get; set; }

        [Required]
        [StringLength(20)]
        public string TypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<account> account { get; set; }
    }
}
