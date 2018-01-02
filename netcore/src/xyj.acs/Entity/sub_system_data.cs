using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyj.acs.Entity
{
    public partial class sub_system_data
    {
        [Key]
        [StringLength(100)]
        public string sub_system_data_id { get; set; }

        [Required]
        [StringLength(100)]
        public string sub_system_id { get; set; }

        [Required]
        [StringLength(100)]
        public string data_key { get; set; }


        public string data_value { get; set; }
        public string model { get; set; }

        [Column(TypeName = "datetime2")]
        [Required]
        public DateTime create_time { get; set; }

        [StringLength(100)]
        public string note { get; set; }


      
    }
}
