using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qx.Order.Entity
{
    public partial class order_item
    {
        [Key]
        [StringLength(150)]
        public string SellOrderItemID { get; set; }

        [Required]
        [StringLength(150)]
        public string OrderID { get; set; }

        [Required]
        [StringLength(300)]
        public string ProductID { get; set; }

        public int Num { get; set; }

        public int? PriceInOrder { get; set; }

        public int? TotalPrice { get; set; }

        [Column(TypeName = "text")]
        public string BenefitDesc { get; set; }

        public int? Discount { get; set; }

        public virtual order order { get; set; }

        public virtual sell_consultant sell_consultant { get; set; }
    }
}
