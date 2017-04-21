using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Qx.Order.Entity
{
    public partial class r_pay_order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public r_pay_order()
        {
            order_pay_item = new HashSet<order_pay_item>();
        }

        [Key]
        [StringLength(100)]
        public string PO_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_pay_item> order_pay_item { get; set; }
    }
}
