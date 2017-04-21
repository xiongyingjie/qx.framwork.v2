using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Qx.Order.Entity
{
    public partial class order_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order_type()
        {
            order = new HashSet<order>();
        }

        [Key]
        [StringLength(50)]
        public string OrderTypeID { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(40)]
        public string Note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> order { get; set; }
    }
}
