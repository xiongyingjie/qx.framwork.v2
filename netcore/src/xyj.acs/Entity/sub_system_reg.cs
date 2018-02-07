using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xyj.acs.Entity
{
    public partial class sub_system_reg
    {
      
        [Key]
     
        public string sub_system_reg_id { get; set; }

          public string sub_system_id { get; set; }
        public string site { get; set; }
        public string user_id { get; set; }
        public DateTime reg_time { get; set; }


        public string note { get; set; }
     
      
    }
}
