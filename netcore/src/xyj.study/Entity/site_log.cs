using System;
using System.ComponentModel.DataAnnotations;

namespace xyj.study.Entity
{
  
    public partial class site_log
    {
     

        [Key]
       
        public string site_log_id { get; set; }

       
        public string site_id { get; set; }

        public string contents { get; set; }
        public DateTime log_time { get; set; }
     

    }
}
