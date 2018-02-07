using System;
using System.ComponentModel.DataAnnotations;

namespace xyj.study.Entity
{
  
    public partial class site_page
    {
     

        [Key]
       
        public string site_page_id { get; set; }

       
        public string site_id { get; set; }

        public string url { get; set; }
        public string html { get; set; }
        public DateTime create_time { get; set; }
        public int seq { get; set; }

    }
}
