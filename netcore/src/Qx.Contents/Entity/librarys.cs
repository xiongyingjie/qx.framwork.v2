namespace Qx.Contents.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class librarys
    {
        [Key]
        [StringLength(50)]
        public string library_id { get; set; }

        [Required]
        [StringLength(50)]
        public string father_id { get; set; }

        public int type_id { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        [StringLength(50)]
        public string description { get; set; }

        [Required]
        [StringLength(500)]
        public string fileurl { get; set; }

        public DateTime last_update_time { get; set; }

        public int referrence_count { get; set; }
    }
}
