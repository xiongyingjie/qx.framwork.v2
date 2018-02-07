using System.ComponentModel.DataAnnotations;

namespace xyj.study.Entity
{
  
    public partial class site
    {
     

        [Key]
       
        public string site_id { get; set; }

       
        public string name { get; set; }

        public string url { get; set; }
        public string decode_method { get; set; }
        public string note { get; set; }
        
    }
}
