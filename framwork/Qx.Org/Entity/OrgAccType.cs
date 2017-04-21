using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qx.Org.Entity
{
    [Table("OrgAccType")]
    public partial class OrgAccType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrgAccType()
        {
            OrgAccounts = new HashSet<OrgAccount>();
        }

        [Key]
        [StringLength(2)]
        public string AccTypeID { get; set; }

        [Required]
        [StringLength(20)]
        public string TypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrgAccount> OrgAccounts { get; set; }
    }
}
