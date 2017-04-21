using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Qx.Org.Entity
{
    public partial class R_Accounts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public R_Accounts()
        {
            OrgAccounts = new HashSet<OrgAccount>();
        }

        [Key]
        [StringLength(100)]
        public string AccountID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrgAccount> OrgAccounts { get; set; }
    }
}
