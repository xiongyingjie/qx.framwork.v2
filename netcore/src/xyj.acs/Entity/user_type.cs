using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace xyj.acs.Entity
{
    public partial class user_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user_type()
        {
            permission_user = new HashSet<permission_user>();
        }

        [Key]
        [StringLength(50)]
        public string user_type_id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<permission_user> permission_user { get; set; }
    }
}
