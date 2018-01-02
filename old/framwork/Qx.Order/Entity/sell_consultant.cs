using System.ComponentModel.DataAnnotations;

namespace Qx.Order.Entity
{
    public partial class sell_consultant
    {
        [Key]
        [StringLength(150)]
        public string SellConsultantID { get; set; }

        [StringLength(50)]
        public string UserID { get; set; }

        public virtual order_item order_item { get; set; }

        public virtual r_user r_user { get; set; }
    }
}
