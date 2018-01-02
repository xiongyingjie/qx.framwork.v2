using System.ComponentModel.DataAnnotations;

namespace Qx.Order.Entity
{
    public partial class order_pay_item
    {
        [Key]
        [StringLength(250)]
        public string OrderPayItemsID { get; set; }

        [Required]
        [StringLength(150)]
        public string OrderID { get; set; }

        [Required]
        [StringLength(100)]
        public string PO_ID { get; set; }

        public virtual order order { get; set; }

        public virtual r_pay_order r_pay_order { get; set; }
    }
}
