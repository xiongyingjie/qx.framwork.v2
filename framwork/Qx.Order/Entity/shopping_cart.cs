using System.ComponentModel.DataAnnotations;

namespace Qx.Order.Entity
{
    public partial class shopping_cart
    {
        [Key]
        [StringLength(100)]
        public string SC_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string BuyerID { get; set; }

        [Required]
        [StringLength(50)]
        public string SellerID { get; set; }

        [Required]
        [StringLength(300)]
        public string ProductID { get; set; }

        public int Num { get; set; }

        public virtual r_user r_user { get; set; }

        public virtual r_user r_user1 { get; set; }
    }
}
