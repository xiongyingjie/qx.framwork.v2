using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qx.Order.Entity
{
    [Table("order")]
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            order_pay_item = new HashSet<order_pay_item>();
            order_item = new HashSet<order_item>();
        }

        [StringLength(150)]
        public string OrderID { get; set; }

        [StringLength(50)]
        public string OrderTypeID { get; set; }

        [StringLength(50)]
        public string SellerID { get; set; }

        [Required]
        [StringLength(50)]
        public string BuyerID { get; set; }

        public DateTime OrderTime { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderStateID { get; set; }

        [StringLength(50)]
        public string ShopID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_pay_item> order_pay_item { get; set; }

        public virtual order_state order_state { get; set; }

        public virtual order_type order_type { get; set; }

        public virtual r_orgnization r_orgnization { get; set; }

        public virtual r_user r_user { get; set; }

        public virtual r_user r_user1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_item> order_item { get; set; }
    }
}
