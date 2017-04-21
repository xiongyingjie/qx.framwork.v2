namespace Qx.Permission.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("menu")]
    public partial class menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public menu()
        {
            button = new HashSet<button>();
            role_menu = new HashSet<role_menu>();
        }

        [StringLength(100)]
        public string MenuID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string FartherID { get; set; }

        [StringLength(10)]
        public string Note { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Value { get; set; }

        [Required]
        [StringLength(10)]
        public string Level { get; set; }

        public int IsAvailable { get; set; }

        public int? Sequence { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<button> button { get; set; }

        public virtual menu_extension menu_extension { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<role_menu> role_menu { get; set; }
    }
}
