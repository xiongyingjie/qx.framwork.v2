using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Qx.Order.Entity
{
    public partial class r_orgnization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public r_orgnization()
        {
            order = new HashSet<order>();
        }

        [Key]
        [StringLength(50)]
        public string OrgID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> order { get; set; }
    }
}
