using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qx.Org.Entity
{
    [Table("Orgnization")]
    public partial class Orgnization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orgnization()
        {
            L_Org_Pos = new HashSet<L_Org_Pos>();
            OrgAccounts = new HashSet<OrgAccount>();
            OrgAssets = new HashSet<OrgAsset>();
        }

        [Key]
        [StringLength(50)]
        public string O_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FatherID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Descripe { get; set; }

        [Required]
        [StringLength(50)]
        public string TypeID { get; set; }

        [StringLength(50)]
        public string Province { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Area { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [Column(TypeName = "text")]
        public string Note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<L_Org_Pos> L_Org_Pos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrgAccount> OrgAccounts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrgAsset> OrgAssets { get; set; }

        public virtual OrgType OrgType { get; set; }
    }
}
