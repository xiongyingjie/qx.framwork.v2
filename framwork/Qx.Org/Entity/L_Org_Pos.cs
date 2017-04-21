using System.ComponentModel.DataAnnotations;

namespace Qx.Org.Entity
{
    public partial class L_Org_Pos
    {
        [Key]
        [StringLength(100)]
        public string L_O_P_ID { get; set; }

        [StringLength(50)]
        public string O_ID { get; set; }

        [StringLength(50)]
        public string PositionID { get; set; }

        public virtual Orgnization Orgnization { get; set; }

        public virtual Position Position { get; set; }
    }
}
