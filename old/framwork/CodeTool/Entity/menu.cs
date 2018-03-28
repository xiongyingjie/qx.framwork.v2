namespace xyj.tool.Entity
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
            role_menu = new HashSet<role_menu>();
        }

        [Key]
        [StringLength(100)]
        public string menu_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(100)]
        public string farther_id { get; set; }

        [StringLength(50)]
        public string note { get; set; }

        [StringLength(199)]
        public string url { get; set; }

        [Required]
        [StringLength(50)]
        public string depth { get; set; }

        public int? sequence { get; set; }

        [StringLength(50)]
        public string sub_system { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        [StringLength(50)]
        public string controller { get; set; }

        [StringLength(50)]
        public string action { get; set; }

        [StringLength(50)]
        public string area { get; set; }

        [StringLength(50)]
        public string image_class { get; set; }

        [StringLength(50)]
        public string active_li { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<role_menu> role_menu { get; set; }
    }
}
