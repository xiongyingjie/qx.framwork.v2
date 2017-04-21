namespace Qx.Permission.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("button")]
    public partial class button
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public button()
        {
            role_button_forbid = new HashSet<role_button_forbid>();
        }

        [StringLength(60)]
        public string ButtonID { get; set; }

        [Required]
        [StringLength(100)]
        public string MenuID { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(10)]
        public string Note { get; set; }

        [Required]
        [StringLength(40)]
        public string Value { get; set; }

        public virtual menu menu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<role_button_forbid> role_button_forbid { get; set; }
    }
}
