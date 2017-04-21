namespace qx.permmision.v2.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class role_button_forbid
    {
        [Key]
        [StringLength(80)]
        public string role_Button_forbid_id { get; set; }

        [Required]
        [StringLength(20)]
        public string role_id { get; set; }

        [Required]
        [StringLength(60)]
        public string button_id { get; set; }

        public DateTimeOffset? expire_time { get; set; }

        [StringLength(10)]
        public string note { get; set; }

        public virtual button button { get; set; }

        public virtual role role { get; set; }
    }
}
