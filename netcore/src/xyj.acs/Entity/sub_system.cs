using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyj.acs.Entity
{
    public partial class sub_system
    {
        [Key]
        [StringLength(50)]
        public string sub_system_id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }
        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime create_time { get; set; }


        public string note { get; set; }
        [Required]
        [StringLength(100)]
        public string plateform { get; set; }
      
    }
}
