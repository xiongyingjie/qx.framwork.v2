using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Qx.Order.Entity
{
    public partial class order_state
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order_state()
        {
            order = new HashSet<order>();
        }

        [Key]
        [StringLength(50)]
        public string OrderStateID { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> order { get; set; }
    }
}
