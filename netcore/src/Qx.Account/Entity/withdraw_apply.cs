using System.ComponentModel.DataAnnotations;

namespace Qx.Account.Entity
{
    public partial class withdraw_apply
    {
        [Key]
        [StringLength(10)]
        public string WithdrawApplyID { get; set; }
    }
}
