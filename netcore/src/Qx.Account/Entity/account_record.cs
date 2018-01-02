using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qx.Account.Entity
{
    public partial class account_record
    {
        [Key]
        [StringLength(100)]
        public string AccountRecordID { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountID { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }

        public DateTime Time { get; set; }

        public int Amount { get; set; }

        public int AfterPayedBalance { get; set; }

        public int? ServiceCharge { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Reason { get; set; }

        [StringLength(400)]
        public string PO_ID { get; set; }

        public virtual account account { get; set; }

        public virtual pay_order pay_order { get; set; }
    }
}
