using System.ComponentModel.DataAnnotations;

namespace Qx.Org.Entity
{
    public partial class OrgAccount
    {
        [Key]
        [StringLength(100)]
        public string OA_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string O_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string AccountID { get; set; }

        [Required]
        [StringLength(2)]
        public string AccTypeID { get; set; }

        public virtual OrgAccType OrgAccType { get; set; }

        public virtual Orgnization Orgnization { get; set; }

        public virtual R_Accounts R_Accounts { get; set; }
    }
}
