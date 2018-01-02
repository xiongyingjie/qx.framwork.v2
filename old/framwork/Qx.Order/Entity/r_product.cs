using System.ComponentModel.DataAnnotations;

namespace Qx.Order.Entity
{
    public partial class r_product
    {
        [Key]
        [StringLength(300)]
        public string ProductID { get; set; }
    }
}
