using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyj.acs.Entity
{
    public partial class sub_system_data_log
    {
        [Key]
        [StringLength(100)]
        public string sub_system_data_log_id { get; set; }

        [Required]
        [StringLength(100)]
        public string sub_system_data_id { get; set; }
        [Required]
        public string old_data_value { get; set; }


        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime change_time { get; set; }

     
      
    }
}
