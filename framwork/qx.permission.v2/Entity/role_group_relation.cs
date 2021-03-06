namespace qx.permmision.v2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class role_group_relation
    {
        [Key]
        [StringLength(100)]
        public string role_group_relation_id { get; set; }

        [Required]
        [StringLength(100)]
        public string role_group_id { get; set; }

        [Required]
        [StringLength(100)]
        public string role_id { get; set; }

        [StringLength(100)]
        public string role_name { get; set; }

        [StringLength(100)]
        public string create_userid { get; set; }

        [StringLength(100)]
        public string create_username { get; set; }

        [StringLength(100)]
        public string create_Date { get; set; }

        public virtual role role { get; set; }

        public virtual role_group role_group { get; set; }
    }
}
