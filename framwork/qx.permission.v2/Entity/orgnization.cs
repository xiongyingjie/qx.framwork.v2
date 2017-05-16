namespace qx.permmision.v2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("orgnization")]
    public partial class orgnization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public orgnization()
        {
            orgnization_position = new HashSet<orgnization_position>();
            user_orgnization = new HashSet<user_orgnization>();
        }

        [Key]
        [StringLength(50)]
        public string orgnization_id { get; set; }

        [Required]
        [StringLength(50)]
        public string father_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string descripe { get; set; }

        [Required]
        [StringLength(50)]
        public string orgnization_type_id { get; set; }

        [Column(TypeName = "text")]
        public string note { get; set; }

        [StringLength(50)]
        public string sub_system { get; set; }

        public virtual orgnization_type orgnization_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orgnization_position> orgnization_position { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_orgnization> user_orgnization { get; set; }
    }
}
