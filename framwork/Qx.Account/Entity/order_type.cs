using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Qx.Account.Entity
{
    public partial class order_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order_type()
        {
            pay_order = new HashSet<pay_order>();
        }

        [Key]
        [StringLength(20)]
        public string OrderTypeID { get; set; }

        [StringLength(50)]
        public string TypeName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pay_order> pay_order { get; set; }
    }
}
