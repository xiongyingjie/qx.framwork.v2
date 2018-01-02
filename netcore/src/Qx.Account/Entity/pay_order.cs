using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Qx.Account.Entity
{
    public partial class pay_order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pay_order()
        {
            account_record = new HashSet<account_record>();
        }

        [Key]
        [StringLength(400)]
        public string PO_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string PayerAccID { get; set; }

        [Required]
        [StringLength(100)]
        public string ReceiverAccID { get; set; }

        [Required]
        [StringLength(20)]
        public string PayOrderTypeID { get; set; }

        [Required]
        [StringLength(20)]
        public string PaymentTypeID { get; set; }

        public int PayNum { get; set; }

        public DateTime CreateTime { get; set; }

        [Required]
        [StringLength(20)]
        public string PayStateID { get; set; }

        [StringLength(100)]
        public string AliPayID { get; set; }

        public virtual account account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<account_record> account_record { get; set; }

        public virtual order_type order_type { get; set; }

        public virtual payment_type payment_type { get; set; }

        public virtual pay_state pay_state { get; set; }
    }
}
