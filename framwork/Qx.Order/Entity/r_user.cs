using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Qx.Order.Entity
{
    public partial class r_user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public r_user()
        {
            order = new HashSet<order>();
            order1 = new HashSet<order>();
            sell_consultant = new HashSet<sell_consultant>();
            shopping_cart = new HashSet<shopping_cart>();
            shopping_cart1 = new HashSet<shopping_cart>();
        }

        [Key]
        [StringLength(50)]
        public string UserID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> order1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sell_consultant> sell_consultant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<shopping_cart> shopping_cart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<shopping_cart> shopping_cart1 { get; set; }
    }
}
