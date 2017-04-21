namespace qx.permmision.v2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user_group()
        {
            user_group_relation = new HashSet<user_group_relation>();
        }

        [Key]
        [StringLength(100)]
        public string user_group_id { get; set; }

        [StringLength(100)]
        public string user_group_name { get; set; }

        [StringLength(100)]
        public string father_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_group_relation> user_group_relation { get; set; }
    }
}
